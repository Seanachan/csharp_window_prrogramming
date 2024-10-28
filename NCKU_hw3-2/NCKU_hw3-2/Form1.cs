using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
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
        string cur_acc;
        bool bool_penguin = false, bool_pork = false, bool_shrimp = false;
        int orderNum = 999;
        List<List<int>> history=new List<List<int>>();
        List<string> history_adder = new List<string>();
        Dictionary<string, string> accountDict = new Dictionary<string, string>() {{ "admin", "admin" }};
        
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
            addAccBut.Visible = false;
            logoutBut.Visible = false;
            sendAddAccBut.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        private void loadMain()
        {
            mesBox.Text = "歡迎登入!，"+cur_acc;
            addItem.Visible = true;
            listItem.Visible = true;
            listBox.Visible = true;
            addAccBut.Visible = true;
            logoutBut.Visible = true;
            
        }
        private void closeMain()
        {
            addItem.Visible = false;
            listItem.Visible = false;
            listBox.Visible = false;
            addAccBut.Visible = false;
            logoutBut.Visible = false;
        }
        private void loadEntry()
        {
            mesBox.Text = "歡迎光臨，請登入";
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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginBut_Click(object sender, EventArgs e)
        {
            string account = accountTextBox.Text, passwd = passwdTextBox.Text;
            if (Regex.IsMatch(account,"^ +$")||Regex.IsMatch(passwd, "^ +$"))
            {
                mesBox.Text = "賬號及密碼不可為空白！";
                return;
            }
            if (accountDict.ContainsKey(account))
            {
                if (passwd==accountDict[account])
                {
                    closeEntry();
                    mesBox.Text = "歡迎登入! ，"+account;
                    cur_acc=account;
                    loadMain();
                    accountTextBox.Clear();
                    passwdTextBox.Clear();
                }
                else
                {
                    mesBox.Text = "賬號或密碼錯誤";
                    accountTextBox.Clear();
                    passwdTextBox.Clear();
                }
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
            closeMain();
            
        }
        private void loadBuy()
        {
            mesBox.Text = "輸入完數量后，請選對應的商品按鈕，並按送出";
            label1.Visible = true;
            numTextBox.Visible = true;
            penguin.Visible = true;
            pork.Visible = true;
            sendBut.Visible = true;
            shrimp.Visible = true;
            numTextBox.Visible = true;
            label1.Visible = true;
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
            penguin.Text = "企鵝";
            pork.Text = "炸豬排";
            shrimp.Text = "炸蝦";
        }

        private void sendBut_Click(object sender, EventArgs e)
        {
            
            if (bool_penguin)//0
            {
                List<int> list = new List<int>() { orderNum+1, 0, int.Parse(numTextBox.Text) };
                history.Add(list);
                history_adder.Add(cur_acc);
            }
            else if (bool_pork)//1
            {
                List<int> list = new List<int>() { orderNum+1, 1, int.Parse(numTextBox.Text) };
                history.Add(list);
                history_adder.Add(cur_acc);
            }
            else if (bool_shrimp)//2
            {
                List<int> list = new List<int>() { orderNum+1, 2, int.Parse(numTextBox.Text) };
                history.Add(list);
                history_adder.Add(cur_acc);
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
            loadMain();
            
            numTextBox.Clear();
            penguin.BackColor = default(Color);
            shrimp.BackColor = default(Color);
            pork.BackColor = default(Color);
            orderNum++;
        }

        private void penguin_Click(object sender, EventArgs e)
        {
            bool_penguin=true;
            bool_shrimp=false;
            bool_pork=false;
            penguin.BackColor = Color.Gray;
            shrimp.BackColor = default(Color);
            pork.BackColor = default(Color);
            penguin.Text = "企鵝（已選擇）";
            pork.Text = "炸豬排";
            shrimp.Text = "炸蝦";
        }


        private void listItem_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
            mesBox.Text = "新增訂單成功，訂單編號"+orderNum.ToString();
            int i = 0;
            foreach (List<int> idx in history)
            {
                string s = "訂單編號 "+idx[0]+" 購買了 "+idx[2] +" 個";
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
                s+="，此訂單由"+history_adder[i]+"新增";
                listBox.Items.Add(s);
                i++;
            }

        }
        private void loadAddAcc()
        {
            accountTextBox.Visible = true;
            passwdTextBox.Visible = true;
            accountTxt.Visible = true;
            passwdTxt.Visible = true;
            sendAddAccBut.Visible = true;
        }
        private void closeAddAcc()
        {
            accountTextBox.Visible = false;
            passwdTextBox.Visible = false;
            accountTxt.Visible = false;
            passwdTxt.Visible = false;
            sendAddAccBut.Visible = false;
        }
        private void addAccBut_Click(object sender, EventArgs e)
        {
            closeMain();
            loadAddAcc();
        }

        private void senAddAccBut_Click(object sender, EventArgs e)
        {
            //after added, directly login
            string name = accountTextBox.Text;

            if (Regex.IsMatch(name, "^ +$")||Regex.IsMatch(passwdTextBox.Text, "^ +$"))
            {
                mesBox.Text = "賬號及密碼不可為空白！";
                accountTextBox.Clear();
                passwdTextBox.Clear();
                return;
            }
            if (accountDict.ContainsKey(name))
            {
                mesBox.Text = "此使用者已經存在";
                accountTextBox.Clear();
                passwdTextBox.Clear();
            }
            else
            {
                accountDict.Add(name, passwdTextBox.Text);
                cur_acc=name;
                accountTextBox.Clear();
                passwdTextBox.Clear();
                closeAddAcc();
                loadMain();
            }
        }

        private void logoutBut_Click(object sender, EventArgs e)
        {
            closeMain();
            loadEntry();
        }

        private void Form1_Load(object sender, EventArgs e)
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
            penguin.Text = "企鵝";
            pork.Text = "炸豬排（已選擇）";
            shrimp.Text = "炸蝦";
        }

        private void shrimp_Click(object sender, EventArgs e)
        {
            bool_penguin=false;
            bool_shrimp=true;
            bool_pork=false;
            penguin.BackColor = default(Color);
            shrimp.BackColor = Color.Gray;
            pork.BackColor = default(Color);
            penguin.Text = "企鵝";
            pork.Text = "炸豬排";
            shrimp.Text = "炸蝦（已選擇）";
        }
    }
}
