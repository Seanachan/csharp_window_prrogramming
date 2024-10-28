namespace NCKU_hw3_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.button2 = new System.Windows.Forms.Button();
            this.mesBox = new System.Windows.Forms.TextBox();
            this.accountTextBox = new System.Windows.Forms.TextBox();
            this.passwdTextBox = new System.Windows.Forms.TextBox();
            this.accountTxt = new System.Windows.Forms.Label();
            this.passwdTxt = new System.Windows.Forms.Label();
            this.loginBut = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.addItem = new System.Windows.Forms.Button();
            this.listItem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numTextBox = new System.Windows.Forms.TextBox();
            this.penguin = new System.Windows.Forms.Button();
            this.pork = new System.Windows.Forms.Button();
            this.shrimp = new System.Windows.Forms.Button();
            this.sendBut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(343, 174);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(349, 212);
            this.button2.TabIndex = 1;
            this.button2.Text = "開店";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mesBox
            // 
            this.mesBox.BackColor = System.Drawing.SystemColors.Window;
            this.mesBox.Enabled = false;
            this.mesBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesBox.Location = new System.Drawing.Point(343, 62);
            this.mesBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mesBox.Name = "mesBox";
            this.mesBox.Size = new System.Drawing.Size(348, 23);
            this.mesBox.TabIndex = 2;
            this.mesBox.Text = "歡迎來到角落生物商店";
            this.mesBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mesBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // accountTextBox
            // 
            this.accountTextBox.HideSelection = false;
            this.accountTextBox.Location = new System.Drawing.Point(317, 209);
            this.accountTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.accountTextBox.Name = "accountTextBox";
            this.accountTextBox.Size = new System.Drawing.Size(357, 25);
            this.accountTextBox.TabIndex = 3;
            this.accountTextBox.TextChanged += new System.EventHandler(this.accountTextBox_TextChanged);
            // 
            // passwdTextBox
            // 
            this.passwdTextBox.Location = new System.Drawing.Point(317, 270);
            this.passwdTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.passwdTextBox.Name = "passwdTextBox";
            this.passwdTextBox.Size = new System.Drawing.Size(357, 25);
            this.passwdTextBox.TabIndex = 4;
            // 
            // accountTxt
            // 
            this.accountTxt.AutoSize = true;
            this.accountTxt.Location = new System.Drawing.Point(236, 212);
            this.accountTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.accountTxt.Name = "accountTxt";
            this.accountTxt.Size = new System.Drawing.Size(37, 15);
            this.accountTxt.TabIndex = 5;
            this.accountTxt.Text = "賬號";
            this.accountTxt.Click += new System.EventHandler(this.label1_Click);
            // 
            // passwdTxt
            // 
            this.passwdTxt.AutoSize = true;
            this.passwdTxt.Location = new System.Drawing.Point(236, 273);
            this.passwdTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.passwdTxt.Name = "passwdTxt";
            this.passwdTxt.Size = new System.Drawing.Size(37, 15);
            this.passwdTxt.TabIndex = 6;
            this.passwdTxt.Text = "密碼";
            // 
            // loginBut
            // 
            this.loginBut.Location = new System.Drawing.Point(752, 227);
            this.loginBut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.loginBut.Name = "loginBut";
            this.loginBut.Size = new System.Drawing.Size(176, 61);
            this.loginBut.TabIndex = 7;
            this.loginBut.Text = "登入";
            this.loginBut.UseVisualStyleBackColor = true;
            this.loginBut.Click += new System.EventHandler(this.loginBut_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(308, 136);
            this.listBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(553, 319);
            this.listBox.TabIndex = 9;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // addItem
            // 
            this.addItem.Location = new System.Drawing.Point(68, 152);
            this.addItem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(160, 75);
            this.addItem.TabIndex = 10;
            this.addItem.Text = "新增訂單";
            this.addItem.UseVisualStyleBackColor = true;
            this.addItem.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // listItem
            // 
            this.listItem.Location = new System.Drawing.Point(68, 286);
            this.listItem.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.listItem.Name = "listItem";
            this.listItem.Size = new System.Drawing.Size(160, 75);
            this.listItem.TabIndex = 11;
            this.listItem.Text = "列出所有訂單";
            this.listItem.UseVisualStyleBackColor = true;
            this.listItem.Click += new System.EventHandler(this.listItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "請輸入數量";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // numTextBox
            // 
            this.numTextBox.Location = new System.Drawing.Point(343, 149);
            this.numTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.numTextBox.Name = "numTextBox";
            this.numTextBox.Size = new System.Drawing.Size(492, 25);
            this.numTextBox.TabIndex = 13;
            this.numTextBox.TextChanged += new System.EventHandler(this.numTextBox_TextChanged);
            // 
            // penguin
            // 
            this.penguin.BackColor = System.Drawing.SystemColors.Control;
            this.penguin.Location = new System.Drawing.Point(308, 212);
            this.penguin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.penguin.Name = "penguin";
            this.penguin.Size = new System.Drawing.Size(155, 66);
            this.penguin.TabIndex = 14;
            this.penguin.Text = "企鵝";
            this.penguin.UseVisualStyleBackColor = false;
            this.penguin.Click += new System.EventHandler(this.penguin_Click);
            // 
            // pork
            // 
            this.pork.Location = new System.Drawing.Point(492, 212);
            this.pork.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pork.Name = "pork";
            this.pork.Size = new System.Drawing.Size(155, 66);
            this.pork.TabIndex = 15;
            this.pork.Text = "炸豬排";
            this.pork.UseVisualStyleBackColor = true;
            this.pork.Click += new System.EventHandler(this.pork_Click);
            // 
            // shrimp
            // 
            this.shrimp.Location = new System.Drawing.Point(684, 212);
            this.shrimp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.shrimp.Name = "shrimp";
            this.shrimp.Size = new System.Drawing.Size(155, 66);
            this.shrimp.TabIndex = 16;
            this.shrimp.Text = "炸蝦";
            this.shrimp.UseVisualStyleBackColor = true;
            this.shrimp.Click += new System.EventHandler(this.shrimp_Click);
            // 
            // sendBut
            // 
            this.sendBut.Location = new System.Drawing.Point(492, 352);
            this.sendBut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.sendBut.Name = "sendBut";
            this.sendBut.Size = new System.Drawing.Size(155, 54);
            this.sendBut.TabIndex = 17;
            this.sendBut.Text = "送出訂單";
            this.sendBut.UseVisualStyleBackColor = true;
            this.sendBut.Click += new System.EventHandler(this.sendBut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 519);
            this.Controls.Add(this.sendBut);
            this.Controls.Add(this.shrimp);
            this.Controls.Add(this.pork);
            this.Controls.Add(this.penguin);
            this.Controls.Add(this.numTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listItem);
            this.Controls.Add(this.addItem);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.loginBut);
            this.Controls.Add(this.passwdTxt);
            this.Controls.Add(this.accountTxt);
            this.Controls.Add(this.passwdTextBox);
            this.Controls.Add(this.accountTextBox);
            this.Controls.Add(this.mesBox);
            this.Controls.Add(this.button2);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.entry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox mesBox;
        private System.Windows.Forms.Button loginBut;
        private System.Windows.Forms.Label passwdTxt;
        private System.Windows.Forms.Label accountTxt;
        private System.Windows.Forms.TextBox passwdTextBox;
        private System.Windows.Forms.TextBox accountTextBox;
        private System.Windows.Forms.Button listItem;
        private System.Windows.Forms.Button addItem;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox numTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button sendBut;
        private System.Windows.Forms.Button shrimp;
        private System.Windows.Forms.Button pork;
        private System.Windows.Forms.Button penguin;
    }
}

