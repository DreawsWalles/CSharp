using System.IO;

namespace Task2
{
    class Сounter
    {
        //текущий каталог
        private string myPath;
        //размер файлов
        public float size;
       
        //конструктор
        public Сounter(string path)
        {
            myPath = path;
            size = 0;
        }

        //обход файлов в дериктории
        private void SearchInDir(string path)
        {
            foreach (string file in RsdnDirectory.GetFilse(path))
            {
                FileInfo newFile = new FileInfo(@path + "\\" + file);
                size += newFile.Length;

            }
        }

        //обход дерикторий
        public void AllSize()
        {
            SearchInDir(this.myPath);
            foreach (string dir in RsdnDirectory.GetAllDirectories(myPath))
                SearchInDir(dir);                                                                                                                                          
        }
    }
}
