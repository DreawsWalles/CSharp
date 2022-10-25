using System;
using System.Collections.Generic;
using System.IO;

namespace Task2_ex7
{
    public class ForDirectories
    {
        /// <summary>
        /// Каталог, с которого начинается обход файлов с целью найти самый поздний
        /// </summary>
        public string Directory { get; set; }     
        
        /// <summary>
        /// Самый поздний файл в каталогах и подкаталогах
        /// </summary>
        public DateTime MaxDateTime { get; private set; }

        /// <summary>
        /// Список всех файлов в каталогах и подкаталогах
        /// </summary>
        public List<string> FilesFromDir { get; } = new List<string>();

        /// <summary> 
        /// Инициализация данных и решение задачи:
        /// Проверить есть ли во втором каталоге более поздний файл, чем все файлы из первого каталога
        /// </summary>
        public void Solve()
        {   
            FilesFromDir.Clear();
            MaxDateTime = DateTime.MinValue;
            
            NewScanDir();
        }

        private void NewScanDir()
        {
            AllFilesFromDir(Directory);

            foreach (string dir in RsdnDirectory.GetAllDirectories(Directory))  
                AllFilesFromDir(dir);                                            
        }

        private void AllFilesFromDir(string dir)
        {
            foreach (string file in RsdnDirectory.GetFilse(dir))
            {
                string filename = dir + "\\" + file; // получаем имя файла
                var createTime = File.GetCreationTime(filename);
                if (DateTime.Compare(createTime, MaxDateTime) > 0)
                    MaxDateTime = createTime;
                FilesFromDir.Add(filename);
            }
        }

    }
}