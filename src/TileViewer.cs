/*
 * TileViewer - The interface for viewing and selecting tiles.
 * Handles most of the heavy lifting that isn't related to editing.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Porno_Graphic
{
	public partial class TileViewer : Form
	{
        private uint mPlanes;
        public uint ElementWidth { get { return tileGrid.ElementWidth; } set { tileGrid.ElementWidth = value; } }
        public uint ElementHeight { get { return tileGrid.ElementHeight; } set { tileGrid.ElementHeight = value; } }
        public Classes.GfxElement[] Elements { get { return tileGrid.Elements; } set { tileGrid.Elements = value; } }
        public Classes.IPalette SelectedPalette 
        { 
            get 
            { 
                return tileGrid.SelectedPalette; 
            } 
            set 
            { 
                tileGrid.SelectedPalette = value; 
                paletteBar.Palette = value; 
            } 
        }
        public BindingList<Classes.IPalette> Palettes { get { return tileGrid.Palettes; } set { tileGrid.Palettes = value; paletteBar.Invalidate(); } }
        public BindingSource PalettesBindingSource { 
            get { return tileGrid.PalettesBindingSource; } 
            set 
            { 
                tileGrid.PalettesBindingSource = value; 
                comboPalettes.DataSource = PalettesBindingSource;
            } }
        public bool SwapAxes { get { return (rotate.SelectedIndex & 1U) != 0U; } }
        public uint ColumnCount { get { return (uint)((tileGrid.AutoScrollMinSize.Width - (2 * tileGrid.ElementPadding)) / tileGrid.ItemWidth);} }
        public bool FlipX { get { return xFlip.Checked; } }
        public bool FlipY { get { return yFlip.Checked; } }
        public uint Rotate { get { return (uint)rotate.SelectedIndex; } }
        public uint Planes { get { return mPlanes; } set { mPlanes = value; } }

		public TileViewer() 
        {
			InitializeComponent();
            rotate.SelectedIndex = 0;

            comboPalettes.SelectedIndexChanged += comboPalettes_SelectedIndexChanged;

            btnAddPalette.Click += btnAddPalette_Click;
            btnDuplicatePalette.Click += btnDuplicatePalette_Click;
            btnEditPalette.Click += btnEditPalette_Click;
        }

        private void comboPalettes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboPalettes.SelectedIndex > -1)
            {
                SelectedPalette = Palettes[comboPalettes.SelectedIndex];
                if (btnEditPalette.Enabled == false) btnEditPalette.Enabled = true;
                if (btnDuplicatePalette.Enabled == false) btnDuplicatePalette.Enabled = true;
            }
            else { btnEditPalette.Enabled = false; btnDuplicatePalette.Enabled = false; }
        }

        private void btnAddPalette_Click(object sender, EventArgs e)
        {
            Classes.IndexedPalette pal = new Classes.IndexedPalette(Planes, "New palette");
        }

        private void btnDuplicatePalette_Click(object sender, EventArgs e)
        {
            Palettes.Add(new Classes.IndexedPalette(SelectedPalette));
        }

        private void btnEditPalette_Click(object sender, EventArgs e)
        {
            PaletteEditor paletteEditor = new PaletteEditor(SelectedPalette);
            if (paletteEditor.ShowDialog() == DialogResult.OK)
            {
                paletteEditor.Close();
                comboPalettes.Invalidate();
            }
        }


        private void TileViewer_Resize(object sender, EventArgs e) 
        {
			
		}

        private void xScale_ValueChanged(object sender, EventArgs e)
        {
            tileGrid.ScaleX = (uint)xScale.Value;
            if (lockScale.Checked)
                yScale.Value = xScale.Value;
        }

        private void yScale_ValueChanged(object sender, EventArgs e)
        {
            tileGrid.ScaleY = (uint)yScale.Value;
            if (lockScale.Checked)
                xScale.Value = yScale.Value;
        }

        private void lockScale_CheckedChanged(object sender, EventArgs e)
        {
            if (lockScale.Checked)
                yScale.Value = xScale.Value;
        }

        private void xFlip_CheckedChanged(object sender, EventArgs e)
        {
            tileGrid.FlipX = xFlip.Checked;
        }

        private void yFlip_CheckedChanged(object sender, EventArgs e)
        {
            tileGrid.FlipY = yFlip.Checked;
        }

        private void rotate_SelectedIndexChanged(object sender, EventArgs e)
        {
            tileGrid.Rotate = (uint)rotate.SelectedIndex;
        }

        public void DrawExportTileset(Graphics graphics, long ElementsCount, long RowCount, long ColumnCount)
        {
            tileGrid.DrawExportTileset(graphics, ElementsCount, RowCount, ColumnCount);
        }
        public void DrawIndexedGif(Bitmap bitmap, uint[] mapData, uint mapWidth, uint mapHeight, uint tileWidth, uint tileHeight, uint offset, uint rotate, bool flipX, bool flipY)
        {
            tileGrid.DrawIndexedGif(bitmap, mapData, mapWidth, mapHeight, tileWidth, tileHeight, offset, rotate, flipX, flipY);
        }

        public void RedrawElementView()
        {
            tileGrid.Invalidate();
        }
    }
}
