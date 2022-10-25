using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace Task3._7
{
    class Model
    {

        ToolHelp32 th;
        List<HeapEntry32> heapEntrys;
        Thread worker;
        public int MinLinAdress { get; private set; }
        public int MaxLinAdress { get; private set; }

        public List<HeapEntry32> HeapEntrys
        {
            get
            {
                if (heapEntrys.Count == 0)
                    ThreadHelper.ThreadStart(worker, GetHeapEntrys);

                return heapEntrys;
            }
        }

        public Model()
        {
            th = new ToolHelp32();
            heapEntrys = new List<HeapEntry32>();
        }


        void GetHeapEntrys()
        {

            foreach (var heapEntry in th.GetHeapInfo())
            {
                heapEntrys.Add(heapEntry);
            }
            int max, min;
            max = 0;
            min = (int)heapEntrys[0].dwAdress;
            foreach(var entry in heapEntrys)
            {
               
                int tmp = (int)entry.dwAdress;
                max = tmp;
                if (min > max)
                    max = min;
                else if (min > tmp)
                    min = tmp;
            }
        }

        public string getProcessInfo(uint th32ProcessID)
        {
            var proc = Process.GetProcessById((int)th32ProcessID);

            StringBuilder str = new StringBuilder();

            str.Append("Информация о процессе:").Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Имя: ").Append(proc.ProcessName).Append(Environment.NewLine)
                .Append("Идентификатор процесса: ").Append(proc.Id).Append(Environment.NewLine)
                .Append("Кол-во потоков процесса: ").Append(proc.Threads.Count).Append(Environment.NewLine);

            return str.ToString();
        }
    }
}
