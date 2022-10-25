using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace ParThread
{
    class MessageBuffer
    {
        //Максимальное число элементов буфера
        public static int maxCapacity = 10;
        //Сами сообщения
        Stack<string> messages;
        //TextBox для вывода сообщений
        private TextBox outBuffer;
        //Текстбокс для вывода читателей
        TextBox readBuffer;
        //Текстбокс для вывода писателей
        TextBox writeBuffer;

        public MessageBuffer(TextBox output, TextBox readers, TextBox writers)
        {
            outBuffer = output;
            readBuffer = readers;
            writeBuffer = writers;
            messages = new Stack<string>();
        }

        //Функция чтения сообщения, возвращает true, если удалось считать
        public bool Read(out string str)
        {
            Monitor.Enter(this);
            try
            {
                if (messages.Count == 0)
                {
                    str = "";
                    return false;
                }
                outBuffer.Invoke(new Action(RemoveFirstLine));
                str = messages.Pop();
            }
            finally
            {
                Monitor.Exit(this);
            }
            return true;
        }
        
        //Функция записи сообщения, возвращает true, если очередь не переполнена и запись удалась
        public bool Write(string str)
        {
            Monitor.Enter(this);
            try
            {
                if (messages.Count >= maxCapacity)
                    return false;
                outBuffer.Invoke(new Action(() => outBuffer.Text += str + "\r\n"));
                messages.Push(str);
            }
            finally
            {
                Monitor.Exit(this);
            }
            return true;
        }

        //Удаление первой строки из текстбокса сообщений
        void RemoveFirstLine()
        {
            if (outBuffer.Lines.Length > 0)
            {
                List<string> list = outBuffer.Lines.ToList();
                list.RemoveAt(0);
                outBuffer.Lines = list.ToArray();
            }
        }
        /// <summary>
        /// Очистка буфера
        /// </summary>
        public void Clear()
        {
            messages.Clear();
        }
    }
}
