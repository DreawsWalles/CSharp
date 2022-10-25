/* Заданы два каталога. Проверить, есть ли во втором файлы,
 * созданые позже, чем любой из первого каталога.
*/

using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace program_2
{
    class CompareCreationTime
    {
        private FileFinder f1;
        private FileFinder f2;
        private Thread thread;
        private TextBox result;
        private bool found;
        
        public CompareCreationTime(FileFinder finder1, FileFinder finder2, TextBox tb)
        {
            this.f1 = finder1;
            this.f2 = finder2;
            this.result = tb;
            this.found = false;
            thread = new Thread(new ThreadStart(Find));
        }

        // Записывает в текстбокс все файлы из второго каталога, младше старшего из первого
        public void Find()
        {
            this.f1.Start();
            this.f2.Start();
            this.f1.Thread.Join();
            this.f2.Thread.Join();

            // Самый старый из первого
            DateTime oldest = f1.Oldest();

            // Выводим все то, что младше из нового
            List<string> ds;
            ds = f2.GetFiles();
            string sresult = "";
            foreach (string d in ds)
                if (DateTime.Compare(oldest, File.GetCreationTime(d)) < 0)
                {
                    sresult += d + Environment.NewLine;
                    found = true;
                }
            if (result.InvokeRequired)
                result.Invoke(new Action<string>((s) => result.AppendText(s)), sresult);
            else
                result.AppendText(sresult);
        }

        public void StartWork()
        {
            thread.Start();
        }

    }
}
