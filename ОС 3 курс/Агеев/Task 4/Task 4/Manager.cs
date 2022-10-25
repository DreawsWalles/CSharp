using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows;
using System.Threading;

namespace Task_4
{
    /// <summary>
    /// Сообщения, отправляемые между потоками
    /// </summary>
    public enum Messages
    {
        WM_REQUEST = 0x400 + 0x001,
        WM_GRANTED = WM_REQUEST + 0x001,
        WM_WAIT = WM_GRANTED + 0x001,
        WM_FINISHED = WM_WAIT + 0x001,
    }
    /// <summary>
    /// Структура сообщения из WinAPI
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public IntPtr hahdler;
        public uint message;
        public IntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public Point pt;
    }

    /// <summary>
    /// Класс-координатор в алгоритме
    /// </summary>
    internal class Manager
    {
        /// <summary>
        /// Полученное сообщение
        /// </summary>
        private MSG msg;
        /// <summary>
        /// Очередь из ID потоков
        /// </summary>
        private readonly Queue<uint> _queue = new Queue<uint>();
        /// <summary>
        /// Занятость ресурса
        /// </summary>
        private bool busy = false;
        /// <summary>
        /// ID менеджера
        /// </summary>
        public uint threadID;
        /// <summary>
        /// Поток координатора
        /// </summary>
        private Thread t;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Manager()
        {
            t = new Thread(Run) { Name = "Manager", Priority = ThreadPriority.AboveNormal };
            t.Start();
        }

        public void Stop()
        {
            t.Abort();
        }
        /// <summary>
        /// Работа координатора
        /// </summary>
        public void Run()
        {
            threadID = GetCurrentWin32ThreadId(); // установка ID менеджера
            PeekMessage(out msg, IntPtr.Zero, 0x400, 0x400, 0x0000); // создаем очередь из сообщений
            while (true) // цикл работает постоянно
            {
                while (PeekMessage(out msg, new IntPtr(-1), 0, 0, 0x0001)) // пока есть сообщения
                {
                    switch (msg.message)
                    {
                        case (uint)(Messages.WM_REQUEST): // если запрос
                            if (!busy) // если ресурс не занят
                            {
                                PostThreadMessage((uint)msg.wParam.ToInt32(), (uint)Messages.WM_GRANTED, IntPtr.Zero, IntPtr.Zero); // выдаем разрешение
                                busy = true;
                            }
                            else
                            {
                                PostThreadMessage((uint)msg.wParam.ToInt32(), (uint)Messages.WM_WAIT, IntPtr.Zero, IntPtr.Zero); // отправляем сообщение об ожидании
                                _queue.Enqueue((uint)msg.wParam.ToInt32()); // ставим в очередь
                            }
                            break;
                        case (uint)(Messages.WM_FINISHED): // если сообщение о завершении
                            busy = false;
                            if (_queue.Count == 0)
                                break; // если очередь пуста, ждем далее
                            var tmp = _queue.Dequeue(); // берем следующий поток
                            PostThreadMessage(tmp, (uint)Messages.WM_GRANTED, IntPtr.Zero, IntPtr.Zero); // даем разрешение
                            busy = true;
                            break;
                        default:
                            break;
                    }
                }
            }
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

        [DllImport("Kernel32", EntryPoint = "GetCurrentThreadId", ExactSpelling = true)]
        public static extern uint GetCurrentWin32ThreadId();
    }
}
