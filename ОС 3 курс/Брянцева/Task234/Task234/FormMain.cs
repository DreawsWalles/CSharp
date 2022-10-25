using System;
using System.Threading;
using System.Windows.Forms;

namespace Task234
{
    /* Задача "Поставщик-потребитель. Поставщик генерирует данные и отправляет их в общий буфер. Размер буфера ограничен.
     * Потребитель забирает данные из буфера. Поставщик не может положить данные, если в буфере нет свободных мест.
     * Потребитель не может взять данные, если буфер пуст. Поставщик и потребитель не могут одновременно работать с буфером.
     * 
     * Представление буфера: очередь
     * Средство синхронизации: Monitor
     * 
     * Задача:
     * Создать многопоточное приложение, в котором главный поток в случайные моменты времени порождает либо поток-читатель, 
     * либо поток-писатель, который в случайные моменты времени помещает данные в буфер и сообщает об этом. 
     * Каждый поток-читатель завершается после удаления заданного заданного числа данных. 
     * Каждый поток-писатель завершается после занесения заданного числа данных. */

    public partial class FormMain : Form
    {
        private ThreadMaker _threadMaker;
        private Thread _threadControl;

        public FormMain()
        {
            InitializeComponent();
            btnExit.Enabled = false;
            btnReadersStart.Enabled = false;
            btnReadersStop.Enabled = false;
            btnWritersStart.Enabled = false;
            btnWritersStop.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _threadMaker = new ThreadMaker(tbStack);
            (_threadControl = new Thread(_threadMaker.ControlProcess)).Start();
            btnStart.Enabled = false;
            btnExit.Enabled = true;
            btnReadersStop.Enabled = true;
            btnWritersStop.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _threadControl?.Abort();
            _threadMaker?.StopProcess();
            btnStart.Enabled = true;
            btnExit.Enabled = false;
            Thread.Sleep(100);
            tbStack.Clear();
            btnReadersStart.Enabled = false;
            btnReadersStop.Enabled = false;
            btnWritersStart.Enabled = false;
            btnWritersStop.Enabled = false;
            
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _threadControl?.Abort();
            _threadMaker?.StopProcess();
        }

        private void btnReaders_Click(object sender, EventArgs e)
        {
            _threadMaker?.PauseReaders();
            btnReadersStart.Enabled = true;
            btnReadersStop.Enabled = false;
        }

        private void btnReadersStart_Click(object sender, EventArgs e)
        {
            _threadMaker?.ResumeReaders();
            btnReadersStart.Enabled = false;
            btnReadersStop.Enabled = true;
        }

        private void btnWritersStop_Click(object sender, EventArgs e)
        {
            _threadMaker?.PauseWriters();
            btnWritersStop.Enabled = false;
            btnWritersStart.Enabled = true;
        }

        private void btnWritersStart_Click(object sender, EventArgs e)
        {
            _threadMaker?.ResumeWriters();
            btnWritersStop.Enabled = true;
            btnWritersStart.Enabled = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
