using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    class PageHandler
    {
        private PageList _pages;
        private Thread _thread;
        private TextBox _output;
        private int _pageCount;
        public bool isAlive { get; private set; }

        public PageHandler(PageList pages, TextBox output)
        {
            _pages = pages;
            _output = output;
            _thread = new Thread(Run);
            _thread.Start();
            isAlive = true;
        }

        private void Run()
        {
            _pageCount = new Random().Next(1, 5);

            int no = new Random().Next(1, 100);

            while (!_pages.Add(no))
            {
                _output.Invoke(
                    new Action(() => _output.Text += "Not enough free memory to create new pages" + Environment.NewLine));
                _output.Invoke(
                    new Action(() =>_output.Text +="Thread deletes pages with number " + _pages.DeleteOldest() + " to free some memory" + Environment.NewLine));
            }

            _output.Invoke(
                new Action(() => _output.Text += "Thread creates pages with number " + no + Environment.NewLine));

            Thread.Sleep(new Random().Next(3500, 7500));

            if (_pages.DeleteByNum(no))
                _output.Invoke(
                    new Action(() => _output.Text += "Thread deletes pages with number " + no + Environment.NewLine));
            else
                _output.Invoke(
                    new Action(
                        () =>
                            _output.Text +=
                                "Thread can not delete pages with number " + no + " for they do not exist anymore" +
                                Environment.NewLine));
            isAlive = false;
        }

        public void Halt()
        {
            _thread.Abort();
            isAlive = false;
        }

        public void Pause()
        {
            //if ((_thread.ThreadState & ThreadState.Running) == ThreadState.Running)
            try
            {
                _thread.Suspend();
            }
            catch (Exception)
            {
            }
        }

        public void Continue()
        {
            try
            {
                _thread.Resume();
            }
            catch (Exception)
            {
            }
        }
    }
}
