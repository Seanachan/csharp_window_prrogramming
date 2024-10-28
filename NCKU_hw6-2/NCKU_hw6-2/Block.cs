using NCKU_hw6_2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCKU_hw6_2
{
    //public enum BlockType
    //{
    //    Grass,
    //    Dirt,
    //    Stone,
    //    Air //no block
    //}
    public class Block : Panel
    {
        private void Block_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                this.BackgroundImage = null;
                this.type = Form1.BlockType.Air;
            }
            else if (e.Button==MouseButtons.Right)
            {
                if (this.BackgroundImage != null) return;
                switch (Form1.selectedBlock)
                {
                    case Form1.BlockType.Dirt:
                        this.BackgroundImage = Image.FromFile("img_dirt.png");
                        this.type = Form1.BlockType.Dirt;
                        break;
                    case Form1.BlockType.Grass:
                        this.BackgroundImage = Image.FromFile("img_grass.png");
                        this.type = Form1.BlockType.Grass;
                        break;
                    case Form1.BlockType.Stone:
                        this.BackgroundImage = Image.FromFile("img_stone.png");
                        this.type = Form1.BlockType.Stone;
                        break;
                    default:
                        this.BackgroundImage = null;
                        break;
                }
                //this.BackgroundImage = null;
            }
        }
        private const int blockSize = 64;
        private const int rows = 15;
        private const int columns = 30;
        public Form1.BlockType type;
        public Block(Form1.BlockType type)
        {
            this.Size = new Size(blockSize, blockSize);
            this.AutoSize = false;
            this.type = type;
            this.Margin=new Padding(0);
            this.Padding=new Padding(20,0,2,0);
            this.BackgroundImageLayout = ImageLayout.Zoom;
            this.MouseClick += Block_MouseClick;
            this.Dock = DockStyle.None;
            this.Anchor = AnchorStyles.None;
            switch (this.type)
            {
                case Form1.BlockType.Dirt:
                    this.BackgroundImage = Image.FromFile("img_dirt.png");
                    break;
                case Form1.BlockType.Grass:
                    this.BackgroundImage = Image.FromFile("img_grass.png");
                    break;
                case Form1.BlockType.Stone:
                    this.BackgroundImage = Image.FromFile("img_stone.png");
                    break;
                default:
                    this.BackgroundImage = null;
                    break;
            }
        }

    }
}
