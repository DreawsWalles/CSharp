using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS.Task3
{
    class ProcessModules
    {
        public ProcessEntry32 Process { get; set; }

        public uint sizeModulse { get; set; }

        public ProcessModules()
        {
            sizeModulse = 0;
        }
    }
}
