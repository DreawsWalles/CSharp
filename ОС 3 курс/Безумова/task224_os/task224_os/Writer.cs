using System;
using System.Threading;
using System.Windows.Forms;
using static task224_os.StaticConstVar;

namespace task224_os
{
    class Writer : MainThreads
    {
        BufQueue MainBuf;
        public Writer(TextBox myTextBox, BufQueue _buf, int num) : base(myTextBox)
        {
            MainBuf = _buf;
            AppendToTextBox("Создан писатель " + num.ToString() + '\n');

            MyThread = new Thread(Work) { Name = num.ToString() };
            MyThread.Start();
        }

        public override void Work()
        {
            Thread.Sleep(GenRandom.Next(2000)); // случайная задержка 
            MessageToTextBox("Ждет семафор");
            MessageToTextBox("Ждет мьютекс");
            MessageToTextBox("Запись"); // действие зависит от того, кем является сущность

            MainBuf.Push();
            //BufQueue.Push();
            
            AppendToTextBox(Environment.NewLine);
            MessageToTextBox("Возвращает мьютекс");
        }

        public new bool ImWriter { get; } = true;

        public override string Name()
        {
            return "Писатель";
        }
    }
}
