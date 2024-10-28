using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCKU_hw6_1
{
    public class Steve:Panel
    {
        Image img = Image.FromFile("Steve.png");
        public Steve()
        {
            this.BackgroundImage = img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //this.Padding = new Padding(0);
            this.Margin = new Padding(0);
            this.BackColor = Color.Gray;
            this.Size = new Size(64, 128);
        }

    }
}
