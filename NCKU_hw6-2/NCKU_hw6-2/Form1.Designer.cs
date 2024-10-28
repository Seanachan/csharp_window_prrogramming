namespace NCKU_hw6_2
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.startGame = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.map = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openSave = new System.Windows.Forms.Button();
            this.quitGame = new System.Windows.Forms.Button();
            this.resumeGame = new System.Windows.Forms.Button();
            this.save_and_backhome = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.LargeChange = 100;
            this.vScrollBar1.Location = new System.Drawing.Point(923, 10);
            this.vScrollBar1.Maximum = 450;
            this.vScrollBar1.Minimum = 1;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(27, 741);
            this.vScrollBar1.SmallChange = 50;
            this.vScrollBar1.TabIndex = 1;
            this.vScrollBar1.Value = 2;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            this.vScrollBar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.vScrollBar1_KeyDown);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.LargeChange = 350;
            this.hScrollBar1.Location = new System.Drawing.Point(32, 756);
            this.hScrollBar1.Maximum = 1100;
            this.hScrollBar1.Minimum = 1;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(904, 22);
            this.hScrollBar1.SmallChange = 100;
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Value = 2;
            this.hScrollBar1.Visible = false;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            this.hScrollBar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hScrollBar1_KeyDown);
            // 
            // startGame
            // 
            this.startGame.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.startGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.startGame.Location = new System.Drawing.Point(355, 394);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(249, 49);
            this.startGame.TabIndex = 2;
            this.startGame.Text = "開始游戲";
            this.startGame.UseVisualStyleBackColor = false;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(182, 673);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(568, 76);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // map
            // 
            this.map.AutoSize = true;
            this.map.BackColor = System.Drawing.SystemColors.Control;
            this.map.ColumnCount = 30;
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.Margin = new System.Windows.Forms.Padding(0);
            this.map.Name = "map";
            this.map.RowCount = 14;
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.map.Size = new System.Drawing.Size(1920, 1024);
            this.map.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(302, 242);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(274, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // openSave
            // 
            this.openSave.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.openSave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.openSave.Location = new System.Drawing.Point(355, 479);
            this.openSave.Name = "openSave";
            this.openSave.Size = new System.Drawing.Size(249, 49);
            this.openSave.TabIndex = 7;
            this.openSave.Text = "開啓存檔";
            this.openSave.UseVisualStyleBackColor = false;
            this.openSave.Click += new System.EventHandler(this.openSave_Click);
            // 
            // quitGame
            // 
            this.quitGame.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.quitGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.quitGame.Location = new System.Drawing.Point(355, 563);
            this.quitGame.Name = "quitGame";
            this.quitGame.Size = new System.Drawing.Size(249, 49);
            this.quitGame.TabIndex = 8;
            this.quitGame.Text = "離開游戲";
            this.quitGame.UseVisualStyleBackColor = false;
            this.quitGame.Click += new System.EventHandler(this.quitGame_Click);
            // 
            // resumeGame
            // 
            this.resumeGame.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.resumeGame.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.resumeGame.Location = new System.Drawing.Point(356, 339);
            this.resumeGame.Name = "resumeGame";
            this.resumeGame.Size = new System.Drawing.Size(249, 49);
            this.resumeGame.TabIndex = 9;
            this.resumeGame.Text = "回到游戲";
            this.resumeGame.UseVisualStyleBackColor = false;
            this.resumeGame.Click += new System.EventHandler(this.resumeGame_Click);
            // 
            // save_and_backhome
            // 
            this.save_and_backhome.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.save_and_backhome.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.save_and_backhome.Location = new System.Drawing.Point(356, 441);
            this.save_and_backhome.Name = "save_and_backhome";
            this.save_and_backhome.Size = new System.Drawing.Size(249, 49);
            this.save_and_backhome.TabIndex = 10;
            this.save_and_backhome.Text = "儲存並回到主畫面";
            this.save_and_backhome.UseVisualStyleBackColor = false;
            this.save_and_backhome.Click += new System.EventHandler(this.save_and_backhome_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 783);
            this.Controls.Add(this.save_and_backhome);
            this.Controls.Add(this.resumeGame);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.quitGame);
            this.Controls.Add(this.openSave);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.map);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button openSave;
        private System.Windows.Forms.Button quitGame;
        private System.Windows.Forms.Button resumeGame;
        private System.Windows.Forms.Button save_and_backhome;
        public System.Windows.Forms.TableLayoutPanel map;
    }
}

