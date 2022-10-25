using System;
using System.Windows.Forms;
using System.Threading;
using static task224_os.StaticConstVar;

namespace task224_os
{
    class Reader : MainThreads
    {
        BufQueue MainBuf;
        public Reader(TextBox myTextBox, BufQueue _buf, int num) : base(myTextBox)
        {
            MainBuf = _buf;
            AppendToTextBox("Создан читатель " + num.ToString() + '\n');

            MyThread = new Thread(Work) { Name = num.ToString() };
            MyThread.Start();
        }

        public override void Work()
        {
            Thread.Sleep(GenRandom.Next(2000)); // случайная задержка
            MessageToTextBox("Ждет семафор");
                        
            MessageToTextBox("Ждет мьютекс");
            MessageToTextBox("Чтение"); // действие зависит от того, кем является сущность

            MainBuf.Pop();
            //BufQueue.Pop();            

            AppendToTextBox(Environment.NewLine);
            MessageToTextBox("Возвращает мьютекс");            
        }

        public new bool ImWriter { get; } = false;

        public override string Name()
        {
            return "Читатель";
        }
    }
}
