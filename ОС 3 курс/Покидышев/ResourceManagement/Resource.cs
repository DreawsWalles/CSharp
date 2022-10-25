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
            var writer = new StreamWriter(FileName);  // rewrite file
            writer.Close();
        }

        // В данной реализации - текстовый файл
        public string FileName { get; }

        // Менеджер, который управляет доступом к ресурсу
        public Manager Manager { get; } = new Manager();

        // Запись в файл
        public void Write(string s)
        {
            var writer = new StreamWriter(FileName, true);
            writer.WriteLine(s);
            writer.Close();
        }
    }
}
