/* Представление буфера: стек
 * Средства синхронизации: критические секции (lock)
 * 
 * Создать многоаоточное приложение с одним потоком-писателем, который
 * в случайные моменты времени помещает данные в буфер и сообщает об этом.
 * Главный поток в случайные моменты времени порождает потоки-читетели,
 * которые в случайные моменты времени удаляют данные из буфера
 * с соответствующим сообщением. Каждый поток-читатель завершается после
 * удаления заданного числа данных.
*/

using System;
using System.Windows.Forms;

namespace program_1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }
    }
}
