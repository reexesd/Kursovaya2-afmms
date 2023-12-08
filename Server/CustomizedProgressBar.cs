using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace Server
{
    internal class CustomizedProgressBar : ProgressBar
    {
        [Description("Шрифт текста на элементе Progress bar"), Category("Text")]
        public Font TextFont {
            get 
            {
                return _textFont;
            }
            set
            {
                _textFont = value;
                Invalidate();
            }
        }

        private Font _textFont = new Font("TimesNewRoman", 12, FontStyle.Regular);

        private SolidBrush _textBrush = new SolidBrush(Color.Black);
        [Description("Цвет текста на элементе Progress bar"), Category("Text")]
        public Color TextColor
        {
            get
            {
                return _textBrush.Color;
            }
            set
            {
                _textBrush.Dispose();
                _textBrush = new SolidBrush(value);
            }
        }

        private SolidBrush _progressBrush = (SolidBrush)Brushes.LightGreen;
        [Description("Цвет шкалы прогресса"), Category("Appearance")]
        public Color ProgressColor
        {
            get
            {
                return _progressBrush.Color;
            }
            set
            {
                _progressBrush.Dispose();
                _progressBrush = new SolidBrush(value);
            }
        }

        private string CurrProgressStr
        {
            get
            {
                return string.Format("{0:f2}/{1}", (float)Value / 1024, (float)Maximum / 1024);
            }
        }

        private string _customText = "";
        [Description("Текст на элементе Progress bar"), Category("Text")]
        public string CustomText
        {
            get
            {
                return _customText;
            }
            set
            {
                _customText = value;
                Invalidate();
            }
        }

        private string TextToDraw
        {
            get
            {
                return $"{_customText}: {CurrProgressStr}";
            }
        }

        public CustomizedProgressBar()
        {
            Value = Minimum;
            FixComponentBlinking();
        }

        private void FixComponentBlinking()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void DrawProgressBar(Graphics g)
        {
            Rectangle rect = ClientRectangle;

            ProgressBarRenderer.DrawHorizontalBar(g, rect);

            rect.Inflate(-3, -3);

            if (Value > 0)
            {
                Rectangle clip = new Rectangle(rect.X, rect.Y, (int)Math.Round(((float)Value / Maximum) * rect.Width), rect.Height);

                g.FillRectangle(_progressBrush, clip);
            }
        }

        private void DrawText(Graphics g)
        {
            string text = TextToDraw;

            SizeF len = g.MeasureString(text, _textFont);

            Point location = new Point(((Width / 2) - (int)len.Width / 2), ((Height / 2) - (int)len.Height / 2));
            Font font = new Font(FontFamily.GenericSansSerif, 12);

            g.DrawString(text, font, _textBrush, location);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            DrawProgressBar(g);

            DrawText(g);
        }

        public new void Dispose()
        {
            _textBrush.Dispose();
            _progressBrush.Dispose();
            base.Dispose();
        }
    }
}
