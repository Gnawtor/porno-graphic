using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Porno_Graphic.Classes
{
    public class ExportDataSet
    {
        private LoadRegion mLoadRegion;
        private byte[] mData;

        public LoadRegion LoadRegion { get { return mLoadRegion; } set { mLoadRegion = value; } }
        public byte[] Data { get { return mData; } set { mData = value; } }

        public ExportDataSet()
        {

        }
    }
}
