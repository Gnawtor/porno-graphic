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
    public partial class PaletteEditorGridView : Panel
    {
        private class ColorBox : Panel
        {
            public Color Color;

            public ColorBox(Color color)
            {
                Color = color;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                if (Color != null) BackColor = Color;
            }

            protected override void OnClick(EventArgs e)
            {
                base.OnClick(e);
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.AllowFullOpen = true;
                colorDialog.Color = Color;
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color = colorDialog.Color;
                    Invalidate();
                }
            }
        }
        
        private static int ColorBoxPadding = 1;
        private static int ColorBoxWidth = 16;
        private static int ColorBoxHeight = 16;

        private IPalette mPalette;
        private ColorBox[] ColorBoxes;
        private uint mColorCount;

        public uint ColorCount
        {
            get
            {
                return mColorCount;
            }
            set
            {
                mColorCount = value;
            }
        }

        public IPalette Palette
        {
            get
            {
                return mPalette;
            }
            set
            {
                mPalette = value;
            }
        }

        public Color[] GetColors
        {
            get
            {
                Color[] colors = new Color[ColorCount];
                for (int i = 0; i < ColorCount; i++)
                {
                    Color sourceColor = ColorBoxes[i].Color;
                    colors[i] = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
                }
                return colors;
            }
        }

        public PaletteEditorGridView() : base()
        {
            DoubleBuffered = true;
            BorderStyle = BorderStyle.Fixed3D;
        }

        public void InitializePalette(IPalette palette)
        {
            Palette = palette;
            ColorCount = Palette.GetColorCount();
            ColorBoxes = new ColorBox[ColorCount];

            for (uint i = 0; i < ColorCount; i++)
            {
                ColorBox colorBox = new ColorBox(Palette.GetColor(i));
                colorBox.Width = ColorBoxWidth;
                colorBox.Height = ColorBoxHeight;

                uint row = i / 16;
                uint column = i % 16;

                colorBox.Location = new Point(
                    (int)(column * ColorBoxWidth) + (int)(ColorBoxPadding + (column * ColorBoxPadding)), //X
                    (int)(row * ColorBoxHeight) + (int)(ColorBoxPadding + (row * ColorBoxPadding))); // Y

                ColorBoxes[i] = colorBox;
                Controls.Add(colorBox);
            }
        }
    }
}
