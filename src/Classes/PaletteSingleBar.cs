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
        private int MouseX;
        private uint SelectedColorIndex;
        //private int ColorBoxWidth;
        private List<int> PaletteBoxRanges;

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
            RecomputeLayout();
        }

        private void RecomputeLayout()
        {
            if (mPalette != null)
            {
                PaletteBoxRanges = new List<int>();
                uint colorCount = mPalette.GetColorCount();
                decimal boxWidth = (decimal)this.Width / (decimal)colorCount;
                decimal pointProgress = 0M;
                for (uint i = 0; i <= colorCount; i++)
                {
                    PaletteBoxRanges.Add((int)pointProgress);
                    pointProgress += boxWidth;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(BackColor);
            if (Palette != null)
            {
                RecomputeLayout();
                int paletteLength = (int)Palette.GetColorCount();
                

                for (int i = 0; i < paletteLength; i++)
                {
                    int colorBoxWidth = PaletteBoxRanges[i + 1] - PaletteBoxRanges[i];
                    Rectangle colorBox = new Rectangle(new Point(PaletteBoxRanges[i], 0), new Size(colorBoxWidth, this.Height));
                    e.Graphics.FillRectangle(Palette.GetBrush((uint)i), colorBox);
                    if (i == SelectedColorIndex) 
                    {
                        Rectangle lineBox = new Rectangle(new Point(colorBox.X, colorBox.Y), new Size(colorBox.Width - 1, colorBox.Height - 1));
                        e.Graphics.DrawRectangle(new Pen(Color.Black, 1), lineBox);
                        float[] dashPattern = { 2, 2 };
                        Pen whiteLine = new Pen(Color.White, 1);
                        whiteLine.DashPattern = dashPattern;
                        e.Graphics.DrawRectangle(whiteLine, lineBox);
                    }
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            MouseX = e.X;
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);

            Invalidate();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            int colorCount = (int)mPalette.GetColorCount();
            for (int i = 0; i < colorCount; i++)
            {
                if ((MouseX >= PaletteBoxRanges[i]) && (MouseX <= PaletteBoxRanges[i + 1])) 
                { 
                    SelectedColorIndex = (uint)i;
                    break;
                }
            }
            OnColorSelected(new PaletteSingleBarEventArgs { SelectedColorIndex = SelectedColorIndex });
            Invalidate();
        }

        public event EventHandler<PaletteSingleBarEventArgs> ColorSelected;

        protected virtual void OnColorSelected(PaletteSingleBarEventArgs e)
        {
            EventHandler<PaletteSingleBarEventArgs> handler = ColorSelected;
            if (handler != null)
            {
                handler.Invoke(this, e);
            }
        }

        public class PaletteSingleBarEventArgs : EventArgs
        {
            public uint SelectedColorIndex { get; set; }
        }
    }
}
