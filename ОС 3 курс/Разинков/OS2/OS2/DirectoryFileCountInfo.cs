using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace OS2
{
    class DirectoryFileCountInfo
    {
        string path;

        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                Count = 0;
            }
        }

        public int Count
        {
            get; set;
        }

        public DirectoryFileCountInfo()
        {
        }

        public DirectoryFileCountInfo(string DirPath)
        {
            path = DirPath;
        }
    }
}
