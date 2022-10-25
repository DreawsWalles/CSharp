using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    public partial class FormMain : Form
    {
        private Processor processor;

        public FormMain()
        {
            InitializeComponent();
            processor = new Processor(dataGridViewMemory, textBoxOutput);
            buttonAbort.Enabled = false;
            buttonContinue.Enabled = false;
            buttonPause.Enabled = false;

            radioButtonSlow.CheckedChanged += ChangeSpeed;
            radioButtonMedium.CheckedChanged += ChangeSpeed;
            radioButtonFast.CheckedChanged += ChangeSpeed;

            radioButtonOverwrite.CheckedChanged += ChangeAddStyle;
        }

        /// <summary>
        /// Изменение скорости добавления процессов
        /// </summary>
        private void ChangeSpeed(object sender, EventArgs e)
        {
            string rbName = (sender as RadioButton).Name;
            switch (rbName)
            {
                case "radioButtonSlow":
                    processor.ChangeWorkTime(1500);
                    break;
                case "radioButtonMedium":
                    processor.ChangeWorkTime(1000);
                    break;
                case "radioButtonFast":
                    processor.ChangeWorkTime(0);
                    break;
            }
        }

        /// <summary>
        /// Изменение способа ручного добавления процессов (с перезаписью/без перезаписи)
        /// </summary>
        private void ChangeAddStyle(object sender, EventArgs e)
        {
            processor.ChangeAddStyle();
        }

        /// <summary>
        /// Автопрокрутка текста в log'е
        /// </summary>
        private void textBoxOutput_TextChanged(object sender, EventArgs e)
        {
            textBoxOutput.SelectionStart = textBoxOutput.Text.Length;
            textBoxOutput.ScrollToCaret();
        }

        /// <summary>
        /// Остановка процессов при закрытии формы
        /// </summary>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (buttonContinue.Enabled)
                buttonContinue_Click(sender, e);
            processor.Halt();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Методы ниже делают кнопки активными/неактивными в зависимости от состояния программы
        private void buttonRun_Click(object sender, EventArgs e)
        {
            processor.Start();
            buttonRun.Enabled = false;
            buttonAbort.Enabled = true;
            buttonContinue.Enabled = false;
            buttonPause.Enabled = true;
        }

        private void buttonAbort_Click(object sender, EventArgs e)
        {
            processor.Halt();
            buttonRun.Enabled = true;
            buttonContinue.Enabled = false;
            buttonPause.Enabled = false;
        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            processor.Continue(checkBoxWithSubthreads.Checked);
            buttonContinue.Enabled = false;
            buttonPause.Enabled = true;
            buttonAbort.Enabled = true;
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            processor.Pause(checkBoxWithSubthreads.Checked);
            buttonPause.Enabled = false;
            buttonContinue.Enabled = true;
            buttonAbort.Enabled = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            processor.AddPages(Convert.ToInt32(numericUpDownPageNumber.Value), Convert.ToInt32(numericUpDownPageQuantity.Value));
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            processor.DeletePages(Convert.ToInt32(numericUpDownPageNumber.Value));
        }
    }
}
