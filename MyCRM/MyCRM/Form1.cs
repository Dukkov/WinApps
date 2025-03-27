using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace MyCRM
{
    public partial class Form1 : Form
    {
        private int startRowId = 1;
        private const int PAGE_SIZE = 100;  // paging view에서 한 페이지에 표시할 row 수
        private const int TOTAL_ROW_CNT = 100000;   // DB의 필드 총 개수
        private readonly string dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MyCRM", "myCRM.db"); // DB 절대경로
        private readonly Dictionary<int, object[]> defaultViewCache = new Dictionary<int, object[]>();  // virtualMode view에서 사용할 캐시
        private readonly Dictionary<string, object> selectedRowData;    // 선택된 row의 정보를 저장할 필드
        private enum ViewMode
        {
            defaultView,
            pagingView
        }
        private ViewMode currentViewMode = ViewMode.defaultView;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DefaultView();
        }

        /// <summary>
        /// view 전환시 컬럼 초기화 메서드
        /// </summary>
        private void SetupColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            var colId = new DataGridViewTextBoxColumn
            {
                Name = "id",
                HeaderText = "회원번호",
                DataPropertyName = "id",
            };
            var colName = new DataGridViewTextBoxColumn
            {
                Name = "name",
                HeaderText = "회원명",
                DataPropertyName = "name",
            };
            var colContact = new DataGridViewTextBoxColumn
            {
                Name = "contact",
                HeaderText = "연락처",
                DataPropertyName = "contact",
            };
            var colEmail = new DataGridViewTextBoxColumn
            {
                Name = "email_address",
                HeaderText = "이메일 주소",
                DataPropertyName = "email_address",
            };
            var colGrade = new DataGridViewTextBoxColumn
            {
                Name = "grade",
                HeaderText = "회원등급",
                DataPropertyName = "grade",
            };
            var colProduct = new DataGridViewTextBoxColumn
            {
                Name = "product",
                HeaderText = "사용중인 상품",
                DataPropertyName = "product",
            };
            var colPoint = new DataGridViewTextBoxColumn
            {
                Name = "point",
                HeaderText = "적립 포인트",
                DataPropertyName = "point",
            };

            dataGridView1.Columns.AddRange(new[]
            {
                colId, colName, colContact, colEmail, colGrade, colProduct, colPoint
            });
        }

        /// <summary>
        /// virtualMode view 설정 메서드
        /// </summary>
        private void DefaultView()
        {
            currentViewMode = ViewMode.defaultView;
            SetupColumns();
            dataGridView1.VirtualMode = true;
            dataGridView1.CellValueNeeded += DataGridView1_CellValueNeeded;
            dataGridView1.DataSource = null;
            dataGridView1.RowCount = TOTAL_ROW_CNT;
        }

        /// <summary>
        /// virtualMode view에서 사용할 데이터 블록 loading 메서드
        /// </summary>
        /// <param name="rowIdx">새로 loading할 row 번호</param>
        /// <returns>입력된 row 번호 기준 +-50개의 데이터 블록</returns>
        private List<object[]> GetDefaultValues(int rowIdx)
        {
            var resultData = new List<object[]>();

            try
            {
                using (var conn = new SQLiteConnection($"Data Source={dbPath}"))
                {
                    conn.Open();

                    string selectQuery = $@"
                        SELECT *
                        FROM customer
                        WHERE id BETWEEN {rowIdx - 50} AND {rowIdx + 50}
                    ;";

                    using (var cmd = new SQLiteCommand(selectQuery, conn))
                    {
                        var reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            resultData.Add(new object[]
                            {
                                reader["id"], reader["name"], reader["contact"],reader["email_address"],
                                reader["grade"], reader["product"], reader["point"], reader["memo"]
                            });
                        }
                    }
                }

                return resultData;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);

                throw new SQLiteException();
            }
        }

        /// <summary>
        /// paging view 설정 메서드
        /// </summary>
        /// <param name="startId">view의 첫번째 row 번호</param>
        private void PagingView(int startId = 1)
        {
            currentViewMode = ViewMode.pagingView;
            SetupColumns();
            dataGridView1.VirtualMode = false;
            dataGridView1.CellValueNeeded -= DataGridView1_CellValueNeeded;
            dataGridView1.AutoGenerateColumns = false;
            UpdatePageLabel();

            try
            {
                using (var conn = new SQLiteConnection($"Data Source = {dbPath}"))
                {
                    conn.Open();

                    string selectQuery = $@"
                        SELECT *
                        FROM customer
                        WHERE id BETWEEN {startId} AND {startId + PAGE_SIZE - 1}
                    ;";

                    using (var cmd = new SQLiteCommand(selectQuery, conn))
                    {
                        var reader = cmd.ExecuteReader();
                        var pageDataTable = new DataTable();

                        pageDataTable.Load(reader);
                        dataGridView1.DataSource = pageDataTable;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);

                throw new SQLiteException();
            }
        }

        /// <summary>
        /// paging view에서 페이지 번호를 업데이트 하는 메서드
        /// </summary>
        private void UpdatePageLabel()
        {
            int currentPageCnt = (startRowId / 100) + 1;
            int totalPageCnt = TOTAL_ROW_CNT / PAGE_SIZE;

            labelPageNum.Text = $"Page {currentPageCnt} / {totalPageCnt}";
        }

        /// <summary>
        /// 보기 메뉴의 '페이징'이 클릭되었을때 실행되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemPaging_Click(object sender, EventArgs e)
        {
            btnToFirst.Visible = true;
            btnToPrev.Visible = true;
            btnToNext.Visible = true;
            btnToEnd.Visible = true;
            labelPageNum.Visible = true;
            textBoxPageNumInput.Visible = true;

            PagingView();
        }

        /// <summary>
        /// 보기 메뉴의 '기본'이 클릭되었을때 실행되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItemDefault_Click(object sender, EventArgs e)
        {
            btnToFirst.Visible = false;
            btnToNext.Visible = false;
            btnToPrev.Visible = false;
            btnToEnd.Visible = false;
            labelPageNum.Visible = false;
            textBoxPageNumInput.Visible = false;

            DefaultView();
        }

        /// <summary>
        /// virtualMode view에서 비어있는 셀의 값을 채워야할때 실행되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            object[] row;

            if (!defaultViewCache.TryGetValue((e.RowIndex + 1), out row))
            {
                defaultViewCache.Clear();
                var block = GetDefaultValues(e.RowIndex);

                foreach (var r in block)
                {
                    defaultViewCache[Convert.ToInt32(r[0])] = r;
                }

                defaultViewCache.TryGetValue((e.RowIndex + 1), out row);
            }

            if (row != null)
            {
                e.Value = row[e.ColumnIndex];
            }
        }

        /// <summary>
        /// paging view에서 '<<' 버튼이 클릭되었을때 실행되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnToFirst_Click(object sender, EventArgs e)
        {
            startRowId = 1;
            PagingView(startRowId);
        }

        /// <summary>
        /// paging view에서 '<' 버튼이 클릭되었을때 실행되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnToPrev_Click(object sender, EventArgs e)
        {
            if (startRowId > PAGE_SIZE)
            {
                startRowId -= PAGE_SIZE;
                PagingView(startRowId);
            }

        }

        /// <summary>
        /// paging view에서 '>' 버튼이 클릭되었을때 실행되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnToNext_Click(object sender, EventArgs e)
        {
            if (startRowId < TOTAL_ROW_CNT - PAGE_SIZE)
            {
                startRowId += PAGE_SIZE;
                PagingView(startRowId);
            }
        }

        /// <summary>
        /// paging view에서 '>>' 버튼이 클릭되었을때 실행되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnToEnd_Click(object sender, EventArgs e)
        {
            startRowId = TOTAL_ROW_CNT - PAGE_SIZE + 1;
            PagingView(startRowId);
        }

        /// <summary>
        /// row를 우클릭 했을때 실행되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hit = dataGridView1.HitTest(e.X, e.Y);

                if (hit.RowIndex >= 0)
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[hit.RowIndex].Selected = true;

                    contextMenuStrip1.Show(dataGridView1, e.Location);
                }

                //if (currentViewMode == ViewMode.defaultView)
                //{
                //    var row;
                //    int rowId = hit.RowIndex + 1;

                //    if (defaultViewCache.TryGetValue(rowId, out row))
                //    {
                //        selectedRowData = new Dictionary<string, object>
                //        {
                //            selectedRowData[0]
                //        }
                //    }
                //}
            }
        }

        /// <summary>
        /// 컨텍스트 메뉴에서 '연락처 복사'가 클릭되었을때 실행되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuItemCopyContact_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                var contact = row.Cells["contact"].Value?.ToString();

                if (!string.IsNullOrEmpty(contact))
                {
                    Clipboard.SetText(contact);
                    MessageBox.Show("연락처 복사 완료.");
                }
            }
        }

        /// <summary>
        /// paging view에서 이동할 페이지 번호를 입력하고 엔터키를 눌렀을때 실행되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxPageNumInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int pageNum;

                if (int.TryParse(textBoxPageNumInput.Text, out pageNum) && pageNum >= 1 && pageNum <= (TOTAL_ROW_CNT / PAGE_SIZE))
                {
                    startRowId = PAGE_SIZE * pageNum - (PAGE_SIZE - 1);
                    PagingView(startRowId);
                }
                else
                {
                    MessageBox.Show("올바른 페이지 번호를 입력하세요.");
                }
            }
        }

        /// <summary>
        /// 선택된 row의 회원번호를 반환하는 메서드
        /// </summary>
        /// <returns>현재 선택된 row의 회원번호</returns>
        private int GetSelectedRowId()
        {
            return dataGridView1.SelectedRows[0].Index + 1;
        }

        /// <summary>
        /// 컨텍스트 메뉴에서 '메모 보기'가 클릭되었을때 실행되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuItemReadMemo_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (currentViewMode == ViewMode.defaultView)
                {
                    object[] row;
                    int selectedRowNum = GetSelectedRowId();

                    if (defaultViewCache.TryGetValue(selectedRowNum, out row))
                    {
                        string memo = row[7]?.ToString();

                        if (string.IsNullOrEmpty(memo))
                        {
                            MessageBox.Show("메모가 존재하지 않습니다.");
                        }
                        else
                        {
                            MessageBox.Show(memo);
                        }
                    }
                }
                else
                {
                    var selectedRow = dataGridView1.Rows[GetSelectedRowId() - 1];
                    var rowView = selectedRow.DataBoundItem as DataRowView;
                    string memo = rowView["memo"]?.ToString();


                    if (string.IsNullOrEmpty(memo))
                    {
                        MessageBox.Show("메모가 존재하지 않습니다.");
                    }
                    else
                    {
                        MessageBox.Show(memo);
                    }
                }
            }
        }

        /// <summary>
        /// 컨텍스트 메뉴에서 '메모작성'이 클릭되었을때 실행되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContextMenuItemCreateMemo_Click(object sender, EventArgs e)
        {
            using (var inputForm = new InputDialog("메모 작성", "메모를 작성해주세요."))
            {
                inputForm.StartPosition = FormStartPosition.Manual;
                inputForm.Location = Cursor.Position;

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    int selectedRowNum = GetSelectedRowId();
                    string memo = inputForm.InputText;

                    try
                    {
                        using (var conn = new SQLiteConnection($"Data Source = {dbPath}"))
                        {
                            conn.Open();

                            string updateQuery = @"
                            UPDATE customer
                            SET memo = @memo
                            WHERE id = @id
                        ;";

                            using (var cmd = new SQLiteCommand(updateQuery, conn))
                            {
                                cmd.Parameters.AddWithValue(@"memo", memo);
                                cmd.Parameters.AddWithValue(@"id", selectedRowNum);

                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        throw new SQLiteException(exc.Message);
                    }

                    if (currentViewMode == ViewMode.defaultView)
                    {
                        defaultViewCache.Clear();
                        DefaultView();
                    }
                    else
                    {
                        PagingView((selectedRowNum - 1) / 100 + 1);
                    }
                }
            }
        }
    }
}
