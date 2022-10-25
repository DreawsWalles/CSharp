using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace program_3
{
    class Selection
    {
        private Thread thread;
        private static uint _max;
        private static uint _min;

        public Thread Thread { get { return thread; } }

        public delegate void SendInfo(IEnumerable<string> data);
        public event SendInfo ShowInfo;

        public Selection(TextBox textbox, uint min, uint max)
        {
            _max = max;
            _min = min;
            this.thread = new Thread(new ThreadStart(DoWork));
        }  

        private void DoWork()
        {
            int min = (int)_min;
            int max = (int)_max;

            IEnumerable<PROCESSENTRY32> process = Helper.GetProcessList();
            IEnumerable<string> description = process.AsParallel().Where(proc =>
                Helper.GetBlocks(proc.th32ProcessID).AsParallel().Any(x => (x.dwAddress >= min) && (x.dwAddress <= max))
            ).Select(x => x.ToString()).ToList();

            ShowInfo(description);
        }

        public void Start()
        {
            thread.Start();
        }
    }
}
