using System.IO;

namespace OS_task2_number14
{
    // вспомогательный класс для хранения основной информации о файлах
    public class FInfo
    {
        // имя файла
        public string FileName;
        // атрибуты файла
        public FileAttributes FileAttr;

        public override string ToString()
        {
            return "FILENAME: " + FileName + "\r\n\t" + " READONLY: " + ((FileAttr & FileAttributes.ReadOnly) != 0) + 
                   " HIDDEN: " + ((FileAttr & FileAttributes.Hidden) != 0) + "\r\n";
        }
    }
}
