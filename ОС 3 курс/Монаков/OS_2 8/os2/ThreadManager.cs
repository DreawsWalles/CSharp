using System;
using System.Threading;
using System.Windows.Forms;

namespace os2
{
    class ThreadManager
    {
        private Thread _tr;
        private Label _lbl1, _lbl2;
        private Searcher _s1,_s2;
      
        public ThreadManager(string p1, string p2,Label t1, Label t2)
        {
            _s1 = new Searcher(p1);
            _s2 = new Searcher(p2);

            _lbl1 = t1;
            _lbl2 = t2;

            _tr = new Thread(this.Start);
            _tr.Start();
        }

        private void Start()
        {
            Thread thread_1 = new Thread(_s1.CountHiddens);
            Thread thread_2 = new Thread(_s2.CountHiddens);

            thread_1.Start();
            thread_2.Start();

            thread_1.Join();
            thread_2.Join();

            _lbl1.Invoke(new Action(() => { _lbl1.Text = _s1.GetResult(); }));
            _lbl2.Invoke(new Action(() => { _lbl2.Text = _s2.GetResult(); }));
            
        }

    }
}
