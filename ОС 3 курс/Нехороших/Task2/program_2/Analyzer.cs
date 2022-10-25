using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace program_2
{
    
    class Analyzer
    {
        public delegate void ShowReadOnlyInDir(string a);
        public event ShowReadOnlyInDir ShowROCountInDir1;
        public event ShowReadOnlyInDir ShowROCountInDir2;
        string dir1;
        string dir2;
        int c1;
        int c2;

        public Analyzer(string d1, string d2)
        {
            dir1 = d1;
            dir2 = d2;
            c1 = 0;
            c2 = 0;
        }
        public void Solution()
        {
            Thread CountInDir1 = new Thread(new ThreadStart(new Action(()=>{c1 = RsdnDirectory.CountReadOnly(dir1);})));
            Thread CountInDir2 = new Thread(new ThreadStart(new Action(() => { c2 = RsdnDirectory.CountReadOnly(dir2); })));
            CountInDir1.Start();
            CountInDir2.Start();
            CountInDir1.Join();
            CountInDir2.Join();

            ShowROCountInDir1(c1.ToString());
            ShowROCountInDir2(c2.ToString());
        }
    }
}
