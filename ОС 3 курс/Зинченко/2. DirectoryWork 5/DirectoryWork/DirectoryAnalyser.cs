using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DirectoryWork
{
    class DirectoryAnalyser
    {

        private string dir;
        private Thread thDir;

        public List<string> dirList;


        public DirectoryAnalyser(string _dir)
        {
            dir = _dir;
        }
        /// <summary>
        /// Нахождение одинаковых имен каталогов в директориях
        /// </summary>
        /// <param name="dir1">Первая директория</param>
        /// <param name="dir2">Вторая директория</param>
        /// <returns>Одинаковые имена каталогов в виде строки</returns>
        /*public static string Analysis(string dir1, string dir2)
        {
            if (dir1 == dir2)
                return "Передано две одинаковых директории";


            List<string> dir1List = DirectoryMethods.GetAllDirectoriesNames(dir1).ToList();
            List<string> dir2List = DirectoryMethods.GetAllDirectoriesNames(dir2).ToList();


           

            //Список директорий для сравнения
            List<string> comparingDirectories = new List<string>();


            foreach (string dirname in dir1List)
            {
                comparingDirectories.AddRange(dir2List.FindAll(x => x == dirname));
            }

            if (comparingDirectories.Count == 0)
                return "Нет каталогов с одинаковыми именами.";
            else
            {
                string result = "Каталоги с одинаковыми именами: \r\n";

                foreach (string comparename in comparingDirectories)
                    result += comparename + "\r\n";
                return result;
            }
        }*/
        void Run()
        {
            dirList = DirectoryMethods.GetAllDirectoriesNames(dir).ToList();
        }
        public void LoadDirectoriesAsync()
        {
            //dir = dir1;
            thDir = new Thread(Run);
            thDir.Start();
            thDir.Join();
            //dir = dir2;
            //Thread thDir2 = new Thread(Run);
        }
        public void Stop()
        {
            if (thDir.IsAlive)
            thDir.Abort();
        }
    }
}
