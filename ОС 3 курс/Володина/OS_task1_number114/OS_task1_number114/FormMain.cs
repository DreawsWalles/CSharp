using System;
using System.Threading;
using System.Windows.Forms;

namespace OS_task1_number114
{
    /* Задача "Поставщик-потребитель. Поставщик генерирует данные и отправляет их в общий буфер. Размер буфера ограничен.
     * Потребитель забирает данные из буфера. Поставщик не может положить данные, если в буфере нет свободных мест.
     * Потребитель не может взять данные, если буфер пуст. Поставщик и потребитель не могут одновременно работать с буфером.
     * 
     * Представление буфера: стек
     * Средство синхронизации: критические секции (lock)
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
            //btnPauseResume.Enabled = false;
            btnExit.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _threadMaker = new ThreadMaker(tbStack);
            (_threadControl = new Thread(_threadMaker.ControlProcess)).Start();
            btnStart.Enabled = false;
            //btnPauseResume.Enabled = true;
            btnExit.Enabled = true;
            gbWriters.Enabled = true;
            rbResumeWriters.Checked = true;
            gbReaders.Enabled = true;
            rbResumeReaders.Checked = true;
        }

        /*private void btnPauseResume_Click(object sender, EventArgs e)
        {
            if (_state)
            {
                _threadControl.Suspend();
                //_threadMaker.PauseProcess();
                btnExit.Enabled = false;
            }
            else
            {
                btnExit.Enabled = true;
                //_threadMaker.ResumeProcess();
                _threadControl.Resume();
            }
            _state = !_state;
        }*/

        private void btnExit_Click(object sender, EventArgs e)
        {
            _threadControl?.Abort();
            _threadMaker?.StopProcess();
            btnStart.Enabled = true;
            //btnPauseResume.Enabled = false;
            btnExit.Enabled = false;
            Thread.Sleep(100);
            tbStack.Text = "";
            gbWriters.Enabled = false;
            gbReaders.Enabled = false;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (_threadControl?.ThreadState == ThreadState.Suspended)
                //_threadControl.Resume();
            _threadControl?.Abort();
            _threadMaker?.StopProcess();
        }

        private void rbPauseWriters_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPauseWriters.Checked)
                _threadMaker?.PauseWriters();
            else
                _threadMaker?.ResumeWriters();
        }

        private void rbPauseReaders_CheckedChanged(object sender, EventArgs e)
        {
            if (rbPauseReaders.Checked)
                _threadMaker?.PauseReaders();
            else
                _threadMaker?.ResumeReaders();
        }
    }
}
