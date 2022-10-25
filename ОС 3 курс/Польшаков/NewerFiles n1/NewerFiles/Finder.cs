using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//Заданы два каталога. Сравнить, в каком из них больше вложенных каталогов и вывести все.

namespace NewerFiles
{
    class Finder
    {
        private string path;
        private IEnumerable<FileInfo> files;
        private Thread thread;

        public Thread CurrentThread { get { return thread; } }

        public Finder(string path)
        {
            this.path = path;
            thread = new Thread(new ThreadStart(FindDirectories));
        }

        public DateTime GetOlderDate()
        {
            return files.Select(x => x.LastWriteTime).Max();
        }

        public IEnumerable<FileInfo> GetOlderThan(DateTime date)
        {
            return files.Where(x => x.LastWriteTime > date);
        }

        public void FindDirectories()
        {
            IEnumerable<string> filesNames = RsdnDirectory.GetFiles(path);
            files = filesNames.Select(x => new FileInfo(path + "\\" + x));
        }

        public void StartWork()
        {
            thread.Start();
        }
    }
}
