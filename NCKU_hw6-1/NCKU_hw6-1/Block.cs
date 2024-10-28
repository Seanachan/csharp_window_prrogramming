using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCKU_hw6_1
{
    //public enum BlockType
    //{
    //    Grass,
    //    Dirt,
    //    Stone,
    //    Air //no block
    //}
    public class Block:Panel
    {
        private void Block_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                this.BackgroundImage = null;
            }
            else if(e.Button==MouseButtons.Right)
            {
                if (this.BackgroundImage != null) return;
                switch (Form1.selectedBlock)
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
                //this.BackgroundImage = null;
            }
        }
        private const int blockSize = 64;
        private const int rows = 15;
        private const int columns = 30;
        Form1.BlockType type;
        public Block(Form1.BlockType type)
        {
            this.Size = new Size(blockSize, blockSize);
            this.type = type;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.MouseClick += Block_MouseClick;
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

            //this.BackgroundImage = this.img;
        }

    }
}
