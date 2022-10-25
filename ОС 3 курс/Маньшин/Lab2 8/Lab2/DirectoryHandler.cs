using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class DirectoryHandler
    {
        public event Action<int> Finished;

        string Path;
        int cnt;

        public DirectoryHandler(string path)
        {
            cnt = 0;
            Path = path;
        }

        public void CountHidden()
        {
            try
            { cnt = DirectoryMethods.CountHidden(Path); }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
            Finished(cnt);
        }
    }
}
