using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;


namespace Task1
{

    class ThreadCreator
    {
        // Писатель
        private Thread myWriter;         // Поток-писатель
        private List<Thread> Readers;  // Список потоков-читателей

        private TextBox output;
        private TextBox pritbuf;

        public ThreadCreator(TextBox tb1, TextBox tb2)
        {
            Readers = new List<Thread>();
            output = tb1;
            pritbuf = tb2;
        }

        public void Start()
        {
            Writer writer = new Writer(output, pritbuf);
            myWriter = new Thread(new ThreadStart(writer.WriteInfo));
            myWriter.Start();

            Random rnd = new Random();
            while (true)
            {
                Thread.Sleep(rnd.Next(1500, 5000));
                Reader reader = new Reader(output, pritbuf);

                Thread tReader = new Thread(reader.ReadInfo);
                Readers.Add(tReader);
                tReader.Start();
            }
        }

        //закончитть
        public void Stop()
        {
            myWriter.Abort();
            for (int i = 0; i < Readers.Count; i++)
                Readers[i].Abort();
            Buffer.Buff.Clear();
        }

    }
}
