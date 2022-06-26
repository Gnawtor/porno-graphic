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
        string GetName();
        void SetName(string name);
    }
}
