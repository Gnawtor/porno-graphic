using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Porno_Graphic
{
    public partial class PaletteEditor : Form
    {
        private Classes.IPalette mPalette;

        public Classes.IPalette Palette
        {
            get
            {
                return mPalette;
            }
            set
            { 
                mPalette = value;
            }
        }
        public PaletteEditor(Classes.IPalette palette) : base()
        {
            InitializeComponent();
            Palette = palette;
            paletteGrid.InitializePalette(Palette);
            textBoxName.Text = Palette.Name;
            btnOk.Click += btnOk_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Palette.Name = textBoxName.Text;
            Color[] editedColors = paletteGrid.GetColors;
            for (uint i = 0; i < Palette.GetColorCount(); i++)
            {
                Palette.SetColor(editedColors[i] , i);
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
