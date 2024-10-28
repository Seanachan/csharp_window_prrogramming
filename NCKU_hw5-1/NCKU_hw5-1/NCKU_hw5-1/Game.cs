using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCKU_hw5_1
{
    public partial class Game : Form
    {
        int veloLine = 15,gravity=2;
        int caught = 0, not_caught = 0;
        int a = 1;
        List<PictureBox> fruits= new List<PictureBox>();
        public Game()
        {
            InitializeComponent(); 
        }

        private void Game_Load(object sender, EventArgs e)
        {
            plate.Image = Image.FromFile("Images/redline.png");
            plate.SizeMode = PictureBoxSizeMode.StretchImage;
            plate.Location = new Point(this.ClientSize.Width/2, this.ClientSize.Height-2*plate.Height);
            label1.Text = "0/0";    
        }
        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            
            int adjustVelo = e.Shift ? veloLine*2 : veloLine;
            if(e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                if (plate.Location.X - veloLine < 0) return;
                plate.Location = new Point(plate.Location.X-adjustVelo,plate.Location.Y);
            }
            else if(e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                if (plate.Location.X + veloLine > this.ClientSize.Width - plate.Width) return;
                plate.Location = new Point(plate.Location.X+adjustVelo,plate.Location.Y);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int idx = fruits.Count;
            int imgrnd = rnd.Next(1, 3);

            fruits.Add(new PictureBox());
            fruits[idx].Image = Image.FromFile("Images/g"+imgrnd+".png");
            fruits[idx].SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(fruits[idx]);
            fruits[idx].Size = new Size(50, 50);

            int x = rnd.Next(0, this.ClientSize.Width - fruits[idx].Width);
            fruits[idx].Location = new Point(x, 10);
            idx %= 9;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < fruits.Count; i++)
            {
                if (fruits[i] != null)
                {
                    fruits[i].Location = new Point(fruits[i].Location.X, fruits[i].Location.Y + gravity*3);
                    if (fruits[i].Location.Y > this.ClientSize.Height)
                    {
                        //not caught
                        this.Controls.Remove(fruits[i]);
                        fruits[i].Dispose();
                        fruits.RemoveAt(i);
                        not_caught++;
                    }
                    else if (fruits[i].Location.X+fruits[i].Size.Width >= plate.Location.X && 
                        fruits[i].Location.X<= plate.Location.X+ plate.Size.Height &&
                        fruits[i].Location.Y + fruits[i].Size.Height >= plate.Location.Y&&
                        fruits[i].Location.Y<= plate.Location.Y + plate.Size.Height)
                    {
                        //caught
                        caught++;not_caught++;
                        fruits[i].Dispose();
                        fruits.RemoveAt(i);
                    }
                }
                
            }
            label1.Text = caught + "/" + not_caught;   
        }
    }
}
