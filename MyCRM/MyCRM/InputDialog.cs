using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCRM
{
    public partial class InputDialog : Form
    {
        public string InputText { get; set; } = "";

        public InputDialog(string title, string label)
        {
            InitializeComponent();
            this.Text = title;
            labelInputDialog.Text = label;
        }

        /// <summary>
        /// '입력' 버튼이 클릭되었을때 실행되는 이벤트 핸들러
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInputDialog_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            InputText = textBoxInputDialog.Text;
            this.Close();
        }
    }
}
