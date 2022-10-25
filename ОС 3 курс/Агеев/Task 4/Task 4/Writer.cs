using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Task_4
{
    /// <summary>
    /// Статус писателя
    /// </summary>
    public enum State
    {
        Idle,
        Waiting,
        Working
    }

    class Writer
    {
        /// <summary>
        /// Встроенный генератор случайных чисел
        /// </summary>
        private static readonly Random Rnd = new Random();
        /// <summary>
        /// Встроенный счетчик писателей
        /// </summary>
        private static int _n = 0;
        /// <summary>
        /// Получаемое сообщение
        /// </summary>
        private MSG msg;
        /// <summary>
        /// Монитор - текстовое поле на форме, где содержатся записи о состоянии писателя
        /// </summary>
        private TextBox Monitor;
        /// <summary>
        /// Состояние писателя
        /// </summary>
        private State state;
        /// <summary>
        /// Номер конкретного писателя
        /// </summary>
        public int N { get; internal set; }
        /// <summary>
        /// ID менеджера
        /// </summary>
        public uint ManagerID { get; }

        /// <summary>
        /// Конструктор писателя
        /// </summary>
        /// <param name="monitor">Текстовое поле для вывода состояния писателя</param>
        /// <param name="threadID">Поток-координатор</param>
        public Writer(TextBox monitor, uint threadID)
        {
            N = _n++;
            Monitor = monitor;
            ManagerID = threadID;
        }

        /// <summary>
        /// Основной метод писателя - работать
        /// </summary>
        public void Work()
        {
            PeekMessage(out msg, IntPtr.Zero, 0x400, 0x400, 0x0000); //создаем очередь из сообщений
            while (true) // цикл работает постоянно
            {
                switch (state) // действия в зависимости от состояния
                {
                    case State.Idle: // если бездействуем
                        Thread.Sleep(Rnd.Next(N * 1000, 10000)); // задержка потока
                        PostThreadMessage(ManagerID, (uint)Messages.WM_REQUEST, new IntPtr(AppDomain.GetCurrentThreadId()), IntPtr.Zero);
                        Monitor.AppendText("Писатель " + N + " запросил доступ\n"); // записываем состояние
                        state = State.Waiting; // переходим в состояние ожидания
                        break;
                    case State.Waiting: // если мы в состоянии ожидания
                        while (true) // пытаемся получить сообщение
                        {
                            if (PeekMessage(out msg, new IntPtr(-1), 0, 0, 0x0001)) // берем сообщение
                            {
                                switch (msg.message) 
                                {
                                    case (uint)(Messages.WM_WAIT): // если пришло сообщение, что нужно ждать
                                        Monitor.AppendText("Писатель " + N + " в очереди\n"); // записываем состояние
                                        break;
                                    case (uint)(Messages.WM_GRANTED): // если доступ разрешен
                                        state = State.Working; // переходим в состояние работы
                                        Monitor.AppendText("Писатель " + N + " получил доступ\n"); //записываем состояние
                                        AccessResource(); // входим в ресурс
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            }
                        }
                        break;
                    case State.Working:
                        break;
                }
            }
        }
        /// <summary>
        /// Доступ к ресурсу
        /// </summary>
        private void AccessResource()
        {
            Thread.Sleep(Rnd.Next(2000, 3000)); // задерживаемся
            Resource.GetInstance().Write("Писатель " + N + " обратился к ресурсу\n"); // работаем с ресурсом
            while (!PostThreadMessage(ManagerID, (uint)Messages.WM_FINISHED, IntPtr.Zero, IntPtr.Zero)) ; //отправляем сообщение о завершении работы с ресурсом
            state = State.Idle; //переходим в бездействие
        }

        /// <summary>
        /// Публикация сообщения в очередь сообщений потока
        /// </summary>
        /// <param name="threadID">Идентификатор потока-адресата</param>
        /// <param name="msg">Сообщение</param>
        /// <param name="wParam">Дополнительные сведения</param>
        /// <param name="lParam">Дополнительные сведения</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostThreadMessage(uint threadID, uint msg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Взятие сообщения из очереди потока
        /// </summary>
        /// <param name="lpMsg">Полученное сообщение</param>
        /// <param name="hWnd">Дескриптор окна</param>
        /// <param name="wMsgFilterMin">Минимальное сообщение</param>
        /// <param name="wMsgFilterMax">Максимальное сообщение</param>
        /// <param name="wRemoveMsg">Параметры удаления сообщения</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);
    }
}
