using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Client
{
    public partial class MailControl : Control
    {
        private bool _isWatched = false;

        private bool _isMouseOver = false;

        private int _borderWidth = 1;
        private bool _isBorderCreate = true;
        private int _opacity = 255;
        private Color _borderColor = Color.FromArgb(200, 200, 200);

        private CheckBox _checkBox;
        private readonly Message _message;

        private readonly Font _fromFont = new Font("Arial", 9.75f, FontStyle.Bold);
        private Rectangle _fromRect;
        private string _from = "Admin";
        private Point _fromLocation;

        private readonly Font _themeFont = new Font("Arial", 9.75f, FontStyle.Bold);
        private Rectangle _themeRect;
        private string _theme = "Theme";
        private Point _themeLocation;

        private readonly Font _contentFont = new Font("Arial", 9.75f, FontStyle.Regular);
        private Rectangle _contentRect;
        private string _content = "Content";

        private string _contentRtf;

        private readonly Font _dateFont = new Font("Arial", 9.75f, FontStyle.Bold);
        private Point _dateLocation;
        private DateTime _receiveDate = DateTime.Now;
        private DateTime _sendDate = DateTime.Now;

        public Message Message { get { return _message; } }

        public bool IsSelected
        {
            get
            {
                if (_checkBox.Visible)
                    return _checkBox.Checked;
                else
                    return false;
            }
            set
            {
                _checkBox.Checked = value;
                Invalidate();
            }
        }

        public bool IsWatched
        {
            get { return _isWatched; }
        }

        protected int FromWidth
        {
            get
            {
                return (int)(Width * 0.15);
            }
        }

        public new Rectangle ClientRectangle
        {
            get
            {
                return new Rectangle(-1, -1, Width + 1, Height + 1);
            }
        }

        [Description("Дата получения сообщения"), Category("Appearance")]
        public DateTime ReceiveDate
        {
            get
            {
                return _receiveDate;
            }
            set
            {
                _receiveDate = value;
                Invalidate();
            }
        }

        [Description("Дата отправки сообщения"), Category("Appearance")]
        public DateTime SendDate
        {
            get
            {
                return _sendDate;
            }
            set
            {
                _sendDate = value;
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

        [Description("Текст сообщения в формате rtf"), Category("Appearance")]
        public string ContentRtf
        {
            get
            {
                return _contentRtf;
            }
            set
            {
                _contentRtf = value;
                Invalidate();
            }
        }

        [Description("Получатель"), Category("Appearance")]
        public string To { get; set; } = "ad@afmms.ru";

        private readonly StringFormat _componentsFormat = StringFormat.GenericTypographic;

        public MailControl()
        {
            Init();
        }

        public MailControl(Message message)
        {
            _message = message;
            From = _message.From;
            Theme = _message.Theme;
            Content = _message.Content.Replace("\n", " ");
            ContentRtf = _message.ContentRtf;
            ReceiveDate = _message.ReceiveTime;
            SendDate = _message.SendTime;
            _isWatched = message.IsOpened;

            To = "";
            foreach (var to in _message.To)
                To += $"{to}, ";
            To = To.TrimEnd(',', ' ');

            Init();
        }

        private void Init()
        {
            InitStyle();

            InitCheckBox();

            Size = new Size(400, 33);
            Cursor = Cursors.Hand;
            MinimumSize = new Size(100, 20);

            if (!_isWatched)
                BackColor = Color.White;
            else
                BackColor = Color.FromArgb(222, 222, 222);

            _checkBox.CheckedChanged += CheckBox_CheckedChanged;
            _checkBox.MouseEnter += MailControl_MouseEnter;
            _checkBox.MouseLeave += MailControl_MouseLeave;
            MouseEnter += MailControl_MouseEnter;
            MouseLeave += MailControl_MouseLeave;
            Click += MailControl_Click;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (_checkBox.Checked)
                BackColor = Color.FromArgb(Opacity, 194, 219, 255);
            else
            {
                if (_isWatched)
                    BackColor = Color.FromArgb(222, 222, 222);
                else
                    BackColor = Color.White;
            }
            MailSelected?.Invoke(sender, this);
        }

        private void MailControl_MouseLeave(object sender, EventArgs e)
        {
            _isMouseOver = false;
            if (!_isMailOpened)
                Invalidate();
        }

        private void MailControl_MouseEnter(object sender, EventArgs e)
        {
            _isMouseOver = true;
            if (!_isMailOpened)
                Invalidate();
        }

        private void InitStyle()
        {
            SetStyle(ControlStyles.UserPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.SupportsTransparentBackColor
                | ControlStyles.Opaque, true);

            _componentsFormat.FormatFlags = StringFormatFlags.FitBlackBox | StringFormatFlags.LineLimit;
            _componentsFormat.Alignment = StringAlignment.Near;
            _componentsFormat.LineAlignment = StringAlignment.Center;
            _componentsFormat.Trimming = StringTrimming.EllipsisCharacter;

        }

        private void InitCheckBox()
        {
            _checkBox = new CheckBox
            {
                Text = string.Empty,
                Size = new Size(14, 14),
                AutoSize = true,
                Cursor = Cursors.Hand,
                BackColor = Color.Transparent,
                Anchor = AnchorStyles.Left,
            };
            _checkBox.Location = new Point(5, (Height - _checkBox.Height) / 2);
            Controls.Add(_checkBox);
        }

        private void InitContentTB()
        {
            _contentTb = new RichTextBox()
            {
                ReadOnly = true,
                Location = new Point(10, _opndFromRect.Y + _opndFromRect.Height),
                Size = new Size(Width - 10 * 2, Height - _opndFromLocation.Y - 30),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom,
                Font = new Font("Arial", 9),
                TabStop = false,
                TabIndex = 0,
            };

            _contentTb.Rtf = ContentRtf;

            if (_contentTb.Size.Height < 200)
            {
                Height += 200;
            }

            Controls.Add(_contentTb);
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
            base.OnSizeChanged(e);

            _fromLocation = new Point(_checkBox.Location.X + _checkBox.Width + 3, _checkBox.Location.Y - 2);

            _themeLocation = new Point(_fromLocation.X + FromWidth, _checkBox.Location.Y - 2);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            g.SetClip(ClientRectangle);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;

            DrawBase(g);

            if (!_isMailOpened)
            {
                DrawMessageComponents(g);

                if (_isMouseOver)
                    DrawShadows(g);
            }
            else
            {
                DrawOpenedMessage(g);
            }
        }

        private void DrawMessageComponents(Graphics graphics)
        {
            DrawFrom(graphics);

            DrawTheme(graphics);

            DrawContent(graphics);

            DrawDate(graphics);
        }

        private void DrawDate(Graphics graphics)
        {
            _dateLocation = new Point(Width - 50, _checkBox.Location.Y - 2);

            string date = ReceiveDate.ToString("dd MMM");

            using (Brush textBrush = new SolidBrush(Color.Black))
                graphics.DrawString(date, _dateFont, textBrush, _dateLocation);
        }

        private void DrawContent(Graphics graphics)
        {
            int themeWidth = (int)graphics.MeasureString(Theme, _themeFont, int.MaxValue, _componentsFormat).Width;

            if (themeWidth > _themeRect.Width)
                return;

            string textToDraw = $" - {Content}";

            _contentRect = new Rectangle(_themeRect.X + themeWidth, _themeRect.Y, _themeRect.Width - themeWidth, _themeRect.Height);

            using (Brush textBrush = new SolidBrush(Color.DimGray))
                graphics.DrawString(textToDraw, _contentFont, textBrush, _contentRect, _componentsFormat);
        }

        private void DrawTheme(Graphics graphics)
        {
            string textToDraw = Theme;

            _themeRect = new Rectangle(_themeLocation.X, _themeLocation.Y, Width - _themeLocation.X - 55, _fromRect.Height);

            using (Brush textBrush = new SolidBrush(Color.Black))
                graphics.DrawString(textToDraw, _themeFont, textBrush, _themeRect, _componentsFormat);
        }

        private void DrawFrom(Graphics graphics)
        {
            string textToDraw = From.Replace("@afmms.ru", string.Empty);
            _fromRect = new Rectangle(_fromLocation.X, _fromLocation.Y, FromWidth, (int)_fromFont.GetHeight() + 3);

            using (Brush textBrush = new SolidBrush(Color.Black))
                graphics.DrawString(textToDraw, _fromFont, textBrush, _fromRect, _componentsFormat);
        }

        private void DrawBase(Graphics g)
        {
            Color color = Color.FromArgb(Opacity, BackColor);

            using (Brush baseBrush = new SolidBrush(color))
                g.FillRectangle(baseBrush, ClientRectangle);

            if (_isBorderCreate)
            {
                DrawBorder(g, _borderWidth);
            }
        }

        private void DrawShadows(Graphics g)
        {
            DrawBorder(g, 1, Color.FromArgb(140, 140, 140));

            using (Pen shadowPen = new Pen(Color.FromArgb(180, 180, 180), 1))
                g.DrawLine(shadowPen, 0, Height - 1, Width, Height - 1);

            using (Pen shadowPen = new Pen(Color.FromArgb(200, 180, 180, 180), 1))
                g.DrawLine(shadowPen, 0, Height - 2, Width, Height - 2);

            using (Pen shadowPen = new Pen(Color.FromArgb(145, 180, 180, 180), 1))
                g.DrawLine(shadowPen, 0, Height - 3, Width, Height - 3);

            using (Pen shadowPen = new Pen(Color.FromArgb(100, 180, 180, 180), 1))
                g.DrawLine(shadowPen, 0, Height - 4, Width, Height - 4);
        }

        private void DrawBorder(Graphics g, int width)
        {
            width += 2;
            Color color = Color.FromArgb(Opacity, BorderColor);
            using (Pen borderPen = new Pen(color, width))
                g.DrawRectangle(borderPen, ClientRectangle);
        }

        private void DrawBorder(Graphics g, int width, Color color)
        {
            Rectangle rect = new Rectangle(new Point(0, 0), Size);
            using (Pen borderPen = new Pen(color, width))
                g.DrawRectangle(borderPen, 0, 0, rect.Width - 1, rect.Height - 1);
        }
    }
}
