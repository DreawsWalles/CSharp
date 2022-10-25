using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskThree
{
    public interface IPublication
    {
        string NamePublication { get; set; }
        string ToString();
        List<string> GetContent();
        Type GetType();

    }
}
