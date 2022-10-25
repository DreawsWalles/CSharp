using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    public class MyType : IComparable<MyType>
    {
        public DateTime date { get; set; }
        public string name { get; set; }

        public MyType(string dateTime, string n)
        {
            date = DateTime.Parse(dateTime);
            name = n;
        }

        public MyType()
        {
            date = DateTime.Today;
            name = "name";
        }


        public override string ToString() => $"Дата: {date}{Environment.NewLine}" +
                                             $"Наименование: {name}{Environment.NewLine}";
        public int CompareTo(MyType other)
        {
            if (date == other.date)
            {
                return 0;
            }
            else if (date < other.date)
            {
                return -1;
            }
            return 1;
        }
    }
}
