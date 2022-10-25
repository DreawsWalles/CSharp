using System;
using System.Threading;
using System.Windows.Forms;

namespace Task2
{
    class Threads
    {
        //потоки для каталогов
        private Thread myThread, myThread_;
        //поля результатов
        private Label label, label_, _label_;
        //экземпляры классов для подсчета размеров обоих каталогов
        private Сounter counter, counter_;
      
        //конструктор
        public Threads(string path, string path_, Label text, Label text_, Label _text_)
        {
            counter = new Сounter(path);
            counter_ = new Сounter(path_);
            myThread = new Thread(counter.AllSize);
            myThread_ = new Thread(counter_.AllSize);

            label = text;
            label_ = text_;
            _label_ = _text_;
        }

        //работа потокок
        public void Start()
        {
            myThread.Start();
            myThread_.Start();

            myThread.Join();
            myThread_.Join();

            label.Invoke(new Action(() => { label.Text = counter.size.ToString(); }));
            label_.Invoke(new Action(() => { label_.Text = counter_.size.ToString(); }));
            _label_.Invoke(new Action(() => { _label_.Text = Math.Abs(counter.size - counter_.size).ToString(); }));
        }

        //экстренное прерывание
        public void Abort()
        {
            if (myThread.ThreadState == ThreadState.WaitSleepJoin || myThread.ThreadState == ThreadState.Suspended)
            {
                myThread.Abort();
                myThread_.Abort();
            }
        }

    }
}
