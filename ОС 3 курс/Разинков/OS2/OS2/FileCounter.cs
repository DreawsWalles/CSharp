using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace OS2
{
    static class FileCounter
    {
        public static void CountFiles(DirectoryFileCountInfo Info)
        {
            ThreadStart f = () =>
            {
                Info.Count = RsdnDirectory.GetFiles(Info.Path).Count();
                List<string> AllDirs = RsdnDirectory.GetAllDirectories(Info.Path).ToList<string>();
                foreach(string dir in AllDirs)
                {
                    Info.Count += RsdnDirectory.GetFiles(dir).Count();
                }
            };
            Thread t = new Thread(f);
            t.Start();
        }
    }
}
