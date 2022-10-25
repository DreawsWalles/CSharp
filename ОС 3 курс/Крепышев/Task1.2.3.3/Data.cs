using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1._2._3._3
{
    class Data
    {
        public int ThreadID { get; private set; }
        public int DataID { get; private set; }

        public Data(int threadID, int dataID)
        {
            this.ThreadID = threadID;
            this.DataID = dataID;
        }

        public override string ToString()
        {
            return String.Format("ID потока - {0}, ID записи - {1}", ThreadID, DataID);
        }
    }
}
