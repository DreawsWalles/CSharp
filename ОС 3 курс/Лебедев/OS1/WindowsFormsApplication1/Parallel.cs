using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    //клсаа буффер - 2 метода - читать и писать - поля текстбокс, стек в методе read и write lockи(из поставщика и потребителя - буфер.readб , буфер.write)
    //в OwnStack поставщики, потребители

    class Parallel
    {
        List<Thread> ThCst = null;
        List<Thread> ThPrv = null;
        private int CustMax = 3, ProvMax = 3;
        //private TextBox goods;
        private TextBox OutMessageP;
        private TextBox OutMessageC;

        private OwnStack OS;

        public Parallel(OwnStack _OS, TextBox _OutMessageC, TextBox _OutMessageP)
        {
            OS = _OS;
            OutMessageC = _OutMessageC;
            OutMessageP = _OutMessageP;
            ThCst = new List<Thread>();
            ThPrv = new List<Thread>();
        }

        public void ControlProcess()
        {
            Random rand = new Random();
            int csCnt = 1, prCnt = 1;
               
                       
            while (true)
            {
                if (rand.Next(2) == 0)
                {
                    int i = rand.Next(3);
                    Customer customer = new Customer(OutMessageC, OS, csCnt);
                    csCnt = rand.Next(3) + 1;
                    Thread Tcustomer = new Thread(customer.Take);
                    ThCst.Add(Tcustomer);
                    Tcustomer.Start();   
                    
                }
                else
                {
                    int j = rand.Next(3);
                    Provider provider = new Provider(OutMessageP, OS, prCnt);
                    prCnt = rand.Next(3) + 1;
                    Thread Tprovider = new Thread(provider.Provide);
                    ThPrv.Add(Tprovider);
                    Tprovider.Start();

                }
                
                
         
                Thread.Sleep(rand.Next(900, 1900));
            }
        }

        public void PauseProcess()
        {
            for (int i = 0; i < ThCst.Count; i++)
            {
                if (ThCst[i].ThreadState == ThreadState.Running || ThCst[i].ThreadState == ThreadState.WaitSleepJoin)
                    ThCst[i].Suspend();
            }
            for (int i = 0; i < ThPrv.Count; i++)
            {
                if (ThPrv[i].ThreadState == ThreadState.Running || ThPrv[i].ThreadState == ThreadState.WaitSleepJoin)
                    ThPrv[i].Suspend();
            }
        }

        public void StopProcess()
        {
            for (int i = 0; i < ThCst.Count; i++)
                ThCst[i].Abort();
            for (int i = 0; i < ThPrv.Count; i++)
                ThPrv[i].Abort();
            OS.stk.Clear();
        }

        public void ResumeProcess()
        {
            for (int i = 0; i < ThCst.Count; i++)
            {
                if (ThCst[i].ThreadState == ThreadState.Suspended)
                    ThCst[i].Resume();
            }
            for (int i = 0; i < ThPrv.Count; i++)
            {
                if (ThPrv[i].ThreadState == ThreadState.Suspended)
                    ThPrv[i].Resume();
            }
        }
    }
}
