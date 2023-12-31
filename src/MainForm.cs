using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Porno_Graphic
{
	public partial class MainForm : Form
	{
        private class ProjectState
        {
            public Classes.Project Project { get; private set; }
            public TileViewer TileViewer { get; set; }

            public ProjectState(Classes.Project project)
            {
                Project = project;
                TileViewer = null;
            }
        }

		/* -- types and shit -- */
		public enum ToolTypes {
			Tool_Pointer = 0,
			Tool_Selection,
			Tool_ColorPicker,
			Tool_FloodFill,
			Tool_Line,
			Tool_RectLine,
			Tool_RectFill,
			Tool_RectStrokeFill,
			Tool_CircleLine,
			Tool_CircleFill,
			Tool_CircleStrokeFill,
			NUM_ToolTypes
		};	 // probably obsolete at this point

        /* -- main form variables -- */
        private int mImportCount = 0;
		public int NewFileCount = 0;
		public int NumOpenDocuments = 0;
		public ToolTypes curActiveTool;
        private ProjectState mActiveProject = null;

		/* -- other important things -- */
		//TileArranger arrangerForm; // the tile arranger/scratchboard
		//TileEditor editorForm; // the tile editor

		// todo: currently active palette set number

		/* -- preferences/options/whatever -- */
		public bool ShowEditorGrid;
		public bool ShowArrangerGrid;
		public bool ShowViewerGrid;

		public Color EditorGridColor;
		public Color ArrangerGridColor;
		public Color ViewerGridColor;

		/* -- save/load filters-- */
		public String defaultLoadFilter = "All Supported Files|*.bin,*.nes,*.gb,*.gbc,*.gba,*.sfc,*.smc,*.smd,*.gen,*.chr,*.pce|All Files|*.*";
		public String defaultSaveFilter = "All Files|*.*";
		//public String paletteLoadFilter = "All Supported Palette Files|*.pgpal,*.act,*.pal,*.ngpal|Porno-Graphic Palette|*.pgpal|Adobe ACT|*.act|Jasc PAL|*.pal|NGFX Palette|*.ngpal|All Files|*.*";
		//public String paletteSaveFilter = "Porno-Graphic Palette|*.pgpal|Adobe ACT|*.act|Jasc PAL|*.pal|NGFX Palette|*.ngpal|All Files|*.*";

		/* == begin form code == */
		public MainForm() {
			InitializeComponent();

			/* set any status strip items to open upwards and to the right (subject to change) */
			mainStatusStrip.DefaultDropDownDirection = ToolStripDropDownDirection.AboveRight;

			/* tool related */
			curActiveTool = ToolTypes.Tool_Pointer;

			/* palette related */
			//cBox_ActivePaletteSet.SelectedIndex = 0;   // OBSOLETE

			/* add tile editor to main window */
			//editorForm = new TileEditor();
			//editorForm.MdiParent = this;
			//editorForm.Show();

			/* add tile arranger to main window */
			//arrangerForm = new TileArranger();
			//arrangerForm.MdiParent = this;
			//arrangerForm.Show();

			/* set variables from settings/config */
			//ShowEditorGrid = Porno_Graphic.Properties.Settings.Default.EditorGrid;
			//ShowArrangerGrid = Porno_Graphic.Properties.Settings.Default.ArrangerGrid;
			//ShowViewerGrid = Porno_Graphic.Properties.Settings.Default.ViewerGrid;
			//EditorGridColor = Porno_Graphic.Properties.Settings.Default.EditorGridColor;
			//ArrangerGridColor = Porno_Graphic.Properties.Settings.Default.ArrangerGridColor;
			//ViewerGridColor = Porno_Graphic.Properties.Settings.Default.ViewerGridColor;

			/* initialize grid item checkmarks */
			menuItem_View_GridEdit.Checked = ShowEditorGrid;
			menuItem_View_GridArranger.Checked = ShowArrangerGrid;
			menuItem_View_GridView.Checked = ShowViewerGrid;

			splitRegionsToolStripMenuItem.Click += MenuItemSplitRegions_Click;
			projectToolStripMenuItem.DropDownOpened += projectToolStripMenuItem_DropDownOpening;
			saveProjectAsToolStripMenuItem.Click += menuItem_File_SaveAs_Click;
			propertiesToolStripMenuItem.Click += propertiesToolStripMenuItem_Click;
		}

		private void menuItem_File_Exit_Click(object sender, EventArgs e) {
			this.Close();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
			AboutDialog about = new AboutDialog();
			about.ShowDialog();
		}

		#region Active Tool status routines
		private void SetTool_Pointer() {
			/* set current tool to mouse pointer */
			curActiveTool = ToolTypes.Tool_Pointer;

			/* check mouse pointer button */
			this.toolToolStrip_Button_Pointer.Checked = true;
			/* uncheck other tool buttons */
			this.toolToolStrip_Button_Colorpicker.Checked = false;
			this.toolToolStrip_Button_Selection.Checked = false;
			this.toolToolStrip_Button_Fill.Checked = false;
			this.toolToolStrip_Button_Line.Checked = false;
			this.toolToolStrip_Button_RectLine.Checked = false;
			this.toolToolStrip_Button_RectFill.Checked = false;
			this.toolToolStrip_Button_RectStrokeFill.Checked = false;
			this.toolToolStrip_Button_CircleLine.Checked = false;
			this.toolToolStrip_Button_CircleFill.Checked = false;
			this.toolToolStrip_Button_CircleStrokeFill.Checked = false;
		}

		private void SetTool_Selection() {
			/* set current tool to selection */
			curActiveTool = ToolTypes.Tool_Selection;
			/* check selection button */
			this.toolToolStrip_Button_Selection.Checked = true;
			/* uncheck other tool buttons */
			this.toolToolStrip_Button_Pointer.Checked = false;
			this.toolToolStrip_Button_Colorpicker.Checked = false;
			this.toolToolStrip_Button_Fill.Checked = false;
			this.toolToolStrip_Button_Line.Checked = false;
			this.toolToolStrip_Button_RectLine.Checked = false;
			this.toolToolStrip_Button_RectFill.Checked = false;
			this.toolToolStrip_Button_RectStrokeFill.Checked = false;
			this.toolToolStrip_Button_CircleLine.Checked = false;
			this.toolToolStrip_Button_CircleFill.Checked = false;
			this.toolToolStrip_Button_CircleStrokeFill.Checked = false;
		}

		private void SetTool_ColorPicker() {
			/* set current tool to color picker */
			curActiveTool = ToolTypes.Tool_ColorPicker;

			/* check color picker button */
			this.toolToolStrip_Button_Colorpicker.Checked = true;
			/* uncheck other tool buttons */
			this.toolToolStrip_Button_Pointer.Checked = false;
			this.toolToolStrip_Button_Selection.Checked = false;
			this.toolToolStrip_Button_Fill.Checked = false;
			this.toolToolStrip_Button_Line.Checked = false;
			this.toolToolStrip_Button_RectLine.Checked = false;
			this.toolToolStrip_Button_RectFill.Checked = false;
			this.toolToolStrip_Button_RectStrokeFill.Checked = false;
			this.toolToolStrip_Button_CircleLine.Checked = false;
			this.toolToolStrip_Button_CircleFill.Checked = false;
			this.toolToolStrip_Button_CircleStrokeFill.Checked = false;
		}

		private void SetTool_Fill() {
			/* set current tool to flood fill */
			curActiveTool = ToolTypes.Tool_FloodFill;

			/* check flood fill button */
			this.toolToolStrip_Button_Fill.Checked = true;
			/* uncheck other tool buttons */
			this.toolToolStrip_Button_Pointer.Checked = false;
			this.toolToolStrip_Button_Selection.Checked = false;
			this.toolToolStrip_Button_Colorpicker.Checked = false;
			this.toolToolStrip_Button_Line.Checked = false;
			this.toolToolStrip_Button_RectLine.Checked = false;
			this.toolToolStrip_Button_RectFill.Checked = false;
			this.toolToolStrip_Button_RectStrokeFill.Checked = false;
			this.toolToolStrip_Button_CircleLine.Checked = false;
			this.toolToolStrip_Button_CircleFill.Checked = false;
			this.toolToolStrip_Button_CircleStrokeFill.Checked = false;
		}

		private void SetTool_Line() {
			/* set current tool to line */
			curActiveTool = ToolTypes.Tool_Line;

			/* check line button */
			this.toolToolStrip_Button_Line.Checked = true;
			/* uncheck other tool buttons */
			this.toolToolStrip_Button_Pointer.Checked = false;
			this.toolToolStrip_Button_Selection.Checked = false;
			this.toolToolStrip_Button_Colorpicker.Checked = false;
			this.toolToolStrip_Button_Fill.Checked = false;
			this.toolToolStrip_Button_RectLine.Checked = false;
			this.toolToolStrip_Button_RectFill.Checked = false;
			this.toolToolStrip_Button_RectStrokeFill.Checked = false;
			this.toolToolStrip_Button_CircleLine.Checked = false;
			this.toolToolStrip_Button_CircleFill.Checked = false;
			this.toolToolStrip_Button_CircleStrokeFill.Checked = false;
		}

		private void SetTool_RectLine() {
			/* set current tool to hollow rectangle */
			curActiveTool = ToolTypes.Tool_RectLine;

			/* check hollow rectangle button */
			this.toolToolStrip_Button_RectLine.Checked = true;
			/* uncheck other tool buttons */
			this.toolToolStrip_Button_Pointer.Checked = false;
			this.toolToolStrip_Button_Selection.Checked = false;
			this.toolToolStrip_Button_Colorpicker.Checked = false;
			this.toolToolStrip_Button_Fill.Checked = false;
			this.toolToolStrip_Button_Line.Checked = false;
			this.toolToolStrip_Button_RectFill.Checked = false;
			this.toolToolStrip_Button_RectStrokeFill.Checked = false;
			this.toolToolStrip_Button_CircleLine.Checked = false;
			this.toolToolStrip_Button_CircleFill.Checked = false;
			this.toolToolStrip_Button_CircleStrokeFill.Checked = false;
		}

		private void SetTool_RectFill() {
			/* set current tool to filled rectangle */
			curActiveTool = ToolTypes.Tool_RectFill;

			/* check filled rectangle button */
			this.toolToolStrip_Button_RectFill.Checked = true;
			/* uncheck other tool buttons */
			this.toolToolStrip_Button_Pointer.Checked = false;
			this.toolToolStrip_Button_Selection.Checked = false;
			this.toolToolStrip_Button_Colorpicker.Checked = false;
			this.toolToolStrip_Button_Fill.Checked = false;
			this.toolToolStrip_Button_Line.Checked = false;
			this.toolToolStrip_Button_RectLine.Checked = false;
			this.toolToolStrip_Button_RectStrokeFill.Checked = false;
			this.toolToolStrip_Button_CircleLine.Checked = false;
			this.toolToolStrip_Button_CircleFill.Checked = false;
			this.toolToolStrip_Button_CircleStrokeFill.Checked = false;
		}

		private void SetTool_RectStrokeFill() {
			/* set current tool to stroke filled rectangle */
			curActiveTool = ToolTypes.Tool_RectStrokeFill;

			/* check stroke filled rectangle button */
			this.toolToolStrip_Button_RectStrokeFill.Checked = true;
			/* uncheck other tool buttons */
			this.toolToolStrip_Button_Pointer.Checked = false;
			this.toolToolStrip_Button_Selection.Checked = false;
			this.toolToolStrip_Button_Colorpicker.Checked = false;
			this.toolToolStrip_Button_Fill.Checked = false;
			this.toolToolStrip_Button_Line.Checked = false;
			this.toolToolStrip_Button_RectLine.Checked = false;
			this.toolToolStrip_Button_RectFill.Checked = false;
			this.toolToolStrip_Button_CircleLine.Checked = false;
			this.toolToolStrip_Button_CircleFill.Checked = false;
			this.toolToolStrip_Button_CircleStrokeFill.Checked = false;
		}

		private void SetTool_CircleLine() {
			/* set current tool to hollow circle */
			curActiveTool = ToolTypes.Tool_CircleLine;

			/* check hollow circle button */
			this.toolToolStrip_Button_CircleLine.Checked = true;
			/* uncheck other tool buttons */
			this.toolToolStrip_Button_Pointer.Checked = false;
			this.toolToolStrip_Button_Selection.Checked = false;
			this.toolToolStrip_Button_Colorpicker.Checked = false;
			this.toolToolStrip_Button_Fill.Checked = false;
			this.toolToolStrip_Button_Line.Checked = false;
			this.toolToolStrip_Button_RectLine.Checked = false;
			this.toolToolStrip_Button_RectFill.Checked = false;
			this.toolToolStrip_Button_RectStrokeFill.Checked = false;
			this.toolToolStrip_Button_CircleFill.Checked = false;
			this.toolToolStrip_Button_CircleStrokeFill.Checked = false;
		}

		private void SetTool_CircleFill() {
			/* set current tool to filled circle */
			curActiveTool = ToolTypes.Tool_CircleFill;
			/* check filled circle button */
			this.toolToolStrip_Button_CircleFill.Checked = true;
			/* uncheck other tool buttons */
			this.toolToolStrip_Button_Pointer.Checked = false;
			this.toolToolStrip_Button_Selection.Checked = false;
			this.toolToolStrip_Button_Colorpicker.Checked = false;
			this.toolToolStrip_Button_Fill.Checked = false;
			this.toolToolStrip_Button_Line.Checked = false;
			this.toolToolStrip_Button_RectLine.Checked = false;
			this.toolToolStrip_Button_RectFill.Checked = false;
			this.toolToolStrip_Button_RectStrokeFill.Checked = false;
			this.toolToolStrip_Button_CircleLine.Checked = false;
			this.toolToolStrip_Button_CircleStrokeFill.Checked = false;
		}

		private void SetTool_CircleStrokeFill() {
			/* set current tool to stroked filled circle */
			curActiveTool = ToolTypes.Tool_CircleStrokeFill;
			/* check stroked filled circle button */
			this.toolToolStrip_Button_CircleStrokeFill.Checked = true;
			/* uncheck other tool buttons */
			this.toolToolStrip_Button_Pointer.Checked = false;
			this.toolToolStrip_Button_Selection.Checked = false;
			this.toolToolStrip_Button_Colorpicker.Checked = false;
			this.toolToolStrip_Button_Fill.Checked = false;
			this.toolToolStrip_Button_Line.Checked = false;
			this.toolToolStrip_Button_RectLine.Checked = false;
			this.toolToolStrip_Button_RectFill.Checked = false;
			this.toolToolStrip_Button_RectStrokeFill.Checked = false;
			this.toolToolStrip_Button_CircleLine.Checked = false;
			this.toolToolStrip_Button_CircleFill.Checked = false;
		}
		#endregion

		#region Tool toolstrip buttons
		private void toolToolStrip_Button_Pointer_Click(object sender, EventArgs e) {
			SetTool_Pointer();
		}

		private void toolToolStrip_Button_Selection_Click(object sender, EventArgs e) {
			SetTool_Selection();
		}

		private void toolToolStrip_Button_Colorpicker_Click(object sender, EventArgs e) {
			SetTool_ColorPicker();
		}

		private void toolToolStrip_Button_Fill_Click(object sender, EventArgs e) {
			SetTool_Fill();
		}

		private void toolToolStrip_Button_Line_Click(object sender, EventArgs e) {
			SetTool_Line();
		}

		private void toolToolStrip_Button_RectLine_Click(object sender, EventArgs e) {
			SetTool_RectLine();
		}

		private void toolToolStrip_Button_RectFill_Click(object sender, EventArgs e) {
			SetTool_RectFill();
		}

		private void toolToolStrip_Button_RectStrokeFill_Click(object sender, EventArgs e) {
			SetTool_RectStrokeFill();
		}

		private void toolToolStrip_Button_CircleLine_Click(object sender, EventArgs e) {
			SetTool_CircleLine();
		}

		private void toolToolStrip_Button_CircleFill_Click(object sender, EventArgs e) {
			SetTool_CircleFill();
		}

		private void toolToolStrip_Button_CircleStrokeFill_Click(object sender, EventArgs e) {
			SetTool_CircleStrokeFill();
		}
		#endregion

		/*
		 * CreateNewDocument()
		 * Creates a new document window after a NewFileDialog is shown.
		 */
		protected void CreateNewDocument() {
			/* bring up the new file dialog */
			NewFileDialog nfd = new NewFileDialog();
			nfd.ShowDialog();

			/* if the dialog was OK, then make a new file */
			if (nfd.DialogResult == System.Windows.Forms.DialogResult.OK) {
				/* xxx: somewhat temporary code to create a new form. */
				TileViewer a = new TileViewer();
				a.MdiParent = this;
				/* icon, caption */
				a.Icon = Porno_Graphic.Properties.Resources.Document;
				a.Text = String.Format("NewFile{0:d02}", NewFileCount);
				a.Show();

				/* increment counters */
				NewFileCount++;
				NumOpenDocuments++;
			}
		}

		/*
		 * ShowOpenFileDialog()
		 * Shows the open file dialog.
		 */
		protected void ShowOpenFileDialog() {
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = defaultLoadFilter;
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				/* load file data */

				/* create new TileViewer */
				//use ofd.FileName.EndsWith(".xxx") to determine input format/bpp setting

				//NumOpenDocuments++;
			}
		}

		/*
		 * ShowSaveFileDialog()
		 * Shows the save file dialog.
		 */

		

		protected string ShowOpenProjectDialog()
        {
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = Properties.Resources.MainForm_ProjectFileFilter;
			dialog.FilterIndex = 1;
			dialog.Title = Properties.Resources.MainForm_OpenProjectDialogTitle;
			if (dialog.ShowDialog() == DialogResult.OK)
				return dialog.FileName; // TODO: make a method for opening project
			else
				return null;
        }
		protected bool ShowSaveFileDialog(Classes.Project project)
        {
			SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = Properties.Resources.MainForm_ProjectFileFilter;
            dialog.FilterIndex = 1;
            dialog.Title = string.Format(Properties.Resources.MainForm_SaveProjectTitleFormat, mActiveProject.Project.DisplayName);
            if (dialog.ShowDialog() == DialogResult.OK)
                return SaveProject(project, dialog.FileName);
            else
                return false;
		}

		protected void ShowSaveBinaryDialog(byte[] data)
        {
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = Properties.Resources.MainForm_BinaryFileFilter;
			dialog.FilterIndex = 1;
			dialog.Title = Properties.Resources.MainForm_SaveBinaryDataTile;
			if (dialog.ShowDialog() == DialogResult.OK)
				File.WriteAllBytes(dialog.FileName, data);
		}

		protected void ShowExportTiledMapSet()
        {
			SaveFileDialog dialog = new SaveFileDialog();
			dialog.Filter = Properties.Resources.MainForm_TiledMapFileFilter;
			dialog.FilterIndex = 1;
			dialog.Title = Properties.Resources.MainForm_ExportToTiledTitle;
			if (dialog.ShowDialog() == DialogResult.OK)
				ExportTilesetFiles(dialog.FileName);
		}

		/*
		 * ShowOptionDialog()
		 * Shows the options dialog.
		 */
		protected void ShowOptionsDialog() {
			OptionsDialog opt = new OptionsDialog();
			if (opt.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				/* save yer options, buddy */
			}
		}

		#region CreateNewDocument callers
		/* Routines that call CreateNewDocument */
		private void mainToolStrip_Button_New_Click(object sender, EventArgs e) {
			CreateNewDocument();
		}

		private void menuItem_File_New_Click(object sender, EventArgs e) {
			CreateNewDocument();
		}
		#endregion

		#region ShowOpenFileDialog callers
		/* Routines that call ShowOpenFileDialog */
		private void mainToolStrip_Button_Open_Click(object sender, EventArgs e) {
			ShowOpenFileDialog();
		}

		private void menuItem_File_Open_Click(object sender, EventArgs e) {
			//ShowOpenFileDialog();
			OpenProject();
		}
		#endregion

		#region ShowSaveFileDialog callers
		/* Routines that call ShowSaveFileDialog */
		private void menuItem_File_SaveAs_Click(object sender, EventArgs e) {
            if (mActiveProject != null)
			    ShowSaveFileDialog(mActiveProject.Project);
		}
		#endregion

		#region ShowOptionsDialog callers
		private void mainToolStrip_Button_Options_Click(object sender, EventArgs e) {
			ShowOptionsDialog();
		}

		private void menuItem_Tools_Options_Click(object sender, EventArgs e) {
			ShowOptionsDialog();
		}
		#endregion

		#region Regular saving routines
		/* Routines that only call ShowSaveFileDialog if this is a new file */
		private void menuItem_File_Save_Click(object sender, EventArgs e) {
            if (mActiveProject != null)
            {
                if (mActiveProject.Project.FilePath != null)
                    SaveProject(mActiveProject.Project, mActiveProject.Project.FilePath);
                else
                    ShowSaveFileDialog(mActiveProject.Project);
            }
		}

		private void mainToolStrip_Button_Save_Click(object sender, EventArgs e) {

		}
		#endregion

		private void mainToolStrip_Button_Reload_Click(object sender, EventArgs e) {
			/* reload currently active document from disk */
		}

		#region Window management routines
		private void menuItem_Window_Editor_Click(object sender, EventArgs e) {
			/* bring tile editor to the front */
			//editorForm.BringToFront();
		}

		private void menuItem_Window_Arranger_Click(object sender, EventArgs e) {
			/* bring tile arranger to the front */
			//arrangerForm.BringToFront();
		}

		private void closeAllToolStripMenuItem_Click(object sender, EventArgs e) {
			/*foreach(Form f in this.MdiChildren){
				// somewhat hacky way of not closing the tile arranger and editor
				if(f.Name != arrangerForm.Name && f.Name != editorForm.Name){
					// todo: check if a window is "dirty"/needs to be save
					f.Close();
					NumOpenDocuments--;
				}
			}*/
		}
		#endregion

		#region Palette load/save routines
		private void loadPaletteToolStripMenuItem_Click(object sender, EventArgs e) {
			/* load palette data from file */
		}

		private void savePaletteToolStripMenuItem_Click(object sender, EventArgs e) {
			/* save palette data to file */
		}

		private void menu_PaletteItem_Import_Click(object sender, EventArgs e) {
			/* import palette from currently opened and active file */
		}
		#endregion

		#region Grid toggle
		private void viewerGridToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowViewerGrid = !ShowViewerGrid;
			//Porno_Graphic.Properties.Settings.Default.ViewerGrid = ShowViewerGrid;
			//Porno_Graphic.Properties.Settings.Default.Save();
			/* toggle TileViewer grid */
			// xxx: is this per-document or for all documents?
		}

		private void editorGridToolStripMenuItem_Click(object sender, EventArgs e) {
			ShowEditorGrid = !ShowEditorGrid;
			//Porno_Graphic.Properties.Settings.Default.EditorGrid = ShowEditorGrid;
			//Porno_Graphic.Properties.Settings.Default.Save();
			/* toggle TileEditor grid */
			//editorForm.ShowGrid = ShowEditorGrid;
		}

		private void menuItem_View_GridArranger_Click(object sender, EventArgs e) {
			ShowArrangerGrid = !ShowArrangerGrid;
			//Porno_Graphic.Properties.Settings.Default.ArrangerGrid = ShowArrangerGrid;
			//Porno_Graphic.Properties.Settings.Default.Save();
			/* toggle TileArranger grid */
			//arrangerForm.ShowGrid = ShowArrangerGrid;
		}
		#endregion

		private void cBox_ActivePaletteSet_SelectedIndexChanged(object sender, EventArgs e) {
			// update active palette set
		}

		protected void ShowPaletteSetDialog() {
			PaletteSets palSets = new PaletteSets();
			palSets.ShowDialog();
		}

		#region access palette set dialog
		private void menuItem_Palette_PalSets_Click(object sender, EventArgs e) {
			ShowPaletteSetDialog();
		}

		private void button_EditPalSets_Click(object sender, EventArgs e) {
			ShowPaletteSetDialog();
		}
		#endregion

		#region Drag/Drop handling
		private void MainForm_DragEnter(object sender, DragEventArgs e) {
			/* check if this is a file */
			if(e.Data.GetDataPresent(DataFormats.FileDrop,false)){
				// ok cool, it's a file, at least.
			}
		}

		private void MainForm_DragDrop(object sender, DragEventArgs e) {
			/* dragging and dropping an item (e.g. a file) onto the main window */
		}
        #endregion

        private void menuItem_File_Import_Click(object sender, EventArgs e)
        {
			NewProject();
        }

		private void NewProject()
        {
			ProfileSelector profileSelector = new ProfileSelector();
			if (profileSelector.ShowDialog() != DialogResult.OK)
				return;

			TileImporter importer = new TileImporter(this, profileSelector.SelectedProfile, profileSelector.SelectedProfilePath, string.Format(Porno_Graphic.Properties.Resources.MainForm_ImportProjectFormat, ++mImportCount));
			importer.Show();
		}

		public void CreateImportProject(Classes.GfxElementSet elementSet)
        {
			Classes.Project project = new Classes.Project(elementSet);
			BuildProject(elementSet, project);
		}

		public void CreateLoadedProject(Classes.GfxElementSet elementSet, string projectPath)
        {
			Classes.Project project = new Classes.Project(elementSet);
			project.FilePath = projectPath;
			project.ClearDirty();
			BuildProject(elementSet, project);
		}

		public void BuildProject(Classes.GfxElementSet elementSet, Classes.Project project)
        {
            TileViewer viewer = new TileViewer();
            viewer.MdiParent = this;
            viewer.ElementWidth = elementSet.ElementWidth;
            viewer.ElementHeight = elementSet.ElementHeight;
            viewer.Elements = elementSet.Elements;
			viewer.Palettes = elementSet.Palettes;
            viewer.PalettesBindingSource = new BindingSource();
            viewer.SelectedPalette = viewer.Palettes[0];
			viewer.Planes = elementSet.Planes;
			viewer.Text = elementSet.Name;

            ProjectState state = new ProjectState(project);
            state.TileViewer = viewer;

            viewer.Activated += new EventHandler(delegate (Object sender, EventArgs e)
            {
                mActiveProject = state;
            });

            viewer.FormClosing += new FormClosingEventHandler(delegate (object sender, FormClosingEventArgs e)
            {
                if (state.Project.Dirty)
                {
                    DialogResult result = MessageBox.Show(
                        string.Format(Properties.Resources.MainForm_ConfirmMessage_CloseWithoutSave, state.Project.DisplayName),
                        Properties.Resources.MainForm_ConfirmTitle_CloseWithoutSave,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.None,
                        MessageBoxDefaultButton.Button1);
                    switch (result)
                    {
                        case DialogResult.Yes:
                            if (state.Project.FilePath != null)
                                e.Cancel = !SaveProject(state.Project, state.Project.FilePath);
                            else
                                e.Cancel = !ShowSaveFileDialog(state.Project);
                            break;
                        case DialogResult.No:
                            e.Cancel = false;
                            break;
                        case DialogResult.Cancel:
                            e.Cancel = true;
                            break;
                    }
                }
            });

            viewer.FormClosed += new FormClosedEventHandler(delegate (object sender, FormClosedEventArgs e)
            {
                if (mActiveProject == state)
                    mActiveProject = null;
            });

            viewer.Show();
        }

        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            menuItem_File_Save.Enabled = mActiveProject != null;
			menuItem_ExportToTilEdMap.Enabled = mActiveProject != null;
			menuItemApplyTmx.Enabled = mActiveProject != null;
			MenuItemConvertTmxToGif.Enabled = mActiveProject != null;
			MenuItemSaveGraphicsData.Enabled = mActiveProject != null;
			saveProjectAsToolStripMenuItem.Enabled = mActiveProject != null;
            //menuItem_File_SaveAs.Enabled = mActiveProject != null;
            //menuItem_File_Reload.Enabled = (mActiveProject != null) && (mActiveProject.Project.FilePath != null);
        }

		private void projectToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
			propertiesToolStripMenuItem.Enabled = mActiveProject != null;
        }

		private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
			ProjectProperties projectProperties = new ProjectProperties(mActiveProject.Project.ImportMetadata, mActiveProject.Project.DisplayName);
			if (projectProperties.ShowDialog() == DialogResult.OK)
            {
				mActiveProject.Project.DisplayName = projectProperties.ProjectName;
				mActiveProject.TileViewer.Text = mActiveProject.Project.DisplayName;
            }
        }

        private bool SaveProject(Classes.Project project, string path)
        {
            try
            {
                project.Save(path);
                return true;
            }
            catch
            {
                // TODO: better error messages
                MessageBox.Show("Error saving project");
                return false;
            }
        }

		public void OpenProject()
		{
			string path = ShowOpenProjectDialog();

			if (path == null)
				return;

			Classes.ChunkReader reader = new Classes.ChunkReader(new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read));
			byte[] ProjectData = null;
			using (reader)
			{
				Classes.ChunkType CurrentChunk = reader.ReadChunkHeader();
				if (CurrentChunk != Classes.ChunkType.ProjectHeader)
					throw new Exception(string.Format("Invalid Porno-Graphic project file."));
				reader.CloseChunk();
				reader.StartDecompression();
				ProjectData = reader.ReadProjectContents();		// Create decompressed array of the project data
			}
			
			reader = new Classes.ChunkReader(new MemoryStream(ProjectData));

			ulong ProjectLength;
			ulong CurrentChunkLength;

			// GfxElementSetInfo variables
			uint GfxElementSetInfo_ElementWidth;
			uint GfxElementSetInfo_ElementHeight;
			string GfxElementSetInfo_Name;

			// GfxElement variables
			List<uint> ElementWidths = new List<uint>();
			List<uint> ElementHeights = new List<uint>();
			List<uint[]> PixelsList = new List<uint[]>();

			// IndexedPalette variables
			List<string> PaletteNames = new List<string>();
			List<uint> ColorCounts = new List<uint>();
			List<uint[]> PaletteReds = new List<uint[]>();
			List<uint[]> PaletteGreens = new List<uint[]>();
			List<uint[]> PaletteBlues = new List<uint[]>();

			// TileImportMetadata variables
			string TileImportMetadata_ProfileFile;
			string TileImportMetadata_ProfileName;
			string TileImportMetadata_RegionName;
			string TileImportMetadata_LayoutName;
			string TileImportMetadata_Offset;
			string TileImportMetadata_Planes;
			string[] TileImportMetadata_RomFilenames;
		
			using (reader)
            {
				Classes.ChunkType CurrentChunk = reader.ReadChunkHeader();
				if (CurrentChunk != Classes.ChunkType.GfxElementSet)
					throw new Exception(string.Format("Invalid header. Not a GfxElementSet."));
				ProjectLength = reader.GetCurrentLength();
				reader.AbortChunk();		// Finished reading GfxElementSet header (the chunk itself is the entire rest of the project file)

				// Start reading GfxElementSetInfo data.
				CurrentChunk = reader.ReadChunkHeader();
				if (CurrentChunk != Classes.ChunkType.GfxElementSetInfo)
					throw new Exception(string.Format("Invalid header. Not a GfxElementSetInfo."));
				CurrentChunkLength = reader.GetCurrentLength();
				GfxElementSetInfo_ElementWidth = reader.ReadUint();
				GfxElementSetInfo_ElementHeight = reader.ReadUint();
				GfxElementSetInfo_Name = reader.ReadString();
				reader.CloseChunk();    
				// Finished reading GfxElementSetInfo data.

				// Start reading GfxElements.
				CurrentChunk = reader.ReadChunkHeader();
				if (CurrentChunk != Classes.ChunkType.GfxElement)
					throw new Exception(string.Format("Invalid header. Not a GfxElement."));
				CurrentChunkLength = reader.GetCurrentLength();
				bool ReadingGfxElements = true;
				while (ReadingGfxElements)
                {
					uint GfxElementWidth = reader.ReadUint();
					uint GfxElementHeight = reader.ReadUint();

					uint n = 0;
					uint[] pixels = new uint[GfxElementWidth * GfxElementHeight];

					while (n < (uint)((CurrentChunkLength - 16U) / 4))
					{
						for (uint y = 0; y < GfxElementHeight; y++)
                        {
							for (uint x = 0; x < GfxElementWidth; x++)
                            {
								pixels[x + (y * GfxElementWidth)] = reader.ReadUint();
								n++;
							}
                        }
					}
                    PixelsList.Add(pixels);
					ElementWidths.Add(GfxElementWidth);
					ElementHeights.Add(GfxElementHeight);
					reader.CloseChunk();
					CurrentChunk = reader.ReadChunkHeader();
					CurrentChunkLength = reader.GetCurrentLength();
					if (CurrentChunk != Classes.ChunkType.GfxElement)		// Read GfxElements until a different header is encountered.
                    {
						ReadingGfxElements = false;
                    }
				}

				// Finished reading GfxElements.

				// Read IndexedPalettes

				if (CurrentChunk != Classes.ChunkType.IndexedPalette)
					throw new Exception("Invalid header. Not IndexedPalette.");

				bool ReadingPalettes = true;
				while (ReadingPalettes)
                {
					PaletteNames.Add(reader.ReadString());
					uint colorCount = reader.ReadUint();
					ColorCounts.Add(colorCount);
					uint[] reds = new uint[colorCount];
					uint[] greens = new uint[colorCount];
					uint[] blues = new uint[colorCount];
					for(int i = 0; i < colorCount; i++)
                    {
						reds[i] = reader.ReadUint();
						greens[i] = reader.ReadUint();
						blues[i] = reader.ReadUint();
                    }

					PaletteReds.Add(reds);
					PaletteGreens.Add(greens);
					PaletteBlues.Add(blues);

					reader.CloseChunk();
					CurrentChunk = reader.ReadChunkHeader();
					CurrentChunkLength = reader.GetCurrentLength();
					if (CurrentChunk != Classes.ChunkType.IndexedPalette) ReadingPalettes = false;     // Read IndexedPalettes until a different header is encountered.
                }


				// Finished reading IndexedPalettes

				if (CurrentChunk != Classes.ChunkType.TileImportMetadata)
					throw new Exception("Invalid header. Not TileImportMetadata.");

				TileImportMetadata_ProfileFile = reader.ReadString();
				TileImportMetadata_ProfileName = reader.ReadString();
				TileImportMetadata_RegionName = reader.ReadString();
				TileImportMetadata_LayoutName = reader.ReadString();
				TileImportMetadata_Offset = reader.ReadString();
				TileImportMetadata_Planes = reader.ReadString();

				// Read RomFilenames

				uint RomFilenamesCount = reader.ReadUint();
				TileImportMetadata_RomFilenames = new string[RomFilenamesCount];

				for (int n = 0; n < RomFilenamesCount; n++)
                {
					TileImportMetadata_RomFilenames[n] = reader.ReadString();
                }

				

				reader.CloseChunk();
			}

            // Begin assembling project

            Classes.GfxElement[] elements = new Classes.GfxElement[PixelsList.Count];
			Parallel.For(0, PixelsList.Count, index => { elements[index] = new Classes.GfxElement(PixelsList[index], ElementWidths[index], ElementHeights[index]); });

			Classes.TileImportMetadata metadata = new Classes.TileImportMetadata();
			metadata.ProfileFile = TileImportMetadata_ProfileFile;
			metadata.ProfileName = TileImportMetadata_ProfileName;
			metadata.RegionName = TileImportMetadata_RegionName;
			metadata.LayoutName = TileImportMetadata_LayoutName;
			metadata.Offset = TileImportMetadata_Offset;
			metadata.Planes = TileImportMetadata_Planes;
			metadata.RomFilenames = TileImportMetadata_RomFilenames;

			uint planes;
			if (uint.TryParse(TileImportMetadata_Planes, out planes))
			{
				Classes.GfxElementSet elementSet = new Classes.GfxElementSet();
				elementSet.Name = GfxElementSetInfo_Name;
				elementSet.ElementWidth = GfxElementSetInfo_ElementWidth;
				elementSet.ElementHeight = GfxElementSetInfo_ElementHeight;
				elementSet.Planes = planes;
				elementSet.Elements = elements;
				elementSet.ImportMetadata = metadata;

				// Construct palettes
				BindingList<Classes.IPalette> paletteSet = new BindingList<Classes.IPalette>();

				for (int p = 0; p < PaletteNames.Count; p++)
                {
					Classes.IndexedPalette palette = new Classes.IndexedPalette(ColorCounts[p], PaletteNames[p]);
					for (uint c = 0; c < palette.GetColorCount(); c++)
                    {
						palette.SetColor(Color.FromArgb((int)PaletteReds[p][c], (int)PaletteGreens[p][c], (int)PaletteBlues[p][c]), c);
                    }
					paletteSet.Add(palette);
                }

				elementSet.Palettes = paletteSet;
				CreateLoadedProject(elementSet, path);
			}
			else
				throw new Exception("Invalid 'Planes' value in TileImportMetadata");			
		}
		public void ExportTilesetFiles(string path)
		{
			string FileName = Path.ChangeExtension(path, null);
			string Name = Path.GetFileNameWithoutExtension(path);

			// write tileset PNG
			long ElementWidth = mActiveProject.TileViewer.ElementWidth;
			long ElementHeight = mActiveProject.TileViewer.ElementHeight;
			long ElementsCount = mActiveProject.TileViewer.Elements.Length;
			if (mActiveProject.TileViewer.SwapAxes)		// swap gfxelement width and height if rotated 90 or 270 degrees
            {
				long ElementWidthTemp = ElementWidth;
				ElementWidth = ElementHeight;
				ElementHeight = ElementWidthTemp;
            }
			long ColumnCount = mActiveProject.TileViewer.ColumnCount;
			long RowCount = ElementsCount / ColumnCount;
			long BitmapHeight = ElementHeight * RowCount;
			long BitmapWidth = ElementWidth * ColumnCount;
			if (ElementsCount % ColumnCount != 0)   // pad image height for remaining tiles that don't fill an entire row
            {
				BitmapHeight += ElementHeight;
				RowCount++;
			}
			Bitmap bitmap = new Bitmap((int)BitmapWidth, (int)BitmapHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
			Graphics graphics = Graphics.FromImage(bitmap);
			mActiveProject.TileViewer.DrawExportTileset(graphics, ElementsCount, RowCount, ColumnCount);
			bitmap.Save(FileName + ".png", System.Drawing.Imaging.ImageFormat.Png);

			//<tileset name="!{tileset_name}" tilewidth="!{tilewidth}" tileheight="!{tileheight}" 
			//tilecount="!{tilecount}" columns="!{columns}" offset="!{offset}" flipx="!{flipx}" flipy="!{flipy}" rotate="!{rotate}">

			// write Tiled tileset file
			//String template = File.ReadAllText("tiled_tileset_template.txt");
			String template = Porno_Graphic.Properties.Resources.tiled_tileset_template;
			template = template.Replace("!{tileset_name}", Name);
			template = template.Replace("!{tileset_image}", Name + ".png");
			template = template.Replace("!{tilewidth}", ElementWidth.ToString());
			template = template.Replace("!{tileheight}", ElementHeight.ToString());
			template = template.Replace("!{tilecount}", ElementsCount.ToString());
			template = template.Replace("!{columns}", ColumnCount.ToString());
			template = template.Replace("!{offset}", mActiveProject.Project.Offset.ToString());
			template = template.Replace("!{flipx}", mActiveProject.TileViewer.FlipX ? "1" : "0");
			template = template.Replace("!{flipy}", mActiveProject.TileViewer.FlipY ? "1" : "0");
			template = template.Replace("!{rotate}", mActiveProject.TileViewer.Rotate.ToString());
			File.WriteAllText(FileName + ".tsx", template);

			// write Tiled tilemap file
			//template = File.ReadAllText("tiled_tilemap_template.txt");
			template = Porno_Graphic.Properties.Resources.tiled_tilemap_template;
			//template = template.Replace("!{tilemapwidth}", "64");
			//template = template.Replace("!{tilemapheight}", "64");
			template = template.Replace("!{tilewidth}", ElementWidth.ToString());
			template = template.Replace("!{tileheight}", ElementHeight.ToString());
			template = template.Replace("!{tileset}", Name + ".tsx");
			File.WriteAllText(FileName + ".tmx", template);
		}

        private void menuItem_ExportToTilEdMap_Click(object sender, EventArgs e)
        {
			if (mActiveProject != null)
			ShowExportTiledMapSet();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
			OpenFileDialog openTiledMapDialog = new OpenFileDialog();
			openTiledMapDialog.Title = "Open Tiled Map";
			openTiledMapDialog.Filter = "Tiled map file (*.tmx)|*.tmx|All files(*.*)|*.*";
			openTiledMapDialog.FilterIndex = 1;
			openTiledMapDialog.Multiselect = false;
			if (openTiledMapDialog.ShowDialog() != DialogResult.OK)
				return;

			Classes.TiledLoader tiledLoader = new Classes.TiledLoader(openTiledMapDialog.FileName);
			Classes.TiledImportData tiledImportData = new Classes.TiledImportData(mActiveProject.TileViewer, tiledLoader.Map, tiledLoader.Tileset);
			Classes.GifWriter gifWriter = new Classes.GifWriter(tiledImportData);

			SaveFileDialog exportGifDialog = new SaveFileDialog();
			exportGifDialog.Title = "Export Tile Arrangement to indexed GIF";
			exportGifDialog.Filter = "CompuServe Graphics Interchange (*.gif)|*.gif|All files(*.*)|*.*";
			exportGifDialog.FilterIndex = 1;
			if (exportGifDialog.ShowDialog() != DialogResult.OK)
				return;
			gifWriter.DrawIndexedGif(exportGifDialog.FileName);
		}

        private void menuItemApplyTmx_Click(object sender, EventArgs e)
        {
			OpenFileDialog openTiledMapDialog = new OpenFileDialog();
			openTiledMapDialog.Title = "Open Tiled Map";
			openTiledMapDialog.Filter = "Tiled map file (*.tmx)|*.tmx|All files(*.*)|*.*";
			openTiledMapDialog.FilterIndex = 1;
			openTiledMapDialog.Multiselect = false;
			if (openTiledMapDialog.ShowDialog() != DialogResult.OK)
				return;

			Classes.TiledLoader tiledLoader = new Classes.TiledLoader(openTiledMapDialog.FileName);
			Classes.TiledImportData tiledImportData = new Classes.TiledImportData(mActiveProject.TileViewer, tiledLoader.Map, tiledLoader.Tileset);

			OpenFileDialog openIndexedGifDialog = new OpenFileDialog();
			openIndexedGifDialog.Title = "Open Indexed GIF";
			openIndexedGifDialog.Filter = "CompuServe Graphics Interchange (*.gif)|*.gif|All files(*.*)|*.*";
			openIndexedGifDialog.FilterIndex = 1;
			openIndexedGifDialog.Multiselect = false;
			if (openIndexedGifDialog.ShowDialog() != DialogResult.OK)
				return;

			Classes.GifReader gifReader = new Classes.GifReader(openIndexedGifDialog.FileName, tiledImportData);
		}

		public Classes.ExportDataSet WriteProjectTilesToSource(Classes.Project project, TileViewer tileViewer)
		{
			Classes.ExportDataSet exportData = new Classes.ExportDataSet();
			if (project == null) return null;

			string profilePath = AppDomain.CurrentDomain.BaseDirectory + @"\profiles";
			if (!Directory.Exists(profilePath))
			{
				MessageBox.Show(Properties.Resources.MainForm_ProfileFolderNotFound, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}

			Classes.ProfileList profileModel = new Classes.ProfileList(profilePath);
			if (profileModel.Profiles == null || profileModel.Profiles.Count < 1)
			{
				MessageBox.Show(Properties.Resources.MainForm_NoValidProfilesFound, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}

			List<Classes.GameProfile> profileList = new List<Classes.GameProfile>();
			foreach (Classes.ProfileLoadModel model in profileModel.Profiles)
				profileList.Add(model.Profile);

			Classes.GameProfile profile = profileList.Find(m => m.Name == project.ImportMetadata.ProfileName);

			if (profile == null)
			{
				MessageBox.Show(String.Format(Properties.Resources.MainForm_MatchingProfileNameNotFound, project.ImportMetadata.ProfileName), "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}

			byte[] data = null;
			Classes.LoadRegion region = null;

			// Find this project's region
			if (project.ImportMetadata.RegionName == "Flat file")
				data = File.ReadAllBytes(project.ImportMetadata.RomFilenames[0]);    // Flat file region isn't in any profile
			else
			{
				uint regionOffset = 0U;
				bool regionFound = false;
				foreach (Classes.LoadRegion loadRegion in profile.LoadRegions)
				{
					if (project.ImportMetadata.RegionName != loadRegion.Name)
						regionOffset++;
					else
					{
						regionFound = true;
						break;
					}
				}
				if (!regionFound)
				{
					MessageBox.Show("Region not found.", "ERROR");
				}
				region = profile.LoadRegions[regionOffset];
				data = region.LoadFiles(project.ImportMetadata.RomFilenames);    // Load original files
			}

			//Find offset to this project's char layout
			uint layoutOffset = 0U;
			bool layoutFound = false;
			foreach (Classes.CharLayout charLayout in profile.CharLayouts)
			{
				if (project.ImportMetadata.LayoutName != charLayout.Name)
					layoutOffset++;
				else
				{
					layoutFound = true;
					break;
				}
			}
			if (!layoutFound)
			{
				MessageBox.Show("Layout not found.", "ERROR");
			}
			for (uint ch = 0; ch < tileViewer.Elements.Length; ch++)
			{
				tileViewer.Elements[ch].WriteBinary(data, profile.CharLayouts[layoutOffset], project.Offset, ch);
			}

			exportData.Data = data;
			exportData.LoadRegion = region;
			return exportData;
		}

		private void MenuItemSaveFlatFile_Click(object sender, EventArgs e)
        {
			Classes.ExportDataSet exportData = WriteProjectTilesToSource(mActiveProject.Project, mActiveProject.TileViewer);
			ShowSaveBinaryDialog(exportData.Data);
		}

		private void MenuItemSplitRegions_Click(object sender, EventArgs e)
        {
			if (mActiveProject != null)
            {
				if (mActiveProject.Project != null)
                {
					SaveToSourceRoms();
                }
            }
        }

		private void SaveToSourceRoms()
        {
			Classes.ExportDataSet exportData = WriteProjectTilesToSource(mActiveProject.Project, mActiveProject.TileViewer);
            if (exportData.LoadRegion != null)
            {
                exportData.LoadRegion.SaveFiles(exportData.Data, mActiveProject.Project.ImportMetadata.RomFilenames);
            }
            else
            {
                // Flat file (not a profile region)
                FileStream stream = new FileStream(mActiveProject.Project.ImportMetadata.RomFilenames[0], FileMode.OpenOrCreate, FileAccess.Write);
                try { stream.Write(exportData.Data, 0, exportData.Data.Length); }
                finally { stream.Close(); }
            }
        }
    }
}
