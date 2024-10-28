using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCKU_hw4_1_1
{
    public partial class Form1 : Form
    {
        private bool isFormOpen = false;
        private Form newForm = new Form();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            string s = textBox2.Text;
            addRow(s);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("id",261,HorizontalAlignment.Left);
            listView1.Columns.Add("name", 261, HorizontalAlignment.Right);

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.Dock = DockStyle.Fill;
            //listView1.GridLines = true;

            listView2.Columns.Add("id", 261, HorizontalAlignment.Left);
            listView2.Columns.Add("name", 261, HorizontalAlignment.Right);

            listView2.HeaderStyle=ColumnHeaderStyle.None;
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.Dock = DockStyle.Fill;
            //listView2.GridLines = true;

            listView1.MouseDown += new MouseEventHandler(listView1_MouseDoubleClick);
        }
        private void addRow(string s)
        {
            ListViewItem row = new ListViewItem("楷特:"+s);
            ListViewItem.ListViewSubItem Douge = new ListViewItem.ListViewSubItem(row, "斗哥:汪！");
            row.SubItems.Add(Douge);
            listView1.Items.Add(row);

            ListViewItem row2 = new ListViewItem("斗哥:汪！");
            ListViewItem.ListViewSubItem KaiTe = new ListViewItem.ListViewSubItem(row2, "楷特:"+s);
            row2.SubItems.Add(KaiTe);
            listView2.Items.Add(row2);


        }

        private void listView2_Click(object sender, EventArgs e)
        {
            listView1_Click(sender, e);
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            Form newForm = new Form();
            newForm.Text = "模态视窗";
            newForm.Size = new Size(300, 200);

            newForm.ShowDialog();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form newForm = new Form();
            newForm.Text = "模态视窗";
            newForm.Size = new Size(300, 200);

            newForm.ShowDialog();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (isFormOpen) return;

            // 获取双击位置下的项目
            ListViewItem clickedItem = listView1.GetItemAt(e.X, e.Y);

            // 如果点击的不是列表中的项目，则意味着点击在空白区域
            if (clickedItem == null)
            {
                // 获取 ListView 可见区域的范围
                Rectangle listViewRect = listView1.ClientRectangle;

                // 计算最后一项的底部，确保在最后一项下方的区域也被识别为空白区域
                int lastItemBottom = (listView1.Items.Count > 0) ? listView1.Items[listView1.Items.Count - 1].Bounds.Bottom : 0;

                // 确保双击的地方在 ListView 可见区域内，并且是在最后一项的底部或右侧空白区域
                if (e.Y > lastItemBottom && listViewRect.Contains(e.Location))
                {
                    isFormOpen = true;

                    
                    newForm.Text = "顔色選擇";
                    newForm.Size = new Size(300, 300);

                    Button button = new Button();
                    button.Text = "確定";
                    button.Size = new Size(100, 40);
                    button.Location = new Point((newForm.ClientSize.Width - button.Width) / 2, (newForm.ClientSize.Height - button.Height) / 2+80);
                    button.Click += Button_Click; // 按钮点击事件处理程序

                    newForm.Controls.Add(button);
                    newForm.Click+=newForm_Click;
                    newForm.FormClosed += (s, args) => isFormOpen = false;

                    newForm.ShowDialog();  // 或者使用 newForm.ShowDialog();
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            newForm.Close();
            newForm.FormClosed += (s, args) => isFormOpen = false;
        }
        private void newForm_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int a = (int) (uint)rnd.Next()%255, b = (int)(uint)rnd.Next()%255, c = (int)(uint)rnd.Next()%255;
            newForm.BackColor = Color.FromArgb(a, b, c);
            this.BackColor = Color.FromArgb(a, b, c);
            listView1.BackColor=Color.FromArgb(a, b, c);
            listView2.BackColor=Color.FromArgb(a, b, c);

        }
        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
    }
}
