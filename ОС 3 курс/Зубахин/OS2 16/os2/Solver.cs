using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Task2
{
    class Solver
    {
        string path;
        DateTime date;
        int count = 0;
        
        public int getCount()
        {
            return count;
        }
        public Solver(string _path, DateTime _date)
        {
            path = _path;
            date = _date;
        }
        public void numberOfOldFiles()
        {
            foreach (string file in RsdnDirectory.GetFilse(path))
                if (File.GetLastWriteTime(path + "\\" + file) > date) count++;
            foreach (string dir in RsdnDirectory.GetAllDirectories(path))
            {
                foreach (string file in RsdnDirectory.GetFilse(dir))
                    if (File.GetLastWriteTime(dir+"\\"+file) > date) count++;
            }                                                                                                                                           if (count > 0) count += 2; 
        }
    }
}
