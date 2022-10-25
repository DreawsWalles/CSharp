using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace project
{
    static class SortUnBalance
    {
        // естественное двухпутевое однофазное слияние
        public static void MergeSort(string inputfileName, string outputFileName)
        {
            string[] fileNames = new string[] { "1.txt", "2.txt", "3.txt", "4.txt" };
            for (int j = 0; j < 4; j++) // создаем вспомогательные файлы
            {
                StreamWriter f = new StreamWriter(fileNames[j]);
                f.Close();
            }
            StreamWriter help = new StreamWriter("help.txt");
            StreamReader file = new StreamReader(inputfileName);
            while (!file.EndOfStream)
            {
                string info = file.ReadLine() + file.ReadLine() + file.ReadLine() + file.ReadLine();
                Film film = new Film(insertNode(info));
                if (film.Date.Year == 2000)
                    help.WriteLine(film);
            }
            help.Close();
            file.Close();
            // переливаем входной файл по двум вспомогательным.
            // файл с именем fileNames[2] гарантированно пуст
            // если перелили в один файл, то получили отсортированный файл
            bool isSorted = MergeSerieses("help.txt", fileNames[2], fileNames[0], fileNames[1]);
            int resultIndex = 0; // индекс названия файла, содержащего результат
            while (!isSorted) // пока файл не отсортирован
            {
                if (resultIndex == 0) // если нечетный номер переливания, льем из 1 и 2 в 3 и 4
                    isSorted = MergeSerieses(fileNames[0], fileNames[1], fileNames[2], fileNames[3]);
                else // иначе из 3 и 4 в 1 и 2
                    isSorted = MergeSerieses(fileNames[2], fileNames[3], fileNames[0], fileNames[1]);
                resultIndex += 2;
                resultIndex %= 4;
            }
            File.Copy(fileNames[resultIndex], outputFileName, true); // сохраняем результат
            for (int j = 0; j < 4; j++) // удаляем вспомогательные файлы
                File.Delete(fileNames[j]);
            File.Delete("help.txt");
        }


        // переливаем содержимое двух вспомогательных файлов в другие два
        static bool MergeSerieses(string f1_in, string f2_in, string f1_out, string f2_out)
        {
            StreamReader f1_read = new StreamReader(f1_in);
            StreamReader f2_read = new StreamReader(f2_in);
            StreamWriter[] f_write = new StreamWriter[] { new StreamWriter(f1_out), new StreamWriter(f2_out) };

            Film lastRead1 = null;
            Film lastRead2 = null;
            string info = f1_read.ReadLine() + f1_read.ReadLine() + f1_read.ReadLine() + f1_read.ReadLine();
            if (info != "")
                lastRead1 = new Film(insertNode(info));
            info = f2_read.ReadLine() + f2_read.ReadLine() + f2_read.ReadLine() + f2_read.ReadLine();
            if (info != "")
                lastRead2 = new Film(insertNode(info));

            int i = 0; // количество получившихся серий
            // пока хотя бы 1 файл не пуст — сливаем серии в новый файл
            while (lastRead1 != null || lastRead2 != null)
            {
                // сливаем крайние серии в 1,
                // чередуем файлы, в которые сливаем
                Merge(f1_read, f2_read, f_write[i % 2], ref lastRead1, ref lastRead2);
                i++;
            }

            f1_read.Close();
            f2_read.Close();
            f_write[0].Close();
            f_write[1].Close();
            return i <= 1;
        }

        /// <summary>
        /// сливаем крайнии серии из файлов
        /// </summary>
        /// <param name="f1_in"> первый файл, содержащий серию </param>
        /// <param name="f2_in"> второй файл, содержащий серию </param>
        /// <param name="f_out"> файл, в который сливаются серии </param>
        /// <param name="lastRead1"> последний считанный из файла fr1 элемент </param>
        /// <param name="lastRead2"> последний считанный из файла fr2 элемент </param>
        static void Merge(StreamReader f1_in, StreamReader f2_in, StreamWriter f_out, ref Film lastRead1, ref Film lastRead2)
        {
            bool isSeriesF1 = lastRead1 != null; // файл содержит серию, если он не пуст
            bool isSeriesF2 = lastRead2 != null;
            while (isSeriesF1 && isSeriesF2) // пока что оба файла сожержат серии
            {
                if (lastRead1.CompareTo(lastRead2) <= 0) // элемент первого файла меньше второго
                    isSeriesF1 = AddFromFile(f1_in, f_out, ref lastRead1);
                else
                    isSeriesF2 = AddFromFile(f2_in, f_out, ref lastRead2);
            }
            if (isSeriesF1) // если в первом файле серия не закончилась
                while (AddFromFile(f1_in, f_out, ref lastRead1)) ; // добавляем из него элементы, пока идет серия
            else if (isSeriesF2) // если во втором файле серия не закончилась
                while (AddFromFile(f2_in, f_out, ref lastRead2)) ; // добавляем из него элементы, пока идет серия
        }

        /// <summary>
        /// записываем в файл последний считанный элемент
        /// </summary>
        /// <param name="f_in"> файл, из которого считан lastRead</param>
        /// <param name="f_out"> файл, в который записываем lastRead</param>
        /// <param name="lastRead"> последний считанный элемент из файла </param>
        /// <returns> возвращаем true, если в файле, из которого считали элемент, продолжается текущая серия </returns>
        static bool AddFromFile(StreamReader f_in, StreamWriter f_out, ref Film lastRead)
        {
            f_out.WriteLine(lastRead); // записываем последний считанный элемент в файл
            Film lastWritten = lastRead; // запоминаем последний записанный элемент
            string info = f_in.ReadLine() + f_in.ReadLine() + f_in.ReadLine() + f_in.ReadLine(); ; // считывает следующий элемент из файла file_read
            // если элемент отсутсвует, то в info будет записан null
            if (info == "")
            {
                lastRead = null;
                return false; // возвращаем false, т.к. серия заканчивается вместе с файлом
            }
            // иначе запоминаем последний считанный элемент
            lastRead = new Film(insertNode(info));
            // если последний считанный > или >= предыдущего, вернется true, 
            // т.к. в файле все еще идет необходимая серия
            // иначе вернется false, т.к. серия закончилась
            return lastRead.CompareTo(lastWritten) >= 0;
        }

        private static string[] insertNode(string info)
        {
            string[] result = new string[7];
            string help = "";
            info = info.Remove(0, 14);
            int i = 0;
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            help = help.Replace(" Фильм", "");
            result[2] = help;
            help = "";
            i += 2;
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            help = help.Replace(" Режиссер", "");
            result[0] = help;
            help = "";
            i += 2;
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            help = help.Replace(" Длительность", "");
            result[3] = help;
            help = "";
            i += 2;
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            help = help.Replace("Дата выхода", "");
            result[4] = help;
            help = "";
            i += 2;
            while (info[i] != 'Г')
            {
                help += info[i];
                i++;
            }
            help = help.Replace("Главые герои", "");
            result[1] = help;
            while (info[i] != ':')
                i++;
            i += 2;
            help = "";
            while (info[i] != ':')
            {
                help += info[i];
                i++;
            }
            help = help.Replace("Призы", "");
            help = help.Replace(";", ",");
            result[5] = help;
            i += 2;
            help = "";
            while (i < info.Length)
            {
                help += info[i];
                i++;
            }
            help = help.Replace(";", ",");
            result[6] = help;
            return result;
        }
    }
}
