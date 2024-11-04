namespace NCKU_hw7_2
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.find_textBox = new System.Windows.Forms.TextBox();
            this.replace_textBox = new System.Windows.Forms.TextBox();
            this.findNext_but = new System.Windows.Forms.Button();
            this.replace_but = new System.Windows.Forms.Button();
            this.allReplace_but = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "尋找";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "取代";
            // 
            // find_textBox
            // 
            this.find_textBox.Location = new System.Drawing.Point(121, 87);
            this.find_textBox.Name = "find_textBox";
            this.find_textBox.Size = new System.Drawing.Size(261, 26);
            this.find_textBox.TabIndex = 2;
            // 
            // replace_textBox
            // 
            this.replace_textBox.Location = new System.Drawing.Point(121, 134);
            this.replace_textBox.Name = "replace_textBox";
            this.replace_textBox.Size = new System.Drawing.Size(261, 26);
            this.replace_textBox.TabIndex = 3;
            // 
            // findNext_but
            // 
            this.findNext_but.Location = new System.Drawing.Point(399, 83);
            this.findNext_but.Name = "findNext_but";
            this.findNext_but.Size = new System.Drawing.Size(112, 34);
            this.findNext_but.TabIndex = 4;
            this.findNext_but.Text = "尋找下一個";
            this.findNext_but.UseVisualStyleBackColor = true;
            this.findNext_but.Click += new System.EventHandler(this.findNext_but_Click);
            // 
            // replace_but
            // 
            this.replace_but.Location = new System.Drawing.Point(399, 184);
            this.replace_but.Name = "replace_but";
            this.replace_but.Size = new System.Drawing.Size(94, 34);
            this.replace_but.TabIndex = 5;
            this.replace_but.Text = "取代";
            this.replace_but.UseVisualStyleBackColor = true;
            this.replace_but.Click += new System.EventHandler(this.replace_but_Click);
            // 
            // allReplace_but
            // 
            this.allReplace_but.Location = new System.Drawing.Point(399, 228);
            this.allReplace_but.Name = "allReplace_but";
            this.allReplace_but.Size = new System.Drawing.Size(94, 34);
            this.allReplace_but.TabIndex = 6;
            this.allReplace_but.Text = "全部取代";
            this.allReplace_but.UseVisualStyleBackColor = true;
            this.allReplace_but.Click += new System.EventHandler(this.allReplace_but_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 296);
            this.Controls.Add(this.allReplace_but);
            this.Controls.Add(this.replace_but);
            this.Controls.Add(this.findNext_but);
            this.Controls.Add(this.replace_textBox);
            this.Controls.Add(this.find_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "尋找與取代";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox find_textBox;
        private System.Windows.Forms.TextBox replace_textBox;
        private System.Windows.Forms.Button findNext_but;
        private System.Windows.Forms.Button replace_but;
        private System.Windows.Forms.Button allReplace_but;
    }
}