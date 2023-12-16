using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Client
{
    public partial class MailControl : Control
    {
        public event EventHandler MailOpened;

        private bool _isMailOpened = false;

        private readonly Font _openedFromFont = new Font("Arial", 10);

        private readonly Font _openedToFont = new Font("Arial", 10);

        private readonly Font _openedDateFont = new Font("Arial", 10);

        private RichTextBox _contentTb;

        private Point _opndThemeLocation = new Point(10, 20);
        private Rectangle _opndThemeRect;

        private Point _opndFromLocation = new Point(10, 40);
        private Rectangle _opndFromRect;

        private Point _opndToLocation = new Point(10, 60);
        private Rectangle _opndToRect;

        private const int DATE_WIDTH = 230;

        private void MailControl_Click(object sender, EventArgs e)
        {
            if(!_isMailOpened)
            {
                _isMailOpened = true;

                OpenTheMessage();
            }
        }

        private void OpenTheMessage()
        {
            foreach (Control control in Parent.Controls)
            {
                if (control != this)
                    control.Hide();
            }
            BackColor = Color.White;
            Cursor = Cursors.Default;
            _checkBox.Hide();

            MailOpened?.Invoke(this, EventArgs.Empty);
        }

        private async Task DrawOpenedMessage(Graphics g)
        {
            using (Brush textBrush = new SolidBrush(Color.Black)) 
            {
                await DrawOpenedThemeAsync(g);

                await DrawOpenedToAsync(g);

                await DrawOpenedFromAsync(g);

                await DrawOpenedDateAsync(g);
            }

            if(_contentTb == null)
                InitContentTB();

            _contentTb.Location = new Point(_contentTb.Location.X, _opndFromRect.Location.Y + _opndFromRect.Height);
            _contentTb.Height = Height - _contentTb.Location.Y - 10;
        }
        
        private async Task DrawOpenedDateAsync(Graphics g)
        {
            string receiveDate = "Получено " + ReceiveDate.ToString("dd.MM.yyyy в HH:mm:ss");
            string sendDate = "Отправлено" + SendDate.ToString("dd.MM.yyyy в HH:mm:ss");

            int dateXCoordinate = Width - DATE_WIDTH;

            Rectangle receiveDateRect = new Rectangle(dateXCoordinate, _opndToRect.Y, DATE_WIDTH, 20);

            Rectangle sendDateRect = new Rectangle(dateXCoordinate, _opndFromRect.Y, DATE_WIDTH, 20);

            await PrintMultilineString(g, receiveDate, _openedDateFont, ref receiveDateRect);

            await PrintMultilineString(g, sendDate, _openedDateFont, ref sendDateRect);
        }

        private async Task DrawOpenedFromAsync(Graphics g)
        {
            string textToDraw = $"От: {From}";

            _opndFromLocation.Y = _opndToRect.Y + _opndToRect.Height;

            _opndFromRect = new Rectangle(_opndFromLocation.X, _opndFromLocation.Y, Width - _opndToLocation.X - (int)DATE_WIDTH, 20);

            await PrintMultilineString(g, textToDraw, _openedFromFont, ref _opndFromRect);
        }

        private async Task DrawOpenedToAsync(Graphics g)
        {
            _opndToLocation.Y = _opndThemeRect.Y + _opndThemeRect.Height;

            _opndToRect = new Rectangle(_opndToLocation.X, _opndToLocation.Y, Width - _opndToLocation.X - (int)DATE_WIDTH, 20);

            string textToDraw = $"Кому: {To}";

            await PrintMultilineString(g, textToDraw, _openedToFont, ref _opndToRect);
        }

        private async Task DrawOpenedThemeAsync(Graphics g)
        {
            _opndThemeRect = new Rectangle(_opndThemeLocation.X, _opndThemeLocation.Y, Width - _opndThemeLocation.X * 2, 20);

            await PrintMultilineString(g, Theme, _themeFont, ref _opndThemeRect);
        }

        private Task PrintMultilineString(Graphics g, string text, Font font, ref Rectangle rect) 
        {
            StringBuilder newText = new StringBuilder();
            StringFormat stringFormat = StringFormat.GenericTypographic;
            stringFormat.LineAlignment = StringAlignment.Near;

            float fontHeight = font.GetHeight(g) + 3;
            rect.Height = 0;

            int charIndex = 0;

            while (charIndex < text.Length)
            {
                StringBuilder currentLine = new StringBuilder();

                foreach (char c in text.Skip(charIndex))
                {
                    if (g.MeasureString(currentLine.ToString() + c, font, int.MaxValue, stringFormat).Width + 3 > rect.Width)
                        break;

                    currentLine.Append(c);
                }

                newText.AppendLine(currentLine.ToString());
                charIndex += currentLine.Length;

                rect.Height += (int)fontHeight;
            }

            string finalText = newText.ToString().TrimEnd();

            using (SolidBrush textBrush = new SolidBrush(Color.Black))
                g.DrawString(finalText, font, textBrush, rect, stringFormat);

            if (rect.Height + rect.Y > Height)
                Height = rect.Height + rect.Y;

            return Task.CompletedTask;
        }
    }
}
