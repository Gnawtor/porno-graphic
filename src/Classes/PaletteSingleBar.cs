using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Porno_Graphic.Classes
{
    public partial class PaletteSingleBar : Panel
    {
        private Classes.IPalette mPalette;

        public Classes.IPalette Palette
        {
            get
            {
                return mPalette;
            }
            set
            {
                mPalette = value;
                Invalidate();
            }
        }

        public PaletteSingleBar() : base()
        {
            
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(BackColor);
            if (Palette != null)
            {
                int paletteLength = (int)Palette.GetColorCount();
                int colorBoxWidth = (this.Width / (paletteLength));
                Rectangle colorBox = new Rectangle(new Point(0, 0), new Size(colorBoxWidth, this.Height));

                for (uint i = 0; i < paletteLength; i++)
                {
                    e.Graphics.FillRectangle(Palette.GetBrush(i), colorBox);
                    colorBox.X += colorBoxWidth;
                }
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            Invalidate();
        }
    }
}
