using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace n16p31 {
    class Founder {
        string FPath;
        DateTime FDate;
        int FCnt = 0;

        public Founder (string pPath, DateTime pDate) {
            FPath = pPath;
            FDate = pDate;
        } //public Founder

        public int getCnt () { return FCnt; }

        public void cntYoungFiles () {
            //поиск файлов во вложенных папках
            foreach (string dir in RsdnDirectory.GetAllDirectories(FPath))
                foreach (string file in RsdnDirectory.GetFilse(dir))
                    if (File.GetLastWriteTime(dir + "\\" + file) > FDate)
                        FCnt++;

            //поиск файлов в заданной директории
            foreach (string file in RsdnDirectory.GetFilse(FPath))
                if (File.GetLastWriteTime(FPath + "\\" + file) > FDate)
                    FCnt++;
        } //public void cntYoungFiles
    } //class Founder
} //namespace n16p31
