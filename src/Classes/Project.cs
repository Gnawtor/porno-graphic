using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Porno_Graphic.Classes
{
    public class Project
    {
        private bool mDirty;
        private GfxElementSet mGfxSet = null;
        private string mFilePath = null;

        public string DisplayName { get { return mGfxSet.Name; } set { mGfxSet.Name = value; } }
        public bool Dirty { get { return mDirty; } }
        public string FilePath { get { return mFilePath; } set { mFilePath = value; } }
        public uint Offset { get { return mGfxSet.Offset; } }
        public TileImportMetadata ImportMetadata { get { return mGfxSet.ImportMetadata; } }

        public Project(GfxElementSet gfxSet)
        {
            mDirty = true;
            mGfxSet = gfxSet;
        }

        public void SetDirty()
        {
            mDirty = true;
        }

        public void ClearDirty()
        {
            mDirty = false;
        }

        public void Save(string path)
        {
            ChunkWriter writer = new ChunkWriter(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write));
            using (writer)
            {
                writer.OpenChunk(ChunkType.ProjectHeader, 0U);  // Write project header
                writer.CloseChunk();
                writer.StartCompression();
                if ((mGfxSet != null) && ((mGfxSet.Elements != null) || (mGfxSet.ImportMetadata != null)))  // Write everything else in this project
                    mGfxSet.Write(writer);
            }
            mDirty = false;
            mFilePath = path;
        }
    }
}
