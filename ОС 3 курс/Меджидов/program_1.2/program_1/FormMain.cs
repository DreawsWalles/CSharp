using System;
using System.Windows.Forms;
using System.Threading;

namespace program_1
{
    public partial class FormMain : Form
    {
        private bool performance = false;   // true - если нажата кнопка "старт"
        private bool created = false;       // false - если нажата кнопка "стоп" или еще не нажата "старт"
        private const int time = 50 * ProgramData.speed;
        //private Thread main;
        //private Thread wThread;

        // K:
        DataStack buffer;  
        ThreadCreator threadCreator; 
        //int max = 10; 
        Thread workingThread; //поток, осуществляющий работу 


        //Print print;
        DataStack st;

        public FormMain()
        {
            InitializeComponent();

            st = new DataStack(TbStack);
            //print = new Print(PrintInfo);
            BttStop.Enabled = false;
        }

        private void BttStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!created) // Если не создан - выполнение с начала
                {
                    BttStart.Text = "     Пауза";
                    BttStart.BackgroundImage = Properties.Resources.pause3;
                    performance = true;
                    created = true;
                    BttStop.Enabled = true;

                    // K:
                    buffer = new DataStack(TbStack);
                    threadCreator = new ThreadCreator(buffer, TbInfo);
                    workingThread = new Thread(new ThreadStart(threadCreator.Run));
                    workingThread.Start(); //заускаем поток
                }
                else // Если создан - то может прерваться или продолжится
                {
                    if (performance) // Пауза
                    {
                        BttStart.Text = "     Старт";
                        BttStart.BackgroundImage = Properties.Resources.start4;
                        performance = false;
                        BttStop.Enabled = false;

                        // K:
                        workingThread.Suspend();
                        threadCreator.Pause();
                    }
                    else // Продолжить
                    {
                        BttStart.Text = "     Пауза";
                        BttStart.BackgroundImage = Properties.Resources.pause3;
                        performance = true;
                        BttStop.Enabled = true;

                        // K:
                        workingThread.Resume();
                        threadCreator.Resume();
                    }

                }
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void BttStop_Click(object sender, EventArgs e)
        {
            if (created)
            {
                created = false;
                BttStart.Text = "     Старт";
                BttStart.BackgroundImage = Properties.Resources.start4;
                //performance = false;

                // K:
                //if (performance)
                workingThread.Abort();
                /*else
                {
                    workingThread.Resume();
                    performance = false;
                }*/
                threadCreator.Stop();
            }

            TbInfo.Clear();
            TbStack.Clear();
            BttStop.Enabled = false;
        }

        /*private void PrintInfo(string str)
        {
            if (TbInfo.InvokeRequired)
                TbInfo.Invoke(new Action<string>((s) => TbInfo.AppendText(s)), str);
            else
                TbInfo.AppendText(str);
        }*/

        /*public void Task()
        {
            Random rand = new Random();
            int readerNum = 1;

            Writer writer = new Writer(st, TbInfo, print);
            wThread = new Thread(new ThreadStart(writer.AddData));
            wThread.Start();
            for (; ; )
            {
                Thread.Sleep(rand.Next(time, 4 * time));
                Reader reader = new Reader(st, ProgramData.NumToString(readerNum), print, rand.Next(1, 4));

                readerNum++;
            }
        }*/

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (created && !performance)
            {
                workingThread.Resume();
                threadCreator.Resume();
            }
            BttStop.Enabled = true;
            BttStop.PerformClick();
        }
    }
}
