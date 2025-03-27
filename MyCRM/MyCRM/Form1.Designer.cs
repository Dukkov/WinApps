
namespace MyCRM
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPaging = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnToEnd = new System.Windows.Forms.Button();
            this.btnToNext = new System.Windows.Forms.Button();
            this.btnToPrev = new System.Windows.Forms.Button();
            this.btnToFirst = new System.Windows.Forms.Button();
            this.labelPageNum = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.등급수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.연락처수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.이메일수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.포인트수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuItemCopyContact = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuItemCreateMemo = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuItemReadMemo = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxPageNumInput = new System.Windows.Forms.TextBox();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(926, 24);
            this.menuStrip2.TabIndex = 0;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDefault,
            this.toolStripMenuItemPaging});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(43, 20);
            this.toolStripMenuItem1.Text = "보기";
            // 
            // toolStripMenuItemDefault
            // 
            this.toolStripMenuItemDefault.Name = "toolStripMenuItemDefault";
            this.toolStripMenuItemDefault.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemDefault.Text = "기본";
            this.toolStripMenuItemDefault.Click += new System.EventHandler(this.ToolStripMenuItemDefault_Click);
            // 
            // toolStripMenuItemPaging
            // 
            this.toolStripMenuItemPaging.Name = "toolStripMenuItemPaging";
            this.toolStripMenuItemPaging.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItemPaging.Text = "페이징";
            this.toolStripMenuItemPaging.Click += new System.EventHandler(this.ToolStripMenuItemPaging_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(870, 376);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.VirtualMode = true;
            this.dataGridView1.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.DataGridView1_CellValueNeeded);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridView1_MouseDown);
            // 
            // btnToEnd
            // 
            this.btnToEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToEnd.AutoSize = true;
            this.btnToEnd.BackColor = System.Drawing.Color.Transparent;
            this.btnToEnd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnToEnd.Location = new System.Drawing.Point(867, 490);
            this.btnToEnd.Margin = new System.Windows.Forms.Padding(0);
            this.btnToEnd.Name = "btnToEnd";
            this.btnToEnd.Size = new System.Drawing.Size(31, 30);
            this.btnToEnd.TabIndex = 2;
            this.btnToEnd.Text = ">>";
            this.btnToEnd.UseVisualStyleBackColor = false;
            this.btnToEnd.Visible = false;
            this.btnToEnd.Click += new System.EventHandler(this.BtnToEnd_Click);
            // 
            // btnToNext
            // 
            this.btnToNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToNext.AutoSize = true;
            this.btnToNext.BackColor = System.Drawing.Color.Transparent;
            this.btnToNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnToNext.Location = new System.Drawing.Point(824, 490);
            this.btnToNext.Margin = new System.Windows.Forms.Padding(0);
            this.btnToNext.Name = "btnToNext";
            this.btnToNext.Size = new System.Drawing.Size(31, 30);
            this.btnToNext.TabIndex = 2;
            this.btnToNext.Text = ">";
            this.btnToNext.UseVisualStyleBackColor = false;
            this.btnToNext.Visible = false;
            this.btnToNext.Click += new System.EventHandler(this.BtnToNext_Click);
            // 
            // btnToPrev
            // 
            this.btnToPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToPrev.AutoSize = true;
            this.btnToPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnToPrev.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnToPrev.Location = new System.Drawing.Point(690, 490);
            this.btnToPrev.Margin = new System.Windows.Forms.Padding(0);
            this.btnToPrev.Name = "btnToPrev";
            this.btnToPrev.Size = new System.Drawing.Size(31, 30);
            this.btnToPrev.TabIndex = 2;
            this.btnToPrev.Text = "<";
            this.btnToPrev.UseVisualStyleBackColor = false;
            this.btnToPrev.Visible = false;
            this.btnToPrev.Click += new System.EventHandler(this.BtnToPrev_Click);
            // 
            // btnToFirst
            // 
            this.btnToFirst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToFirst.AutoSize = true;
            this.btnToFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnToFirst.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnToFirst.Location = new System.Drawing.Point(647, 490);
            this.btnToFirst.Margin = new System.Windows.Forms.Padding(0);
            this.btnToFirst.Name = "btnToFirst";
            this.btnToFirst.Size = new System.Drawing.Size(31, 30);
            this.btnToFirst.TabIndex = 2;
            this.btnToFirst.Text = "<<";
            this.btnToFirst.UseVisualStyleBackColor = false;
            this.btnToFirst.Visible = false;
            this.btnToFirst.Click += new System.EventHandler(this.BtnToFirst_Click);
            // 
            // labelPageNum
            // 
            this.labelPageNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPageNum.AutoSize = true;
            this.labelPageNum.Location = new System.Drawing.Point(726, 498);
            this.labelPageNum.Name = "labelPageNum";
            this.labelPageNum.Size = new System.Drawing.Size(38, 12);
            this.labelPageNum.TabIndex = 3;
            this.labelPageNum.Text = "label1";
            this.labelPageNum.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.수정ToolStripMenuItem,
            this.contextMenuItemCopyContact,
            this.contextMenuItemCreateMemo,
            this.contextMenuItemReadMemo});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            // 
            // 수정ToolStripMenuItem
            // 
            this.수정ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.등급수정ToolStripMenuItem,
            this.연락처수정ToolStripMenuItem,
            this.이메일수정ToolStripMenuItem,
            this.포인트수정ToolStripMenuItem});
            this.수정ToolStripMenuItem.Name = "수정ToolStripMenuItem";
            this.수정ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.수정ToolStripMenuItem.Text = "수정";
            // 
            // 등급수정ToolStripMenuItem
            // 
            this.등급수정ToolStripMenuItem.Name = "등급수정ToolStripMenuItem";
            this.등급수정ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.등급수정ToolStripMenuItem.Text = "등급 수정";
            // 
            // 연락처수정ToolStripMenuItem
            // 
            this.연락처수정ToolStripMenuItem.Name = "연락처수정ToolStripMenuItem";
            this.연락처수정ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.연락처수정ToolStripMenuItem.Text = "연락처 수정";
            // 
            // 이메일수정ToolStripMenuItem
            // 
            this.이메일수정ToolStripMenuItem.Name = "이메일수정ToolStripMenuItem";
            this.이메일수정ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.이메일수정ToolStripMenuItem.Text = "이메일 수정";
            // 
            // 포인트수정ToolStripMenuItem
            // 
            this.포인트수정ToolStripMenuItem.Name = "포인트수정ToolStripMenuItem";
            this.포인트수정ToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.포인트수정ToolStripMenuItem.Text = "포인트 수정";
            // 
            // contextMenuItemCopyContact
            // 
            this.contextMenuItemCopyContact.Name = "contextMenuItemCopyContact";
            this.contextMenuItemCopyContact.Size = new System.Drawing.Size(180, 22);
            this.contextMenuItemCopyContact.Text = "연락처 복사";
            this.contextMenuItemCopyContact.Click += new System.EventHandler(this.ContextMenuItemCopyContact_Click);
            // 
            // contextMenuItemCreateMemo
            // 
            this.contextMenuItemCreateMemo.Name = "contextMenuItemCreateMemo";
            this.contextMenuItemCreateMemo.Size = new System.Drawing.Size(180, 22);
            this.contextMenuItemCreateMemo.Text = "메모 작성";
            this.contextMenuItemCreateMemo.Click += new System.EventHandler(this.ContextMenuItemCreateMemo_Click);
            // 
            // contextMenuItemReadMemo
            // 
            this.contextMenuItemReadMemo.Name = "contextMenuItemReadMemo";
            this.contextMenuItemReadMemo.Size = new System.Drawing.Size(180, 22);
            this.contextMenuItemReadMemo.Text = "메모 보기";
            this.contextMenuItemReadMemo.Click += new System.EventHandler(this.ContextMenuItemReadMemo_Click);
            // 
            // textBoxPageNumInput
            // 
            this.textBoxPageNumInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPageNumInput.Location = new System.Drawing.Point(521, 495);
            this.textBoxPageNumInput.Name = "textBoxPageNumInput";
            this.textBoxPageNumInput.Size = new System.Drawing.Size(103, 21);
            this.textBoxPageNumInput.TabIndex = 4;
            this.textBoxPageNumInput.Visible = false;
            this.textBoxPageNumInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxPageNumInput_KeyUp);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(926, 531);
            this.Controls.Add(this.textBoxPageNumInput);
            this.Controls.Add(this.labelPageNum);
            this.Controls.Add(this.btnToFirst);
            this.Controls.Add(this.btnToPrev);
            this.Controls.Add(this.btnToNext);
            this.Controls.Add(this.btnToEnd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "Form1";
            this.Text = "회원 관리";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDefault;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPaging;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnToEnd;
        private System.Windows.Forms.Button btnToNext;
        private System.Windows.Forms.Button btnToPrev;
        private System.Windows.Forms.Button btnToFirst;
        private System.Windows.Forms.Label labelPageNum;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 등급수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 연락처수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 이메일수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 포인트수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemCopyContact;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemCreateMemo;
        private System.Windows.Forms.TextBox textBoxPageNumInput;
        private System.Windows.Forms.ToolStripMenuItem contextMenuItemReadMemo;
    }
}

