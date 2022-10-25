using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class DBNote
    {
        public int id;
        public string Name;
        public string FileName; 
        public DBNote(int id, string Name, string FileName)
        {
            this.id = id;
            this.Name = Name;
            this.FileName = FileName;
        }
    }
}
