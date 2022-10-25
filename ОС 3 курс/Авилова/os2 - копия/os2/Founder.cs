using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace os2
{
    class Founder
    {
        //путь
        string path;

        //кол-во таких файлов
        int count = 0;
        
        public int Count
        {
            get
            {
                return count;
            }
        }

        public Founder(string _path)
        {
            path = _path;
        }

        //ищет дату самого молодой файла, т.е. который создан позже всех 
        public void FindYungestDate(out DateTime date)
        {
            //Инициализирует новый экземпляр структуры DateTime заданным годом, месяцем, днем, часом, минутой и секундой.
            DateTime _date = new DateTime(1, 1, 1, 0, 0, 0);
            //перебор всех файлов из списка файлов по некоторому заданному пути
            foreach (string file in RsdnDirectory.GetFilse(path))
                // GetLastWriteTime Возвращает время и дату последней операции записи в указанный файл 
                if (File.GetLastWriteTime(path + "\\" + file) > _date)
                    _date = File.GetLastWriteTime(path + "\\" + file);

            //перебор всех каталогов из списка каталогов по некоторому заданному пути
            foreach (string dir in RsdnDirectory.GetAllDirectories(path))
            {
                //перебор всех файлов из списка файлов по некоторому заданному пути
                foreach (string file in RsdnDirectory.GetFilse(dir))
                    if (File.GetLastWriteTime(dir + "\\" + file) > _date)
                        _date = File.GetLastWriteTime(dir + "\\" + file);
            }
            date = _date; 
        }

        //считает кол-во файлов, которые моложе указанной даты
        public void countOldestFiles(DateTime _date)
        {
            foreach (string file in RsdnDirectory.GetFilse(path))
                // GetLastWriteTime Возвращает время и дату последней операции записи в указанный файл 
                if (File.GetLastWriteTime(path + "\\" + file) > _date)
                    count++;

            //перебор всех каталогов из списка каталогов по некоторому заданному пути
            foreach (string dir in RsdnDirectory.GetAllDirectories(path))
            {
                //перебор всех файлов из списка файлов по некоторому заданному пути
                foreach (string file in RsdnDirectory.GetFilse(dir))
                    if (File.GetLastWriteTime(dir+"\\"+file) > _date) 
                      count++;
            }                                                                                                                                          
        }
    }
}
