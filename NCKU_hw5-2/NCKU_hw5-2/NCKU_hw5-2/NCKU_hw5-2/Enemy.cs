using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
//using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCKU_hw5_2
{
    public class Enemy
    {
        int avg_HP= 1800;
        int avg_atk= 535;
        int avg_DEF=323;
        public int hp, attack, def;
        public Label label;
        private Random rand;

        public Enemy() {
            rand = new Random();
            this.label = new Label();
            this.label.BackColor = Color.Yellow;
            this.hp = rand.Next((int)Math.Round(avg_HP*1.2),(int)Math.Round(avg_HP*1.5));
            this.attack = rand.Next((int)Math.Round(avg_DEF*1.1), (int)Math.Round(avg_atk*1.2));
            this.def = rand.Next((int)Math.Round(avg_atk*0.8), (int)Math.Round(avg_atk*0.9));
            this.label.Text = this.hp.ToString();
        }
    }
}
