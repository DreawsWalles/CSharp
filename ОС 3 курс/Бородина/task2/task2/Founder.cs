using System;
using System.IO;

namespace task2
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

        public void CountSameDates(out int cnt)
        {
            cnt = 0;
            foreach (string file in RsdnDirectory.GetFilse(path))
                if (File.GetLastWriteTime(path + "\\" + file) == File.GetLastAccessTime(path + "\\" + file))
                    cnt++;
            foreach (string dir in RsdnDirectory.GetAllDirectories(path))
            {
                foreach (string file in RsdnDirectory.GetFilse(dir))
                {
                    if (File.GetLastWriteTime(path + "\\" + file) == File.GetLastAccessTime(path + "\\" + file))
                        cnt++;
                }
            }
        }
    }
}
