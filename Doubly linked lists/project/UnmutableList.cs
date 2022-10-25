using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class UnmutableList<T>:IList<T> where T:IComparable<T>
    {
        IList<T> list;
        public UnmutableList(IList<T> linkOnList)
        {
            list = linkOnList;
        }

        public int Count
        {
            get;
            private set;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new IndexListException();
                return list[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new InvalidActionExeption();
            }
        }

        public void Add(T value)
        {
            throw new InvalidActionExeption();
        }

        public void Insert(int index, T value)
        {
            throw new InvalidActionExeption();
        }

        public void Remove(T value)
        {
            throw new InvalidActionExeption();
        }

        public void RemoveAt(int index)
        {
            throw new InvalidActionExeption();
        }

        public void Clear()
        {
            throw new InvalidActionExeption();
        }

        public int IndexOf(T value)
        {
            return list.IndexOf(value);
        }
        
        public bool Contains(T value)
        {
            return list.Contains(value);
        }
        public IList<T> subList(int fromIndex, int toIndex)
        {
            return list.subList(fromIndex, toIndex);
        }
        public IEnumerator<T> GetEnumerator()
        {
            // Перебираем все элементы связного списка, для представления в виде коллекции элементов.
            throw new InvalidDoingException(); 
        }

        /// <summary>
        /// Вернуть перечислитель, который осуществляет итерационный переход по связному списку.
        /// </summary>
        /// <returns> Объект IEnumerator, который используется для прохода по коллекции. </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            // Просто возвращаем перечислитель, определенный выше.
            // Это необходимо для реализации интерфейса IEnumerable
            // чтобы была возможность перебирать элементы связного списка операцией foreach.
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        public void Save(string path, int type, int realization, bool mutable)
        {
            list.Save(path, type, realization, mutable);
        }
    }
}
