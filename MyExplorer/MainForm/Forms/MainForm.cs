using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainForm.Models;
using MainForm.Services;

namespace MainForm
{
    public partial class FormMain : Form
    {
        private int currentDirectoryId = 1;
        private int lastSortedColumn = 0;
        private bool sortDescending = false;
        private readonly ExplorerService explorerService;

        public FormMain()
        {
            InitializeComponent();
            explorerService = new ExplorerService();
            LoadTreeView();
            LoadListView();
            SetLabelStatus();
        }

        /// <summary>
        /// 하단 상태창 텍스트 설정 메서드.
        /// </summary>
        private void SetLabelStatus()
        {
            int itemCnt = explorerService.FileCache.Count();

            this.labelStatus.Text = $"{itemCnt}개 항목";
        }

        /// <summary>
        /// TreeView 렌더링 메서드.
        /// </summary>
        private void LoadTreeView()
        {
            explorerService.RefreshDirectoryTree();
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();

            foreach (var root in explorerService.DirectoryTree)
            {
                var rootNode = CreateTreeNode(root);
                treeView1.Nodes.Add(rootNode);
            }

            treeView1.EndUpdate();
        }

        /// <summary>
        /// DirectoryTreeNode로 구성된 트리를 재귀적으로 TreeNode로 변환하는 메서드.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private TreeNode CreateTreeNode(DirectoryTreeNode node)
        {
            var treeNode = new TreeNode(node.Name)
            {
                Tag = node
            };

            foreach (var child in node.Children)
            {
                treeNode.Nodes.Add(CreateTreeNode(child));
            }

            return treeNode;
        }

        /// <summary>
        /// ListView 렌더링 메서드.
        /// </summary>
        private void LoadListView()
        {
            listView1.BeginUpdate();
            explorerService.RefreshFileCache(currentDirectoryId);
            listView1.VirtualListSize = explorerService.FileCache.Count;
            listView1.EndUpdate();
        }

        /// <summary>
        /// TreeView 영역에서 디렉토리 선택시 실행되는 이벤트 핸들러.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            DirectoryTreeNode selectedNode = (DirectoryTreeNode)e.Node.Tag;
            currentDirectoryId = selectedNode.Id;

            explorerService.RefreshFileCache(currentDirectoryId);

            LoadListView();
            SetLabelStatus();
        }

        /// <summary>
        /// ListView 영역에 파일 목록을 렌더링하는 이벤트 핸들러.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            var file = explorerService.FileCache[e.ItemIndex];

            string name = file.Extender != null ? $"{file.Name}.{file.Extender}" : file.Name;
            string updatedAt = file.UpdatedAt?.ToString("yyyy-MM-dd HH:mm")
                                ?? file.CreatedAt.ToString("yyyy-MM-dd HH:mm");
            string type = file.Extender ?? "파일 폴더";
            string size = file.Size.HasValue ? $"{file.Size.Value / 1024:#,##0} KB" : "";

            var item = new ListViewItem(name);
            item.SubItems.Add(updatedAt);
            item.SubItems.Add(type);
            item.SubItems.Add(size);

            e.Item = item;
        }

        /// <summary>
        /// 폼 로드시 현재 해상도에 맞춰 폼 크기 동적 조절하도록 override.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var screen = Screen.FromControl(this);

            this.Width = (int)(screen.WorkingArea.Width * 0.6);
            this.Height = (int)(screen.WorkingArea.Height * 0.6);
        }

        /// <summary>
        /// 폼 닫힐때 DB연결 해제하도록 override.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            explorerService.Dispose();
            base.OnFormClosed(e);
        }

        /// <summary>
        /// ListView 영역의 헤더 클릭시 파일목록을 정렬하는 이벤트 핸들러.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            sortDescending = !sortDescending;

            switch (e.Column)
            {
                case 0:
                    explorerService.SortFileCache(f => f.Name, sortDescending);
                    break;
                case 1:
                    explorerService.SortFileCache(f => f.UpdatedAt, sortDescending);
                    break;
                case 2:
                    explorerService.SortFileCache(f => f.Extender, sortDescending);
                    break;
                case 3:
                    explorerService.SortFileCache(f => f.Size ?? 0, sortDescending);
                    break;
            }

            UpdateHeaderIndicator(e.Column);
            listView1.Invalidate();
        }

        /// <summary>
        /// ListView 영역의 헤더 정렬방향 표시 업데이트하는 메서드.
        /// </summary>
        /// <param name="selectedColumn"></param>
        private void UpdateHeaderIndicator(int selectedColumn)
        {
            var col = listView1.Columns[selectedColumn];
            listView1.Columns[lastSortedColumn].Text 
                = listView1.Columns[lastSortedColumn].Text.Replace("∧", "").Replace("∨", "");
            col.Text = col.Text.Replace("∧", "").Replace("∨", "")
                + (sortDescending ? "∨" : "∧");
            lastSortedColumn = selectedColumn;
        }
    }
}
