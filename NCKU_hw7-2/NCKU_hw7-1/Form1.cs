using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCKU_hw7_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            openFileDialog1.Filter = "文字檔 (*.txt)|*.txt|自訂文字檔 (*.mytxt)|*.mytxt";
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frmChild = new Form2();   // 宣告frmChild為表單實體
            //frmChild.LoadFile(openFileDialog1.FileName);
            frmChild.MdiParent = this;      // 指定父表單

            frmChild.Show();    // 顯示子表單
        }

        private void 開啓舊檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Form2 frmChild = new Form2();   // 宣告frmChild為表單實體
                frmChild.LoadFile(openFileDialog1.FileName);
                frmChild.MdiParent = this;      // 指定父表單

                frmChild.Show();    // 顯示子表單
            }
        }
    }
}
