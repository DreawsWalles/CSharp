using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task1._2._3._3
{
    class Model
    {
        Buffer buffer;
        Console console;
        Writer writer;
        Thread workerWriter;
        private volatile bool shouldStop = false;

        public Model(Console console)
        {
            buffer = new Buffer(15, console);
            this.console = console;
            writer = new Writer(buffer);
            workerWriter = new Thread(writer.Add);
        }


        public void RequestStop()
        {




            shouldStop = true;
            workerWriter.Abort();
            
            console.printMessage(Environment.NewLine + Environment.NewLine + "Поток - писатель прекратил своё существование =(!" + Environment.NewLine + Environment.NewLine);
            
        }

        public void loop()
        {
            if(workerWriter.ThreadState == ThreadState.Aborted)
            {
                workerWriter = new Thread(writer.Add);
                workerWriter.Start();
            }
            else 
                workerWriter.Start();

            

            while (!shouldStop)
            {
                Thread reader = null;
                if (new Random().Next(7) > 3)
                    reader = new Thread(new Reader(buffer).Delete);
                Thread.Sleep(2000);

                if (reader != null)
                {
                    reader.Start();
                    

                    reader.Join();
                    console.printMessage(Environment.NewLine + Environment.NewLine + "Поток - читатель завершился!" + Environment.NewLine + Environment.NewLine);
                }

            }

        }

    }
}
