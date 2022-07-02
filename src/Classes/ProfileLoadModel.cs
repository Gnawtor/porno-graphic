using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Porno_Graphic.Classes
{
    public class ProfileLoadModel : IComparable
    {
        private GameProfile mProfile;
        private string mProfilePath;
        public GameProfile Profile { get { return mProfile; } }
        public string ProfilePath { get { return mProfilePath; } }
        public ProfileLoadModel(GameProfile profile, string profilePath)
        {
            mProfile = profile;
            mProfilePath = profilePath;
        }

        public override string ToString()
        {
            return mProfile.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            ProfileLoadModel comparand = obj as ProfileLoadModel;

            return string.Compare(this.ToString(), comparand.ToString(), true, CultureInfo.CurrentCulture);
        }
    }
}
