using System;
using System.Windows.Forms;

namespace OS_task4_number3
{
    /* Планирование заданий: простой круговорот. */

    public partial class FormMain : Form
    {
        // планировщик заданий
        private static TaskScheduler _scheduler;

        public FormMain()
        {
            InitializeComponent();
            Height = 620;
        }

        // запуск планировщика
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_scheduler == null)
                _scheduler = new TaskScheduler(tbInfo, (int)numTime.Value); 
            _scheduler.Start();
            btnPause.Enabled = true;
            numTime.Enabled = false;
        }

        // пауза
        private void btnPause_Click(object sender, EventArgs e)
        {
            _scheduler?.Pause();
            btnPause.Enabled = false;
        }

        // событие при закрытии формы: завершение потоков
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _scheduler?.Abort();
        }

        private void numTime_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
