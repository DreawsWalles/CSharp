using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OS.Task3
{
    class Solution
    {
       public static void Solve(TextBox info, TextBox res)
        {
            ToolHelp32 tmp = new ToolHelp32();
            List<ProcessEntry32> process_list = new List<ProcessEntry32>();

           //выводим инфу обо всех процессах
            foreach (var i in tmp.GetProcessList())
            {
                process_list.Add(i);
                info.Text += i.ToString();
            }

            UInt64 maxcount = 0, id = 0;
            foreach (var i in tmp.GetHeapList())
            {
                UInt64 t = tmp.CountFixedSpaceInHeap(i.th32ProcessID, i.th32HeapID);
                if (t > maxcount)
                {
                    maxcount = t;
                    id = i.th32ProcessID;
                }
            }

            res.Text = process_list.Find(x => x.th32ProcessID == id).ToString();
            res.Text += "Свободая память : " + (maxcount / 1024).ToString() + " Кбайт";
        }
    }
}
