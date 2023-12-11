using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server;
using Message = Server.Message;

namespace Client
{
    public partial class MailControl : Control
    {
        private bool _isMouseOver = false;

        private int _borderWidth = 1;
        private bool _isBorderCreate = true;
        private int _opacity = 255;
        private Color _borderColor = Color.LightGray;

        private CheckBox _checkBox;
        private readonly Message _message;

        private readonly Font _fromFont = new Font("Arial", 10, FontStyle.Bold);
        private string _from = "Admin";
        private Point _fromLocation;
        private float _maxFromWidth;

        private readonly Font _themeFont = new Font("Arial", 10, FontStyle.Bold);
        private string _theme = "Theme";
        private Point _themeLocation;

        private readonly Font _contentFont = new Font("Arial", 10, FontStyle.Regular);
        private string _content = "Content";

        private readonly Font _dateFont = new Font("Arial", 10, FontStyle.Bold);
        private Point _dateLocation;
        private DateTime _date = DateTime.Today;

        public CheckBox CheckBox
        {
            get { return _checkBox; }
        }

        private float MaxFromWidth
        {
            get 
            {
                _maxFromWidth = Width * 0.1f;
                return _maxFromWidth; 
            }
        }

        [Description("Дата получения сообщения"), Category("Appearance")]
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
                Invalidate();
            }
        }

        [Description("Содержание сообщения"), Category("Appearance")]
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                Parent?.Invalidate(Bounds, true);
            }
        }

        [Description("Тема сообщения"), Category("Appearance")]
        public string Theme
        {
            get
            {
                return _theme;
            }
            set
            {
                _theme = value;
                Parent?.Invalidate(Bounds, true);
            }
        }

        [Description("Отправитель"), Category("Appearance")]
        public string From
        {
            get
            {
                return _from;
            }
            set
            {
                _from = value;
                Parent?.Invalidate(Bounds, true);
            }
        }

        [Description("Цвет рамки вокруг сообщения"), Category("Appearance")]
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [Description("Толщина рамки вокруг сообщения"), Category("Appearance")]
        public int BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                _borderWidth = value;
                Invalidate();
            }
        }

        [Description("Флаг, отвечающий за рисование границы"), Category("Appearance")]
        public bool IsBorderCreate
        {
            get
            {
                return _isBorderCreate;
            }
            set
            {
                _isBorderCreate = value;
                Invalidate();
            }
        }

        [Description("Значение прозрачности от 0 до 255"), Category("Appearance")]
        public int Opacity
        {
            get
            {
                return _opacity;
            }
            set
            {
                if (value > 255)
                    _opacity = 255;
                else if (value < 0)
                    _opacity = 0;
                else
                    _opacity = value;
                Parent?.Invalidate(Bounds, true);
            }
        }

        public MailControl()
        {
            Init();
        }

        public MailControl(Message message)
        {
            Init();

            _message = message;
            From = _message.From;
            Theme = _message.Theme;
            Content = _message.Content;
            Date = _message.ReceiveTime;
        }

        private void Init()
        {
            InitStyle();
            InitCheckBox();
            InitFrom();
            InitTheme();

            Cursor = Cursors.Hand;
            Dock = DockStyle.Top;
            Height = 30;

            _checkBox.CheckedChanged += _checkBox_CheckedChanged;
            _checkBox.MouseEnter += MailControl_MouseEnter;
            _checkBox.MouseLeave += MailControl_MouseLeave;
            MouseEnter += MailControl_MouseEnter;
            MouseLeave += MailControl_MouseLeave;
        }

        private void _checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_checkBox.Checked)
                BackColor = Color.FromArgb(Opacity, 194, 219, 255);
            else
                BackColor = Color.Transparent;
        }

        private void _checkBox_MouseLeave(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MailControl_MouseLeave(object sender, EventArgs e)
        {
            _isMouseOver = false;
            Invalidate();
        }

        private void MailControl_MouseEnter(object sender, EventArgs e)
        {
            _isMouseOver = true;
            Invalidate();
        }

        private void InitTheme()
        {
            _themeLocation = new Point(_fromLocation.X + (int)_maxFromWidth + 5, _checkBox.Location.Y - 2);
        }

        private void InitFrom()
        {
            _fromLocation = new Point(_checkBox.Location.X + _checkBox.Width + 3, _checkBox.Location.Y - 2);
        }

        private void InitStyle()
        {
            SetStyle(ControlStyles.UserPaint
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.SupportsTransparentBackColor
                | ControlStyles.Opaque, true);
        }

        private void InitCheckBox()
        {
            _checkBox = new CheckBox
            {
                AutoSize = true,
                Cursor = Cursors.Hand,
                BackColor = Color.Transparent,
                Text = string.Empty
            };
            _checkBox.Location = new Point(5, Size.Height / 2 - _checkBox.Height / 2);
            Controls.Add(_checkBox);
            MinimumSize = _checkBox.Size;
            Size = new Size(400, 40);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            _checkBox.Location = new Point(5, Size.Height / 2 - _checkBox.Height / 2);
            _fromLocation = new Point(_checkBox.Location.X + _checkBox.Width + 3, _checkBox.Location.Y - 2);
            _themeLocation = new Point(_fromLocation.X + (int)MaxFromWidth + 5, _checkBox.Location.Y - 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            DrawBase(g);
            DrawMessageComponents(g);

            if (_isMouseOver)
            {
                DrawShadows(g);
            }
        }

        private string TrimStringForMaxWidtgh(string text, Font font, Graphics g, float maxWidth)
        {
            float currentWidth = g.MeasureString(text, font).Width;
            int charactersToRemove = 0;
            string trimmedText = text;

            while (currentWidth > maxWidth && charactersToRemove < text.Length)
            {
                charactersToRemove++;
                trimmedText = text.Remove(text.Length - charactersToRemove);
                trimmedText += "...";
                currentWidth = g.MeasureString(trimmedText, font).Width;
            }

            return trimmedText;
        }

        private void DrawMessageComponents(Graphics graphics)
        {
            using(Brush textBrush = new SolidBrush(Color.FromArgb(Opacity, Color.Black)))
            {
                DrawFrom(graphics, textBrush);

                DrawThemeAndContent(graphics, textBrush);

                _dateLocation = new Point(Width - 50, _checkBox.Location.Y - 2);
                string date = Date.ToString("dd MMM");
                graphics.DrawString(date, _dateFont, textBrush, _dateLocation);
            }
        }

        private void DrawContent(Graphics graphics, Brush brush, float themeWidth)
        {
            Point contentLocation = new Point(_themeLocation.X + (int)themeWidth, _checkBox.Location.Y - 2);
            string textToDraw = Content;
            float textToDrawWidth = graphics.MeasureString(_content, _themeFont).Width;
            float remainingWidth = Width - contentLocation.X - 50;

            if (textToDrawWidth > remainingWidth)
                textToDraw = TrimStringForMaxWidtgh(textToDraw, _contentFont, graphics, remainingWidth);

            graphics.DrawString(textToDraw, _contentFont, brush, contentLocation);
        }

        private void DrawThemeAndContent(Graphics graphics, Brush brush)
        {
            string textToDraw = $"{Theme} - ";
            float textToDrawWidth = graphics.MeasureString(textToDraw, _themeFont).Width;
            float remainingWidth = Width - _themeLocation.X - 50;

            if (textToDrawWidth > remainingWidth)
            {
                textToDraw = TrimStringForMaxWidtgh(textToDraw, _themeFont, graphics, remainingWidth);
                graphics.DrawString(textToDraw, _themeFont, brush, _themeLocation);
                return;
            }

            graphics.DrawString(textToDraw, _themeFont, brush, _themeLocation);

            brush = new SolidBrush(Color.FromArgb(Opacity, 116, 116, 118));
            DrawContent(graphics, brush, textToDrawWidth);
        }

        private void DrawFrom(Graphics graphics, Brush brush)
        {
            string textToDraw = From.Replace("@afmms.ru", string.Empty);
            float textToDrawWidth = graphics.MeasureString(textToDraw, _fromFont).Width;

            if (textToDrawWidth > MaxFromWidth)
                textToDraw = TrimStringForMaxWidtgh(textToDraw, _fromFont, graphics, MaxFromWidth);

            graphics.DrawString(textToDraw, _fromFont, brush, _fromLocation);
        }

        private void DrawBase(Graphics g)
        {
            Rectangle rect = new Rectangle(new Point(0, 0), Size);
            Color color = Color.FromArgb(Opacity, BackColor);

            using (Brush baseBrush = new SolidBrush(color))
                g.FillRectangle(baseBrush, rect);

            if (_isBorderCreate)
            {
                DrawBorder(g, _borderWidth);
            }
        }
        
        private void DrawShadows(Graphics g)
        {
            DrawBorder(g, 1, Color.FromArgb(140,140,140));

            using (Pen shadowPen = new Pen(Color.FromArgb(180, 180, 180), 1))
                g.DrawLine(shadowPen,0,Height - 1, Width, Height - 1);

            using (Pen shadowPen = new Pen(Color.FromArgb(200, 180, 180, 180), 1))
                g.DrawLine(shadowPen, 0, Height - 2, Width, Height - 2);

            using (Pen shadowPen = new Pen(Color.FromArgb(145, 180, 180, 180), 1))
                g.DrawLine(shadowPen, 0, Height - 3, Width, Height - 3);

            using (Pen shadowPen = new Pen(Color.FromArgb(100, 180, 180, 180), 1))
                g.DrawLine(shadowPen, 0, Height - 4, Width, Height - 4);
        }

        private void DrawBorder(Graphics g, int width)
        {
            Rectangle rect = new Rectangle(new Point(0, 0), Size);
            Color color = Color.FromArgb(Opacity, BorderColor);
            using (Pen borderPen = new Pen(color, width))
                g.DrawRectangle(borderPen, 0, 0, rect.Width - 1, rect.Height - 1);
        }

        private void DrawBorder(Graphics g, int width, Color color)
        {
            Rectangle rect = new Rectangle(new Point(0, 0), Size);
            using (Pen borderPen = new Pen(color, width))
                g.DrawRectangle(borderPen, 0, 0, rect.Width - 1, rect.Height - 1);
        }
    }
}
