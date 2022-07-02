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
    public partial class TextDisplayer : Form
    {
        public TextDisplayer(string displayText, string windowTitle)
        {
            InitializeComponent();
            Text = windowTitle;
            textBox.Text = displayText;

            buttonClose.Click += buttonClose_Click;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
