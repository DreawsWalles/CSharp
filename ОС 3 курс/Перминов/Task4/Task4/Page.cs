using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Page
    {
        public int Number { get; }
        private string data;
        private int useRegister;

        /// <summary>
        /// Создание страницы
        /// </summary>
        /// <param name="num">Номер страницы</param>
        /// <param name="dt">Информация</param>
        /// <param name="ur">Регистр старения</param>
        public Page(int num, string dt, int ur)
        {
            Number = num;
            data = dt;
            useRegister = ur;
        }

        /// <summary>
        /// Увеличение регистра старения
        /// </summary>
        public void Outdate()
        {
            useRegister++;
        }

        /// <summary>
        /// Получение регистра старения
        /// </summary>
        /// <returns>Целое число - регистр старения</returns>
        public int GetUseRegister()
        {
            return useRegister;
        }
    }
}
