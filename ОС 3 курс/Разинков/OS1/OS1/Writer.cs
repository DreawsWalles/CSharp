using System;
using System.Windows.Forms;

namespace OS1
{
    class Writer: Worker
    {
        public Writer(string WorkerName, int CountActions, TextBox Log)
            : base(WorkerName, CountActions, Log) { }

        public override void DoWork()
        {
            while (!stop && performedActions < countActionsToDo)
            {
                if(Buffer.RecordsCount < Buffer.MaxBufferSize)
                {
                    ++performedActions;
                    Logger temp = () => { log.Text += Name + " added record #" + PerformedActions.ToString() + Environment.NewLine; };
                    log.Invoke(temp);
                    Buffer.WorkWithBuffer(this);
                }
            }
        }
    }
}
