using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task4
{
    class PageList
    {
        private Dictionary<int, Page> _memory;
        const int maxSize = 20;
        private DataGridView _memoryDgv;
        public int Count { get; private set; }

        public int MaxSize
        {
            get { return maxSize; }
        }

        /// <summary>
        /// Создание контейнера для страниц (модель памяти)
        /// </summary>
        /// <param name="memoryDgv">Таблица для вывода информации</param>
        public PageList(DataGridView memoryDgv)
        {
            Count = 0;
            _memory = new Dictionary<int, Page>();
            _memoryDgv = memoryDgv;

            for (int i = 0; i < maxSize; i++)
                _memory[i] = null;
        }

        /// <summary>
        /// Добавление страниц
        /// </summary>
        /// <param name="no">Номер процесса</param>
        /// <param name="quantity">Количество страниц</param>
        /// <returns>True - если достаточно свободной памяти и страницы добавлены, иначе - False</returns>
        public bool Add(int no, int? quantity = null)
        {
            if (quantity == null)
                quantity = new Random().Next(1, 7);

            for (int i = 0; i < maxSize; i++)
                if (_memory[i] != null)
                    _memory[i].Outdate();

            if (Count + quantity > maxSize)
                return false;

            Monitor.Enter(this);
            try
            {
                for (int i = 0; i < maxSize && quantity > 0; i++)
                    if (_memory[i] == null)
                    {
                        _memory[i] = new Page(no, "data", 0);
                        ++Count;
                        --quantity;
                        _memoryDgv.Rows[0].Cells[i].Value = no.ToString();
                    }

                for (int i = 0; i < maxSize; i++)
                    if (_memory[i] != null)
                        _memoryDgv.Rows[0].Cells[i].Value = _memory[i].Number.ToString();
            }
            finally
            {
                Monitor.Exit(this);
            }
            return true;
        }

        /// <summary>
        /// Удаление страниц с заданным номером
        /// </summary>
        /// <param name="num">Номер процесса</param>
        /// <returns>True - если страницы существовали и были удалены, иначе - False</returns>
        public bool DeleteByNum(int num)
        {
            bool res = false;
            for (int i = 0; i < maxSize; i++)
                if (_memory[i] != null)
                    _memory[i].Outdate();

            Monitor.Enter(this);
            try
            {
                for (int i = 0; i < maxSize; i++)
                    if (_memory[i] != null && _memory[i].Number == num)
                    {
                        _memoryDgv.Rows[0].Cells[i].Value = ' ';
                        res = true;
                    }

                for (int i = 0; i < maxSize; i++)
                    if (_memory[i] != null && _memory[i].Number == num)
                    {
                        _memory[i] = null;
                        Count--;
                    }
            }
            finally
            {
                Monitor.Exit(this);
            }

            return res;
        }

        /// <summary>
        /// Удаление страниц с самым высоким регистром старения
        /// </summary>
        /// <returns>Номер страниц, которые были удалены</returns>
        public int DeleteOldest()
        {
            int num = -1;
            int useRegister = -1;

            for (int i = 0; i < maxSize; i++)
                if (_memory[i] != null)
                    _memory[i].Outdate();

            Monitor.Enter(this);
            try
            {
                for (int i = 0; i < _memory.Count; i++)
                {
                    if (_memory[i] != null && _memory[i].GetUseRegister() > useRegister)
                    {
                        useRegister = _memory[i].GetUseRegister();
                        num = _memory[i].Number;
                    }
                }

                for (int i = 0; i < maxSize; i++)
                    if (_memory[i] != null && _memory[i].Number == num)
                        _memoryDgv.Rows[0].Cells[i].Value = ' ';

                for (int i = 0; i < maxSize; i++)
                    if (_memory[i] != null && _memory[i].Number == num)
                    {
                        _memory[i] = null;
                        Count--;
                    }
            }
            finally
            {
                Monitor.Exit(this);
            }
            return num;
        }
    }
}
