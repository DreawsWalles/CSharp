using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class FormMain : Form
    {
        private Processor proc;

        // Инициализация главной формы
        public FormMain()
        {
            InitializeComponent();
            buttonStop.Enabled = false;
            buttonReadersChangeState.Enabled = false;
            buttonWritersChangeState.Enabled = false;
        }

        // Действия при нажатии на кнопку "Run"
        private void buttonRun_Click(object sender, EventArgs e)
        {
            QueueBuffer buffer = new QueueBuffer(textBoxMain, 7);
            proc = new Processor(buffer, textBoxMain, textBoxWriters, textBoxReaders);
            buttonRun.Enabled = false;
            buttonStop.Enabled = true;
            buttonReadersChangeState.Enabled = true;
            buttonWritersChangeState.Enabled = true;
        }

        // Действия при нажатии на кнопку "Stop"
        private void buttonStop_Click(object sender, EventArgs e)
        {
            proc.Exit();
            buttonStop.Enabled = false;
            buttonRun.Enabled = true;
            buttonReadersChangeState.Enabled = false;
            buttonWritersChangeState.Enabled = false;
            //textBoxMain.Clear();
            //textBoxReaders.Clear();
            //textBoxWriters.Clear();
        }

        // Действия при включении/отключении добавления писателей
        private void buttonWritersChangeState_Click(object sender, EventArgs e)
        {
            if (proc.WritersActive)
                proc.WaitWriters();
            else
                proc.PulseWriters();
        }

        // Действия при включении/отключении добавления читателей
        private void buttonReadersChangeState_Click(object sender, EventArgs e)
        {
            if (proc.ReadersActive)
                proc.WaitReaders();
            else
                proc.PulseReaders();
        }

        // Для всех TextBox'ов ниже выполняется прокрутка к последнему символу и очистка в случае полного заполнения
        private void textBoxMain_TextChanged(object sender, EventArgs e)
        {
            TextBox tmpTextBox = sender as TextBox;
            tmpTextBox.SelectionStart = tmpTextBox.Text.Length;
            tmpTextBox.ScrollToCaret();
            if (tmpTextBox.TextLength == tmpTextBox.MaxLength)
                tmpTextBox.Clear();
        }

        private void textBoxWriters_TextChanged(object sender, EventArgs e)
        {
            TextBox tmpTextBox = sender as TextBox;
            tmpTextBox.SelectionStart = tmpTextBox.Text.Length;
            tmpTextBox.ScrollToCaret();
            if (tmpTextBox.TextLength == tmpTextBox.MaxLength)
                tmpTextBox.Clear();
        }

        private void textBoxReaders_TextChanged(object sender, EventArgs e)
        {
            TextBox tmpTextBox = sender as TextBox;
            tmpTextBox.SelectionStart = tmpTextBox.Text.Length;
            tmpTextBox.ScrollToCaret();
            if (tmpTextBox.TextLength == tmpTextBox.MaxLength)
                tmpTextBox.Clear();
        }

        // Очистка TextBox'ов
        private void buttonClearWriters_Click(object sender, EventArgs e)
        {
            textBoxWriters.Clear();
        }

        private void buttonClearReaders_Click(object sender, EventArgs e)
        {
            textBoxReaders.Clear();
        }

        private void buttonClearMain_Click(object sender, EventArgs e)
        {
            textBoxMain.Clear();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            buttonClearWriters_Click(sender, e);
            buttonClearReaders_Click(sender, e);
            buttonClearMain_Click(sender, e);
        }
    }
}
