using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCKU_hw6_2
{
    public class Steve : Panel
    {
        Image img = Image.FromFile("Steve.png");
        public Vector2F position;
        public Steve(int x,int y)
        {
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            this.Padding = new Padding(0);
            this.Margin = new Padding(0);
            this.BackColor = Color.Gray;
            this.Size = new Size(56, 128);
            this.position = new Vector2F(x,y);
            this.Location = new Point((int) this.position.X,(int)this.position.Y);
        }
        

    }
}
