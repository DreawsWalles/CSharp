using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace task224_os
{
    class StaticConstVar
    {
        /// <summary>
        /// Генератор случайных чисел
        /// </summary>
        public static Random GenRandom = new Random();

        public static TextBox MyTextBox;

        public static void AppendToTextBox(string value)
        {
            if (MyTextBox.InvokeRequired)
            {
                MyTextBox.Invoke(new Action<string>(AppendToTextBox), value);
                return;
            }
            MyTextBox.AppendText(value);
        }
    }
}
