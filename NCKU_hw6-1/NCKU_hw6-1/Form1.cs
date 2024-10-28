using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NCKU_hw6_1
{
    public partial class Form1 : Form
    {
        private const int blockSize = 64;
        private const int rows = 15;
        private const int columns = 30;
        private Panel hotbar;
        private Panel blockPanel;
        public Image img_grass, img_dirt, img_stone;
        public Steve steve;
        public static BlockType selectedBlock;
        private Vector2F _playerPosition;
        //private Point steveMapPosition = new Point(5 * blockSize, 3 * blockSize); // Set based on your grid layout

        public enum BlockType
        {
            Grass,
            Dirt,
            Stone,
            Air //no block
        }
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Location = new Point((this.ClientSize.Width-pictureBox1.Width+10)/2, this.ClientSize.Height/2);
            pictureBox1.BackColor= Color.Transparent;
            startGame.Location = new Point((this.ClientSize.Width-startGame.Width)/2, this.ClientSize.Height /2+pictureBox1.Height);
            hScrollBar1.Visible = false;
            vScrollBar1.Visible = false;
            stevePanel.Visible = false;
            map.Visible = false;
            stevePanel.BackColor = Color.Transparent;
            setScrollBar();
            setMap();
            setFlowLayout();
            this.BackgroundImage = Image.FromFile("background.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            
            img_grass = Image.FromFile("img_grass.png");img_dirt = Image.FromFile("img_dirt.png");img_stone = Image.FromFile("img_stone.png");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void setFlowLayout()
        {
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel1.AutoSize=false;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Location = new Point(this.ClientSize.Height-flowLayoutPanel1.Size.Height*2, this.ClientSize.Width/2);
            flowLayoutPanel1.Location = new Point(this.ClientSize.Width/2-flowLayoutPanel1.Width/2, this.ClientSize.Height-3*flowLayoutPanel1.Height);
            flowLayoutPanel1.Size = new Size(blockSize*5, blockSize+5);
        }
        private void setMap()
        {
            map.BackColor = Color.Gray;
            for (int i = 0;i<rows;i++)
            {
                for (int j = 0; j<columns; j++)
                {
                    if (i>9)
                    {
                        Block newBlock = new Block(BlockType.Stone);
                        map.Controls.Add(newBlock, j, i);
                    }
                    else if (i>6)
                    {
                        Block newBlock = new Block(BlockType.Dirt);
                        map.Controls.Add(newBlock, j, i);
                    }
                    else if (i>5)
                    {
                        Block newBlock = new Block(BlockType.Grass);
                        map.Controls.Add(newBlock, j, i);
                    }
                    else
                    {
                        Block newBlock = new Block(BlockType.Air);
                        map.Controls.Add(newBlock, j, i);
                    }
                }
            }

            //map.Controls.Add(new Block(BlockType.Dirt));
            //map.Controls.Add(new Block(Form1.BlockType.Grass),1,1);
        }
        private void setScrollBar()
        {
            hScrollBar1.Size = new Size(this.ClientSize.Width, 25);
            vScrollBar1.Size = new Size(25, this.ClientSize.Height);
            hScrollBar1.Location = new Point(0, this.ClientSize.Height-hScrollBar1.Height);
            vScrollBar1.Location = new Point(this.ClientSize.Width-vScrollBar1.Width, 0);

            hScrollBar1.Maximum = blockSize*29-this.ClientSize.Width-40;
            vScrollBar1.Maximum=blockSize*14-this.ClientSize.Height-3;
        }
        private void AddSteve()
        {
            steve = new Steve();
            stevePanel.Size = new Size(steve.Width, steve.Height);
            stevePanel.Location = new Point(5, blockSize*3-9);
            //_playerPosition=  new Vector2F(5, blockSize*3-9);
            stevePanel.Controls.Add(steve);
            steve.BringToFront();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            map.Left = -hScrollBar1.Value;
            UpdateStevePosition();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            map.Top = -vScrollBar1.Value;
            UpdateStevePosition();
        }

        private void SetupHotbar()
        {
            FlowLayoutPanel hotbar = new FlowLayoutPanel
            {
                Height = blockSize+2,
                Width = blockSize*9,
                BackColor = Color.Transparent,
                //Dock = DockStyle.Bottom,
                //BorderStyle = BorderStyle.FixedSingle
            };

            // Create buttons for each block type
            Button grassButton = new Button { Text = "Grass",BackgroundImage=img_grass,Size = new Size(blockSize,blockSize)};
            Button dirtButton = new Button { Text = "Dirt", BackgroundImage=img_dirt, Size = new Size(blockSize, blockSize) };
            Button stoneButton = new Button { Text = "Stone", BackgroundImage=img_stone, Size = new Size(blockSize, blockSize) };

            // Hook up event handlers to set the selected block type
            grassButton.Click += (s, e) => selectedBlock = (BlockType.Grass);
            dirtButton.Click += (s, e) => selectedBlock = (BlockType.Dirt);
            stoneButton.Click += (s, e) => selectedBlock = (BlockType.Stone);

            // Add buttons to hotbar panel
            hotbar.Controls.Add(grassButton);
            hotbar.Controls.Add(dirtButton);
            hotbar.Controls.Add(stoneButton);

            // Add hotbar to form
            flowLayoutPanel1.Controls.Add(hotbar);
        }
        private void UpdateStevePosition()
        {
            // Set Steve's position based on map location and an offset
            int xOffset = map.Left + (5); // Assuming Steve is in the 5th column
            int yOffset = map.Top + (3 * blockSize-9); // Assuming Steve is in the 3rd row

            stevePanel.Location = new Point(xOffset, yOffset);
        }
        private void map_Paint(object sender, PaintEventArgs e)
        {

        }

        private void setVisibleGame()
        {
            startGame.Visible = false;
            pictureBox1.Visible = false;
            hScrollBar1.Visible = true;
            vScrollBar1.Visible = true;
            flowLayoutPanel1.Visible = true;
            map.Visible = true;
            stevePanel.Visible = true;
            this.BackgroundImage=null;
            this.BackColor = Color.DarkGray;
        }
        private void startGame_Click(object sender, EventArgs e)
        {
            setVisibleGame();
            AddSteve();
            SetupHotbar();
        }
        private void DetectCellUnderPictureBox()
        {
            Point relativePosition = this.PointToClient(steve.Location);
            int relativeX = relativePosition.X - map.Location.X; // X position relative to TableLayoutPanel
            int relativeY = relativePosition.Y - map.Location.Y; // Y position relative to TableLayoutPanel

            int column = relativeX / blockSize; // Assuming all columns have the same width (blockSize)
            int row = relativeY / blockSize;    // Assuming all rows have the same height (blockSize)
        }
    }
}
