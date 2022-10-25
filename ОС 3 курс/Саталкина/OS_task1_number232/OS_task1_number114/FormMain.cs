using System;
using System.Threading;
using System.Windows.Forms;

namespace OS_task1_number232
{
    /* Задача "Поставщик-потребитель. Поставщик генерирует данные и отправляет их в общий буфер. Размер буфера ограничен.
     * Потребитель забирает данные из буфера. Поставщик не может положить данные, если в буфере нет свободных мест.
     * Потребитель не может взять данные, если буфер пуст. Поставщик и потребитель не могут одновременно работать с буфером.
     * 
     * Представление буфера: очередь
     * Средство синхронизации: монитор (Enter-Exit)
     * 
     * Задача:
     * Создать многопоточное приложение с одним потоком-читателем, удаляющим данные из буфера. 
     * Главный поток в случайные моменты времени порождает потоки-писатели, которые в случайные моменты  
     * времени помещают данные в буфер, если в структуре имеется свободное место, 
     * или самоуничтожаются с соответствующим сообщением */

    public partial class FormMain : Form
    {
        private ThreadMaker _threadMaker;
        private Thread _threadControl;

        public FormMain()
        {
            InitializeComponent();
            btnExit.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            _threadMaker = new ThreadMaker(tbStack);
            (_threadControl = new Thread(_threadMaker.ControlProcess)).Start();
            btnStart.Enabled = false;
            btnExit.Enabled = true;
            gbWriters.Enabled = true;
            rbResumeWriters.Checked = true;
            gbReaders.Enabled = true;
            rbResumeReaders.Checked = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            _threadControl?.Abort();
            _threadMaker?.StopProcess();
            btnStart.Enabled = true;
            btnExit.Enabled = false;
            Thread.Sleep(100);
            tbStack.Text = "";
            gbWriters.Enabled = false;
            gbReaders.Enabled = false;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                _threadMaker?.PauseReader();
            else
                _threadMaker?.ResumeReader();
        }
    }
}
