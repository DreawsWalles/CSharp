using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace OS1
{
    class Reader: Worker
    {
        public Reader(string WorkerName, int CountActions, TextBox Log)
            : base(WorkerName, CountActions, Log)
        {
        }

        public override void DoWork()
        {
            while (!stop && performedActions < countActionsToDo)
                if(Buffer.RecordsCount > 0)
                {
                    Logger temp = () => { log.Text += "Reader " + Name + " removed record '" + Buffer.WorkWithBuffer(this) + "'" + Environment.NewLine; };
                    log.Invoke(temp);
                    ++performedActions;
                }
        }
    }
}
