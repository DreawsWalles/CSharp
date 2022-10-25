using System.Collections.Generic;

namespace OS_task3_number16
{
    // вспомогательный класс для хранения модуля и всех процессов, которые ссылаются на данный модуль
    class ModulesProcess
    {
        // модуль
        public ModuleEntry32 Module { get; set; }
        // список процессов, ссылающихся на модуль
        public List<ProcessEntry32> Processes { get; set; }
        // количество процессов, ссылающихся на модуль
        public int Count => Processes.Count;

        public ModulesProcess()
        {
            Processes = new List<ProcessEntry32>();
        }
    }
}
