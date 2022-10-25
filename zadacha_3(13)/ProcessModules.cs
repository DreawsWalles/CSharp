using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_3_13_
{
    public class ProcessModules
    {
        public ProcessEntry32 Process { get; set; }

        public uint sizeModulse { get; set; }

        public ProcessModules()
        {
            sizeModulse = 0;
        }
    }
}
