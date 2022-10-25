using System.IO;

namespace ResourceManagement
{
    // Ресурс
    internal class Resource
    {
        // Инициализирует новый ресурс
        public Resource(string fileName)
        {
            FileName = fileName;
            var file = File.Create(FileName);
            file.Close();
        }

        // В данной реализации - текстовый файл
        public string FileName { get; }

        // Запись в файл
        public void Write(string s)
        {
            lock (this)
            {
                using (var writer = new StreamWriter(FileName, true))
                {
                    writer.WriteLine(s);
                }
            }
        }
    }
}
