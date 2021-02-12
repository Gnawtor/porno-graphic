using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Porno_Graphic.Classes
{
    public class ChunkReader : ChunkIOBase
    {
        private bool mDecompressing;

        public ChunkReader(Stream stream) : base(stream)
        {
            mDecompressing = false;
        }

        public ChunkType ReadChunkHeader()
        {
            if (mOpenChunks.Count() > 0)
                mOpenChunks.Peek().SetContainsSubChunks();
            byte[] buffer = new byte[8];

            int count = mStream.Read(buffer, 0, 8);     // Get ChunkType from header
            if (count != 8)
                throw new Exception(string.Format("Need 8 bytes but only got {0}", count));
            if (BitConverter.IsLittleEndian)
                buffer.Reverse();
            ChunkType type = (ChunkType)BitConverter.ToUInt64(buffer, 0);
            count = mStream.Read(buffer, 0, 8);     // Get length from header
            if (count != 8)
                throw new Exception(string.Format("Need 8 bytes but only got {0}", count));
            if (BitConverter.IsLittleEndian)
                buffer.Reverse();
            ulong length = BitConverter.ToUInt64(buffer, 0);
            if (mOpenChunks.Count() > 0)
                mOpenChunks.Peek().Consume(16U + length);
            mOpenChunks.Push(new ChunkInfo(type, length));
            return type;
        }

        public ushort ReadUshort()
        {
            if (mOpenChunks.Count <= 0)
                throw new Exception("Attempt to read data with no chunk open");
            mOpenChunks.Peek().Consume(4);
            byte[] bytes = new byte[2];
            int count = mStream.Read(bytes, 0, 2);
            if (count != 2)
                throw new Exception(string.Format("Need 2 bytes but only got {0}", count));
            if (BitConverter.IsLittleEndian)
                bytes.Reverse();
            return (ushort)(BitConverter.ToInt32(bytes, 0) & 0xFFFF);
        }

        public uint ReadUint()
        {
            if (mOpenChunks.Count <= 0)
                throw new Exception("Attempt to read data with no chunk open");
            mOpenChunks.Peek().Consume(4);
            byte[] bytes = new byte[4];
            int count = mStream.Read(bytes, 0, 4);
            if (count != 4)
                throw new Exception(string.Format("Need 4 bytes but only got {0}", count));
            if (BitConverter.IsLittleEndian)
                bytes.Reverse();
            return BitConverter.ToUInt32(bytes, 0);
        }

        /*
        public byte[] ReadChunkData()   // Returns all data from a chunk
        {
            ChunkInfo current = mOpenChunks.Peek();
            byte[] data = new byte[current.Length];
            int count = mStream.Read(data, 0, (int)current.Length);
            if (count != (int)current.Length)
                throw new Exception(string.Format("Need {0} bytes but only got {1}", (int)current.Length, count));
            mOpenChunks.Pop();
            return data;
        }
        */

        public string ReadString()
        {
            if (mOpenChunks.Count <= 0)
                throw new Exception("Attempt to read data with no chunk open");
            mOpenChunks.Peek().Consume(4);
            byte[] bytes = new byte[4];
            int count = mStream.Read(bytes, 0, 4);  // read string length
            if (count != 4)
                throw new Exception(string.Format("Need 4 bytes but only got {0}", count));
            if (BitConverter.IsLittleEndian)
                bytes.Reverse();
            int StringLength = BitConverter.ToInt32(bytes, 0);
            mOpenChunks.Peek().Consume((ulong)StringLength);
            bytes = new byte[StringLength];
            count = mStream.Read(bytes, 0, StringLength);  // read string
            if (count != StringLength)
                throw new Exception(string.Format("Need {0} bytes but only got {1}", StringLength, count));
            if (BitConverter.IsLittleEndian)
                bytes.Reverse();
            return Encoding.BigEndianUnicode.GetString(bytes);
        }

        public ulong GetCurrentLength()
        {
            return mOpenChunks.Peek().Length;
        }

        public void CloseChunk()
        {
            if (mOpenChunks.Count <= 0)
                throw new Exception("Attempt to close chunk with no chunks open");
            ChunkInfo current = mOpenChunks.Peek();
            if (current.Remaining > 0U)
                throw new Exception(string.Format("Attempt to close incomplete chunk ({0} of {1} bytes still needed)", current.Remaining, current.Length));
            mOpenChunks.Pop();
        }

        public void AbortChunk()
        {
            if (mOpenChunks.Count <= 0)
                throw new Exception("Attempt to close chunk with no chunks open");
            mOpenChunks.Pop();
        }

        public byte[] ReadProjectContents()     // Hacky method of opening a project file. Only call this if a project header was read.
        {
            using (var MemStream = new MemoryStream())
            {
                mStream.CopyTo(MemStream);
                return MemStream.ToArray();
            }
        }

        public void SkipRemainingChunk()
        {
            ChunkInfo current = mOpenChunks.Peek();
            byte[] buffer = new byte[256];
            while (current.Remaining > 0)
            {
                int block = (int)Math.Min(current.Remaining, 256U);
                int count = mStream.Read(buffer, 0, block);
                if (count != block)
                    throw new Exception(string.Format("Need {0} bytes but only got {0}", block, count));
                current.Consume((ulong)count);
            }
            mOpenChunks.Pop();
        }

        public void StartDecompression()
        {
            if (mDecompressing)
                throw new Exception("Attempt to start decompression while already decompressing");
            if (mOpenChunks.Count() > 0)
                throw new Exception("Attempt to start decompression partway through chunk");
            mStream = new DeflateStream(mStream, CompressionMode.Decompress);
            mDecompressing = true;
        }
    }
}
