namespace Porno_Graphic
{
	partial class AboutDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            this.about_ProductLabel = new System.Windows.Forms.Label();
            this.about_CopyrightLabel = new System.Windows.Forms.Label();
            this.about_OkButton = new System.Windows.Forms.Button();
            this.about_CompanyLabel = new System.Windows.Forms.LinkLabel();
            this.about_Picture = new System.Windows.Forms.PictureBox();
            this.about_DisclaimerLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.about_Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // about_ProductLabel
            // 
            this.about_ProductLabel.Location = new System.Drawing.Point(30, 177);
            this.about_ProductLabel.Margin = new System.Windows.Forms.Padding(12, 0, 6, 0);
            this.about_ProductLabel.Name = "about_ProductLabel";
            this.about_ProductLabel.Size = new System.Drawing.Size(814, 33);
            this.about_ProductLabel.TabIndex = 26;
            this.about_ProductLabel.Text = "[Porno-Graphic]";
            this.about_ProductLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // about_CopyrightLabel
            // 
            this.about_CopyrightLabel.Location = new System.Drawing.Point(30, 238);
            this.about_CopyrightLabel.Margin = new System.Windows.Forms.Padding(12, 0, 6, 0);
            this.about_CopyrightLabel.Name = "about_CopyrightLabel";
            this.about_CopyrightLabel.Size = new System.Drawing.Size(512, 33);
            this.about_CopyrightLabel.TabIndex = 27;
            this.about_CopyrightLabel.Text = "[Copyright]";
            this.about_CopyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // about_OkButton
            // 
            this.about_OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.about_OkButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.about_OkButton.Location = new System.Drawing.Point(18, 341);
            this.about_OkButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.about_OkButton.Name = "about_OkButton";
            this.about_OkButton.Size = new System.Drawing.Size(824, 44);
            this.about_OkButton.TabIndex = 29;
            this.about_OkButton.Text = "&OK whatever, get me back to the program";
            // 
            // about_CompanyLabel
            // 
            this.about_CompanyLabel.AutoSize = true;
            this.about_CompanyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.about_CompanyLabel.Location = new System.Drawing.Point(30, 210);
            this.about_CompanyLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.about_CompanyLabel.Name = "about_CompanyLabel";
            this.about_CompanyLabel.Size = new System.Drawing.Size(81, 25);
            this.about_CompanyLabel.TabIndex = 31;
            this.about_CompanyLabel.TabStop = true;
            this.about_CompanyLabel.Text = "[RHSF]";
            // 
            // about_Picture
            // 
            this.about_Picture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.about_Picture.Dock = System.Windows.Forms.DockStyle.Top;
            this.about_Picture.Image = global::Porno_Graphic.Properties.Resources.AboutPictureDuck;
            this.about_Picture.Location = new System.Drawing.Point(18, 17);
            this.about_Picture.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.about_Picture.Name = "about_Picture";
            this.about_Picture.Size = new System.Drawing.Size(824, 142);
            this.about_Picture.TabIndex = 30;
            this.about_Picture.TabStop = false;
            // 
            // about_DisclaimerLabel
            // 
            this.about_DisclaimerLabel.AutoSize = true;
            this.about_DisclaimerLabel.Location = new System.Drawing.Point(30, 273);
            this.about_DisclaimerLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.about_DisclaimerLabel.Name = "about_DisclaimerLabel";
            this.about_DisclaimerLabel.Size = new System.Drawing.Size(124, 25);
            this.about_DisclaimerLabel.TabIndex = 32;
            this.about_DisclaimerLabel.Text = "[Disclaimer]";
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.about_OkButton;
            this.ClientSize = new System.Drawing.Size(860, 402);
            this.Controls.Add(this.about_DisclaimerLabel);
            this.Controls.Add(this.about_CompanyLabel);
            this.Controls.Add(this.about_Picture);
            this.Controls.Add(this.about_ProductLabel);
            this.Controls.Add(this.about_CopyrightLabel);
            this.Controls.Add(this.about_OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.Padding = new System.Windows.Forms.Padding(18, 17, 18, 17);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutDialog";
            ((System.ComponentModel.ISupportInitialize)(this.about_Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label about_ProductLabel;
		private System.Windows.Forms.Label about_CopyrightLabel;
		private System.Windows.Forms.Button about_OkButton;
		private System.Windows.Forms.PictureBox about_Picture;
		private System.Windows.Forms.LinkLabel about_CompanyLabel;
        private System.Windows.Forms.Label about_DisclaimerLabel;
    }
}
