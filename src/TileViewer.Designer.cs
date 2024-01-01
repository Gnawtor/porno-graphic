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
            this.columnsLimit = new System.Windows.Forms.NumericUpDown();
            this.limitColumns = new System.Windows.Forms.CheckBox();
            this.PaletteGroupBox = new System.Windows.Forms.GroupBox();
            this.sliderPanelBlue = new Porno_Graphic.Classes.NumberSliderPanel();
            this.sliderPanelGreen = new Porno_Graphic.Classes.NumberSliderPanel();
            this.sliderPanelRed = new Porno_Graphic.Classes.NumberSliderPanel();
            this.colorPreviewBox = new System.Windows.Forms.Panel();
            this.comboPalettes = new System.Windows.Forms.ComboBox();
            this.btnDuplicatePalette = new System.Windows.Forms.Button();
            this.btnAddPalette = new System.Windows.Forms.Button();
            this.paletteBar = new Porno_Graphic.Classes.PaletteSingleBar();
            this.btnRenamePalette = new System.Windows.Forms.Button();
            this.tileGrid = new Porno_Graphic.Classes.ElementGridView();
            ((System.ComponentModel.ISupportInitialize)(this.xScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yScale)).BeginInit();
            this.groupBox_Options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnsLimit)).BeginInit();
            this.PaletteGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // xScaleLabel
            // 
            this.xScaleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xScaleLabel.Location = new System.Drawing.Point(14, 42);
            this.xScaleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.xScaleLabel.Name = "xScaleLabel";
            this.xScaleLabel.Size = new System.Drawing.Size(94, 25);
            this.xScaleLabel.TabIndex = 1;
            this.xScaleLabel.Text = "X Scale:";
            // 
            // xScale
            // 
            this.xScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xScale.Location = new System.Drawing.Point(108, 38);
            this.xScale.Margin = new System.Windows.Forms.Padding(6);
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
            this.yScaleLabel.Location = new System.Drawing.Point(228, 42);
            this.yScaleLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.yScaleLabel.Name = "yScaleLabel";
            this.yScaleLabel.Size = new System.Drawing.Size(94, 25);
            this.yScaleLabel.TabIndex = 3;
            this.yScaleLabel.Text = "Y Scale:";
            // 
            // yScale
            // 
            this.yScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.yScale.Location = new System.Drawing.Point(322, 38);
            this.yScale.Margin = new System.Windows.Forms.Padding(6);
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
            this.lockScale.Location = new System.Drawing.Point(446, 40);
            this.lockScale.Margin = new System.Windows.Forms.Padding(6);
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
            this.xFlip.Location = new System.Drawing.Point(844, 46);
            this.xFlip.Margin = new System.Windows.Forms.Padding(6);
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
            this.yFlip.Location = new System.Drawing.Point(968, 44);
            this.yFlip.Margin = new System.Windows.Forms.Padding(6);
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
            this.rotateLabel.Location = new System.Drawing.Point(584, 42);
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
            this.rotate.Location = new System.Drawing.Point(670, 37);
            this.rotate.Margin = new System.Windows.Forms.Padding(6);
            this.rotate.Name = "rotate";
            this.rotate.Size = new System.Drawing.Size(124, 33);
            this.rotate.TabIndex = 9;
            this.rotate.SelectedIndexChanged += new System.EventHandler(this.rotate_SelectedIndexChanged);
            // 
            // groupBox_Options
            // 
            this.groupBox_Options.Controls.Add(this.columnsLimit);
            this.groupBox_Options.Controls.Add(this.limitColumns);
            this.groupBox_Options.Controls.Add(this.PaletteGroupBox);
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
            this.groupBox_Options.Location = new System.Drawing.Point(0, 751);
            this.groupBox_Options.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox_Options.Name = "groupBox_Options";
            this.groupBox_Options.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_Options.Size = new System.Drawing.Size(1679, 287);
            this.groupBox_Options.TabIndex = 10;
            this.groupBox_Options.TabStop = false;
            this.groupBox_Options.Text = "Options";
            // 
            // columnsLimit
            // 
            this.columnsLimit.Location = new System.Drawing.Point(1312, 40);
            this.columnsLimit.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.columnsLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.columnsLimit.Name = "columnsLimit";
            this.columnsLimit.Size = new System.Drawing.Size(120, 31);
            this.columnsLimit.TabIndex = 18;
            this.columnsLimit.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // limitColumns
            // 
            this.limitColumns.AutoSize = true;
            this.limitColumns.Location = new System.Drawing.Point(1114, 44);
            this.limitColumns.Name = "limitColumns";
            this.limitColumns.Size = new System.Drawing.Size(179, 29);
            this.limitColumns.TabIndex = 17;
            this.limitColumns.Text = "Limit Columns";
            this.limitColumns.UseVisualStyleBackColor = true;
            // 
            // PaletteGroupBox
            // 
            this.PaletteGroupBox.Controls.Add(this.sliderPanelBlue);
            this.PaletteGroupBox.Controls.Add(this.sliderPanelGreen);
            this.PaletteGroupBox.Controls.Add(this.sliderPanelRed);
            this.PaletteGroupBox.Controls.Add(this.colorPreviewBox);
            this.PaletteGroupBox.Controls.Add(this.comboPalettes);
            this.PaletteGroupBox.Controls.Add(this.btnDuplicatePalette);
            this.PaletteGroupBox.Controls.Add(this.btnAddPalette);
            this.PaletteGroupBox.Controls.Add(this.paletteBar);
            this.PaletteGroupBox.Controls.Add(this.btnRenamePalette);
            this.PaletteGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PaletteGroupBox.Location = new System.Drawing.Point(6, 89);
            this.PaletteGroupBox.Margin = new System.Windows.Forms.Padding(6);
            this.PaletteGroupBox.Name = "PaletteGroupBox";
            this.PaletteGroupBox.Padding = new System.Windows.Forms.Padding(6);
            this.PaletteGroupBox.Size = new System.Drawing.Size(1667, 192);
            this.PaletteGroupBox.TabIndex = 16;
            this.PaletteGroupBox.TabStop = false;
            this.PaletteGroupBox.Text = "Palette";
            // 
            // sliderPanelBlue
            // 
            this.sliderPanelBlue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderPanelBlue.ControlPadding = 0;
            this.sliderPanelBlue.IdText = "B";
            this.sliderPanelBlue.Location = new System.Drawing.Point(783, 131);
            this.sliderPanelBlue.Margin = new System.Windows.Forms.Padding(6);
            this.sliderPanelBlue.Maximum = ((uint)(255u));
            this.sliderPanelBlue.Minimum = ((uint)(0u));
            this.sliderPanelBlue.Name = "sliderPanelBlue";
            this.sliderPanelBlue.Size = new System.Drawing.Size(706, 58);
            this.sliderPanelBlue.TabIndex = 18;
            this.sliderPanelBlue.Value = ((uint)(0u));
            // 
            // sliderPanelGreen
            // 
            this.sliderPanelGreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderPanelGreen.ControlPadding = 0;
            this.sliderPanelGreen.IdText = "G";
            this.sliderPanelGreen.Location = new System.Drawing.Point(783, 75);
            this.sliderPanelGreen.Margin = new System.Windows.Forms.Padding(6);
            this.sliderPanelGreen.Maximum = ((uint)(255u));
            this.sliderPanelGreen.Minimum = ((uint)(0u));
            this.sliderPanelGreen.Name = "sliderPanelGreen";
            this.sliderPanelGreen.Size = new System.Drawing.Size(706, 58);
            this.sliderPanelGreen.TabIndex = 18;
            this.sliderPanelGreen.Value = ((uint)(0u));
            // 
            // sliderPanelRed
            // 
            this.sliderPanelRed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderPanelRed.ControlPadding = 0;
            this.sliderPanelRed.IdText = "R";
            this.sliderPanelRed.Location = new System.Drawing.Point(783, 21);
            this.sliderPanelRed.Margin = new System.Windows.Forms.Padding(6);
            this.sliderPanelRed.Maximum = ((uint)(255u));
            this.sliderPanelRed.Minimum = ((uint)(0u));
            this.sliderPanelRed.Name = "sliderPanelRed";
            this.sliderPanelRed.Size = new System.Drawing.Size(706, 58);
            this.sliderPanelRed.TabIndex = 17;
            this.sliderPanelRed.Value = ((uint)(0u));
            // 
            // colorPreviewBox
            // 
            this.colorPreviewBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.colorPreviewBox.Location = new System.Drawing.Point(1511, 27);
            this.colorPreviewBox.Margin = new System.Windows.Forms.Padding(6);
            this.colorPreviewBox.Name = "colorPreviewBox";
            this.colorPreviewBox.Size = new System.Drawing.Size(128, 123);
            this.colorPreviewBox.TabIndex = 22;
            // 
            // comboPalettes
            // 
            this.comboPalettes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboPalettes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPalettes.FormattingEnabled = true;
            this.comboPalettes.Location = new System.Drawing.Point(18, 37);
            this.comboPalettes.Margin = new System.Windows.Forms.Padding(6);
            this.comboPalettes.Name = "comboPalettes";
            this.comboPalettes.Size = new System.Drawing.Size(427, 33);
            this.comboPalettes.TabIndex = 10;
            // 
            // btnDuplicatePalette
            // 
            this.btnDuplicatePalette.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDuplicatePalette.Location = new System.Drawing.Point(543, 35);
            this.btnDuplicatePalette.Margin = new System.Windows.Forms.Padding(4);
            this.btnDuplicatePalette.Name = "btnDuplicatePalette";
            this.btnDuplicatePalette.Size = new System.Drawing.Size(90, 44);
            this.btnDuplicatePalette.TabIndex = 15;
            this.btnDuplicatePalette.Text = "Dupl.";
            this.btnDuplicatePalette.UseVisualStyleBackColor = true;
            // 
            // btnAddPalette
            // 
            this.btnAddPalette.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPalette.Location = new System.Drawing.Point(465, 35);
            this.btnAddPalette.Margin = new System.Windows.Forms.Padding(6);
            this.btnAddPalette.Name = "btnAddPalette";
            this.btnAddPalette.Size = new System.Drawing.Size(76, 44);
            this.btnAddPalette.TabIndex = 11;
            this.btnAddPalette.Text = "Add";
            this.btnAddPalette.UseVisualStyleBackColor = true;
            // 
            // paletteBar
            // 
            this.paletteBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paletteBar.Location = new System.Drawing.Point(18, 98);
            this.paletteBar.Margin = new System.Windows.Forms.Padding(6);
            this.paletteBar.Name = "paletteBar";
            this.paletteBar.Palette = null;
            this.paletteBar.Size = new System.Drawing.Size(737, 77);
            this.paletteBar.TabIndex = 14;
            // 
            // btnRenamePalette
            // 
            this.btnRenamePalette.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenamePalette.Location = new System.Drawing.Point(635, 35);
            this.btnRenamePalette.Margin = new System.Windows.Forms.Padding(6);
            this.btnRenamePalette.Name = "btnRenamePalette";
            this.btnRenamePalette.Size = new System.Drawing.Size(124, 44);
            this.btnRenamePalette.TabIndex = 12;
            this.btnRenamePalette.Text = "Rename";
            this.btnRenamePalette.UseVisualStyleBackColor = true;
            // 
            // tileGrid
            // 
            this.tileGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tileGrid.AutoScroll = true;
            this.tileGrid.AutoScrollMinSize = new System.Drawing.Size(1672, 2);
            this.tileGrid.Elements = new Porno_Graphic.Classes.GfxElement[0];
            this.tileGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tileGrid.HighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.tileGrid.Location = new System.Drawing.Point(0, 0);
            this.tileGrid.Margin = new System.Windows.Forms.Padding(6);
            this.tileGrid.Name = "tileGrid";
            this.tileGrid.Palettes = null;
            this.tileGrid.PalettesBindingSource = null;
            this.tileGrid.SelectedPalette = null;
            this.tileGrid.Size = new System.Drawing.Size(1679, 740);
            this.tileGrid.TabIndex = 0;
            this.tileGrid.Tag = "";
            // 
            // TileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1679, 1038);
            this.Controls.Add(this.groupBox_Options);
            this.Controls.Add(this.tileGrid);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = global::Porno_Graphic.Properties.Resources.Document;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimumSize = new System.Drawing.Size(604, 367);
            this.Name = "TileViewer";
            this.Text = "[Tile Viewer]";
            this.Resize += new System.EventHandler(this.TileViewer_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.xScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yScale)).EndInit();
            this.groupBox_Options.ResumeLayout(false);
            this.groupBox_Options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.columnsLimit)).EndInit();
            this.PaletteGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnRenamePalette;
        private System.Windows.Forms.Button btnAddPalette;
        private System.Windows.Forms.ComboBox comboPalettes;
        private Classes.PaletteSingleBar paletteBar;
        private System.Windows.Forms.Button btnDuplicatePalette;
        private System.Windows.Forms.GroupBox PaletteGroupBox;
        private System.Windows.Forms.Panel colorPreviewBox;
        private Classes.NumberSliderPanel sliderPanelRed;
        private Classes.NumberSliderPanel sliderPanelBlue;
        private Classes.NumberSliderPanel sliderPanelGreen;
        private System.Windows.Forms.NumericUpDown columnsLimit;
        private System.Windows.Forms.CheckBox limitColumns;
    }
}