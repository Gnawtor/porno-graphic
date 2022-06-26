
namespace Porno_Graphic
{
    partial class PaletteEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaletteEditor));
            this.labelRename = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.paletteGrid = new Porno_Graphic.Classes.PaletteEditorGridView();
            this.SuspendLayout();
            // 
            // labelRename
            // 
            this.labelRename.AutoSize = true;
            this.labelRename.Location = new System.Drawing.Point(6, 11);
            this.labelRename.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRename.Name = "labelRename";
            this.labelRename.Size = new System.Drawing.Size(38, 13);
            this.labelRename.TabIndex = 0;
            this.labelRename.Text = "Name:";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(46, 11);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(239, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(134, 317);
            this.btnOk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 22);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(215, 317);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 22);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // paletteGrid
            // 
            this.paletteGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.paletteGrid.ColorCount = ((uint)(0u));
            this.paletteGrid.Location = new System.Drawing.Point(8, 37);
            this.paletteGrid.Margin = new System.Windows.Forms.Padding(2);
            this.paletteGrid.Name = "paletteGrid";
            this.paletteGrid.Palette = null;
            this.paletteGrid.Size = new System.Drawing.Size(277, 273);
            this.paletteGrid.TabIndex = 4;
            // 
            // PaletteEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 346);
            this.Controls.Add(this.paletteGrid);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelRename);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaletteEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Palette Editor";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRename;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private Classes.PaletteEditorGridView paletteGrid;
    }
}