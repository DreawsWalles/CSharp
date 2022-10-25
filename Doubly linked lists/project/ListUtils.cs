using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class ListUtils
    {
        public class SetUtils
        {
            public delegate bool CheckDelegate<T>(T x);
            public delegate bool CheckDelegate_<T>(T x, T y);
            public delegate IList<T> SetConstructorDelegate<T>() where T : IComparable<T>;
            public delegate T ActionDelegate<T>(T x);
            public delegate TO ConvertDelegate<TI, TO>(TI x);

            public static IList<T> ArrayListConstructor<T>() where T : IComparable<T>
            {
                return new ArrayList<T>();
            }
            public static IList<T> LinkedListConstructor<T>() where T : IComparable<T>
            {
                return new LinkedList<T>();
            }

            //проверка на существование элемента, подходящего под критерий check
            public static bool Exists<T>(IList<T> iList, CheckDelegate<T> check)
            {
                foreach (T t in iList)
                {
                    if (check(t))
                    {
                        return true;
                    }
                }
                return false;
            }
            public static bool Exists<T>(IList<T> iList, CheckDelegate_<T> check, T element)
            {
                foreach (T t in iList)
                {
                    if (check(t, element))
                    {
                        return true;
                    }
                }
                return false;
            }

            //копирование элементов из одного списка в другой
            public static IList<T> CopyAll<T>(IList<T> iList, SetConstructorDelegate<T> constructor) where T : IComparable<T>
            {
                IList<T> result = constructor();
                foreach (T t in iList)
                {
                    result.Add(t);
                }
                return result;
            }

            //создание нового списка, включающего только элементы, подходящие под критерий check
            public static IList<T> FindAll<T>(IList<T> iList, CheckDelegate<T> check, SetConstructorDelegate<T> constructor) where T : IComparable<T>
            {
                IList<T> result = constructor();
                foreach (T t in iList)
                {
                    if (check(t))
                        result.Add(t);
                }
                return result;
            }
            public static IList<T> FindAll_<T>(IList<T> iList, CheckDelegate_<T> check, T parametr, SetConstructorDelegate<T> constructor) where T : IComparable<T>
            {
                IList<T> result = constructor();
                foreach (T t in iList)
                {
                    if (check(t, parametr))
                        result.Add(t);
                }
                return result;
            }

            //преобразование всех элементов
            public static IList<TO> ConvertAll<TI, TO>(IList<TI> iList, ConvertDelegate<TI, TO> convertDelegate, SetConstructorDelegate<TO> constructor) where TO : IComparable<TO>
            {
                IList<TO> result = constructor();
                foreach (TI tI in iList)
                {
                    result.Add(convertDelegate(tI));
                }
                return result;
            }

            //реализация цикла ForEach
            public static void ForEach<T>(ref IList<T> iList, ActionDelegate<T> actionDelegate) where T : IComparable<T>
            {
                if (iList is UnmutableList<T>)
                {
                    throw new InvalidActionExeption();
                }
                IList<T> result = null;
                switch (iList)
                {
                    case ArrayList<T> _:
                        {
                            result = new ArrayList<T>();
                        }
                        break;
                    case LinkedList<T> _:
                        {
                            result = new LinkedList<T>();
                        }
                        break;
                }
                foreach (T t in iList)
                {
                    result.Add(actionDelegate(t));
                }
                iList = result;
            }

            //проверка списка на то что все элементы соответствуют критерию check
            public static bool CheckForAll<T>(IList<T> iSet, CheckDelegate<T> check)
            {
                foreach (T t in iSet)
                {
                    if (!check(t))
                        return false;
                }
                return true;
            }
        }
    }
}
