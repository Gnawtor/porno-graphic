﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Porno_Graphic.Classes
{
    public class ChunkWriter : IDisposable
    {
        private class ChunkInfo
        {
            public ChunkType Type { get; private set; }
            public ulong Length { get; private set; }
            public ulong Remaining { get; private set; }
            public bool ContainsSubChunks { get; private set; }

            public ChunkInfo(ChunkType type, ulong length)
            {
                Type = type;
                Length = length;
                Remaining = length;
                ContainsSubChunks = false;
            }

            public void Consume(ulong size)
            {
                if (Remaining < size)
                    throw new Exception(string.Format("Attempt to consume {0} bytes from chunk with {1} bytes remaining", size, Remaining));
                Remaining -= size;
            }

            public void SetContainsSubChunks()
            {
                if (!ContainsSubChunks)
                {
                    if (Remaining < Length)
                        throw new Exception(string.Format("Attempt to add subchunks to chunk containing {0} bytes of raw data", Length - Remaining));
                    ContainsSubChunks = true;
                }
            }
        };

        private bool mCompressing;
        private Stream mStream;
        private Stack<ChunkInfo> mOpenChunks;

        public ChunkWriter(Stream stream)
        {
            mCompressing = false;
            mStream = stream;
            mOpenChunks = new Stack<ChunkInfo>();
        }

        public void OpenChunk(ChunkType type, ulong length)
        {
            if (mOpenChunks.Count() > 0)
            {
                ChunkInfo current = mOpenChunks.Peek();
                current.SetContainsSubChunks();
                current.Consume(length + 16);
            }
            mOpenChunks.Push(new ChunkInfo(type, length));
            byte[] bytes;
            bytes = BitConverter.GetBytes((ulong)type);
            if (BitConverter.IsLittleEndian)
                bytes.Reverse();
            mStream.Write(bytes, 0, 8);
            bytes = BitConverter.GetBytes(length);
            if (BitConverter.IsLittleEndian)
                bytes.Reverse();
            mStream.Write(bytes, 0, 8);
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

        public void Write(sbyte value)
        {
            if (mOpenChunks.Count <= 0)
                throw new Exception("Attempt to write data with no chunk open");
            mOpenChunks.Peek().Consume(1);
            mStream.WriteByte(unchecked((byte)value));
        }

        public void Write(byte value)
        {
            if (mOpenChunks.Count <= 0)
                throw new Exception("Attempt to write data with no chunk open");
            mOpenChunks.Peek().Consume(1);
            mStream.WriteByte(value);
        }

        public void Write(short value)
        {
            if (mOpenChunks.Count <= 0)
                throw new Exception("Attempt to write data with no chunk open");
            mOpenChunks.Peek().Consume(2);
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                bytes.Reverse();
            mStream.Write(bytes, 0, 2);
        }

        public void Write(ushort value)
        {
            if (mOpenChunks.Count <= 0)
                throw new Exception("Attempt to write data with no chunk open");
            mOpenChunks.Peek().Consume(2);
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                bytes.Reverse();
            mStream.Write(bytes, 0, 2);
        }

        public void Write(int value)
        {
            if (mOpenChunks.Count <= 0)
                throw new Exception("Attempt to write data with no chunk open");
            mOpenChunks.Peek().Consume(4);
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                bytes.Reverse();
            mStream.Write(bytes, 0, 4);
        }

        public void Write(uint value)
        {
            if (mOpenChunks.Count <= 0)
                throw new Exception("Attempt to write data with no chunk open");
            mOpenChunks.Peek().Consume(4);
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                bytes.Reverse();
            mStream.Write(bytes, 0, 4);
        }

        public void Write(long value)
        {
            if (mOpenChunks.Count <= 0)
                throw new Exception("Attempt to write data with no chunk open");
            mOpenChunks.Peek().Consume(8);
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                bytes.Reverse();
            mStream.Write(bytes, 0, 8);
        }

        public void Write(ulong value)
        {
            if (mOpenChunks.Count <= 0)
                throw new Exception("Attempt to write data with no chunk open");
            mOpenChunks.Peek().Consume(8);
            byte[] bytes = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian)
                bytes.Reverse();
            mStream.Write(bytes, 0, 8);
        }

        public void Write(string value)
        {
            if (value != null)
            {
                if (mOpenChunks.Count <= 0)
                    throw new Exception("Attempt to write data with no chunk open");
                byte[] bytes = Encoding.BigEndianUnicode.GetBytes(value);
                mOpenChunks.Peek().Consume((ulong)(4U + bytes.Length));
                byte[] lengthBytes = BitConverter.GetBytes(bytes.Length);
                if (BitConverter.IsLittleEndian)
                    bytes.Reverse();
                mStream.Write(lengthBytes, 0, 4);
                mStream.Write(bytes, 0, bytes.Length);
            }
            else
            {
                Write(0);
            }
        }

        public void StartCompression()
        {
            if (mCompressing)
                throw new Exception("Attempt to start compression while already compressing");
            if (mOpenChunks.Count() > 0)
                throw new Exception("Attempt to start compression partway through chunk");
            mStream = new DeflateStream(mStream, CompressionMode.Compress);
            mCompressing = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (mStream != null)
                    mStream.Dispose();
            }
        }
    }
}
