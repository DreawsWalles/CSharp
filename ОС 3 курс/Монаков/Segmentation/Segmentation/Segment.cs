using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segmentation
{
    class Segment
    {
        public  int size {get; private set;}
        public int number { get; private set; }
        public bool isTaken { get; set; }
        public int adrr { get; set; }
        public Segment(int si,int num, bool taken = false)
        {
            size = si;
            number = num;
            isTaken = taken;
        }
    }
}
