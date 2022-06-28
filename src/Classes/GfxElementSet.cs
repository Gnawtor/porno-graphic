using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;

/*      This class contains all data that is saved to a project file.      */

namespace Porno_Graphic.Classes
{
    public class GfxElementSet
    {
        public string Name { get; set; }
        public uint ElementWidth { get; set; }
        public uint ElementHeight { get; set; }
        public uint Planes { get; set; }
        public GfxElement[] Elements { get; set; }
        public TileImportMetadata ImportMetadata { get; set; }
        public BindingList<IPalette> Palettes { get; set; }
        public uint Offset
        {
            get
            {
                uint offset;
                if (uint.TryParse(ImportMetadata.Offset, System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.CurrentCulture, out offset))
                { return offset; }
                else
                { return 0; }
            }
        }

        public void Write(ChunkWriter writer)
        {
            ulong infoChunkLength = (ulong)((2U * 4U) + 4U + ((Name != null) ? Encoding.BigEndianUnicode.GetByteCount(Name) : 0));
            ulong total = 16U + infoChunkLength;
            if (Elements != null)
            {
                foreach (GfxElement element in Elements)
                    total += element.ChunkSize();
            }
            if (Palettes != null)
            {
                foreach (IPalette palette in Palettes)
                    total += palette.ChunkSize();
            }
            if (ImportMetadata != null)
                total += ImportMetadata.ChunkSize();
            writer.OpenChunk(ChunkType.GfxElementSet, total);
            writer.OpenChunk(ChunkType.GfxElementSetInfo, infoChunkLength);
            writer.Write(ElementWidth);
            writer.Write(ElementHeight);
            writer.Write(Name);
            writer.CloseChunk();
            if (Elements != null)
            {
                foreach (GfxElement element in Elements)
                    element.Write(writer);
            }
            if (Palettes != null)
            {
                foreach (IPalette palette in Palettes)
                    palette.Write(writer);
            }
            if (ImportMetadata != null)
                ImportMetadata.Write(writer);
            writer.CloseChunk();
        }

        public void DrawBitmap(Graphics gfx, int TilesPerRow)
        {

        }
    }
}
