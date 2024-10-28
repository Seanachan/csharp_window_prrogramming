namespace NCKU_hw5_2
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
            this.components = new System.ComponentModel.Container();
            this.startGame = new System.Windows.Forms.Button();
            this.chosenView = new System.Windows.Forms.ListView();
            this.startAction = new System.Windows.Forms.Button();
            this.goRight = new System.Windows.Forms.Button();
            this.goLeft = new System.Windows.Forms.Button();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.characterPlacer = new System.Windows.Forms.FlowLayoutPanel();
            this.tobeChoseView = new System.Windows.Forms.ListView();
            this.lifeAndEnemy = new System.Windows.Forms.Label();
            this.money = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.info = new System.Windows.Forms.Label();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.enemyGenerateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // startGame
            // 
            this.startGame.Location = new System.Drawing.Point(252, 218);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(396, 98);
            this.startGame.TabIndex = 0;
            this.startGame.Text = "開始游戲";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // chosenView
            // 
            this.chosenView.HideSelection = false;
            this.chosenView.Location = new System.Drawing.Point(489, 114);
            this.chosenView.Name = "chosenView";
            this.chosenView.Size = new System.Drawing.Size(302, 249);
            this.chosenView.TabIndex = 2;
            this.chosenView.UseCompatibleStateImageBehavior = false;
            // 
            // startAction
            // 
            this.startAction.Location = new System.Drawing.Point(489, 369);
            this.startAction.Name = "startAction";
            this.startAction.Size = new System.Drawing.Size(302, 41);
            this.startAction.TabIndex = 3;
            this.startAction.Text = "開始行動";
            this.startAction.UseVisualStyleBackColor = true;
            this.startAction.Click += new System.EventHandler(this.startAction_Click);
            // 
            // goRight
            // 
            this.goRight.Location = new System.Drawing.Point(433, 165);
            this.goRight.Name = "goRight";
            this.goRight.Size = new System.Drawing.Size(50, 47);
            this.goRight.TabIndex = 4;
            this.goRight.Text = ">";
            this.goRight.UseVisualStyleBackColor = true;
            this.goRight.Click += new System.EventHandler(this.goRight_Click);
            // 
            // goLeft
            // 
            this.goLeft.Location = new System.Drawing.Point(433, 316);
            this.goLeft.Name = "goLeft";
            this.goLeft.Size = new System.Drawing.Size(50, 47);
            this.goLeft.TabIndex = 5;
            this.goLeft.Text = "<";
            this.goLeft.UseVisualStyleBackColor = true;
            this.goLeft.Click += new System.EventHandler(this.goLeft_Click);
            // 
            // table
            // 
            this.table.AutoSize = true;
            this.table.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.table.ColumnCount = 11;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.090908F));
            this.table.Location = new System.Drawing.Point(38, 78);
            this.table.Name = "table";
            this.table.RowCount = 3;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.table.Size = new System.Drawing.Size(851, 201);
            this.table.TabIndex = 6;
            this.table.UseWaitCursor = true;
            // 
            // characterPlacer
            // 
            this.characterPlacer.BackColor = System.Drawing.SystemColors.Control;
            this.characterPlacer.Location = new System.Drawing.Point(38, 337);
            this.characterPlacer.Name = "characterPlacer";
            this.characterPlacer.Size = new System.Drawing.Size(445, 120);
            this.characterPlacer.TabIndex = 8;
            // 
            // tobeChoseView
            // 
            this.tobeChoseView.HideSelection = false;
            this.tobeChoseView.Location = new System.Drawing.Point(125, 114);
            this.tobeChoseView.Name = "tobeChoseView";
            this.tobeChoseView.Size = new System.Drawing.Size(302, 296);
            this.tobeChoseView.TabIndex = 1;
            this.tobeChoseView.UseCompatibleStateImageBehavior = false;
            // 
            // lifeAndEnemy
            // 
            this.lifeAndEnemy.AutoSize = true;
            this.lifeAndEnemy.Location = new System.Drawing.Point(69, 301);
            this.lifeAndEnemy.Name = "lifeAndEnemy";
            this.lifeAndEnemy.Size = new System.Drawing.Size(32, 15);
            this.lifeAndEnemy.TabIndex = 0;
            this.lifeAndEnemy.Text = "3/10";
            // 
            // money
            // 
            this.money.AutoSize = true;
            this.money.Location = new System.Drawing.Point(762, 316);
            this.money.Name = "money";
            this.money.Size = new System.Drawing.Size(0, 15);
            this.money.TabIndex = 9;
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.game_Tick);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(743, 23);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 15);
            this.info.TabIndex = 11;
            // 
            // refreshTimer
            // 
            this.refreshTimer.Interval = 20;
            this.refreshTimer.Tick += new System.EventHandler(this.refresh_Tick);
            // 
            // enemyGenerateTimer
            // 
            this.enemyGenerateTimer.Interval = 3000;
            this.enemyGenerateTimer.Tick += new System.EventHandler(this.enemy_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 516);
            this.Controls.Add(this.info);
            this.Controls.Add(this.money);
            this.Controls.Add(this.lifeAndEnemy);
            this.Controls.Add(this.characterPlacer);
            this.Controls.Add(this.goLeft);
            this.Controls.Add(this.goRight);
            this.Controls.Add(this.startAction);
            this.Controls.Add(this.chosenView);
            this.Controls.Add(this.tobeChoseView);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.table);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startGame;
        private System.Windows.Forms.ListView chosenView;
        private System.Windows.Forms.Button startAction;
        private System.Windows.Forms.Button goRight;
        private System.Windows.Forms.Button goLeft;
        public System.Windows.Forms.TableLayoutPanel table;
        public System.Windows.Forms.FlowLayoutPanel characterPlacer;
        private System.Windows.Forms.ListView tobeChoseView;
        private System.Windows.Forms.Label lifeAndEnemy;
        private System.Windows.Forms.Label money;
        private System.Windows.Forms.Timer gameTimer;
        public System.Windows.Forms.Label info;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.Timer enemyGenerateTimer;
    }
}

