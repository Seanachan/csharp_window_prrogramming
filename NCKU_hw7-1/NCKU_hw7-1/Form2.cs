using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace NCKU_hw7_1
{
    public partial class Form2 : Form
    {
        string currentFilePath;
        public Form2()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "文字檔 (*.txt)|*.txt|自訂文字檔 (*.mytxt)|*.mytxt";
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SaveCustomFile(string filePath)
        {
            string fontName = textBox1.Font.Name;
            float fontSize = textBox1.Font.Size;
            int colorArgb = textBox1.ForeColor.ToArgb();

            bool isBold = textBox1.Font.Style.HasFlag(FontStyle.Bold);
            bool isItalic = textBox1.Font.Style.HasFlag(FontStyle.Italic);
            bool isUnderline = textBox1.Font.Style.HasFlag(FontStyle.Underline);

            string fileHeader = $"[Font={fontName};Size={fontSize};Color={colorArgb};Bold={isBold};Italic={isItalic};Underline={isUnderline}]\n";

            string content = textBox1.Text;

            string fileContent = fileHeader + content;

            File.WriteAllText(filePath, fileContent);
        }
        private void SaveFile(string filePath)
        {
            if (Path.GetExtension(filePath).ToLower() == ".mytxt")
            {
                SaveCustomFile(filePath);
            }
            else
            {
                File.WriteAllText(filePath, textBox1.Text);
            }
        }

        public void LoadFile(string path)
        {
            currentFilePath = path;
            if (Path.GetExtension(path) == ".mytxt")
            {
                string[] lines = File.ReadAllLines(path);
                string[] headerParts = lines[0].Trim('[', ']').Split(';');
                string fontName = headerParts[0].Split('=')[1];
                float fontSize = float.Parse(headerParts[1].Split('=')[1]);
                int colorArgb = int.Parse(headerParts[2].Split('=')[1]);

                bool isBold = bool.Parse(headerParts[3].Split('=')[1]);
                bool isItalic = bool.Parse(headerParts[4].Split('=')[1]);
                bool isUnderline = bool.Parse(headerParts[5].Split('=')[1]);

                FontStyle style = FontStyle.Regular;
                if (isBold) style |= FontStyle.Bold;
                if (isItalic) style |= FontStyle.Italic;
                if (isUnderline) style |= FontStyle.Underline;

                textBox1.Font = new Font(fontName, fontSize, style);
                textBox1.ForeColor = Color.FromArgb(colorArgb);

                textBox1.Text = string.Join("\n", lines, 1, lines.Length - 1);
            }
            else
            {
                textBox1.Text = File.ReadAllText(path);
            }
        }

        private void 剪下ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void 複製ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void 貼上ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void 字型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }

        private void 顔色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }

        private void 另存新檔ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = saveFileDialog1.FileName;
                SaveFile(currentFilePath);
                //MessageBox.Show("檔案複製成功 !.....");
            }
        }

        private void 儲存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedFilePath = saveFileDialog1.FileName;
            if (string.IsNullOrEmpty(currentFilePath))
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveFile(saveFileDialog1.FileName);
                }
            }
            else
            {
                SaveFile(currentFilePath);
            }
        }
    }
}
