﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Porno_Graphic.Classes
{
    class GifWriter
    {
        public TiledImportData mTiledData { get; private set; }

        public GifWriter(TiledImportData tiledImportData)
        {
            mTiledData = tiledImportData;
		}

        public void DrawIndexedGif(string path)
        {
            Bitmap bitmap = new Bitmap((int)(mTiledData.mMapWidth * mTiledData.mTileWidth), (int)(mTiledData.mMapHeight * mTiledData.mTileHeight), PixelFormat.Format8bppIndexed);

            mTiledData.mTileViewer.DrawIndexedGif(bitmap, mTiledData.mMapData, mTiledData.mMapWidth, mTiledData.mMapHeight, mTiledData.mTileWidth, mTiledData.mTileHeight, mTiledData.mOffset, mTiledData.mRotate, mTiledData.mFlipX, mTiledData.mFlipY);

            ColorPalette colorPalette = bitmap.Palette;
            uint paletteLength = mTiledData.mTileViewer.Palette.GetLength();

            for (int n = 0; n < paletteLength; n++)
            {
                colorPalette.Entries[n] = mTiledData.mTileViewer.Palette.GetColor((uint)n);
            }
            colorPalette.Entries[255] = Color.Gray; // Blank tile color

            bitmap.Palette = colorPalette;

            bitmap.Save(path, ImageFormat.Gif);
            bitmap.Dispose();
        }
        
    }
}
