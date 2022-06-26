namespace Porno_Graphic
{
	partial class TileViewer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.xScaleLabel = new System.Windows.Forms.Label();
            this.xScale = new System.Windows.Forms.NumericUpDown();
            this.yScaleLabel = new System.Windows.Forms.Label();
            this.yScale = new System.Windows.Forms.NumericUpDown();
            this.lockScale = new System.Windows.Forms.CheckBox();
            this.xFlip = new System.Windows.Forms.CheckBox();
            this.yFlip = new System.Windows.Forms.CheckBox();
            this.rotateLabel = new System.Windows.Forms.Label();
            this.rotate = new System.Windows.Forms.ComboBox();
            this.groupBox_Options = new System.Windows.Forms.GroupBox();
            this.labelPalette = new System.Windows.Forms.Label();
            this.btnEditPalette = new System.Windows.Forms.Button();
            this.btnAddPalette = new System.Windows.Forms.Button();
            this.comboPalettes = new System.Windows.Forms.ComboBox();
            this.paletteBar = new Porno_Graphic.Classes.PaletteSingleBar();
            this.tileGrid = new Porno_Graphic.Classes.ElementGridView();
            this.btnDuplicatePalette = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.xScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yScale)).BeginInit();
            this.groupBox_Options.SuspendLayout();
            this.SuspendLayout();
            // 
            // xScaleLabel
            // 
            this.xScaleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xScaleLabel.Location = new System.Drawing.Point(14, 38);
            this.xScaleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.xScaleLabel.Name = "xScaleLabel";
            this.xScaleLabel.Size = new System.Drawing.Size(94, 25);
            this.xScaleLabel.TabIndex = 1;
            this.xScaleLabel.Text = "X Scale:";
            // 
            // xScale
            // 
            this.xScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xScale.Location = new System.Drawing.Point(120, 35);
            this.xScale.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.xScale.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.xScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xScale.Name = "xScale";
            this.xScale.Size = new System.Drawing.Size(96, 31);
            this.xScale.TabIndex = 2;
            this.xScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.xScale.ValueChanged += new System.EventHandler(this.xScale_ValueChanged);
            // 
            // yScaleLabel
            // 
            this.yScaleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.yScaleLabel.Location = new System.Drawing.Point(14, 88);
            this.yScaleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.yScaleLabel.Name = "yScaleLabel";
            this.yScaleLabel.Size = new System.Drawing.Size(94, 25);
            this.yScaleLabel.TabIndex = 3;
            this.yScaleLabel.Text = "Y Scale:";
            // 
            // yScale
            // 
            this.yScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.yScale.Location = new System.Drawing.Point(120, 85);
            this.yScale.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.yScale.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.yScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.yScale.Name = "yScale";
            this.yScale.Size = new System.Drawing.Size(96, 31);
            this.yScale.TabIndex = 4;
            this.yScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.yScale.ValueChanged += new System.EventHandler(this.yScale_ValueChanged);
            // 
            // lockScale
            // 
            this.lockScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lockScale.Checked = true;
            this.lockScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.lockScale.Location = new System.Drawing.Point(230, 63);
            this.lockScale.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.lockScale.Name = "lockScale";
            this.lockScale.Size = new System.Drawing.Size(100, 33);
            this.lockScale.TabIndex = 5;
            this.lockScale.Text = "Lock";
            this.lockScale.UseVisualStyleBackColor = true;
            this.lockScale.CheckedChanged += new System.EventHandler(this.lockScale_CheckedChanged);
            // 
            // xFlip
            // 
            this.xFlip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xFlip.AutoSize = true;
            this.xFlip.Location = new System.Drawing.Point(24, 210);
            this.xFlip.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.xFlip.Name = "xFlip";
            this.xFlip.Size = new System.Drawing.Size(99, 29);
            this.xFlip.TabIndex = 6;
            this.xFlip.Text = "Flip X";
            this.xFlip.UseVisualStyleBackColor = true;
            this.xFlip.CheckedChanged += new System.EventHandler(this.xFlip_CheckedChanged);
            // 
            // yFlip
            // 
            this.yFlip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.yFlip.AutoSize = true;
            this.yFlip.Location = new System.Drawing.Point(144, 210);
            this.yFlip.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.yFlip.Name = "yFlip";
            this.yFlip.Size = new System.Drawing.Size(100, 29);
            this.yFlip.TabIndex = 7;
            this.yFlip.Text = "Flip Y";
            this.yFlip.UseVisualStyleBackColor = true;
            this.yFlip.CheckedChanged += new System.EventHandler(this.yFlip_CheckedChanged);
            // 
            // rotateLabel
            // 
            this.rotateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rotateLabel.Location = new System.Drawing.Point(12, 150);
            this.rotateLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.rotateLabel.Name = "rotateLabel";
            this.rotateLabel.Size = new System.Drawing.Size(96, 25);
            this.rotateLabel.TabIndex = 8;
            this.rotateLabel.Text = "Rotate:";
            // 
            // rotate
            // 
            this.rotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rotate.FormattingEnabled = true;
            this.rotate.Items.AddRange(new object[] {
            "0°",
            "90°",
            "180°",
            "270°"});
            this.rotate.Location = new System.Drawing.Point(120, 144);
            this.rotate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.rotate.Name = "rotate";
            this.rotate.Size = new System.Drawing.Size(124, 33);
            this.rotate.TabIndex = 9;
            this.rotate.SelectedIndexChanged += new System.EventHandler(this.rotate_SelectedIndexChanged);
            // 
            // groupBox_Options
            // 
            this.groupBox_Options.Controls.Add(this.btnDuplicatePalette);
            this.groupBox_Options.Controls.Add(this.paletteBar);
            this.groupBox_Options.Controls.Add(this.labelPalette);
            this.groupBox_Options.Controls.Add(this.btnEditPalette);
            this.groupBox_Options.Controls.Add(this.btnAddPalette);
            this.groupBox_Options.Controls.Add(this.comboPalettes);
            this.groupBox_Options.Controls.Add(this.xScaleLabel);
            this.groupBox_Options.Controls.Add(this.rotate);
            this.groupBox_Options.Controls.Add(this.xScale);
            this.groupBox_Options.Controls.Add(this.rotateLabel);
            this.groupBox_Options.Controls.Add(this.yScaleLabel);
            this.groupBox_Options.Controls.Add(this.yFlip);
            this.groupBox_Options.Controls.Add(this.yScale);
            this.groupBox_Options.Controls.Add(this.xFlip);
            this.groupBox_Options.Controls.Add(this.lockScale);
            this.groupBox_Options.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_Options.Location = new System.Drawing.Point(0, 678);
            this.groupBox_Options.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox_Options.Name = "groupBox_Options";
            this.groupBox_Options.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox_Options.Size = new System.Drawing.Size(1248, 260);
            this.groupBox_Options.TabIndex = 10;
            this.groupBox_Options.TabStop = false;
            this.groupBox_Options.Text = "Options";
            // 
            // labelPalette
            // 
            this.labelPalette.AutoSize = true;
            this.labelPalette.Location = new System.Drawing.Point(356, 31);
            this.labelPalette.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelPalette.Name = "labelPalette";
            this.labelPalette.Size = new System.Drawing.Size(79, 25);
            this.labelPalette.TabIndex = 13;
            this.labelPalette.Text = "Palette";
            // 
            // btnEditPalette
            // 
            this.btnEditPalette.Location = new System.Drawing.Point(588, 150);
            this.btnEditPalette.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnEditPalette.Name = "btnEditPalette";
            this.btnEditPalette.Size = new System.Drawing.Size(92, 44);
            this.btnEditPalette.TabIndex = 12;
            this.btnEditPalette.Text = "Edit";
            this.btnEditPalette.UseVisualStyleBackColor = true;
            // 
            // btnAddPalette
            // 
            this.btnAddPalette.Location = new System.Drawing.Point(362, 150);
            this.btnAddPalette.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnAddPalette.Name = "btnAddPalette";
            this.btnAddPalette.Size = new System.Drawing.Size(86, 44);
            this.btnAddPalette.TabIndex = 11;
            this.btnAddPalette.Text = "Add";
            this.btnAddPalette.UseVisualStyleBackColor = true;
            // 
            // comboPalettes
            // 
            this.comboPalettes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPalettes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPalettes.FormattingEnabled = true;
            this.comboPalettes.Location = new System.Drawing.Point(692, 152);
            this.comboPalettes.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.comboPalettes.Name = "comboPalettes";
            this.comboPalettes.Size = new System.Drawing.Size(530, 33);
            this.comboPalettes.TabIndex = 10;
            // 
            // paletteBar
            // 
            this.paletteBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteBar.Location = new System.Drawing.Point(362, 62);
            this.paletteBar.Margin = new System.Windows.Forms.Padding(6);
            this.paletteBar.Name = "paletteBar";
            this.paletteBar.Palette = null;
            this.paletteBar.Size = new System.Drawing.Size(864, 77);
            this.paletteBar.TabIndex = 14;
            // 
            // tileGrid
            // 
            this.tileGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tileGrid.AutoScroll = true;
            this.tileGrid.AutoScrollMinSize = new System.Drawing.Size(1242, 2);
            this.tileGrid.Elements = new Porno_Graphic.Classes.GfxElement[0];
            this.tileGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tileGrid.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.tileGrid.Location = new System.Drawing.Point(0, 0);
            this.tileGrid.Margin = new System.Windows.Forms.Padding(6);
            this.tileGrid.Name = "tileGrid";
            this.tileGrid.Palettes = null;
            this.tileGrid.SelectedPalette = null;
            this.tileGrid.Size = new System.Drawing.Size(1248, 650);
            this.tileGrid.TabIndex = 0;
            this.tileGrid.Tag = "";
            // 
            // btnDuplicatePalette
            // 
            this.btnDuplicatePalette.Location = new System.Drawing.Point(457, 150);
            this.btnDuplicatePalette.Name = "btnDuplicatePalette";
            this.btnDuplicatePalette.Size = new System.Drawing.Size(122, 44);
            this.btnDuplicatePalette.TabIndex = 15;
            this.btnDuplicatePalette.Text = "Duplicate";
            this.btnDuplicatePalette.UseVisualStyleBackColor = true;
            // 
            // TileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1248, 938);
            this.Controls.Add(this.groupBox_Options);
            this.Controls.Add(this.tileGrid);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = global::Porno_Graphic.Properties.Resources.Document;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MinimumSize = new System.Drawing.Size(614, 396);
            this.Name = "TileViewer";
            this.Text = "[Tile Viewer]";
            this.Resize += new System.EventHandler(this.TileViewer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.xScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yScale)).EndInit();
            this.groupBox_Options.ResumeLayout(false);
            this.groupBox_Options.PerformLayout();
            this.ResumeLayout(false);

		}

        #endregion

        private Classes.ElementGridView tileGrid;
        private System.Windows.Forms.NumericUpDown xScale;
        private System.Windows.Forms.Label yScaleLabel;
        private System.Windows.Forms.NumericUpDown yScale;
        private System.Windows.Forms.Label xScaleLabel;
        private System.Windows.Forms.CheckBox lockScale;
        private System.Windows.Forms.CheckBox yFlip;
        private System.Windows.Forms.CheckBox xFlip;
        private System.Windows.Forms.Label rotateLabel;
		private System.Windows.Forms.ComboBox rotate;
		private System.Windows.Forms.GroupBox groupBox_Options;
        private System.Windows.Forms.Label labelPalette;
        private System.Windows.Forms.Button btnEditPalette;
        private System.Windows.Forms.Button btnAddPalette;
        private System.Windows.Forms.ComboBox comboPalettes;
        private Classes.PaletteSingleBar paletteBar;
        private System.Windows.Forms.Button btnDuplicatePalette;
    }
}