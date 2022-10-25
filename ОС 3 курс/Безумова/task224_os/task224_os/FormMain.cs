using System;
using System.Threading;
using System.Windows.Forms;
using static task224_os.StaticConstVar;

namespace task224_os
{
    public partial class FormMain : Form
    {
        /// <summary>
        /// Поток, который принимает ф-ю решения задачи
        /// </summary>
        private Thread _solve;

        public FormMain()
        {
            InitializeComponent();
            MyTextBox = tbSupCon;
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Представление буфера: Очередь\nСредства синхронизации: Семафоры и мьютексы\nСоздать многопоточное приложение, в котором главный поток в случайные моменты времени порождает либо поток-читатель, либо поток-писатель, который в случайные моменты времени помещает данные в буфер и сообщает об этом.Каждый поток-читатель завершается после удаления заданного заданного числа данных.Каждый поток-писатель завершается после занесения заданного числа данных");
        }

        private void Solve()
        {
            int numOfThr = 1; // порядковый номер текущего потока  
            
            BufQueue buf = new BufQueue(MyTextBox, 10); // непосредственно читатель и писатель как попадают в один буфер

            while (true)
            {
                Thread.Sleep(StaticConstVar.GenRandom.Next(1000, 1500));

                MainThreads threadsMaker;
                if (rbAll.Checked)
                {
                    int who = StaticConstVar.GenRandom.Next(2);
                    if (who == 0)
                        threadsMaker = new Writer(tbSupCon, buf, numOfThr);
                    else
                        threadsMaker = new Reader(tbSupCon, buf, numOfThr);
                }
                else
                    if (rbR.Checked)
                    threadsMaker = new Writer(tbSupCon, buf, numOfThr);
                else
                    threadsMaker = new Reader(tbSupCon, buf, numOfThr);

                BufQueue.Workers.Add(threadsMaker);

                ++numOfThr;
            }
            ChangeTxtOnLbl("Работа процесса завершена!");
            Thread.CurrentThread.Abort();
        }


        /// <summary>
        /// Запуск нового процесса, принудительно завершив старый
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            BufQueue.Abort();
            BufQueue.Workers.Clear();

            _solve?.Abort(); //if _solve != NULL { _solve.Abort }
            tbSupCon.Clear();
            lblSupCon.Text = @"Выполняется процесс";

            _solve = new Thread(Solve);
            _solve.Start();
        }

        /// <summary>
        /// Запрашивает разрешение на внесение данных в компонент формы из другого потока
        /// </summary>
        void ChangeTxtOnLbl(string value)
        {
            if (lblSupCon.InvokeRequired)
            {
                lblSupCon.Invoke(new Action<string>(ChangeTxtOnLbl), value);
                return;
            }
            lblSupCon.Text = value;
        }

        /// <summary>
        /// Принудительно завершает работу, если поток уже запущен
        /// </summary>
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_solve != null)
            {
                _solve.Abort();
                _solve = null;
                BufQueue.Abort();
                lblSupCon.Text = @"Запустите процесс";
            }
        }

        /// <summary>
        /// Событие, отвечающее за корректное завершение всех потоков перед закрытием программы
        /// </summary>
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_solve != null)
            {
                BufQueue.Abort();
                _solve.Abort();
                _solve = null;
            }
            Environment.Exit(Environment.ExitCode);
        }

        private void rbR_CheckedChanged(object sender, EventArgs e)
        {
            BufQueue.Stop(false);
            BufQueue.Resume(true);
        }

        private void rbW_CheckedChanged(object sender, EventArgs e)
        {
            BufQueue.Stop(true);
            BufQueue.Resume(false);
        }
    }
}
