using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Porno_Graphic
{
    public partial class ProfileSelector : Form
    {
        private Classes.ProfileList mProfileList;
        private Classes.ProfileLoadModel mSelectedProfile;
        public Classes.ProfileList ProfileList { get { return mProfileList; } set { mProfileList = value; } }
        public Classes.GameProfile SelectedProfile { get { return mSelectedProfile.Profile; } }
        public string SelectedProfilePath { get { return mSelectedProfile.ProfilePath; } }

        

        public ProfileSelector()
        {
            InitializeComponent();
            labelErrorMessage.Text = String.Empty;
            buttonCancel.Click += buttonCancel_Click;
            string profilePath = AppDomain.CurrentDomain.BaseDirectory + @"\profiles";
            if (Directory.Exists(profilePath))
            {
                ProfileList = new Classes.ProfileList(profilePath);
                if(ProfileList.Profiles.Count != 0)
                {
                    listBoxProfiles.DataSource = ProfileList.Profiles;
                    buttonOK.Click += buttonOK_Click;

                    if(ProfileList.ErrorMessages != null && ProfileList.ErrorMessages.Count > 0)
                    {
                        buttonViewErrors.Visible = true;
                        buttonViewErrors.Enabled = true;
                        buttonViewErrors.Click += buttonViewErrors_Click;
                        labelErrorMessage.Text = String.Format("{0} error{1} found while attemping to load profiles! Click 'View Errors' for more information.", ProfileList.ErrorMessages.Count, ProfileList.ErrorMessages.Count > 1 ? "s" : "");
                    }
                }
                else
                {
                    buttonOK.Enabled = false;
                    labelErrorMessage.Text = "ERROR: No profiles found!";
                }
            }
            else
            {
                buttonOK.Enabled = false;
                labelErrorMessage.Text = "ERROR: Profile directory not found in executable folder!";
            }
        }
         
        private void buttonOK_Click(object sender, EventArgs e)
        {
            mSelectedProfile = ProfileList.Profiles[listBoxProfiles.SelectedIndex];
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonViewErrors_Click(object sender, EventArgs e)
        {
            string errors = String.Empty;
            foreach (string error in ProfileList.ErrorMessages) { errors += error + Environment.NewLine; }
            TextDisplayer errorDisplay = new TextDisplayer(errors, "Profile Errors");
            errorDisplay.ShowDialog();
        }
    }
}
