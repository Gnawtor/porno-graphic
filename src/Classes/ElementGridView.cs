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
    public partial class ElementGridView : ScrollableControl
    {
        private uint mElementWidth = 8U;
        private uint mElementHeight = 8U;
        private uint mElementPadding = 1U;

        private uint mScaleX = 1U;
        private uint mScaleY = 1U;
        private uint mRotate = 0U;
        private uint mMaxColumns = 1U;
        private bool mFlipX = false;
        private bool mFlipY = false;
        private bool mLimitColumns = false;

        private Color mGridColor = Color.FromArgb(255, 0, 0, 0);
        private Color mHighlightColor = Color.FromArgb(255, 255, 255, 0);

        private GfxElement[] mElements = new GfxElement[0];

        private IPalette mSelectedPalette;
        private BindingList<IPalette> mPalettes;
        private BindingSource mPalettesBindingSource;

        [DefaultValue(typeof(uint), "8")]
        public uint ElementWidth
        {
            get
            {
                return mElementWidth;
            }
            set
            {
                if (value != mElementWidth)
                {
                    mElementWidth = value;
                    RecomputeLayout();
                    Invalidate();
                }
            }
        }
        [DefaultValue(typeof(uint), "8")]
        public uint ElementHeight
        {
            get
            {
                return mElementHeight;
            }
            set
            {
                if (value != mElementHeight)
                {
                    mElementHeight = value;
                    RecomputeLayout();
                    Invalidate();
                }
            }
        }
        [DefaultValue(typeof(uint), "1")]
        public uint ElementPadding
        {
            get
            {
                return mElementPadding;
            }
            set
            {
                if (value != mElementPadding)
                {
                    mElementPadding = value;
                    RecomputeLayout();
                    Invalidate();
                }
            }
        }

        [DefaultValue(typeof(uint), "1")]
        public uint ScaleX
        {
            get
            {
                return mScaleX;
            }
            set
            {
                if (value != mScaleX)
                {
                    mScaleX = value;
                    RecomputeLayout();
                    Invalidate();
                }
            }
        }
        [DefaultValue(typeof(uint), "1")]
        public uint ScaleY
        {
            get
            {
                return mScaleY;
            }
            set
            {
                if (value != mScaleY)
                {
                    mScaleY = value;
                    RecomputeLayout();
                    Invalidate();
                }
            }
        }
        [DefaultValue(typeof(uint), "0")]
        public uint Rotate
        {
            get
            {
                return mRotate;
            }
            set
            {
                if (value != mRotate)
                {
                    mRotate = value;
                    RecomputeLayout();
                    Invalidate();
                }
            }
        }
        [DefaultValue(typeof(uint), "1")]
        public uint MaxColumns
        {
            get
            {
                return mMaxColumns;
            }
            set
            {
                if (value >= 1 && value != mMaxColumns)
                {
                    mMaxColumns = value;
                    RecomputeLayout();
                    Invalidate();
                }
            }
        }
        [DefaultValue(false)]
        public bool FlipX
        {
            get
            {
                return mFlipX;
            }
            set
            {
                mFlipX = value;
                Invalidate();
            }
        }
        [DefaultValue(false)]
        public bool FlipY
        {
            get
            {
                return mFlipY;
            }
            set
            {
                mFlipY = value;
                Invalidate();
            }
        }
        [DefaultValue(false)]
        public bool LimitColumns
        {
            get
            {
                return mLimitColumns;
            }
            set
            {
                if (mLimitColumns != value)
                {
                    mLimitColumns = value;
                    RecomputeLayout();
                    Invalidate();
                }
            }
        }

        public Color GridColor { get { return mGridColor; } set { mGridColor = value; Invalidate(); } }
        public Color HighlightColor { get { return mHighlightColor; } set { mHighlightColor = value; Invalidate(); } }

        public GfxElement[] Elements
        {
            get
            {
                return mElements;
            }
            set
            {
                mElements = value;
                RecomputeLayout();
                Invalidate();
            }
        }
        public IPalette SelectedPalette
        {
            get
            {
                return mSelectedPalette;
            }
            set
            {
                mSelectedPalette = value;
                Invalidate();
            }
        }

        public BindingList<IPalette> Palettes
        {
            get
            {
                return mPalettes;
            }
            set
            {
                mPalettes = value;
                Invalidate();
            }
        }

        public BindingSource PalettesBindingSource
        {
            get
            {
                return mPalettesBindingSource;
            }
            set
            {
                mPalettesBindingSource = value;
                if (mPalettesBindingSource != null) { mPalettesBindingSource.DataSource = mPalettes; }
            }
        }

        public uint ItemWidth { get { return (ScaleX * (((Rotate & 1U) != 0U) ? ElementHeight : ElementWidth)) + (2 * ElementPadding); } }
        private uint ItemHeight { get { return (ScaleY * (((Rotate & 1U) != 0U) ? ElementWidth : ElementHeight)) + (2 * ElementPadding); } }

        public ElementGridView()
        {
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.Clear(BackColor);
            Rectangle clip = e.ClipRectangle;
            clip.Offset(-AutoScrollPosition.X, -AutoScrollPosition.Y);
            e.Graphics.TranslateTransform(AutoScrollPosition.X, AutoScrollPosition.Y);

            int columns = mLimitColumns ? (mMaxColumns <= Elements.Length ? (int)mMaxColumns : Elements.Length) : (int)((AutoScrollMinSize.Width - (2 * ElementPadding)) / ItemWidth);
            int rows = (Elements.Length + columns - 1) / columns;
            int firstRow = (int)Math.Max(clip.Top / ItemHeight, 0);
            int lastRow = (int)Math.Min((clip.Bottom - 1 - (2 * ElementPadding)) / ItemHeight, rows - 1);
            int firstColumn = mLimitColumns ? 0 : (int)Math.Max(clip.Left / ItemWidth, 0);
            int lastColumn = mLimitColumns ? (int)mMaxColumns - 1 : (int)Math.Min((clip.Right - 1 - (2 * ElementPadding)) / ItemWidth, columns - 1);
            if (SelectedPalette != null)
            {
                bool swapAxes = (Rotate & 1U) != 0U;
                bool reverseX = FlipX != (((Rotate + 1U) & 2U) != 0U);
                bool reverseY = FlipY != ((Rotate & 2U) != 0U);
                int[,] transform = new int[,] { { swapAxes ? 0 : 1, swapAxes ? 1 : 0, 0 }, { swapAxes ? 1 : 0, swapAxes ? 0 : 1, 0 }, { 0, 0, 1 } };
                if (reverseX)
                {
                    transform[0, 0] = -transform[0, 0];
                    transform[0, 1] = -transform[0, 1];
                }
                if (reverseY)
                {
                    transform[1, 0] = -transform[1, 0];
                    transform[1, 1] = -transform[1, 1];
                }
                transform[0, 0] *= (int)ScaleX;
                transform[0, 1] *= (int)ScaleX;
                transform[1, 0] *= (int)ScaleY;
                transform[1, 1] *= (int)ScaleY;
                transform[1, 2] = (int)((ItemHeight * firstRow) + (2 * ElementPadding) + (reverseY ? (((swapAxes ? ElementWidth : ElementHeight) * ScaleY) - 1) : 0));
                for (int row = firstRow; row <= lastRow; row++, transform[1, 2] += (int)ItemHeight)
                {
                    transform[0, 2] = (int)((ItemWidth * firstColumn) + (2 * ElementPadding) + (reverseX ? (((swapAxes ? ElementHeight : ElementWidth) * ScaleX) - 1) : 0));
                    for (int column = firstColumn; (column <= lastColumn) && (((row * columns) + column) < Elements.Length); column++, transform[0, 2] += (int)ItemWidth)
                    {
                        GfxElement element = Elements[(row * columns) + column];
                        if (element != null)
                            element.Draw(e.Graphics, SelectedPalette, transform);
                    }
                }
            }
        }

        public void DrawExportTileset(Graphics graphics, long ElementsCount, long RowCount, long ColumnCount)
        {
            if (SelectedPalette == null)
                throw new Exception("Cannot export with null palette.");
            else
            {
                int rows = (int)RowCount;
                int columns = (int)ColumnCount;

                bool swapAxes = (Rotate & 1U) != 0U;
                bool reverseX = FlipX != (((Rotate + 1U) & 2U) != 0U);
                bool reverseY = FlipY != ((Rotate & 2U) != 0U);
                int[,] transform = new int[,] { { swapAxes ? 0 : 1, swapAxes ? 1 : 0, 0 }, { swapAxes ? 1 : 0, swapAxes ? 0 : 1, 0 }, { 0, 0, 1 } };
                if (reverseX)
                {
                    transform[0, 0] = -transform[0, 0];
                    transform[0, 1] = -transform[0, 1];
                }
                if (reverseY)
                {
                    transform[1, 0] = -transform[1, 0];
                    transform[1, 1] = -transform[1, 1];
                }
                transform[1, 2] = (int)(reverseY ? (swapAxes ? ElementWidth : ElementHeight) : 0);
                for (int row = 0; row <= rows; row++, transform[1, 2] += (swapAxes ? (int)ElementWidth : (int)ElementHeight))
                {
                    transform[0, 2] = (int)((ElementWidth * 0) + (reverseX ? (swapAxes ? ElementHeight : ElementWidth) : 0));
                    for (int column = 0; (column <= columns) && (((row * columns) + column) < Elements.Length); column++, transform[0, 2] += (swapAxes ? (int)ElementHeight : (int)ElementWidth))
                    {
                        GfxElement element = Elements[(row * columns) + column];
                        if (element != null)
                            element.Draw(graphics, SelectedPalette, transform);
                    }
                }
            }
        }

        public void DrawIndexedGif(Bitmap bitmap, uint[] mapData, uint mapWidth, uint mapHeight, uint tileWidth, uint tileHeight, uint offset, uint rotate, bool flipX, bool flipY)
        {
            
            int rows = (int)mapHeight;
            int columns = (int)mapWidth;
            bool swapAxes = (rotate & 1U) != 0U;
            bool reverseX = flipX != (((rotate + 1U) & 2U) != 0U);
            bool reverseY = flipY != ((rotate & 2U) != 0U);

            int[,] transform = new int[,] { { swapAxes ? 0 : 1, swapAxes ? 1 : 0, 0 }, { swapAxes ? 1 : 0, swapAxes ? 0 : 1, 0 }, { 0, 0, 1 } };
            if (reverseX)
            {
                transform[0, 0] = -transform[0, 0];
                transform[0, 1] = -transform[0, 1];
            }
            if (reverseY)
            {
                transform[1, 0] = -transform[1, 0];
                transform[1, 1] = -transform[1, 1];
            }

            transform[1, 2] = (int)(reverseY ? (swapAxes ? ElementWidth : ElementHeight) : 0);

            int StrideMultiplier = bitmap.Width;
            BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
            IntPtr ptr = bmpData.Scan0;
            byte[] pixels = new byte[bitmap.Width * bitmap.Height];
            System.Runtime.InteropServices.Marshal.Copy(ptr, pixels, 0, pixels.Length);

            for (int row = 0; row < rows; row++, transform[1, 2] += (swapAxes ? (int)ElementWidth : (int)ElementHeight))
            {
                transform[0, 2] = (int)(reverseX ? (swapAxes ? ElementHeight : ElementWidth) : 0);
                for (int column = 0; column < columns; column++)
                {
                    uint tileID = mapData[(row * columns) + column];

                    if (tileID == 0U)
                    {
                        // Fill blank tile
                        for(int y = 0 ; y < (swapAxes ? (int)ElementWidth : (int)ElementHeight); y++)
                        {
                            for(int x = 0; x < (swapAxes ? (int)ElementHeight : (int)ElementWidth); x++)
                            {
                                int pixelDest = (row * (((int)ElementWidth * (int)ElementHeight) * columns))
                                              + (column * (swapAxes ? (int)ElementHeight : (int)ElementWidth))
                                              + (y * StrideMultiplier)
                                              + x;
                                pixels[pixelDest] = 0xFF;
                            }
                        }
                    }
                    else
                    {
                        tileID -= 1U;
                        GfxElement element = Elements[tileID];
                        if (element != null)
                            element.DrawIndexed(pixels, transform, StrideMultiplier, column * (swapAxes ? (int)ElementHeight : (int)ElementWidth));
                    }
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptr, pixels.Length);
            bitmap.UnlockBits(bmpData);
        }

        /*  Transform layout:
         *       
         *       0,0    X pixel offset
         *       0,1    X scale
         *       0,2    rowstart X
         *       
         *       1,0    Y pixel offset
         *       1,1    Y scale
         *       1,2    rowstart Y
         */

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            bool needRedraw = RecomputeLayout();
            base.OnSizeChanged(e);
            if (needRedraw)
                Invalidate();
        }

        private bool RecomputeLayout()
        {
            int columns = (int)Math.Max(1, (Size.Width - (2 * ElementPadding)) / ItemWidth);
            int rows = (((Elements != null) ? Elements.Length : 0) + columns - 1) / columns;
            if (((ItemHeight * rows) + (2 * ElementPadding)) > Size.Height)
            {
                columns = mLimitColumns ? (int)mMaxColumns : (int)Math.Max(1, (Size.Width - SystemInformation.VerticalScrollBarWidth - (2 * ElementPadding)) / ItemWidth);
                rows = (((Elements != null) ? Elements.Length : 0) + columns - 1) / columns;
            }
            int desiredWidth = (int)((columns * ItemWidth) + (2 * ElementPadding));
            int desiredHeight = (int)((rows * ItemHeight) + (2 * ElementPadding));
            if ((desiredWidth != AutoScrollMinSize.Width) || (desiredHeight != AutoScrollMinSize.Height))
            {
                AutoScrollMinSize = new Size(desiredWidth, desiredHeight);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
