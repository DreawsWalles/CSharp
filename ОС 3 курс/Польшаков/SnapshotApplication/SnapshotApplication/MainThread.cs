using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SnapshotApplication
{
    class MainThread
    {
        private Thread thread;
        private uint n;
        private IEnumerable<HEAPENTRY32> blocks;
        private IEnumerable<PROCESSENTRY32> proccess;

        public Thread CurrentThread { get { return thread; } }

        public delegate void SendInfo(IEnumerable<string> infos);
        public event SendInfo ShowLarge;

        public MainThread(uint n)
        {
            this.n = n;
            thread = new Thread(new ThreadStart(DoWork));
        }

        private void DoWork()
        {
            IEnumerable<PROCESSENTRY32> process = Helper.GetProcessList();
            IEnumerable<string> description = process.AsParallel().Where(proc =>
                Helper.GetBlocks(proc.th32ProcessID).AsParallel().Any(x => x.dwBlockSize > n)
            ).Select(x => x.ToString()).ToList();

            ShowLarge(description);
        }

        public void Start()
        {
            thread.Start();
        }
    }
}
