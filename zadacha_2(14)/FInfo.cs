using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_2
{
    public class FInfo
    {
        public string FileName;
        public FileAttributes FileAttr;

        public override string ToString()
        {
            return "FILENAME: " + FileName + "\r\n\t" + " READONLY: " + ((FileAttr & FileAttributes.ReadOnly) != 0) +
                   " HIDDEN: " + ((FileAttr & FileAttributes.Hidden) != 0) + "\r\n";
        }
    }
}
