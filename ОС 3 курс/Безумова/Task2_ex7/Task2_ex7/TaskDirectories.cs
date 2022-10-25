using System;
using System.Threading;

namespace Task2_ex7
{
    public class TaskDirectories
    {
        /// <summary>
        /// Первый каталог, по которому будет происходить поиск самой поздней даты
        /// </summary>
        public ForDirectories First { get; } = new ForDirectories();
        
        /// <summary>
        /// Второй каталог, по которому будет происходить поиск самой поздней даты
        /// </summary>
        public ForDirectories Second { get; } = new ForDirectories();

        /// <summary>
        /// Флаг, показывающий, можно ли произвести поиск по подкаталогам
        /// </summary>
        public bool CanScan => First.Directory != null && Second.Directory != null;

        /// <summary>
        /// Поиск самой поздней даты в двух каталогах параллельно
        /// </summary>
        public void Solve()
        {
            Thread th1 = new Thread(First.Solve);
            Thread th2 = new Thread(Second.Solve);
            th1.Start();
            th2.Start();
            th1.Join();
            th2.Join();
        }

        /// <summary>
        /// Сравнение самых поздних дат из каталогов
        /// </summary>
        /// <returns>Номер каталога, в котором содержится наиболее поздний файл.</returns>
        public int TheLatestDate()
        {
            if (DateTime.Compare(First.MaxDateTime, Second.MaxDateTime) < 0)
                return 2;
            return 1;
        }

    }
}