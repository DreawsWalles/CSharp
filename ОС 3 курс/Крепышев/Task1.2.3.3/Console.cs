using System;
using System.Windows.Forms;
using System.Drawing;

namespace Task1
{
    delegate void MessageHandler(string m);
    class Console : TextBox
    {
        MessageHandler mshandler;
        private object threadLock = new object();
        /// <summary>
        /// Св-во обеспечивающее возможность достучаться безнаказанно из другого потока
        /// </summary>


        /// <summary>
        /// Дефолтный конструктор 
        /// </summary>
        /// <param name="x">позиция по X</param>
        /// <param name="y">позиция по Y</param>
        public Console(int x, int y)
        {
            this.Location = new Point(x, y);
            mshandler = putMessage;
            this.BackColor = Color.DarkGray;
            this.Text = "";
        }
        /// <summary>
        /// Конструктор с расширенным набором параметров
        /// </summary>
        /// <param name="x">позиция по X</param>
        /// <param name="y">позиция по Y</param>
        /// <param name="w">ширина в px</param>
        /// <param name="h">высота в px</param>
        public Console(int x, int y, int w, int h) : this(x, y)
        {

            this.Size = new Size(w, h);
            this.ClientSize = new Size(w, h);
            this.MinimumSize = new Size(w, h);
            this.MaximumSize = new Size(w, h);
        }
        /// <summary>
        /// Конструктор с расширенным набором параметров
        /// </summary>
        /// <param name="x">позиция по X</param>
        /// <param name="y">позиция по Y</param>
        /// <param name="w">ширина в px</param>
        /// <param name="h">высота в px</param>
        /// <param name="_readonly">только для чтения true - да, false - нет</param>
        public Console(int x, int y, int w, int h, bool _readonly) : this(x, y, w, h)
        {
            this.ReadOnly = _readonly;
            this.Multiline = true;
            this.ScrollBars = ScrollBars.Vertical;
        }

        void putMessage(string m)
        {
            this.Text += m;
            this.SelectionStart = this.Text.Length;
            this.ScrollToCaret();
        }

        public void printMessage(string m)
        {
            lock (threadLock)
            {
                Invoke(mshandler, m);
            }

        }



    }
}
