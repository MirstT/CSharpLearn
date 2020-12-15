using System;
using System.Collections.Generic;
using System.Text;

namespace _2048
{
    struct Location
    {
        public int Rindex { get; set; }
        public int CIndex { get; set; }

        public Location(int rIndex,int cIndex):this()
        {
            this.Rindex = rIndex;
            this.CIndex = cIndex;
        }
    }
}
