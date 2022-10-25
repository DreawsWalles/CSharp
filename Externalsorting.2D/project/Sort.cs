using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace project
{
    public static class Sort
    {
        static private int step = 8;
        static private void Swap(ref Film a, ref Film b)
        {
            Film t = a;
            a = b;
            b = t;
        }

        static private Film[] Sort_Shell(Film[] array, int length)
        {

            int d = length / 2;
            while (d >= 1)
            {
                for (int i = d; i < length; i++)
                {
                    int j = i;
                    while ((j >= d) && (array[j - d].CompareTo(array[j])) > 0)
                    {
                        Swap(ref array[j], ref array[j - d]);
                        j = j - d;
                    }
                }
                d = d / 2;
            }
            return array;
        }
        static private string[] insertNode(string info)
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
        // естественное двухпутевое однофазное слияние
        static public void MergeSort(string inputfileName, string outputFileName)
        {
            string[] fileNames = new string[] { "1", "2", "3", "4" };
            for (int j = 0; j < 4; j++) // создаем вспомогательные файлы
            {
                FileStream f = new FileStream(fileNames[j],FileMode.Create);
                f.Close();
            }
            FileStream f1_in = new FileStream(fileNames[0],FileMode.Open,FileAccess.ReadWrite);
            FileStream f2_in = new FileStream(fileNames[1], FileMode.Open, FileAccess.ReadWrite);
            FileStream file = new FileStream(inputfileName, FileMode.Open, FileAccess.Read);
            Film[] series = new Film[step];
            int count = 0;
            int resultIndex = 0; // индекс названия файла, содержащего результат
            while (file.Position != file.Length)
            {
                Film film = new Film();
                film.Read(file);
                if (film.Prizes[0] != "-")
                {
                    series[count] = film;
                    count++;
                }
                if (count == step)
                {
                    series = Sort_Shell(series, count);
                    foreach (Film element in series)
                        if (resultIndex % 2 == 0)
                            element.Write(f1_in);
                        else
                            element.Write(f2_in);
                    resultIndex++;
                    count = 0;
                }
            }
            if (count != 0)
            {
                series = Sort_Shell(series, count);
                for (int i = 0; i < count; i++)
                    if (resultIndex % 2 == 0)
                        series[i].Write(f1_in);
                    else
                        series[i].Write(f2_in);
                resultIndex++;
            }
            f1_in.Close();
            f2_in.Close();
            file.Close();
            bool isSorted = resultIndex == 1;
            resultIndex = 0;
            while (!isSorted) // пока файл не отсортирован
            {
                if (resultIndex == 0) // если нечетный номер переливания, льем из 1 и 2 в 3 и 4
                    isSorted = MergeSerieses(fileNames[0], fileNames[1], fileNames[2], fileNames[3]);
                else // иначе из 3 и 4 в 1 и 2
                    isSorted = MergeSerieses(fileNames[2], fileNames[3], fileNames[0], fileNames[1]);
                resultIndex += 2;
                resultIndex %= 4;
                step *= 2;
            }
            File.Copy(fileNames[resultIndex], outputFileName, true); // сохраняем результат
            for (int j = 0; j < 4; j++) // удаляем вспомогательные файлы
                File.Delete(fileNames[j]);
            File.Delete("help.txt");
        }


        // переливаем содержимое двух вспомогательных файлов в другие два
        static bool MergeSerieses(string f1_in, string f2_in, string f1_out, string f2_out)
        {
            FileStream f1_read = new FileStream(f1_in, FileMode.Open, FileAccess.Read);
            FileStream f2_read = new FileStream(f2_in, FileMode.Open, FileAccess.Read);
            FileStream[] f_write = new FileStream[] { new FileStream(f1_out, FileMode.Open, FileAccess.Write), new FileStream(f2_out, FileMode.Open, FileAccess.Write) };

            Film lastRead1 = null;
            Film lastRead2 = null;
            

            if (f1_read.Position != f1_read.Length)
            {
                lastRead1 = new Film();
                lastRead1.Read(f1_read);
            }
            if (f2_read.Position != f2_read.Length)
            {
                lastRead1 = new Film();
                lastRead1.Read(f1_read);
            }
            int i = 0;
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
        static void Merge(FileStream f1_in, FileStream f2_in, FileStream f_out, ref Film lastRead1, ref Film lastRead2)
        {
            bool isSeriesF1 = lastRead1 != null; // файл содержит серию, если он не пуст
            bool isSeriesF2 = lastRead2 != null;
            int count1 = isSeriesF1 ? 1 : 0;
            int count2 = isSeriesF2 ? 1 : 0;
            while (isSeriesF1 && isSeriesF2 && count1 <= step && count2 <= step) // пока что оба файла сожержат серии
            {
                if (lastRead1.CompareTo(lastRead2) <= 0) // элемент первого файла меньше второго
                {
                    isSeriesF1 = AddFromFile(f1_in, f_out, ref lastRead1);
                    if (isSeriesF1)
                        count1++;
                }
                else
                {
                    isSeriesF2 = AddFromFile(f2_in, f_out, ref lastRead2);
                    if (isSeriesF2)
                        count2++;
                }

            }
            if (isSeriesF1) // если в первом файле серия не закончилась
                while (count1 <= step && AddFromFile(f1_in, f_out, ref lastRead1))
                    count1++;  // добавляем из него элементы, пока идет серия
            else if (isSeriesF2) // если во втором файле серия не закончилась
                while (count2 <= step && AddFromFile(f2_in, f_out, ref lastRead2))
                    count2++; // добавляем из него элементы, пока идет серия
        }

        /// <summary>
        /// записываем в файл последний считанный элемент
        /// </summary>
        /// <param name="f_in"> файл, из которого считан lastRead</param>
        /// <param name="f_out"> файл, в который записываем lastRead</param>
        /// <param name="lastRead"> последний считанный элемент из файла </param>
        /// <returns> возвращаем true, если в файле, из которого считали элемент, продолжается текущая серия </returns>
        static bool AddFromFile(FileStream f_in, FileStream f_out, ref Film lastRead)
        {
            lastRead.Write(f_out);
            Film lastWritten = lastRead;
            if (f_in.Position == f_in.Length)
            {
                lastRead = null;
                return false;
            }
            lastRead = new Film();
            lastRead.Read(f_in);
            return lastRead.CompareTo(lastWritten) >= 0;
        }
    }
}
