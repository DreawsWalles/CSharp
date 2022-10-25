using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace project
{



    public class ArrayList<T>  :IList<T> where T : IComparable<T>
    {
        static int max_size = 20;
        T[] List;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public int Count
        {
            get;
            private set;          
        }

        public ArrayList()
        {
            List = new T[max_size];
            max_size = 20;
            Count = 0;
        }


        private void Resize()
        {
            max_size += 20;
            T[] new_list = new T[max_size];
            for (int i = 0; i < max_size; i++)
                new_list[i] = List[i];
            List = new_list;
        }

        public void Add(T value)
        {
            if (Count == max_size)
                Resize();
            List[Count] = value;
            Count++;
        }

        public void Clear()
        {
            while (Count != 0)
                Remove(List[Count]);
        }

        public T this[int index] 
        {
            get
            {
                return List[index];
            }
            set
            {

                List[index] = value;
            }
        }

        public bool Contains(T value)
        {
            for (int i = 0; i <= Count; i++)
                if (List[i].CompareTo(value) == 0)
                    return true;
            return false;
        }
        public int IndexOf(T value)
        {
            for (int i = 0; i <= Count; i++)
                if (List[i].CompareTo(value) == 0)
                    return i;
            return -1;
        }

        public void Insert(int index, T value)
        {

            if (index > Count || index < 0)
                throw new IndexListException();
            else
            {
                if (Count == max_size + 1)
                    Resize();
                if (Count == 0)
                    Add(value);
                int new_index = Count;
                while (new_index != index)
                {
                    List[new_index] = List[new_index - 1];
                    new_index--;
                }
                List[index] = value;
                Count++;
            }
        }
        public void RemoveAt(int index)
        {
            if (index >= Count || index < 0)
                throw new IndexListException();
            else
            {
                if (index != (Count - 1))
                {
                    while (index != Count - 1)   
                    {
                        List[index] = List[index + 1];
                        index++;
                    }
                }
                Count--;
                List[Count] = default;
            }
        }
        public void Remove(T value)
        {
            int index = IndexOf(value);
            if (index != -1)
                RemoveAt(index);
        }
        public IList<T> subList(int fromIndex, int toIndex)
        {
            if (fromIndex < 0 && ((toIndex + 1) == Count))
                throw new RangeListException();
            IList<T> result = new ArrayList<T>();
            for (int i = fromIndex; i <= toIndex; i++)
            {
                result.Add(List[i]);
            }
            return result;
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                    yield return List[i];
            }
        }

        public void Save(string path, int type, int realization, bool mutable)
        {
            StreamWriter file = new StreamWriter(File.OpenWrite(path));
            if (mutable)
                file.WriteLine("+");
            else
                file.WriteLine("-");
            file.WriteLine(type);
            file.WriteLine(realization);
            int index = 0;
            while (index != Count)
            {
                file.WriteLine(List[index]);
                index++;
            }
            file.Close();  
        }
    }
}
