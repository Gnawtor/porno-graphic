using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Porno_Graphic.Classes
{
    public class IndexedPalette : SolidPalette
    {
        public IndexedPalette(uint planes, string name)
        {
            mName = name;

            int paletteLength = 1 << (int)planes;
            Colors = new Color[paletteLength];

            for (uint i = 0; i < Colors.Length; i++)
            {
                int intensity = (int)(((paletteLength - 1) - i) * (256 / (paletteLength - 1)));
                Colors[i] = Color.FromArgb(intensity, intensity, intensity);
            }
        }

        public IndexedPalette(IPalette sourcePalette)
        {
            mName = sourcePalette.GetName() + " (Copy)";
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

        public override string GetName()
        {
            return mName;
        }

        public override void SetName(string name)
        {
            mName = name;
        }

        public override string ToString()
        {
            return mName;
        }
    }
}
