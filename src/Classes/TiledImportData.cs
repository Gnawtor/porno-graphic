using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Porno_Graphic.Classes
{
    public class TiledImportData
    {
        public TileViewer mTileViewer { get; private set; }
		public TiledMapReader mMap { get; private set; }
		public TiledTilesetReader mTileset { get; private set; }
		public uint mMapWidth { get; private set; }
		public uint mMapHeight { get; private set; }
		public uint[] mMapData { get; private set; }
		public uint mTileWidth { get; private set; }
		public uint mTileHeight { get; private set; }
		public uint mTileCount { get; private set; }
		public uint mOffset { get; private set; }
		public uint mColumns { get; private set; }
		public uint mRotate { get; private set; }
		public bool mFlipX { get; private set; }
		public bool mFlipY { get; private set; }

		public TiledImportData(TileViewer tileViewer, TiledMapReader map, TiledTilesetReader tileset)
		{
			mTileViewer = tileViewer;
			mMap = map;
			mTileset = tileset;
			mMapData = mMap.MapDataArray;

			mMapWidth = map.MapWidth;
			mMapHeight = map.MapHeight;
			uint temp;

			if (uint.TryParse(mTileset.TileWidth, out temp))
			{
				mTileWidth = temp;
			}
			else
            {
				MessageBox.Show("Cannot parse TileWidth in Tileset " + mMap.TilesetName);
				return; 
            }

			if (uint.TryParse(mTileset.TileHeight, out temp))
			{
				mTileHeight = temp;
			}
			else
			{ 
				MessageBox.Show("Cannot parse TileHeight in Tileset " + mMap.TilesetName);
				return;
			}

			if (uint.TryParse(mTileset.TileCount, out temp))
			{
				mTileCount = temp;
			}
			else
			{ 			
				MessageBox.Show("Cannot parse TileCount in Tileset " + mMap.TilesetName);
				return;
			}

			if (uint.TryParse(mTileset.Offset, out temp))
			{
				mOffset = temp;
			}
			else
			{ 
				MessageBox.Show("Cannot parse Offset in Tileset " + mMap.TilesetName);
				return;
			}

			if (uint.TryParse(mTileset.Columns, out temp))
			{
				mColumns = temp;
			}
			else
			{ 
				MessageBox.Show("Cannot parse Columns in Tileset " + mMap.TilesetName);
				return;
			}

			if (uint.TryParse(mTileset.Rotate, out temp))
			{
				mRotate = temp;
			}
			else
			{ 
				MessageBox.Show("Cannot parse Rotate in Tileset " + mMap.TilesetName);
				return;
			}
		}
	}
}
