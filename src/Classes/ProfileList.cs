using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Porno_Graphic.Classes
{
    public class ProfileList
    {
        private string mProfileFolderPath;
        private List<ProfileLoadModel> mProfiles;
        private List<string> mErrorMessages;
        public string ProfileFolderPath { get { return mProfileFolderPath; } set { mProfileFolderPath = value; } }
        public List<ProfileLoadModel> Profiles { get { return mProfiles; } set { mProfiles = value; } }
        public List<string> ErrorMessages { get { return mErrorMessages; } private set { mErrorMessages = value; } }

        public ProfileList(string profileFolderPath)
        {
            mProfiles = new List<ProfileLoadModel>();
            mProfileFolderPath = profileFolderPath;
            string[] files = Directory.GetFiles(mProfileFolderPath, "*.profile");
            XmlSerializer profileLoader = new XmlSerializer(typeof(Classes.GameProfile));
            StreamReader reader = null;
            foreach (string path in files)
            {
                Classes.GameProfile profile = null;
                try
                {
                    reader = new StreamReader(path);
                    profile = (Classes.GameProfile)profileLoader.Deserialize(reader);
                }
                catch
                {
                }
                finally
                {
                    if (reader != null)
                        reader.Close();
                }

                if (profile == null) { ErrorMessages.Add(String.Format("Error loading profile {0}", Path.GetFileName(path))); }
                else { Profiles.Add(new ProfileLoadModel(profile, path)); }
            }

            Profiles.Sort();
        }
    }
}
