using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCKU_hw4_2
{
    public partial class Form1 : Form
    {
        string sticker_img_path = "Images/button.png";
        bool game_start = false;
        ImageList imgList = new ImageList{ ImageSize = new Size(16,16)};
        ImageList buttonImgList = new ImageList() ;
        Image[] emojiImages = {
                Image.FromFile("Images/0.png"),
                Image.FromFile("Images/1.png"),
                Image.FromFile("Images/2.png"),
                Image.FromFile("Images/3.png"),
                Image.FromFile("Images/4.png"),
                Image.FromFile("Images/5.png")
            };
        RadioButton[] radioButton = new RadioButton[6];
        FlowLayoutPanel emojiFlowlayout;
        Form emoji, colorChoice;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < emojiImages.Length; i++)
            {
                radioButton[i] = new RadioButton();
                radioButton[i].Location = new Point(25, 70);
                radioButton[i].AutoSize = true;
                radioButton[i].CheckedChanged += RadioButton_CheckedChanged;
            }
        }
        private void generateEmojiForm()
        {
            emoji = new Form();
            emoji.Text = "表情符號選擇";
            emoji.Size = new Size(300, 400);
            emojiFlowlayout = new FlowLayoutPanel();
            emojiFlowlayout.Size = new Size(280, 300);
            emojiFlowlayout.FlowDirection = FlowDirection.LeftToRight;
            emojiFlowlayout.WrapContents = true;
            emojiFlowlayout.Padding = new Padding(10);
            emojiFlowlayout.Size = new Size(280, 300);

            

            for (int i = 0; i<=5; i++){
                Panel panel = new Panel();
                panel.Size = new Size(80, 100);

                // PictureBox for the emoji
                PictureBox pictureBox = new PictureBox();
                pictureBox.Size = new Size(60, 60);
                pictureBox.Image = emojiImages[i];
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Location = new Point(10, 0);
               

                // Add PictureBox and RadioButton to the panel
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(radioButton[i]);

                // Add the panel to the FlowLayoutPanel
                emojiFlowlayout.Controls.Add(panel);

            }
                emoji.Controls.Add(emojiFlowlayout);
            Button confirmButton = new Button();
            confirmButton.Text = "確認";
            confirmButton.Size = new Size(60, 30);
            confirmButton.Location = new Point((emoji.ClientSize.Width-confirmButton.Width)/2, emojiFlowlayout.Bottom+10);
            confirmButton.Click += ConfirmButton_Click;
            emoji.Controls.Add(confirmButton);
        }
        
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!(sender is RadioButton currentRadioButton) || !currentRadioButton.Checked)
                return;

            foreach (Control control in emojiFlowlayout.Controls)
            {
                if (control is Panel panel)
                {
                    foreach (Control panelControl in panel.Controls)
                    {
                        if (panelControl is RadioButton radioButton && radioButton != currentRadioButton)
                        {
                            radioButton.Checked = false;  // Uncheck the other radio buttons
                        }
                    }
                }
            }
        }
        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            PictureBox pb = new PictureBox();
            pb.Size = new Size(32, 32);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            for (int i = 0; i<=5; i++)
            {
                if (radioButton[i].Checked)
                {
                    // send the emoji
                    sendEmojiDog(i);


                    radioButton[i].Checked = false;
                }
            }

            emoji.Hide();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            buttonImgList.Images.Add(Image.FromFile(sticker_img_path));
            imgList.Images.Add(Image.FromFile("Images/cat.png"));
            imgList.Images.Add(Image.FromFile("Images/dog.png"));
            imgButton.ImageList=buttonImgList;
            imgButton.ImageIndex=0;
            imgButton2.ImageList=buttonImgList;
            imgButton2.ImageIndex=0;
        }
        private void sendEmojiDog(int imgIdx)
        {
            //MessageBox.Show(tabControl1.SelectedIndex.ToString());
            if (tabControl1.SelectedIndex == 0)
            {
                string s = "斗哥: " ;

                FlowLayoutPanel fp = new FlowLayoutPanel();
                fp.Size = new Size(tabControl1.Width - 20, 32);
                fp.AutoSize = true;
                fp.FlowDirection = FlowDirection.LeftToRight;
                //fp.AutoSize = true;
                PictureBox pbEmoji = new PictureBox();
                pbEmoji.Size = new Size(16, 16);
                pbEmoji.SizeMode = PictureBoxSizeMode.Zoom;
                pbEmoji.Image = emojiImages[imgIdx];

                PictureBox pb = new PictureBox();
                pb.Size = new Size(16, 16);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = imgList.Images[1];

                Label lb1 = new Label();
                lb1.Text = s;
                lb1.AutoSize = true;
                lb1.Padding = new Padding(0, 5, 0, 0);

                fp.Controls.Add(pb);
                fp.Controls.Add(lb1 );
                fp.Controls.Add(pbEmoji);
                flowLayoutPanel1.Controls.Add(fp);
                /******************************************************************************/
                FlowLayoutPanel fp2 = new FlowLayoutPanel();
                fp2.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                fp2.Size = new Size(tabControl1.Width - 20, 32);
                //fp2.AutoSize = true;
                fp2.Padding = new Padding(0);
                fp2.FlowDirection = FlowDirection.RightToLeft;

                PictureBox pbEmoji2 = new PictureBox();
                pbEmoji2.Size = new Size(16, 16);
                pbEmoji2.SizeMode = PictureBoxSizeMode.Zoom;
                pbEmoji2.Image = emojiImages[imgIdx];

                PictureBox pb2 = new PictureBox();
                pb2.Size = new Size(16, 16);
                pb2.SizeMode = PictureBoxSizeMode.Zoom;
                pb2.Image = imgList.Images[1];

                Label lb2 = new Label();
                lb2.Text = s;
                lb2.AutoSize = true;
                lb2.Padding = new Padding(0, 5, 0, 0);

                fp2.Controls.Add(pbEmoji2);
                fp2.Controls.Add(lb2 );
                fp2.Controls.Add(pb2);

                flowLayoutPanel2.Controls.Add(fp2);
                textBox.Clear();
            }
            else
            {
                string s = "楷特: ";
                //1
                FlowLayoutPanel fp = new FlowLayoutPanel();
                fp.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
                fp.Size = new Size(tabControl1.Width - 20, 32);
                fp.FlowDirection = FlowDirection.RightToLeft;
                fp.Padding = new Padding(0);

                PictureBox pbEmoji = new PictureBox();
                pbEmoji.Size = new Size(16, 16);
                pbEmoji.SizeMode = PictureBoxSizeMode.Zoom;
                pbEmoji.Image = emojiImages[imgIdx];
                
                
                PictureBox pb = new PictureBox();
                pb.Size = new Size(16, 16);
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.Image = imgList.Images[0];

                Label lb1 = new Label();
                lb1.Text = s;
                lb1.AutoSize = true;
                lb1.Padding = new Padding(0, 5, 0, 0);

                fp.Controls.Add(pbEmoji);
                fp.Controls.Add(lb1 );
                fp.Controls.Add(pb);

                flowLayoutPanel1.Controls.Add(fp);


                FlowLayoutPanel fp2 = new FlowLayoutPanel();

                fp2.Size = new Size(tabControl1.Width - 20, 32);
                fp2.FlowDirection = FlowDirection.LeftToRight;

                PictureBox pbEmoji2 = new PictureBox();
                pbEmoji2.Size= new Size(16, 16);
                pbEmoji2.SizeMode = PictureBoxSizeMode.Zoom;
                pbEmoji2.Image = emojiImages[imgIdx];

                PictureBox pb2 = new PictureBox();
                pb2.Size = new Size(16, 16);
                pb2.SizeMode = PictureBoxSizeMode.Zoom;
                pb2.Image = imgList.Images[0];

                Label lb2 = new Label();
                lb2.Text = s;
                lb2.AutoSize = true;
                lb2.Padding = new Padding(0,5,0,0);

                fp2.Controls.Add(pb2);
                fp2.Controls.Add(lb2);
                fp2.Controls.Add(pbEmoji2);

                flowLayoutPanel2.Controls.Add(fp2);
                textBox2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = "斗哥: "+textBox.Text;
            
            
            //1
            FlowLayoutPanel fp = new FlowLayoutPanel();
            fp.Size = new Size(tabControl1.Width - 20, 32);
            fp.AutoSize = true;
            fp.FlowDirection = FlowDirection.LeftToRight;
            //fp.AutoSize = true;
            Label lb = new Label();
            lb.Text = s;
            lb.AutoSize = true;
            lb.Padding = new Padding(0,5,0,0);

            PictureBox pb = new PictureBox();
            pb.Size = new Size(16, 16);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Image = imgList.Images[1];

            fp.Controls.Add(pb);
            fp.Controls.Add(lb);
            flowLayoutPanel1.Controls.Add(fp);
            /////////

            FlowLayoutPanel fp2 = new FlowLayoutPanel();
            fp2.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            fp2.Size = new Size(tabControl1.Width-20, 32);
            //fp2.AutoSize = true;
            fp2.Padding = new Padding(0);
            fp2.FlowDirection = FlowDirection.RightToLeft;

            Label lb2 = new Label();
            lb2.Text = s;
            lb2.AutoSize = true;
            lb2.Padding = new Padding(0, 5, 0, 0);
            PictureBox pb2 = new PictureBox();
            pb2.Size = new Size(16, 16);
            pb2.SizeMode = PictureBoxSizeMode.Zoom;
            pb2.Image = imgList.Images[1];
            
            fp2.Controls.Add(lb2);
            fp2.Controls.Add(pb2);

            flowLayoutPanel2.Controls.Add(fp2);
            if (game_start)
            {
                if (textBox.Text == "剪刀")
                {
                    textBox2.Text = "布";
                    button2_Click(sender, e);
                }
                else if (textBox.Text == "石頭")
                {
                    textBox2.Text = "剪刀";
                    button2_Click(sender, e);
                }
                else
                {
                    textBox2.Text = "石頭";
                    button2_Click(sender, e);
                }
            }
            else
            {
                if (textBox.Text == "汪!")
                {
                    textBox2.Text = "喵";
                    button2_Click(sender, e);
                }
                else if (textBox.Text == "猜拳")
                {
                    textBox2.Text = "游戲開始";
                    button2_Click(sender, e);
                    game_start = true;
                }
            }
            textBox.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "楷特: " + textBox2.Text;
            
            //1
            FlowLayoutPanel fp = new FlowLayoutPanel();
            fp.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            fp.Size = new Size(tabControl1.Width - 20, 32);
            fp.FlowDirection = FlowDirection.RightToLeft;
            fp.Padding = new Padding(0);

            Label lb = new Label();
            lb.Text = s;
            lb.AutoSize = true;
            lb.Padding = new Padding(0, 5, 0, 0);
            PictureBox pb = new PictureBox();
            pb.Size = new Size(16, 16);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Image = imgList.Images[0];

            fp.Controls.Add(lb);
            fp.Controls.Add(pb);

            flowLayoutPanel1.Controls.Add(fp);


            FlowLayoutPanel fp2 = new FlowLayoutPanel();
            
            fp2.Size = new Size(tabControl1.Width - 20, 32);
            fp2.FlowDirection = FlowDirection.LeftToRight;

            Label lb2 = new Label();
            lb2.Text = s;
            lb2.AutoSize = true;
            lb2.Padding = new Padding(0, 5, 0, 0);
            PictureBox pb2 = new PictureBox();
            pb2.Size = new Size(16, 16);
            pb2.SizeMode = PictureBoxSizeMode.Zoom;
            pb2.Image = imgList.Images[0];

            fp2.Controls.Add(pb2);
            fp2.Controls.Add(lb2);

            flowLayoutPanel2.Controls.Add(fp2);
            if (textBox2.Text == "喵!")
            {
                textBox.Text = "汪";
                button1_Click(sender, e);
            }
            textBox2.Clear();
        }

        private void imgButton_Click(object sender, EventArgs e)
        {
            if(emoji==null)
                generateEmojiForm();

            emoji.Show();
        }

        private void imgButton2_Click(object sender, EventArgs e)
        {
            if (emoji==null)
                generateEmojiForm();
            
            emoji.Show();
        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            colorChoice = new Form();
            Button confirm_color = new Button();
            confirm_color.Location = new Point(colorChoice.Width/2- confirm_color.Width,colorChoice.Height-20- confirm_color.Height);
            colorChoice.Controls.Add(confirm_color);

            colorChoice.Click += colorChoice_Click; 
            colorChoice.Show();
        }
        private void colorChoice_Click(object sender, EventArgs e)
        {
            Random rnd = new Random(); ;
            int a = rnd.Next(0,255), b = rnd.Next(0,255), c = rnd.Next(0,255);
            Color color = Color.FromArgb(a, b, c);
            //colorChoice
        }
        private void confirm_color_Click(object sender, EventArgs e)
        {

        }
    }

}
