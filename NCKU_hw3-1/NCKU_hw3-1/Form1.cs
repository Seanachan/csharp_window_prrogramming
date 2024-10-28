using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NCKU_hw3_1
{
    public partial class Form1 : Form
    {
        string default_account = "admin";
        string default_acc_passwd = "admin";
        bool bool_penguin = false, bool_pork = false, bool_shrimp = false;
        int orderNum = 1000;
        List<List<int>> history=new List<List<int>>();
        
        
        public Form1()
        {
            InitializeComponent();
            listBox.HorizontalScrollbar=true;
            passwdTextBox.Visible = false;
            accountTextBox.Visible = false;
            loginBut.Visible = false;
            accountTxt.Visible = false;
            passwdTxt.Visible = false;
            addItem.Visible = false;
            listItem.Visible = false;
            listBox.Visible = false;
            penguin.Visible= false;
            pork.Visible= false;
            sendBut.Visible= false;
            shrimp.Visible = false;
            numTextBox.Visible = false;
            label1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void loadMain()
        {
            addItem.Visible = true;
            listItem.Visible = true;
            listBox.Visible = true;
        }
        private void closeMain()
        {
            addItem.Visible = false;
            listItem.Visible = false;
            listBox.Visible = false;
        }
        private void loadEntry()
        {
            passwdTextBox.Visible = true;
            accountTextBox.Visible = true;
            loginBut.Visible = true;
            accountTxt.Visible = true;
            passwdTxt.Visible = true;
        }
        public void closeEntry()
        {
            passwdTextBox.Visible = false;
            accountTextBox.Visible = false;
            loginBut.Visible = false;
            accountTxt.Visible = false;
            passwdTxt.Visible = false ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mesBox.Text = "歡迎光臨！請進入！";
            button2.Visible=false;
            loadEntry();
        }

        private void entry_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void accountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginBut_Click(object sender, EventArgs e)
        {
            if (accountTextBox.Text == default_account&& passwdTextBox.Text == default_acc_passwd)
            {
                closeEntry();
                mesBox.Text = "歡迎登入! ，admin";
                loadMain();
            }
            else
            {
                mesBox.Text = "賬號或密碼錯誤";
                accountTextBox.Clear();
                passwdTextBox.Clear();
                
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadBuy();
            
        }
        private void loadBuy()
        {
            label1.Visible = true;
            numTextBox.Visible = true;
            penguin.Visible = true;
            pork.Visible = true;
            sendBut.Visible = true;
            shrimp.Visible = true;
            numTextBox.Visible = true;
            label1.Visible = true;
            closeMain ();
            mesBox.Text = "輸入完數量后，請選對應的商品按鈕，並按送出";
        }
        private void closeBuy()
        {
            penguin.Visible = false;
            pork.Visible = false;
            sendBut.Visible = false;
            shrimp.Visible = false;
            numTextBox.Visible = false;
            label1.Visible=false;
            bool_penguin=false;
            bool_shrimp=false;
            bool_pork=false;
            loadMain();
         }

        private void sendBut_Click(object sender, EventArgs e)
        {
            
                if (bool_penguin)//0
            {
                List<int> list = new List<int>() { orderNum, 0, int.Parse(numTextBox.Text) };
                history.Add(list);
            }
            else if (bool_pork)//1
            {
                List<int> list = new List<int>() { orderNum, 1, int.Parse(numTextBox.Text) };
                history.Add(list);
            }
            else if (bool_shrimp)//2
            {
                List<int> list = new List<int>() { orderNum, 2, int.Parse(numTextBox.Text) };
                history.Add(list);
            }
            else
            {
                mesBox.Text="請選擇商品！";
                return;
            }
            if (!Regex.IsMatch(numTextBox.Text, "^[0-9][0-9]*$"))
            {
                //NaN
                mesBox.Text = "商品數量必須是正整數";
                return;
            }
            closeBuy();
            mesBox.Text = "新增訂單成功，訂單編號"+orderNum.ToString();
            
            numTextBox.Clear();
            orderNum++;
            penguin.BackColor = default(Color);
            shrimp.BackColor = default(Color);
            pork.BackColor = default(Color);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void penguin_Click(object sender, EventArgs e)
        {
            bool_penguin=true;
            bool_shrimp=false;
            bool_pork=false;
            penguin.BackColor = Color.Gray;
            shrimp.BackColor = default(Color);
            pork.BackColor = default(Color);
        }

        private void numTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void listItem_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            foreach (List<int> idx in history)
            {
                string s = "訂單編號 "+idx[0]+" 購買了 "+idx[2] +" 個 ";
                if (idx[1]==0)
                {
                    //pen
                    s+="企鵝";
                }
                else if (idx[1]==1)
                {
                    //pork
                    s+="炸豬排";
                }
                else
                {
                    //shrimp
                    s+="炸蝦";
                }
                listBox.Items.Add(s);
            }

        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pork_Click(object sender, EventArgs e)
        {
            bool_penguin=false;
            bool_shrimp=false;
            bool_pork=true;
            penguin.BackColor = default(Color);
            shrimp.BackColor = default(Color);
            pork.BackColor = Color.Gray;
        }

        private void shrimp_Click(object sender, EventArgs e)
        {
            bool_penguin=false;
            bool_shrimp=true;
            bool_pork=false;
            penguin.BackColor = default(Color);
            shrimp.BackColor = Color.Gray;
            pork.BackColor = default(Color);
        }
    }
}
