using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zadacha_1
{
    public class Writer : IThread
    {
        public Writer()
        {
        }
        BlockingQueue<int> buffer = BlockingQueue<int>.GetInstanse();
        public Thread MainThread { get; set; }
        private static object Locker = new object();

        public void Run()
        {

            bool successAdd = true;
            while (successAdd)
            {

                Thread.Sleep(1);
                Random rand = new Random(DateTime.Now.Millisecond);

                int newValue = rand.Next(1, 20);


                if (!BlockingQueue<int>.GetInstanse().TryEnqueue(newValue))
                {
                    successAdd = false;
                }


                Thread.Sleep(new Random(DateTime.Now.Millisecond).Next(1500, 3000));
            }
        }
    }
}
