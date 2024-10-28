using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCKU_hw5_2
{
    public class Character
    {
        public static void skill_Myrtle(){
            Form1.money_int+=14;
            Form1.updateInfo();
        }
        public static void skill_Cardigan(Character ch) {
            ch.cur_hp = ch.cur_hp+(int)Math.Round(ch.hp*0.4);
            if (ch.cur_hp>ch.hp) ch.cur_hp=ch.hp;
            Form1.updateInfo();
        }
        public static void skill_Shaw(int w,Character character) {
            if (Form1.enemy==null) return;
            int x_enemy = Form1.enemy.label.Location.X-Form1.tableX;
            int y_enemy = Form1.enemy.label.Location.Y-Form1.tableY;
            int x_def = character.label.Location.X;
            int y_def = character.label.Location.Y;
            if (Math.Abs(x_def-x_enemy)<=Form1.cellW&& Math.Abs(y_def-y_enemy)<=Form1.cellW*1.5)
            {
                if (Form1.enemy!=null)
                    Form1.enemy.label.Location = new Point(Form1.enemy.label.Location.X-Form1.cellW, Form1.enemy.label.Location.Y);
            }

            Form1.updateInfo();
        }
        public static void skill_Melantha(Character character) 
        {
            if(Form1.enemy==null) return;
            int x_enemy = Form1.enemy.label.Location.X-Form1.tableX;
            int y_enemy = Form1.enemy.label.Location.Y-Form1.tableY;
            int x_def = character.label.Location.X;
            int y_def = character.label.Location.Y;
            if (Math.Abs(x_def-x_enemy)<=Form1.cellW && Math.Abs(y_def-y_enemy)<=Form1.cellW )
            {
                Form1.enemy.hp -= (character.atk*2-Form1.enemy.def);
            }
            Form1.updateInfo();
        }
        
        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.label.Parent is FlowLayoutPanel)
                    label.DoDragDrop(this, DragDropEffects.Move);
                else
                {
                    Label l = (Label)sender as Label;
                    Character character = (Character)l.Tag;
                    if (character.time_left<=0)
                    {
                        switch (character.name)
                        {
                            case "Shaw":
                                Character.skill_Shaw(Form1.cellW,character);
                                break;
                            case "Myrtle":
                                Character.skill_Myrtle();
                                break;

                            case "Melantha":
                                Character.skill_Melantha(character);
                                break;
                            case "Cardigan":
                                Character.skill_Cardigan(character);
                                break;
                        }
                        character.label.BackColor=Color.Gray;
                    }
                    character.time_left = character.cd;
                    Form1.updateInfo();
                }
            }
        }
        public Character(string ch) {
            this.label = new Label();
            this.label.BackColor = System.Drawing.Color.White;
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //this.label.Padding = new Padding(0);
            //this.label.Anchor = AnchorStyles.None;
            //this.label.Dock = DockStyle.None;
            this.label.MouseDown += label_MouseDown;

            this.time_left=this.cd;
            switch (ch) {
                case "Cardigan":
                    this.name="Cardigan";
                    this.hp=2130;
                    this.atk=305;
                    this.def=475;
                    this.cost=18;
                    this.cd=20;
                    this.label.Text = "Cardigan\n"+this.cost;
                    break;
                case "Myrtle":
                    this.name="Myrtle";
                    this.hp=1565;
                    this.atk=520;
                    this.def=300;
                    this.cost=10;
                    this.cd=22;
                    this.label.Text = "Myrtle\n"+this.cost;
                    break;
                case "Melantha":
                    this.name="Melantha";
                    this.hp=2745;
                    this.atk=738;
                    this.def=155;
                    this.cost=15;
                    this.cd=40;
                    this.label.Text = "Melantha\n"+this.cost;
                    break;
                case "Shaw":
                    this.name="Shaw";
                    this.hp=1785;
                    this.atk=580;
                    this.def=365;
                    this.cost=19;
                    this.cd=5;

                    this.label.Text = "Shaw\n"+this.cost;
                    break;
            }
            this.cur_hp = this.hp;

        }

        public string name;
        public int hp;
        public int cur_hp { get; set; }
        public int atk;
        public int def;
        public int cost;
        public int cd; 
        public int time_left;

        public Label label;
    }
}
