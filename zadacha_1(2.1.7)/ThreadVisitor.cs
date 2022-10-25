using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zadacha_1
{
    public class ThreadVisitor
    {
        //навесить на новый поток Run метод из аргумента
        public void SetNeedCharacteristics(IThread threading, string name)
        {
            threading.MainThread = new Thread(threading.Run);
            threading.MainThread.Name = threading.MainThread.Name + name;
            threading.MainThread.IsBackground = true;
        }
        public void StartThread(IThread thread)
        {
            thread.MainThread.Start();
        }
        public void Kill(IThread thread)
        {
            thread.MainThread.Abort();
            thread.MainThread.Join(100);
        }
    }
}
