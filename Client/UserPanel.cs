using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics.SymbolStore;

namespace Client
{
    internal class UserPanel : Panel
    {
        private int _cornerRadius = 10;
        private int _padding = 10;

        public int PaddingP
        {
            get { return _padding; }
            set
            {
                _padding = value;
                UpdateRegion();
            }
        }

        public int CornerRadius
        {
            get { return _cornerRadius; }
            set
            {
                _cornerRadius = value;
                UpdateRegion();
            }
        }

        public UserPanel()
        {
            this.BackColor = Color.LightGray;
            SizeChanged += UserPanel_SizeChanged;
            UpdateRegion();
        }

        private void UserPanel_SizeChanged(object sender, EventArgs e)
        {
            UpdateRegion();
            Invalidate();
        }

        private void FillRoundedRectangle(Graphics g, Brush brush, int x, int y, int width, int height, int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(x, y, radius * 2, radius * 2, 180, 90);
                path.AddArc(x + width - radius * 2, y, radius * 2, radius * 2, 270, 90);
                path.AddArc(x + width - radius * 2, y + height - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddArc(x, y + height - radius * 2, radius * 2, radius * 2, 90, 90);
                path.CloseAllFigures();

                g.FillPath(brush, path);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            base.OnPaint(e);

            using (var brush = new SolidBrush(Color.LightGray))
            {
                FillRoundedRectangle(e.Graphics, brush, _padding, _padding, Width - 2 * _padding, Height - 2 * _padding, _cornerRadius);
            }
        } 

        private void UpdateRegion()
        {
            using (GraphicsPath path = new GraphicsPath())
            { 
                path.AddArc(0, 0, _cornerRadius * 2, _cornerRadius * 2, 180, 90);
                path.AddArc(this.Width - _cornerRadius * 2, 0, _cornerRadius * 2, _cornerRadius * 2, 270, 90);
                path.AddArc(this.Width - _cornerRadius * 2, this.Height - _cornerRadius * 2, _cornerRadius * 2, _cornerRadius * 2, 0, 90);
                path.AddArc(0, this.Height - _cornerRadius * 2, _cornerRadius * 2, _cornerRadius * 2, 90, 90);
                this.Region = new Region(path);
            }
        }
    }
}
