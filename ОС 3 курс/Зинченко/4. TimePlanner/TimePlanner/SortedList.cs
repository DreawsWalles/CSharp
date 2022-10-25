using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimePlanner
{
    
    /// <summary>
    /// Обертка над стандартным списком.
    /// Сортированный список, добавляющий элементы согласно их оставшемуся времени выполнения
    /// и удаляющий тот, у которого самое маленькое время
    /// </summary>
    class SortedList : IEnumerable
    {

        List<ThreadWorker> elements;

        public int Count { get { return elements.Count; } }

        public ThreadWorker this[int key]
        {
            get
            {
                return elements[key];
            }
            set
            {
                elements[key] = value;
            }
        }
        public SortedList()
        {
            elements = new List<ThreadWorker>();
        }
        /// <summary>
        /// Добавляем элемент в список, и сортируем его
        /// </summary>
        /// <param name="elem">Элемент для добавления</param>
        public void Add(ThreadWorker elem)
        {
            elements.Add(elem);
            elements.Sort((i1, i2) =>  i1.RemainingTime.CompareTo(i2.RemainingTime));
        }
        /// <summary>
        /// Удаляем первый элемент из списка
        /// </summary>
        /// <returns>Возвращает удаляемый элемент для удобства работы</returns>
        public ThreadWorker Remove()
        {
            ThreadWorker th = elements[0];
            elements.RemoveAt(0);
            return th;
        }
        public ThreadWorker RemoveAt(int index)
        {
            ThreadWorker th = elements[index];
            elements.RemoveAt(index);
            return th;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)elements).GetEnumerator();
        }
    }
}
