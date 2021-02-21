using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Porno_Graphic.Classes
{
    [Serializable()]
    [XmlRoot(ElementName = "map")]
    public class TiledMapReader
    {
        [Serializable()]
        public class TilesetSource
        {
            [XmlAttribute("source")]
            public string Source { get; set; }
        }
        [Serializable]
        public class MapData
        {
            [XmlElement(ElementName = "data")]
            public String Data { get; set; }
        }

        [XmlElement(ElementName = "layer", Form = XmlSchemaForm.Unqualified)]
        public MapData mapData { get; set; }

        [XmlAttribute("width")]
        public string mapWidth { get; set; }

        [XmlAttribute("height")]
        public string mapHeight { get; set; }

        [XmlElement("tileset")]
        public TilesetSource TilesetName { get; set; }

        public string TilesetFilename { get { return TilesetName.Source; } }
        public uint MapWidth { get
            {
                uint width;
                if (uint.TryParse(mapWidth, out width))
                    return width;
                else
                    return 0U;
            } }
        public uint MapHeight
        {
            get
            {
                uint height;
                if (uint.TryParse(mapHeight, out height))
                    return height;
                else
                    return 0U;
            }
        }
        public string MapDataRawString { get { return mapData.Data; } }
        public uint[] MapDataArray { get
            {
                uint[] data = new uint[MapWidth * MapHeight];
                string[] substrings = MapDataRawString.Split(',');

                for (int n = 0; n < data.Length; n++)
                {
                    if (uint.TryParse(substrings[n], out data[n]) == false)
                        throw new Exception("Could not parse map data.");
                }
                return data;

            } }
    }
}
