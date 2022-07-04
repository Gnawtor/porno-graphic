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
    public partial class ProjectProperties : Form
    {
        Classes.GameProfile mProfile;
        Classes.TileImportMetadata mTileImportMetadata;
        private string mProjectName;

        public Classes.GameProfile Profile { get { return mProfile; } set { mProfile = value; } }
        public Classes.TileImportMetadata TileImportMetadata { get { return mTileImportMetadata; } set { mTileImportMetadata = value; } }
        public string ProjectName { get { return mProjectName; } set { mProjectName = value; } }
        public ProjectProperties(Classes.TileImportMetadata importMetadata, string projectName)
        {
            InitializeComponent();
            TileImportMetadata = importMetadata;
            ProjectName = projectName;
            this.Text = String.Format(Properties.Resources.ProjectProperties_Title, ProjectName);
            fileGrid.CellContentClick += fileGrid_CellContentClick;
            fileGrid.DragDrop += fileGrid_DragDrop;
            fileGrid.DragEnter += fileGrid_DragEnter;
            cancelButton.Click += cancelButton_Click;
            okButton.Click += okButton_Click;

            projectNameTextBox.Text = ProjectName;

            Classes.ProfileList profileList = new Classes.ProfileList(AppDomain.CurrentDomain.BaseDirectory + @"\profiles");
            Profile = profileList.Profiles.Find(p => p.Profile.Name == TileImportMetadata.ProfileName).Profile;

            fileGrid.Rows.Clear();
            if (TileImportMetadata.LayoutName == "Flat file")
            {
                int i = fileGrid.Rows.Add();
                fileGrid.Rows[i].Cells[0].Value = Porno_Graphic.Properties.Resources.TileImporter_FlatFileDisplayName;
                fileGrid.Rows[i].Cells[1].Value = "";
                fileGrid.Rows[i].Cells[3].Value = TileImportMetadata.RomFilenames[0];
            }
            else
            {
                int regionIndex = 0;
                for (int i = 0; i < Profile.LoadRegions.Length; i++, regionIndex++)
                    if (Profile.LoadRegions[i].Name == TileImportMetadata.RegionName) break;

                foreach (Classes.LoadRegion.File file in Profile.LoadRegions[regionIndex].Files)
                {
                    int i = fileGrid.Rows.Add();
                    fileGrid.Rows[i].Cells[0].Value = file.Name;
                    fileGrid.Rows[i].Cells[1].Value = String.Format("0x{0:x}", file.LoadedLength);
                    fileGrid.Rows[i].Cells[3].Value = TileImportMetadata.RomFilenames[i];
                }
            }
        }

        private void fileGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((fileGrid.Columns[e.ColumnIndex].Name == "browse") && (e.RowIndex >= 0))
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = string.Format(Porno_Graphic.Properties.Resources.TileImporter_OpenDataFileTitle, fileGrid.Rows[e.RowIndex].Cells[0].Value);
                dialog.Filter = Porno_Graphic.Properties.Resources.TileImporter_OpenDataFileFilter;
                dialog.FilterIndex = 1;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileGrid.Rows[e.RowIndex].Cells[3].Value = dialog.FileName;
                }
            }
        }

        private void fileGrid_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
            {
                string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (paths.Length == 1)
                {
                    Point cursorPosition = fileGrid.PointToClient(Cursor.Position);
                    int row = fileGrid.HitTest(cursorPosition.X, cursorPosition.Y).RowIndex;
                    if (row >= 0)
                    {
                        fileGrid.Rows[row].Cells[3].Value = paths[0];
                    }
                }
            }
        }

        private void fileGrid_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) && (((string[])e.Data.GetData(DataFormats.FileDrop)).Length == 1))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (ProjectName != projectNameTextBox.Text && projectNameTextBox.Text != String.Empty) ProjectName = projectNameTextBox.Text;

            for (int i = 0; i < TileImportMetadata.RomFilenames.Length; i++)
            {
                if (TileImportMetadata.RomFilenames[i] != (string)fileGrid.Rows[i].Cells[3].Value) TileImportMetadata.RomFilenames[i] = (string)fileGrid.Rows[i].Cells[3].Value;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
