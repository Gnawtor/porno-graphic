using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Porno_Graphic.Classes
{
    class TiledLoader
    {
        private TiledMapReader mMap { get; set; }
        private TiledTilesetReader mTileset { get; set; }

        public TiledLoader(string fileName)
            {
			StreamReader reader = null;
			try
			{
				reader = new StreamReader(fileName);
				XmlSerializer MapLoader = new XmlSerializer(typeof(Classes.TiledMapReader));
				mMap = (Classes.TiledMapReader)MapLoader.Deserialize(reader);
			}
			catch
			{
			}
			finally
			{
				if (reader != null)
					reader.Close();
			}

			if (mMap == null)
			{
				// TODO more meaningful error message
				MessageBox.Show("Map is null", "ERROR");
				return;
			}

			/*
			//DEBUG
			MessageBox.Show(
				"Height: " + Map.mapHeight + Environment.NewLine + 
				"Width: " + Map.mapWidth + Environment.NewLine +
				"Tileset: " + Map.TilesetFilename + Environment.NewLine +
				"Map data: " + Map.MapDataRawString, 
				"Map Info");
			//END DEBUG
			*/

			string TilesetPath = Path.GetDirectoryName(fileName) + "\\" + mMap.TilesetFilename;

			//MessageBox.Show(TilesetPath);

			reader = null;
			
			try
			{
				reader = new StreamReader(TilesetPath);
				XmlSerializer TilesetLoader = new XmlSerializer(typeof(Classes.TiledTilesetReader));
				mTileset = (Classes.TiledTilesetReader)TilesetLoader.Deserialize(reader);
			}
			catch
			{
			}
			finally
			{
				if (reader != null)
					reader.Close();
			}

			if (mTileset == null)
			{
				// TODO more meaningful error message
				MessageBox.Show("Tileset is null", "ERROR");
				return;
			}
		}
		public TiledMapReader Map { get { return mMap; } }
		public TiledTilesetReader Tileset { get { return mTileset; } }
    }
}
