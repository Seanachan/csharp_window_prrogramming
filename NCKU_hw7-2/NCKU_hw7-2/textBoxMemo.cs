using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCKU_hw7_2
{
    public  class Memo
    {
        public string Text { get; private set; }
        public Font TextBoxFont { get; private set; }
        public Color TextBoxColor { get; private set; }
        public FontStyle TextBoxFontStyle { get; private set; }
        public string filePath { get; private set; }
        public Memo(string text, Font font, Color color, FontStyle fontStyle)
        {
            Text = text;
            TextBoxFont = font;
            TextBoxColor = color;
            TextBoxFontStyle = fontStyle;
        }
        public Memo(string path)
        {
            filePath= path;
        }

    }
}
