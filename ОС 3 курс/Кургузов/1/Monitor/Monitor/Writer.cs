using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monitor
{
    public class Writer
    {
        #region Fields

        /// <summary>
        /// Контрол для отображения информации
        /// </summary>
        private TextBox _tbOutput = null;

        // <summary>
        /// Буффер
        /// </summary>
        private Buffer _buffer = null;

        /// <summary>
        /// Поток читателя
        /// </summary>
        private Thread _thread = null;

        #endregion

        #region Properties

        /// <summary>
        /// Количество обращений
        /// </summary>
        private int ActionsNumber { get; set; }

        /// <summary>
        /// Номер читателя
        /// </summary>
        private int Index { get; set; }

        #endregion

        #region Constructor/destructor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="size"></param>
        /// <param name="num"></param>
        /// <param name="b"></param>
        private Writer(TextBox tb, int actionscount, int index, Buffer b)
        {
            _tbOutput = tb;
            _buffer = b;

            ActionsNumber = actionscount;
            Index = index;

            _thread = new Thread(Write);
            _thread.Start();
        }

        /// <summary>
        /// Метод создания объекта
        /// </summary>
        /// <returns></returns>
        public static Writer CreateObject(TextBox tb, int size, int num, Buffer b)
        {
            return new Writer(tb, size, num, b);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Главный метод
        /// </summary>
        private void Write()
        {
            var rnd = new Random();
            _tbOutput.Invoke(new Action(() => _tbOutput.Text += "Создан писатель " + Index.ToString() + Environment.NewLine));

            while (ActionsNumber > 0)
            {
                var tmp = rnd.Next((Index + 1));
                _buffer.Enqueue(Index, tmp.ToString());
                ActionsNumber--;
                Thread.Sleep(rnd.Next(200, 1200));
            }
            _tbOutput.Invoke(new Action(() => _tbOutput.Text += "Уничтожен писатель " + Index.ToString() + Environment.NewLine));
        }

        /// <summary>
        /// Метод немедленного завершения потока
        /// </summary>
        public void Abort()
        {
            if (_thread != null && _thread.ThreadState == ThreadState.Running)
                _thread.Abort();
        }

        /// <summary>
        /// Метод паузы потока
        /// </summary>
        public void Stop()
        {
            if (_thread != null && _thread.ThreadState == ThreadState.Running || _thread != null && _thread.ThreadState == ThreadState.WaitSleepJoin)
                _thread.Suspend();
        }

        /// <summary>
        /// Метод снятия с паузы
        /// </summary>
        public void Resume()
        {
            if (_thread != null && _thread.ThreadState == ThreadState.Suspended)
                _thread.Resume();
        }


        #endregion
    }
}
