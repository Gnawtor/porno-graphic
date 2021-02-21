using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Porno_Graphic.Classes
{
    [Serializable()]
    [XmlRoot(ElementName = "tileset")]
    public class TiledTilesetReader
    {
        [XmlAttribute("tilewidth")]
        public string TileWidth { get; set; }

        [XmlAttribute("tileheight")]
        public string TileHeight { get; set; }

        [XmlAttribute("tilecount")]
        public string TileCount { get; set; }

        [XmlAttribute("columns")]
        public string Columns { get; set; }

        [XmlAttribute("offset")]
        public string Offset { get; set; }

        [XmlAttribute("flipx")]
        public string FlipX { get; set; }

        [XmlAttribute("flipy")]
        public string FlipY { get; set; }

        [XmlAttribute("rotate")]
        public string Rotate { get; set; }
    }
}