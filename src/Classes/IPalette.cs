using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Porno_Graphic.Classes
{
    public interface IPalette
    {
        Color GetColor(uint pen);
        void SetColor(Color color, uint pen);
        Brush GetBrush(uint pen);
        uint GetColorCount();
        string Name { get; set; }
        void Write(ChunkWriter writer);
        uint ChunkSize();
    }
}
