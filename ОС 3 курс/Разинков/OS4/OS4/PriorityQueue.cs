using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS4
{
    /// <summary>
    /// Класс очереди, элементы в которую добавляются с сортировкой по приоритету
    /// </summary>
    /// <typeparam name="T">Тип элементов очереди, реализует интерфейс IComparable</typeparam>
    class PriorityQueue<T> where T: IComparable
    {
        //Список элементов очереди
        private List<T> items;

        /// <summary>
        /// Количество элементов в очереди. Свойство только на чтение
        /// </summary>
        public int Count
        {
            get { return items.Count; }
        }

        /// <summary>
        /// Конструктор очереди с приоритетом
        /// </summary>
        public PriorityQueue()
        {
            items = new List<T>();
        }

        /// <summary>
        /// Метод добавления элемента в очередь
        /// </summary>
        /// <param name="Item">Добавляемый элемент</param>
        public void Enqueue(T Item)
        {
            int InsertPosition = 0;
            int ItemsCount = items.Count;
            //Пропускаем все текущие элементы из очереди с большим или равным приоритетом
            foreach (var CurrentItem in items)
                if (Item.CompareTo(CurrentItem) < 1)
                    ++InsertPosition;
                else
                    break;
            items.Insert(InsertPosition, Item);
        }

        /// <summary>
        /// Метод извлечения элемента из очереди в соответствии с его приоритетом
        /// </summary>
        /// <returns>Возвращает верхний элемент очереди</returns>
        public T Dequeue()
        {
            T Item = items.First();
            items.RemoveAt(0);
            return Item;
        }
    }
}
