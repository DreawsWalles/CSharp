using System;
using System.Windows.Forms;

namespace OS1
{
    static class WorkerFactory
    {
        static int writersCount = 0;

        static int readersCount = 0;

        static bool IsWriter = true;

        public static Worker GenerateWorker(TextBox ReaderLog, TextBox WriterLog)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int actionsCount = rnd.Next(1, 5);
            Worker result = null;
            if (IsWriter)
                result = new Writer("Writer" + (++writersCount).ToString(), actionsCount, WriterLog);
            else
                result = new Reader("Reader" + (++readersCount).ToString(), actionsCount, ReaderLog);
            IsWriter = !IsWriter;
            return result;
        }
    }
}
