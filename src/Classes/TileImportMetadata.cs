using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Porno_Graphic.Classes
{
    public class TileImportMetadata
    {
        public string ProfileFile { get; set; }
        public string ProfileName { get; set; }
        public string RegionName { get; set; }
        public string LayoutName { get; set; }
        public string Offset { get; set; }
        public string Planes { get; set; }
        public string[] RomFilenames { get; set; }

        public void Write(ChunkWriter writer)
        {
            writer.OpenChunk(ChunkType.TileImportMetadata, ChunkContentLength());
            writer.Write(ProfileFile);
            writer.Write(ProfileName);
            writer.Write(RegionName);
            writer.Write(LayoutName);
            writer.Write(Offset);
            writer.Write(Planes);

            writer.Write(RomFilenames.Length);  // file path count

            foreach (String fileName in RomFilenames)
            {
                writer.Write(fileName);
            }

            writer.CloseChunk();
        }

        public ulong ChunkSize()
        {
            return 16U + ChunkContentLength();
        }

        private ulong ChunkContentLength()
        {
            uint RomFilenamesLength = 4U;

            foreach (string fileName in RomFilenames)
            {
                RomFilenamesLength += (uint)Encoding.BigEndianUnicode.GetByteCount(fileName);
            }

            RomFilenamesLength += (uint)(RomFilenames.Length * 4U);
            
            return (ulong)((6U * 4U)
                + ((ProfileFile != null) ? Encoding.BigEndianUnicode.GetByteCount(ProfileFile) : 0)
                + ((ProfileName != null) ? Encoding.BigEndianUnicode.GetByteCount(ProfileName) : 0)
                + ((RegionName != null) ? Encoding.BigEndianUnicode.GetByteCount(RegionName) : 0)
                + ((LayoutName != null) ? Encoding.BigEndianUnicode.GetByteCount(LayoutName) : 0)
                + ((Offset != null) ? Encoding.BigEndianUnicode.GetByteCount(Offset) : 0)
                + ((Planes != null) ? Encoding.BigEndianUnicode.GetByteCount(Planes) : 0)
                + RomFilenamesLength);
        }
    }
}
