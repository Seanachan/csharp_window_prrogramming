using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NCKU_hw7_2
{
    public partial class Form3 : Form
    {
        TextBox textBox;
        public Form3(TextBox t)
        {
            InitializeComponent();
            textBox = t;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void findNext_but_Click(object sender, EventArgs e)
        {
            string toFind = find_textBox.Text;
            int l = toFind.Length;

            if (string.IsNullOrEmpty(find_textBox.Text))
            {
                MessageBox.Show( "請輸入要尋找的項目","錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox.Text.IndexOf(toFind) != -1)
            {
                int idx = textBox.Text.IndexOf(toFind); ;
                if (textBox.SelectedText.Equals(toFind))
                {
                    //start from the end + 1 of selected text
                    int tmp_idx = (textBox.SelectionStart + textBox.SelectionLength) % textBox.TextLength;
                    int tmp = textBox.Text.Substring(tmp_idx).IndexOf(toFind);
                    if (tmp != -1)
                    {
                        idx += tmp;
                    }
                }

                //exist
                textBox.Select(idx, l);
                textBox.Focus();

            }
            else
            {
                MessageBox.Show("已找不到更多匹配項目", "尋找",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void replace_but_Click(object sender, EventArgs e)
        {
            string toFind = find_textBox.Text;
            string toReplace = replace_textBox.Text;
            int l = toFind.Length;
            //string oldText = textBox.SelectedText;
            if (textBox.Text.IndexOf(toFind) != -1)
            {
                int idx = textBox.Text.IndexOf(toFind);
                textBox.Select(idx, l);

                textBox.SelectedText = replace_textBox.Text;
                textBox.Select(idx, toReplace.Length - 1);
            }
        }

        private void allReplace_but_Click(object sender, EventArgs e)
        {
            string toFind = find_textBox.Text;
            string toReplace = replace_textBox.Text;
            int l = toFind.Length,start=0;
            //string sub = textBox.Text;
            string sub;
            int idx = textBox.Text.IndexOf(toFind);
            bool flag = true;
            while (flag)
            {
                textBox.Select(idx, l);
                textBox.SelectedText = toReplace;

                start = idx+toReplace.Length;
                sub = textBox.Text.Substring(start%textBox.TextLength);
                
                if (sub.IndexOf(toFind) == -1)
                    break;
                idx= idx+toReplace.Length+sub.IndexOf(toFind);
            }
        }
    }
}
