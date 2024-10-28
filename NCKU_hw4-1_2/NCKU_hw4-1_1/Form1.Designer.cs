using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NCKU_hw4_1_1
{
    public partial class Form1 : Form
    {
        private bool isFormOpen = false;
        private Form newForm = new Form();
        private ImageList imageList;
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
            // Initialize listView1 (Left side)
            listView1.Columns.Add("id", 260, HorizontalAlignment.Left);
            //listView1.Location = new Point(0, 0); // Align to the left
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.SmallImageList = new ImageList();

            // Initialize listView2 (Left side below listView1)
            listView2.Columns.Add("id", 260, HorizontalAlignment.Left);
            //listView2.Location = new Point(0, 200); // Below listView1
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.HeaderStyle = ColumnHeaderStyle.None;
            listView2.SmallImageList = new ImageList();

            // Initialize listView3 (Right side)
            listView3.Columns.Add("id", 260, HorizontalAlignment.Right);
            listView3.View = View.Details;
            listView3.FullRowSelect = true;
            listView3.HeaderStyle = ColumnHeaderStyle.None;
            listView3.SmallImageList = new ImageList();

            // Initialize listView4 (Right side below listView3)
            listView4.Columns.Add("id", 260, HorizontalAlignment.Right);
            listView4.View = View.Details;
            listView4.FullRowSelect = true;
            listView4.HeaderStyle = ColumnHeaderStyle.None;
            listView4.SmallImageList = new ImageList();

            // Load images into the ImageList
            imageList = new ImageList();
            imageList.ImageSize = new Size(32, 32);
            imageList.Images.Add(Image.FromFile("Images/cat.png"));
            imageList.Images.Add(Image.FromFile("Images/cat.png"));
            imageList.Images.Add(Image.FromFile("Images/dog.png"));
            imageList.Images.Add(Image.FromFile("Images/dog.png"));


            listView3.Columns[0].Width = listView3.ClientSize.Width - 20; // Adjust width

            // Assign the same ImageList to all ListViews
            listView1.SmallImageList = imageList;
            listView2.SmallImageList = imageList;
            listView3.SmallImageList = imageList;
            listView4.SmallImageList = imageList;

            // Handle mouse click events for all list views
            listView1.MouseDown += new MouseEventHandler(listView1_MouseDoubleClick);
            listView2.MouseDown += new MouseEventHandler(listView1_MouseDoubleClick);
            listView3.MouseDown += new MouseEventHandler(listView1_MouseDoubleClick);
            listView4.MouseDown += new MouseEventHandler(listView1_MouseDoubleClick);

            listView3.Columns[0].Width = listView3.ClientSize.Width - 20; // Adjust width for listView3
            listView4.Columns[0].Width = listView4.ClientSize.Width - 20; // Adjust width for listView4


            // Update alignment when the form is resized
            // this.Resize += new EventHandler(Form1_Resize);
        }


        private void addRow(string s)
        {
            ListViewItem KaiTe1 = new ListViewItem("楷特:"+s)
            {
                ImageIndex = 0
            };

            ListViewItem KaiTe2 = new ListViewItem("楷特:"+s)
            {
                ImageIndex = 1
            };

            ListViewItem Douge1 = new ListViewItem("斗哥:汪！")
            {
                ImageIndex= 2
            };

            ListViewItem Douge2 = new ListViewItem("斗哥:汪！")
            {
                ImageIndex= 3
            };


            listView1.Items.Add(KaiTe1);
            listView2.Items.Add(Douge1);
            listView3.Items.Add(KaiTe2);
            listView4.Items.Add(Douge2);

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
            int a = (int)(uint)rnd.Next()%255, b = (int)(uint)rnd.Next()%255, c = (int)(uint)rnd.Next()%255;
            newForm.BackColor = Color.FromArgb(a, b, c);
            this.BackColor = Color.FromArgb(a, b, c);
            listView1.BackColor=Color.FromArgb(a, b, c);
            listView2.BackColor=Color.FromArgb(a, b, c);

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}