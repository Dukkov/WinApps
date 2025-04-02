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
        private readonly ExplorerService explorerService;

        public FormMain()
        {
            InitializeComponent();
            explorerService = new ExplorerService();
            LoadTreeView();
            LoadListView();
            SetLabelStatus();
        }

        private void SetLabelStatus()
        {
            int itemCnt = explorerService.ProcessedFileList.Count();

            this.labelStatus.Text = $"{itemCnt}개 항목";
        }

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

        private void LoadListView()
        {
            listView1.BeginUpdate();
            explorerService.RefreshProcessedFileList();
            listView1.VirtualListSize = explorerService.ProcessedFileList.Count;
            listView1.EndUpdate();
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is DirectoryTreeNode selectedNode)
            {
                int selectedId = selectedNode.Id;
                currentDirectoryId = selectedId;

                explorerService.RefreshFileCache(selectedId);
                explorerService.ProcessedFileList = explorerService.FileCache;

                LoadListView();
                SetLabelStatus();
            }
        }

        private void ListView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            var file = explorerService.ProcessedFileList[e.ItemIndex];

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
        /// 폼 로드시 해상도에 맞춰 폼 크기 동적 조절
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var screen = Screen.FromControl(this);
            int screenWidth = screen.WorkingArea.Width;
            int screenHeight = screen.WorkingArea.Height;

            this.Width = (int)(screenWidth * 0.6);
            this.Height = (int)(screenHeight * 0.6);
        }
    }
}
