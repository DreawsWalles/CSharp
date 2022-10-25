using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class ListException : Exception
    {
        public ListException(string message) : base(message)
        {

        }

    }
    public class IndexListException : ListException
    {
        private const string MESSAGE = "Индекс находился вне границ списка.";

        public IndexListException()
            : base(MESSAGE) { }
    }
    public class RangeListException : ListException
    {
        private const string MESSAGE = "Диапазон ячеек находится вне границ списка";
        public RangeListException() : base(MESSAGE) { }
    }
    public class InvalidActionExeption : ListException
    {
        private const string MESSAGE = "Данный класс не поддерживает изменения";
        public InvalidActionExeption() : base(MESSAGE) { }
    }
    public class InvalidDoingException : ListException
    {
        private const string MESSAGE = "Данный класс не поддерживает данную функцию";
        public InvalidDoingException() : base(MESSAGE) { }
    }
}
