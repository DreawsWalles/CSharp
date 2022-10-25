using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace threads
{
    class Consumer
    {
        MainForm.PrintStr PrintOnStatus;
        string name;
        Thread consumerThread;
        MutStack mutStack;
        int n;

        public Consumer(MutStack varStack, string varName, MainForm.PrintStr varPrintOnStatus, int varN)
        {
            n = varN;
            mutStack = varStack;
            name = varName;        
            PrintOnStatus = varPrintOnStatus;
            consumerThread = new Thread(new ThreadStart(TakeProdut));
            consumerThread.Start();
            PrintOnStatus("Создался потребитель - [" + name + "], со счетчиком: " + n.ToString() + Environment.NewLine);
        }

        public void TakeProdut()
        {
            Random r = new Random();
            int t = r.Next(500, 2000);            
            Thread.Sleep(t);

            int? x = null;

            while (x == null || n>0)
            {
                if (MutStack.generalStack.Count > 0)
                {
                    x = mutStack.Pop();
                    n--;
                }

                if(x != null)
                {
                    PrintOnStatus("Потребитель - [" + name + "] берет товар: " + x.ToString() + ", осталось взять: " + n.ToString() + Environment.NewLine);
                }
                else
                {
                    PrintOnStatus("Для потребителя - [" + name + "] нет товара" + Environment.NewLine);
                }
                Thread.Sleep(1000);
            }        
        }
    }
}
