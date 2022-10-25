using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Task2
{
    class Finder
    {
        const string _searchPattern = "*.*";
        string _filePath1 = "";
        string _filePath2 = "";
        bool _directoriesCorrect = false;
        TextBox _output;
        Thread thread;

        /// <summary>
        /// Конструктор по умолчанию класса Finder
        /// </summary>
        /// <param name="output">TextBox для вывода информации</param>
        public Finder(TextBox output)
        {
            _filePath1 = "E:\\Program Files (x86)\\Adobe";
            _filePath2 = "E:\\My Files\\Учеба\\3 курс (5 семестр)\\ОС\\Task2\\Test\\Directory2";
            _directoriesCorrect = true;
            _output = output;
            thread = new Thread(CountSubdirectoriesWithoutHiddenFiles);
        }

        /// <summary>
        /// Конструктор с параметрами класса Finder
        /// </summary>
        /// <param name="output">TextBox для вывода информации</param>
        /// <param name="file1">Путь к первой директории</param>
        /// <param name="file2">Путь ко второй директории</param>
        public Finder(TextBox output, string file1, string file2)
        {
            _directoriesCorrect = Directory.Exists(file1) && Directory.Exists(file2);
            if (_directoriesCorrect)
            {
                _filePath1 = file1;
                _filePath2 = file2;
            }
            _output = output;
            thread = new Thread(CountSubdirectoriesWithoutHiddenFiles);
        }

        /// <summary>
        /// Изменить директории
        /// </summary>
        /// <param name="file1">Путь к первой директории</param>
        /// <param name="file2">Путь ко второй директории</param>
        /// <returns>True, если директории существуют, иначе - False</returns>
        public bool ChangeDirectories(string file1, string file2)
        {
            _directoriesCorrect = Directory.Exists(file1) && Directory.Exists(file2);
            if (_directoriesCorrect)
            {
                _filePath1 = file1;
                _filePath2 = file2;
            }
            return _directoriesCorrect;
        }

        /// <summary>
        /// Запуск потока проверки директорий
        /// </summary>
        public void Start()
        {
            thread.Start();
            thread = new Thread(CountSubdirectoriesWithoutHiddenFiles);
        }

        /// <summary>
        /// Подсчет поддиректоий в заданных директориях, не содержащих скрытых файлов
        /// </summary>
        private void CountSubdirectoriesWithoutHiddenFiles()
        {
            Thread thread1 = new Thread(CountSubdirectories);
            Thread thread2 = new Thread(CountSubdirectories);

            _output.Invoke(new Action(() => _output.Text += "Directories without hidden files:" + Environment.NewLine));

            thread1.Start(_filePath1);
            thread1.Join();
            thread2.Start(_filePath2);
            thread2.Join();
            _output.Invoke(new Action(() => _output.Text += Environment.NewLine));
        }

        /// <summary>
        /// Вывести текущие директории
        /// </summary>
        public void ShowDirectories()
        {
            _output.Invoke(new Action(() => _output.Text += "Directory one: " + _filePath1 + Environment.NewLine));
            _output.Invoke(new Action(() => _output.Text += "Directory two: " + _filePath2 + Environment.NewLine + Environment.NewLine));
        }

        /// <summary>
        /// Подсчет поддиректорий, не содержащих скрытых файлов
        /// </summary>
        /// <param name="directory">Директория, в которой производится поиск</param>
        /// <returns>Количество поддиректорий, не содержащих скрытых файлов</returns>
        private void CountSubdirectories(object directory)
        {
            string rootFolderPath = directory.ToString();
            Queue<string> dirQueue = new Queue<string>();
            dirQueue.Enqueue(rootFolderPath);
            string[] tmp_files;
            int dirWithoutHiddenFilesCount = 0;
            while (dirQueue.Count > 0)
            {
                rootFolderPath = dirQueue.Dequeue();

                tmp_files = DirectoryHandler.GetFiles(rootFolderPath).ToArray();

                ++dirWithoutHiddenFilesCount;
                
                for (int i = 0; i < tmp_files.Length; ++i)
                {
                    if (DirectoryHandler.Hidden(rootFolderPath, tmp_files[i]))
                    {
                        --dirWithoutHiddenFilesCount;
                        break;
                    }
                }

                tmp_files = DirectoryHandler.GetDirectories(rootFolderPath).ToArray();

                for (int i = 0; i < tmp_files.Length; ++i)
                {
                    if (tmp_files[i] != "." && tmp_files[i] != "..")
                        dirQueue.Enqueue(rootFolderPath + "//" + tmp_files[i]);                    
                }
            }
            _output.Invoke(new Action(() => _output.Text += directory + ": " + dirWithoutHiddenFilesCount + Environment.NewLine));
        }
    }
}
