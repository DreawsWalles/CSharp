using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace os2
{
    class Founder
    {
        string path;
        int count = 0;
        
        public int getCount()
        {
            return count;
        }
        public Founder(string _path)
        {
            path = _path;
        }
        public void countYungFiles()
        {
            foreach (string dir in RsdnDirectory.GetAllDirectories(path))
            {
                foreach (string file in RsdnDirectory.GetFilse(dir))
                {
                    FileAttributes attributes = File.GetAttributes(dir + "\\" + file);
                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        count++;
                }
            } 
        }
    }
}
