using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Porno_Graphic.Classes
{
    public class GifReader
    {
        protected class TileInfo
        {
            public uint TiledMapOffset { get; private set; }
            public uint ElementOffset { get; private set; }
            public TileInfo(uint tiledMapOffset, uint elementOffset)
            {
                TiledMapOffset = tiledMapOffset;
                ElementOffset = elementOffset;
            }
        }

        public GifReader(string path, TiledImportData tiledData)
        {
            // Get all pixel data from imported GIF
            Bitmap Gif = new Bitmap(path);
            BitmapData bmpData = Gif.LockBits(new Rectangle(0, 0, Gif.Width, Gif.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            IntPtr ptr = bmpData.Scan0;
            byte[] gifPixels = new byte[Gif.Width * Gif.Height];
            System.Runtime.InteropServices.Marshal.Copy(ptr, gifPixels, 0, gifPixels.Length);

            uint[] mapData = tiledData.mMapData;
            int rows = (int)tiledData.mMapHeight;
            int columns = (int)tiledData.mMapWidth;
            int gifTileWidth = (int)tiledData.mTileWidth;
            int gifTileHeight = (int)tiledData.mTileHeight;
            int tileWidth = (int)tiledData.mTileViewer.ElementWidth;
            int tileHeight = (int)tiledData.mTileViewer.ElementHeight;
            bool swapAxes = (tiledData.mRotate & 1U) != 0;
            bool reverseX = tiledData.mFlipX != (((tiledData.mRotate + 1U) & 2U) != 0U);
            bool reverseY = tiledData.mFlipY != ((tiledData.mRotate & 2U) != 0U);

            //Get a list of all non-blank tiles in the map
            // TODO: Ensure no tile IDs in the map exceed the length of the project tiles

            List<TileInfo> tileBuffer = new List<TileInfo>();

            // filter out blank tiles
            for(int n = 0; n < (rows * columns); n++)
            {
                if (mapData[n] != 0)
                    tileBuffer.Add(new TileInfo((uint)n, (mapData[n] - 1)));
            }

            // Check that there are no duplicate tiles in the Tiled map
            var tileDuplicates = tileBuffer
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => y.Key)
                .ToList();

            if (tileDuplicates.Count != 0)
            {
                // Duplicate tiles found in map. 
                string duplicateString = "";
                foreach (TileInfo duplicate in tileDuplicates)
                {
                    duplicateString = duplicateString + Environment.NewLine + duplicate.ElementOffset;
                }

                MessageBox.Show((tileDuplicates.Count > 1 ? "Duplicate tile IDs found in map:" : "Duplicate tile ID found in map:") + Environment.NewLine + duplicateString, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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

            transform[1, 2] = (int)(reverseY ? (swapAxes ? tileWidth : tileHeight) : 0);

            foreach (TileInfo tile in tileBuffer)
            {
                Rectangle rowStart = new Rectangle(
                    transform[0, 2], 
                    transform[1, 2], 
                    transform[0, 0] + transform[0, 1], 
                    transform[1, 0] + transform[1, 1]);

                if (rowStart.Width < 0)
                {
                    rowStart.X += rowStart.Width;
                    rowStart.Width = -rowStart.Width;
                }

                if (rowStart.Height < 0)
                {
                    rowStart.Y += rowStart.Height;
                    rowStart.Height = -rowStart.Height;
                }

                Point yStep = new Point(transform[0, 1], transform[1, 1]);
                Point xStep = new Point(transform[0, 0], transform[1, 0]);
                for (uint y = 0; y < tileHeight; y++, rowStart.Offset(yStep))
                {
                    Rectangle pixel = rowStart;
                    for (uint x = 0; x < tileWidth; x++, pixel.Offset(xStep))
                    {
                        uint pixelValue = gifPixels[
                            ((Gif.Width * gifTileHeight) * (tile.TiledMapOffset / columns))
                            + (gifTileWidth * (tile.TiledMapOffset % columns))
                            + (pixel.Y * Gif.Width)
                            + pixel.X];
                        tiledData.mTileViewer.Elements[tile.ElementOffset].SetPixel(pixelValue, x, y);
                    }
                }
            }
            tiledData.mTileViewer.RedrawElementView();
        }
    }
}
