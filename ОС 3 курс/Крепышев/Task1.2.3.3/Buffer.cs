using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task1._2._3._3
{
    class Buffer:IBuffer
    {
        Queue<Data> buffer;
        Console console;
        int MaxSize;

        public Buffer(int maxSize,Console console)
        {
            this.MaxSize = maxSize;
            this.console = console;
            buffer = new Queue<Data>(maxSize);
        }

        public void Add(Data item)
        {

            console.printMessage(Environment.NewLine + Environment.NewLine + "Поток ID - " + Thread.CurrentThread.ManagedThreadId + " встал в очередь к буфферу" + Environment.NewLine);

            Monitor.Enter(buffer);

            console.printMessage("Поток ID - " + Thread.CurrentThread.ManagedThreadId + " получил доступ к буфферу" + Environment.NewLine );

            try
            {

                if (MaxSize <= buffer.Count)
                    throw new Exception("Поток ID - " + Thread.CurrentThread.ManagedThreadId + " не смог добавить в буффер данные, так как он полон!");

                buffer.Enqueue(item);
                console.printMessage("Поток ID - " + Thread.CurrentThread.ManagedThreadId + " успешно добавил данные в буффер!" + Environment.NewLine);

            } catch (Exception e)
            {
                console.printMessage(e.Message + Environment.NewLine);
            }


            Monitor.Exit(buffer);

            console.printMessage("Поток ID - " + Thread.CurrentThread.ManagedThreadId + " покинул буффер и освободил место" + Environment.NewLine + Environment.NewLine );

        }


        public void Delete()
        {
            console.printMessage(Environment.NewLine + Environment.NewLine + "Поток ID - " + Thread.CurrentThread.ManagedThreadId + " встал в очередь к буфферу" + Environment.NewLine);

            Monitor.Enter(buffer);

            console.printMessage("Поток ID - " + Thread.CurrentThread.ManagedThreadId + " получил доступ к буфферу" + Environment.NewLine);

            try
            {

                if (buffer.Count == 0)
                    throw new Exception("Поток ID - " + Thread.CurrentThread.ManagedThreadId + " не смог удалить данные из буффера, так как он пуст!");

                console.printMessage("Поток ID - " + Thread.CurrentThread.ManagedThreadId + " успешно удалил данные: '" + buffer.Dequeue().ToString() + "'" + Environment.NewLine);

            }
            catch (Exception e)
            {
                console.printMessage(e.Message + Environment.NewLine);
            }


            Monitor.Exit(buffer);

            console.printMessage("Поток ID - " + Thread.CurrentThread.ManagedThreadId + " покинул буффер и освободил место" + Environment.NewLine + Environment.NewLine);
        }

    }
}
