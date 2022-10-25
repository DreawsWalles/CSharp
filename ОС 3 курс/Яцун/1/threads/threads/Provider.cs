using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace threads
{
    class Provider
    {
        MainForm.PrintStr PrintOnStatus;

        MutStack mutStack;
        TextBox tbStatus;      

        public Provider(MutStack varStack, TextBox varStatus, MainForm.PrintStr varPrintOnStatus)
        {
            mutStack = varStack;
            tbStatus = varStatus;

            PrintOnStatus = varPrintOnStatus;
        }

        public void AddProduct()
        {
            Random r = new Random();
            while (true)
            {
                int t = r.Next(500, 2000);
                Thread.Sleep(t);
                
                int x = r.Next(300);
                PrintOnStatus("Поставщик добавляет: " + x.ToString() + Environment.NewLine);
                mutStack.Push(x);          
            }
        }
    }
}
