using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class MessageWriter : Form
    {
        public MessageWriter()
        {
            InitializeComponent();
        }

        private void SetFontStyle(FontStyle style)
        {
            int selectionStart = MsgContentTB.SelectionStart;
            int selectionLength = MsgContentTB.SelectionLength;

            Font currentFont = MsgContentTB.SelectionFont;
            FontStyle newStyle = currentFont.Style ^ style; 

            MsgContentTB.SelectionFont = new Font(currentFont, newStyle);


            MsgContentTB.Select(selectionStart, selectionLength);
        }

        private void AlignLeft_Click(object sender, EventArgs e)
        {
            MsgContentTB.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void AlignCenter_Click(object sender, EventArgs e)
        {
            MsgContentTB.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void AlignRight_Click(object sender, EventArgs e)
        {
            MsgContentTB.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void ItalicStyle_Click(object sender, EventArgs e)
        {
            SetFontStyle(FontStyle.Italic);
        }

        private void BoldStyle_Click(object sender, EventArgs e)
        {
            SetFontStyle(FontStyle.Bold);
        }

        private void UnderlineStyle_Click(object sender, EventArgs e)
        {
            SetFontStyle(FontStyle.Underline);
        }
    }
}
