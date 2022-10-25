using System.Collections.Generic;
using System.Threading;
using System;
using System.IO;
using System.Linq;

namespace program_2
{
    class FileFinder
    {
        private string directory;
        private Thread thread;
        //private List<IEnumerable<string>> filenames;
        private List<string> filenames;
        //private IEnumerable<string> directories;
        //private List<string> directories;
        private string[] directories;

        public Thread Thread { get { return thread; } }

        public FileFinder(string directory)
        {
            this.directory = directory;
            this.filenames = new List<string>();
            thread = new Thread(new ThreadStart(Files));
        }

        public void Files()
        {
            directories = RsdnDirectory.GetAllDirectories(directory).ToArray();
            List<string> tmp = RsdnDirectory.GetFiles(directory).ToList();
            for (int i = 0; i < tmp.ToArray().Length; i++)
                tmp[i] = directory + "\\" + tmp[i];
            filenames.AddRange(tmp);
            foreach (string path in directories)
            {
                tmp = RsdnDirectory.GetFiles(path).ToList();
                for (int i = 0; i < tmp.ToArray().Length; i++)
                    tmp[i] = path + "\\" + tmp[i];
                filenames.AddRange(tmp);
            }
        }

        public void Start()
        {
            thread.Start();
        }

        //public List<IEnumerable<string>> GetFiles()
        public List<string> GetFiles()
        {
            return this.filenames;
        }

        // Возвращает время создания самого старого файла
        public DateTime Oldest()
        {
            /*DateTime result = DateTime.MaxValue;
            foreach (IEnumerable<string> f in filenames)
                foreach (string d in f)
                {
                    string str = directory + "\\" + f;
                    DateTime cd = File.GetCreationTime(str);
                    if (DateTime.Compare(result, cd) > 0)
                        result = cd;
                }
            return result;*/
            DateTime result = DateTime.MaxValue;
            foreach (string f in filenames)
            {
                //string str = directory + "\\" + f;
                DateTime cd = File.GetCreationTime(f);
                if (DateTime.Compare(result, cd) > 0)
                    result = cd;
            }
            return result;
        }

        public IEnumerable<string> Directories()
        {
            return this.directories;
        }
    }
}
