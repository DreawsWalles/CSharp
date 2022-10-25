using System;
using System.Threading;
using System.Windows.Forms;

namespace program_1
{
    class Writer
    {
        private const int time = 25 * ProgramData.speed;    // Минимальный период времени между добавлениями данных в буфер
        private const int max = 30 * ProgramData.speed;     // Максимальное значение, добавляемое в буфер

        private Print status;
        private TextBox textbox;
        private DataStack st;


        // Конструктор
        public Writer(DataStack stack, TextBox output, Print massage)
        {
            this.st = stack;
            this.textbox = output;
            this.status = massage;
        }

        // Добавление данных в буфер
        public void AddData()
        {
            Random rand = new Random();
            for (; ; )
            {
                Thread.Sleep(rand.Next(time, 4 * time));

                int added = rand.Next(max);
                status("Писатель помещает: " + added.ToString() + Environment.NewLine);
                st.Push(added);
            }
        }
    }
}
