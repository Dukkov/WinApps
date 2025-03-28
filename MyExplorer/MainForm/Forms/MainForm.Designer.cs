
namespace MainForm
{
    partial class FormMain
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
            this.listViewFileList = new System.Windows.Forms.ListView();
            this.listViewNavPane = new System.Windows.Forms.ListView();
            this.labelStatus = new System.Windows.Forms.Label();
            this.textBoxSearchBox = new System.Windows.Forms.TextBox();
            this.textBoxAddressBar = new System.Windows.Forms.TextBox();
            this.buttonToBack = new System.Windows.Forms.Button();
            this.buttonToForward = new System.Windows.Forms.Button();
            this.buttonToParent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewFileList
            // 
            this.listViewFileList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewFileList.HideSelection = false;
            this.listViewFileList.Location = new System.Drawing.Point(209, 45);
            this.listViewFileList.Name = "listViewFileList";
            this.listViewFileList.Size = new System.Drawing.Size(579, 376);
            this.listViewFileList.TabIndex = 0;
            this.listViewFileList.UseCompatibleStateImageBehavior = false;
            // 
            // listViewNavPane
            // 
            this.listViewNavPane.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewNavPane.HideSelection = false;
            this.listViewNavPane.Location = new System.Drawing.Point(12, 45);
            this.listViewNavPane.Name = "listViewNavPane";
            this.listViewNavPane.Size = new System.Drawing.Size(197, 376);
            this.listViewNavPane.TabIndex = 1;
            this.listViewNavPane.UseCompatibleStateImageBehavior = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 429);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(38, 12);
            this.labelStatus.TabIndex = 2;
            this.labelStatus.Text = "label1";
            // 
            // textBoxSearchBox
            // 
            this.textBoxSearchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSearchBox.Location = new System.Drawing.Point(688, 12);
            this.textBoxSearchBox.Name = "textBoxSearchBox";
            this.textBoxSearchBox.Size = new System.Drawing.Size(100, 21);
            this.textBoxSearchBox.TabIndex = 3;
            // 
            // textBoxAddressBar
            // 
            this.textBoxAddressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAddressBar.Location = new System.Drawing.Point(151, 12);
            this.textBoxAddressBar.Name = "textBoxAddressBar";
            this.textBoxAddressBar.Size = new System.Drawing.Size(518, 21);
            this.textBoxAddressBar.TabIndex = 4;
            // 
            // buttonToBack
            // 
            this.buttonToBack.Location = new System.Drawing.Point(12, 12);
            this.buttonToBack.Name = "buttonToBack";
            this.buttonToBack.Size = new System.Drawing.Size(27, 23);
            this.buttonToBack.TabIndex = 5;
            this.buttonToBack.Text = "button1";
            this.buttonToBack.UseVisualStyleBackColor = true;
            // 
            // buttonToForward
            // 
            this.buttonToForward.Location = new System.Drawing.Point(55, 12);
            this.buttonToForward.Name = "buttonToForward";
            this.buttonToForward.Size = new System.Drawing.Size(27, 23);
            this.buttonToForward.TabIndex = 5;
            this.buttonToForward.Text = "button1";
            this.buttonToForward.UseVisualStyleBackColor = true;
            // 
            // buttonToParent
            // 
            this.buttonToParent.Location = new System.Drawing.Point(98, 12);
            this.buttonToParent.Name = "buttonToParent";
            this.buttonToParent.Size = new System.Drawing.Size(27, 23);
            this.buttonToParent.TabIndex = 5;
            this.buttonToParent.Text = "button1";
            this.buttonToParent.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonToParent);
            this.Controls.Add(this.buttonToForward);
            this.Controls.Add(this.buttonToBack);
            this.Controls.Add(this.textBoxAddressBar);
            this.Controls.Add(this.textBoxSearchBox);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.listViewNavPane);
            this.Controls.Add(this.listViewFileList);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewFileList;
        private System.Windows.Forms.ListView listViewNavPane;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.TextBox textBoxSearchBox;
        private System.Windows.Forms.TextBox textBoxAddressBar;
        private System.Windows.Forms.Button buttonToBack;
        private System.Windows.Forms.Button buttonToForward;
        private System.Windows.Forms.Button buttonToParent;
    }
}

