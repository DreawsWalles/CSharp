using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    /// <summary>
    /// Для сравнения двух ThreadHandler'ов по оставшемуся объёму работы
    /// </summary>
    class ComparerByWork : IComparer<ThreadHandle>
    {
        public int Compare(ThreadHandle x, ThreadHandle y)
        {
            return x.RemainingWork.CompareTo(y.RemainingWork);
        }
    }
}
