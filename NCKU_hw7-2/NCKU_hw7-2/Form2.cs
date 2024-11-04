using NCKU_hw7_1;
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

namespace NCKU_hw7_2
{
    public partial class Form2 : Form
    {
        Form3 form3;
        string currentFilePath;
        private bool notSaved = false, dialogPresented=false;
        private Stack<Memo> history = new Stack<Memo>();
        private Stack<Memo> redoStack = new Stack<Memo>();
        Memo curState;
        public Form2()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "文字檔 (*.txt)|*.txt|自訂文字檔 (*.mytxt)|*.mytxt";
            //form3 = new Form3(textBox1);
            save_timer.Start();
            curState = new Memo(textBox1.Text,textBox1.Font,textBox1.ForeColor,textBox1.Font.Style);
            history.Push(curState);
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (notSaved)
            {
                DialogResult result = MessageBox.Show("未儲存的變更，是否確定要關閉？", "未儲存的變更",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result==DialogResult.Yes)
                    this.Close();

            }
            else
            {
                this.Close();
            }
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
            }
            if (notSaved) 檔案ToolStripMenuItem.Text = 檔案ToolStripMenuItem.Text.Substring(1);
            notSaved = false;
            history.Push(new Memo(currentFilePath));
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
            if (notSaved) 檔案ToolStripMenuItem.Text = 檔案ToolStripMenuItem.Text.Substring(1);
            notSaved = false;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!history.Any())
                return;

            Memo memo = history.Pop();
            redoStack.Push(memo);
            if (history.Any())
                memo = history.Pop();
            else
                return;
            //if (memo==curState)
            if (memo.filePath==null)
            {
                textBox1.Text = memo.Text;
                textBox1.ForeColor = memo.TextBoxColor;
                textBox1.Font = new Font(memo.TextBoxFont, memo.TextBoxFontStyle);
            }
            else
            {
                File.Delete(memo.filePath);
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!redoStack.Any())
                return;
            Memo memo = redoStack.Pop();
            if (memo.filePath==null)
            {
                textBox1.Text = memo.Text;
                textBox1.ForeColor = memo.TextBoxColor;
                textBox1.Font = new Font(memo.TextBoxFont, memo.TextBoxFontStyle);
            }
            else
            {
                File.Delete(memo.filePath);
            }
        }

        private void 字數統計ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int l = textBox1.Text.Length;
            MessageBox.Show("字數: " + l.ToString(), "字數統計", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 尋找與取代ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (form3 != null && !form3.IsDisposed) form3.Focus();
            else { form3 = new Form3(textBox1); form3.Show(); }
        }

        private void save_timer_Tick(object sender, EventArgs e)
        {
            if (dialogPresented|| !notSaved) return;
            dialogPresented = true;
            string selectedFilePath = saveFileDialog1.FileName;
            if (string.IsNullOrEmpty(currentFilePath))
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    SaveFile(saveFileDialog1.FileName);
            }
            else
                SaveFile(currentFilePath);

            if(notSaved) 檔案ToolStripMenuItem.Text = 檔案ToolStripMenuItem.Text.Substring(1);
            notSaved=false;
            dialogPresented = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(notSaved==false) 檔案ToolStripMenuItem.Text = "*"+檔案ToolStripMenuItem.Text;
            notSaved = true;
            Memo memo = new Memo(textBox1.Text,textBox1.Font,textBox1.ForeColor,textBox1.Font.Style);
            history.Push(memo);
        }
    }
}
