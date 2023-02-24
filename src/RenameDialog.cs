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
    public partial class RenameDialog : Form
    {
        public RenameDialog(string text)
        {
            InitializeComponent();
            renameBox.Text = text;
            this.Text = "Rename + '" + text + "'";
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }
        public string RenamedText { get { return renameBox.Text; } }
    }
}
