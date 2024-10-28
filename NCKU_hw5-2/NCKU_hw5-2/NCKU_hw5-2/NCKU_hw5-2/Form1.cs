using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
//using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCKU_hw5_2
{
    public partial class Form1 : Form
    {
        public Dictionary<string, Character> Character_dict = new Dictionary<string, Character>();
        public Character Cardigan, Myrtle, Melantha, Shaw;
        int cellHeight,cellWidth;
        public static int money_int = 0,life_int=3,enemy_int=10;
        public static Enemy enemy;
        static Character[] character_arr = new Character[5];
        public static int cellW,tableX,tableY;
        public Form1()
        {
            InitializeComponent();
            info.AutoSize = true;
            

            gameTimer.Stop();
            refreshTimer.Stop();
            enemyGenerateTimer.Stop();

            setVisibleChoose(false);
            setVisibleGame(false);

            chosenView.View=View.Details;
            chosenView.FullRowSelect = true;
            chosenView.Columns.Add("column 1", 200);
            chosenView.HeaderStyle = ColumnHeaderStyle.None;

            tobeChoseView.View=View.Details;
            tobeChoseView.FullRowSelect = true;
            tobeChoseView.Columns.Add("column 1", 200);
            tobeChoseView.HeaderStyle = ColumnHeaderStyle.None;
            tobeChoseView.Items.Add("Cardigan");
            tobeChoseView.Items.Add("Myrtle");
            tobeChoseView.Items.Add("Melantha");
            tobeChoseView.Items.Add("Shaw");

            table.AutoSize = false;
            table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            table.AllowDrop = true;
            table.DragEnter += new DragEventHandler(tablePanel_DragEnter);
            table.DragDrop += new DragEventHandler(tablePanel_DragDrop);
            table.Padding = new Padding(0);
            table.CellPaint+=new TableLayoutCellPaintEventHandler(table_CellPaint);
            cellHeight=table.GetRowHeights()[1];
            cellWidth=table.GetRowHeights()[1];
        }

        private void Label_MouseHover(object sender, EventArgs e)
        {
            Label label = sender as Label;
            info.Text = label.Text;
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            Label label = sender as Label;
            info.Text = label.Text;
        }

        private void label_MouseLeave(object sender, EventArgs e){}

        private void table_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row==1&&e.Column==0)
            {
                e.Graphics.FillRectangle(Brushes.Red, e.CellBounds);
            }
            if (e.Row==1&&e.Column==10)
            {
                e.Graphics.FillRectangle(Brushes.DeepSkyBlue, e.CellBounds);
            }
        }
        private int GetRowFromPosition(TableLayoutPanel tableLayoutPanel, Point point)
        {
            int row = 0;
            int accumulatedHeight = 0;

            // Calculate the row by adding the heights of the rows and comparing to the drop location
            for (int i = 0; i < tableLayoutPanel.RowCount; i++)
            {
                accumulatedHeight += tableLayoutPanel.GetRowHeights()[i];
                if (point.Y < accumulatedHeight)
                {
                    row = i;
                    break;
                }
            }

            return row;
        }

        private int GetColumnFromPosition(TableLayoutPanel tableLayoutPanel, Point point)
        {
            int column = 0;
            int accumulatedWidth = 0;

            // Calculate the column by adding the widths of the columns and comparing to the drop location
            for (int i = 0; i < tableLayoutPanel.ColumnCount; i++)
            {
                accumulatedWidth += tableLayoutPanel.GetColumnWidths()[i];
                if (point.X < accumulatedWidth)
                {
                    column = i;
                    break;
                }
            }

            return column;
        }
        
        private void label_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Label clickedLabel = sender as Label;
                int row = GetRowFromPosition(table, clickedLabel.Location);
                int col = GetColumnFromPosition(table,clickedLabel.Location);

                Character ch = clickedLabel.Tag as Character;
                //ch.time_left = ch.cd;
                //ch.cur_hp = ch.hp;
                if (clickedLabel != null && clickedLabel.Parent == table)
                {
                    table.Controls.Remove(clickedLabel);

                    clickedLabel.Dock = DockStyle.None;
                    clickedLabel.Margin = new Padding(0);
                    clickedLabel.Text = ch.name+"\n"+ch.cost;
                    clickedLabel.BackColor = Color.White;

                    characterPlacer.Controls.Add(clickedLabel);
                }
            }
           
        }
        private void tablePanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Character))||e.Data.GetDataPresent(typeof(Label)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect= DragDropEffects.None;
            }
        }
        private void tablePanel_DragDrop(object sender, DragEventArgs e)
        {
            Point dropLocation = table.PointToClient(new Point(e.X, e.Y));

            int row = GetRowFromPosition(table, dropLocation);
            int column = GetColumnFromPosition(table, dropLocation);
            if ((row==1&&column==0)||(row==1&&column==10)) return;

            Character ch =(Character) e.Data.GetData(typeof(Character));
            if (ch != null&&ch.cost>money_int) return;
            
            Label droppedLabel = (Label)ch.label;
            ch.time_left = ch.cd ;
            ch.cur_hp=ch.hp;
            droppedLabel.BackColor= Color.Gray;
            droppedLabel.Dock = DockStyle.Fill;
            droppedLabel.Margin=new Padding(0);
            droppedLabel.Text=ch.name+ "\n"+ch.cur_hp+"/"+ch.hp+"\n"+ch.time_left;
            droppedLabel.Tag = ch;

            droppedLabel.MouseUp += new MouseEventHandler(label_MouseUp);
            droppedLabel.MouseEnter += new EventHandler(label_MouseEnter);
            droppedLabel.MouseLeave += new EventHandler(label_MouseLeave);
            

            droppedLabel.Parent.Controls.Remove(droppedLabel);

            table.Controls.Add(droppedLabel, column, row);
            money_int-=ch.cost;
        }

        void setVisibleChoose(bool b)
        {
            if (!b)
            {
                tobeChoseView.Hide();
                chosenView.Hide();
                goRight.Hide();
                goLeft.Hide();
                startAction.Hide();
            }
            else
            {
                tobeChoseView.Show();
                chosenView.Show();
                goRight.Show();
                goLeft.Show();
                startAction.Show();
            }
        }
        void setVisibleGame(bool b)
        {
            if (b)
            {
                table.Show();
                characterPlacer.Show();
                lifeAndEnemy.Show();
                money.Show();   
                info.Show();
            }
            else
            {
                table.Hide();
                characterPlacer.Hide();
                lifeAndEnemy.Hide();
                money.Hide();
                info.Hide();
            }
        }

        private void gameWin()
        {
            Label label = new Label();
            label.Text="通關成功";
            label.Location= new Point(this.ClientSize.Width/2, this.ClientSize.Height/2);
            this.Controls.Add(label);
        }
        private void gameOver()
        {
            Label label = new Label();
            label.Text="通關失敗";
            label.Location= new Point(this.ClientSize.Width/2,this.ClientSize.Height/2);
            this.Controls.Add(label);
        }
        private void enemy_Tick(object sender, EventArgs e)
        {
            //5000 ms
            if (enemy==null)
            {
                generateEnemy();
            }
        }
        public static void updateInfo()
        {
            foreach(Character ch in character_arr)
            {
                if (ch==null) continue;
                if (ch.label.Parent is TableLayoutPanel)
                {
                    if (ch.time_left==0) ch.label.BackColor = Color.Green;
                    else ch.label.BackColor = Color.Gray;
                    ch.label.Text = ch.name+"\n"+ch.cur_hp+"/"+ch.hp+"\n"+ch.time_left;
                }
                else
                {
                    ch.label.Text = ch.name+"\n"+ch.cost;
                    ch.label.BackColor = Color.White;
                }
            }
            if (enemy!=null)
            {
                enemy.label.Text = enemy.hp.ToString();
            }
        }
        private void refresh_Tick(object sender, EventArgs e)
        {
            //5 ms
            int velo =1;
            if (enemy==null) return;
            int x_enemy = enemy.label.Location.X-table.Location.X;
            int y_enemy = enemy.label.Location.Y-table.Location.Y;
            bool flag = true;
            //boundary of table
            if(x_enemy<cellHeight*10)
            {
                foreach (Control control in table.Controls)
                {
                    if (!(control is Label)||enemy==null) continue;
                    int x_def = control.Location.X;
                    int y_def = control.Location.Y;
                    x_enemy = enemy.label.Location.X-table.Location.X;
                    y_enemy = enemy.label.Location.Y-table.Location.Y;
                    //enemy is relative to Form, but defender is relative to tableLayoutPanel
                    if ((Math.Abs(x_def-x_enemy) <=cellWidth/2)&&Math.Abs(y_enemy-y_def)<=cellHeight/2)
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else
            {
                life_int--;
                enemy_int--;
                lifeAndEnemy.Text=+life_int+"/"+enemy_int;
                enemy.label.Dispose();
                enemy=null;
                return;
            }
            if (flag&&x_enemy<cellHeight*10+cellWidth/2)
            {
                enemy.label.Location = new Point(enemy.label.Location.X+velo, enemy.label.Location.Y);
            }
             
        }
        private void character_Click(object sender, EventArgs e)
        {
            
        }

        private void game_Tick(object sender, EventArgs e)
        {
            //1000 ms
            if (money_int<99)
            {
                money_int+=1;
                money.Text = money_int.ToString();
            }
            else
            {
                money_int=99;
                money.Text = money_int.ToString();
            }


            //if skill is ready
            foreach(Character ch in Character_dict.Values)
            {
                if(ch==null || !(ch.label.Parent is TableLayoutPanel)) continue;
                if (ch.time_left>0) { 
                    if(ch.time_left>=10){
                        string substr = ch.label.Text.Substring(0, ch.label.Text.Length-2);
                        ch.label.Text=substr+ --ch.time_left;
                    }
                    else
                    {
                        string substr = ch.label.Text.Substring(0, ch.label.Text.Length-1);
                        ch.label.Text=substr+ --ch.time_left;
                    }
                }
                if (ch.time_left==0 && !(ch.label.Parent is FlowLayoutPanel))
                {
                    ch.label.BackColor=Color.Green;
                }
            }

            //meet defender
            foreach (Control control in table.Controls)
            {
                if (!(control is Label)||enemy==null) continue;
                //Label defender = control as Label;
                int x_enemy = enemy.label.Location.X-table.Location.X, x_def = control.Location.X;
                int y_enemy = enemy.label.Location.Y-table.Location.Y, y_def = control.Location.Y;
                Character ch = control.Tag as Character;
                if ((Math.Abs(x_def-x_enemy) <=cellWidth/2+5)&&Math.Abs(y_enemy-y_def)<cellWidth/2+5)
                {
                    //MessageBox.Show("here");
                    // if enemey and defender encounters
                    ch.cur_hp-= (enemy.attack-ch.def)<=0? 0:(enemy.attack-ch.def);
                    enemy.hp-= (ch.atk-enemy.def)<=0? 0: (ch.atk-enemy.def);
                }else if (Math.Abs(x_enemy-x_def)<cellWidth&&Math.Abs(y_enemy-y_def)<cellHeight)
                {
                    // if enemey is within 1 cell
                    enemy.hp-= (ch.atk-enemy.def) <= 0 ? 0 : (ch.atk - enemy.def);
                }
                
                //updateInfo();
                
                //if defender dies
                if (ch.cur_hp<=0)
                {
                    table.Controls.Remove(ch.label);
                    table.Controls.Remove(control);
                    characterPlacer.Controls.Add(ch.label);
                }
                
                //if enemy dies
                if (enemy.hp<=0)
                {
                    enemy.label.Dispose();
                    enemy=null;
                    enemy_int--;
                }
                lifeAndEnemy.Text = life_int+"/"+enemy_int;
                updateInfo();
            }

            //game over or win
            if (life_int<=0)
            {
                setVisibleGame(false);
                enemyGenerateTimer.Stop();
                gameOver();
                if (enemy!=null) enemy=null;
            }
            if (enemy_int<=0)
            {
                setVisibleGame(false);
                enemyGenerateTimer.Stop();
                gameWin();
                if (enemy!=null) enemy=null;
            }
        }
        private void generateEnemy()
        {
            enemy = new Enemy();
            enemy.label.Location = new Point(table.Location.X, table.Location.Y+table.GetRowHeights()[1]+8);
            enemy.label.Size = new Size(40, 40);
            enemy.label.TextAlign = ContentAlignment.MiddleCenter;
            enemy.label.AllowDrop= false;
            this.Controls.Add(enemy.label);
            enemy.label.BringToFront();
        }
        private void startGame_Click(object sender, EventArgs e)
        {
            startGame.Hide();
            setVisibleChoose(true);
            money_int=5;
            
        }
        private void goRight_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in tobeChoseView.Items)
            {
                if (item.Selected)
                {
                    chosenView.Items.Add(item.Text);
                    tobeChoseView.Items.Remove(item);
                    break;
                }
            }
        }

        private void goLeft_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in chosenView.Items)
            {
                if (item.Selected)
                {
                    tobeChoseView.Items.Add(item.Text);
                    chosenView.Items.Remove(item);
                    break;
                }
            }
        }

        private void startAction_Click(object sender, EventArgs e)
        {
            setVisibleChoose(false);
            setVisibleGame(true);
            int idx = 0;
            foreach(ListViewItem item in chosenView.Items)
            {
                switch (item.Text)
                {
                    case "Shaw":
                        Shaw = new Character(item.Text); Shaw.label.Size = new Size(77,77); 
                        characterPlacer.Controls.Add(Shaw.label);
                        Character_dict.Add("Shaw", Shaw);
                        character_arr[idx++]=Shaw;
                        break;
                    case "Melantha":
                        Melantha = new Character(item.Text); Melantha.label.Size = new Size(77,77); 
                        characterPlacer.Controls.Add(Melantha.label); 
                        Character_dict.Add("Melantha", Melantha);
                        character_arr[idx++]=Melantha;
                        break;
                    case "Myrtle":
                        Myrtle = new Character(item.Text); Myrtle.label.Size = new Size(77,77);
                        characterPlacer.Controls.Add(Myrtle.label); Character_dict.Add("Myrtle", Myrtle);
                        character_arr[idx++]=Myrtle;
                        break;
                    case "Cardigan":
                        Cardigan = new Character(item.Text);
                        Cardigan.label.Size = new Size(77,77); characterPlacer.Controls.Add(Cardigan.label);
                        Character_dict.Add("Cardigan", Cardigan);
                        character_arr[idx++]=Cardigan;
                        break;
                }
            }
            gameTimer.Start();
            if (!refreshTimer.Enabled &&enemy==null)
            {
                refreshTimer.Start();
                enemyGenerateTimer.Start();
            }
            Form1.cellW= table.GetRowHeights()[1];
            Form1.tableX = table.Location.X;
            Form1.tableY = table.Location.Y;
        }
    }
}
