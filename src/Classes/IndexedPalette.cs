using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Porno_Graphic.Classes
{
    public class IndexedPalette : SolidPalette
    {
        public IndexedPalette(uint colorCount, string name)
        {
            mName = name;

            Colors = new Color[colorCount];

            for (uint i = 0; i < Colors.Length; i++)
            {
                int intensity = (int)(((colorCount - 1) - i) * (256 / (colorCount - 1)));
                Colors[i] = Color.FromArgb(intensity, intensity, intensity);
            }
        }

        public IndexedPalette(IPalette sourcePalette)
        {
            mName = sourcePalette.Name + " (Copy)";
            uint colorCount = sourcePalette.GetColorCount();
            Colors = new Color[colorCount];
            for (uint i = 0; i < colorCount; i++)
            {
                Color sourceColor = sourcePalette.GetColor(i);
                Colors[i] = Color.FromArgb(sourceColor.R, sourceColor.G, sourceColor.B);
            }
        }

        private Color[] mColors;
        private string mName;

        public Color[] Colors
        {
            get
            {
                return mColors;
            }
            set
            {
                mColors = value;
                ClearCache();
            }
        }

        public uint ColorCount
        {
            get
            {
                return (uint)mColors.Length;
            }
        }

        public override Color GetColor(uint pen)
        {
            return mColors[pen % Colors.Length];
        }

        public override void SetColor (Color color, uint pen)
        {
            pen = (uint)(pen % Colors.Length);
            mColors[pen] = color;
            ClearCache();
        }

        public override uint GetColorCount()
        {
            return (uint)mColors.Length;
        }

        protected override uint GetEffectivePen(uint pen)
        {
            return (uint)(pen % Colors.Length);
        }

        public override string Name
        {
            get
            {
                return mName;
            }
            set
            {
                mName = value;
            }
        }
        public override void Write(ChunkWriter writer)
        {
            writer.OpenChunk(ChunkType.IndexedPalette, (uint)Encoding.BigEndianUnicode.GetByteCount(Name) + 4U + 4U + (12U * GetColorCount()));
            writer.Write(Name);
            writer.Write(GetColorCount());
            for (int i = 0; i < GetColorCount(); i++)
            {
                writer.Write((uint)Colors[i].R);
                writer.Write((uint)Colors[i].G);
                writer.Write((uint)Colors[i].B);
            }
            writer.CloseChunk();
        }

        public override uint ChunkSize()
        {
            return 16U + (uint)Encoding.BigEndianUnicode.GetByteCount(Name) + 4U + 4U + (12U * GetColorCount());
        }
    }
}
