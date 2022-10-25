using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoldersInfo
{
    public class Counter
    {
        #region Fields

        /// <summary>
        /// Контрол для первого каталога
        /// </summary>
        private TextBox _tbFirstFolder = null;

        /// <summary>
        /// Контрол для второго каталога
        /// </summary>
        private TextBox _tbSecondFolder = null;

        /// <summary>
        /// Первый путь
        /// </summary>
        private string _firstPath = string.Empty;

        /// <summary>
        /// Второй путь
        /// </summary>
        private string _secondPath = string.Empty;

        /// <summary>
        /// Поток первой папки
        /// </summary>
        private Thread _firstThread = null;

        /// <summary>
        /// Поток второй папки
        /// </summary>
        private Thread _secondThread = null;

        #endregion

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        private Counter(TextBox first, TextBox second, string firstpath, string secondpath)
        {
            _tbFirstFolder = first;
            _tbSecondFolder = second;

            _firstThread = new Thread(RunFirst);
            _secondThread = new Thread(RunSecond);

            _firstPath = firstpath;
            _secondPath = secondpath;
        }
          
        /// <summary>
        /// Статичесский метод создания объекта
        /// </summary>
        /// <param name="f"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static Counter CreateObject(TextBox f, TextBox s, string fp, string sp)
        {
            return new Counter(f, s, fp, sp);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Метод подсчета для первой папки
        /// </summary>
        private void RunFirst()
        {
            GetDirectory(_firstPath, _tbFirstFolder);
        }

        /// <summary>
        /// Метод подсчета файлов в директории
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private void CountInDirectory(string path, TextBox tb)
        {
            var data = new Data();
            foreach (var files in Directory.GetFiles(path).Where(files => files != null))
            {
                if (File.GetAttributes(path + "\\" + files).HasFlag(FileAttributes.Archive))
                    data.Archives++;
                if (File.GetAttributes(path + "\\" + files).HasFlag(FileAttributes.Hidden))
                    data.Hidden++;
                if (File.GetAttributes(path + "\\" + files).HasFlag(FileAttributes.ReadOnly))
                    data.ReadOnly++;
                if (File.GetAttributes(path + "\\" + files).HasFlag(FileAttributes.System))
                    data.System++;
            }
            data.CountAll();
            tb.Invoke(new Action( () => tb.Text += data.ToString())); 
            data.Dispose();
        }

        /// <summary>
        /// Метод получения каталогов по заданному пути
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tb"></param>
        private void GetDirectory(string path, TextBox tb)
        {
            foreach (var dir in Directory.GetDirectories(path).Where(dir => dir != null))
            {
                if (Directory.GetDirectories(path + "\\" + dir).Count() != 0)
                    GetDirectory(path + "\\" + dir, tb); 

                tb.Invoke(new Action(() => tb.Text += Environment.NewLine + "Название каталога: " + dir));
                tb.Invoke(new Action(() => tb.Text += Environment.NewLine + "Каталоги внутри: " + Directory.GetDirectories(path + "\\" + dir).Count().ToString()));
                CountInDirectory(path + "\\" + dir, tb);
            }
        }

        /// <summary>
        /// Метод подсчета для второй папки
        /// </summary>
        private void RunSecond()
        {
            GetDirectory(_secondPath, _tbSecondFolder);
        }

        /// <summary>
        /// Запуск подсчета для обеих папок
        /// </summary>
        public void Start()
        {
            _firstThread?.Start();
            _secondThread?.Start();
        }

        /// <summary>
        /// Метод немедленного завершения потоков
        /// </summary>
        public void Abort()
        {
            _firstThread?.Abort();
            _secondThread?.Abort();
        }  

        #endregion
    }
}
