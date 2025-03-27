
namespace MyCRM
{
    partial class InputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.labelInputDialog = new System.Windows.Forms.Label();
            this.textBoxInputDialog = new System.Windows.Forms.TextBox();
            this.btnInputDialog = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // labelInputDialog
            // 
            this.labelInputDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelInputDialog.AutoSize = true;
            this.labelInputDialog.Font = new System.Drawing.Font("굴림", 10F);
            this.labelInputDialog.Location = new System.Drawing.Point(80, 36);
            this.labelInputDialog.Name = "labelInputDialog";
            this.labelInputDialog.Size = new System.Drawing.Size(45, 14);
            this.labelInputDialog.TabIndex = 0;
            this.labelInputDialog.Text = "label1";
            // 
            // textBoxInputDialog
            // 
            this.textBoxInputDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInputDialog.Location = new System.Drawing.Point(12, 79);
            this.textBoxInputDialog.Multiline = true;
            this.textBoxInputDialog.Name = "textBoxInputDialog";
            this.textBoxInputDialog.Size = new System.Drawing.Size(196, 49);
            this.textBoxInputDialog.TabIndex = 1;
            // 
            // btnInputDialog
            // 
            this.btnInputDialog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInputDialog.Font = new System.Drawing.Font("굴림", 11F);
            this.btnInputDialog.Location = new System.Drawing.Point(231, 79);
            this.btnInputDialog.Name = "btnInputDialog";
            this.btnInputDialog.Size = new System.Drawing.Size(75, 49);
            this.btnInputDialog.TabIndex = 2;
            this.btnInputDialog.Text = "입력";
            this.btnInputDialog.UseVisualStyleBackColor = true;
            this.btnInputDialog.Click += new System.EventHandler(this.BtnInputDialog_Click);
            // 
            // InputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(318, 153);
            this.Controls.Add(this.btnInputDialog);
            this.Controls.Add(this.textBoxInputDialog);
            this.Controls.Add(this.labelInputDialog);
            this.Name = "InputDialog";
            this.Text = "InputDialog";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button btnInputDialog;
        private System.Windows.Forms.TextBox textBoxInputDialog;
        private System.Windows.Forms.Label labelInputDialog;
    }
}