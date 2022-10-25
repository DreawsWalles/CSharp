using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OS.Task3
{
    class ProcessModules
    {
        public ProcessEntry32 Process { get; set; }
        public ModuleEntry32 BestModule { get; set; }

        public ProcessModules()
        {
            BestModule = new ModuleEntry32();
        }
    }
}
