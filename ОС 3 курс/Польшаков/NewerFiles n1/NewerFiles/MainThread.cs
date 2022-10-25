using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewerFiles
{
    class MainThread
    {
        private Thread thread;
        private Finder finder1, finder2;

        public delegate void GetFiles(IEnumerable<FileInfo> files);
        public event GetFiles ShowOlderFiles;

        public Thread CurrentThread { get { return thread; } }

        public MainThread(Finder finder1, Finder finder2)
        {
            this.finder1 = finder1;
            this.finder2 = finder2;
            thread = new Thread(new ThreadStart(Find));
        }

        public void Find()
        {
            finder1.StartWork();
            finder2.StartWork();
            finder1.CurrentThread.Join();
            finder2.CurrentThread.Join();

            DateTime date = finder2.GetOlderDate();
            IEnumerable<FileInfo> older = finder1.GetOlderThan(date);
            ShowOlderFiles(older);
        }

        public void StartWork()
        {
            thread.Start();
        }
    }
}
