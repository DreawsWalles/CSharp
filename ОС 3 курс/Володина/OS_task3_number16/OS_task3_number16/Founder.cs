using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OS_task3_number16
{
    // Класс Founder предназначен для решения основной задачи
    public static class Founder
    {
        // список объектов вспомогательного класса, который хранит модуль и список процессов, ссылающихся на модуль
        private static List<ModulesProcess> _listModulesProcess = new List<ModulesProcess>();

        // функция печати на TreeView
        private static void PrintToTreeView(TreeView tw)
        {
            tw.Nodes.Clear();
            foreach (var modulesProcess in _listModulesProcess)
                // если на модуль ссылаются несколько процессов
                if (modulesProcess.Count > 1)
                {
                    TreeNode[] trs = new TreeNode[modulesProcess.Processes.Count];
                    for (int index = 0; index < modulesProcess.Processes.Count; index++)
                    {
                        TreeNode tr = new TreeNode
                        {
                            Text = modulesProcess.Processes[index].szExeFile
                        };
                        trs[index] = tr;
                    }
                    tw.Nodes.Add(new TreeNode(modulesProcess.Module.szModule, trs));
                }
        }

        // получаем информацию о модуле по заданному индексу
        public static string GetModuleInfo(int index)
        {
            return _listModulesProcess[index].Module.ToString(_listModulesProcess[index].Processes.Count);
        }

        // получаем информацию о модуле по заданному индексу
        public static string GetProcessInfo(int parentIndex, int index)
        {
            return _listModulesProcess[parentIndex].Processes[index].ToString();
        }

        // функция, которая выполняет основную задачу: отбирает модули, на которые ссылаются несколько процессов
        public static void Solve(TreeView tw)
        {
            // перебираем все процессы
            foreach (var processEntry32 in ToolHelp32.GetProcessList())
            {
                // перебираем все модули текщего процесса
                foreach (var moduleEntry32 in ToolHelp32.GetModuleList(processEntry32.th32ProcessID))
                {
                    bool isAddModule = true; // флаг- добавить модуль
                    int index = 0;
                    // перебираем все модули в списке
                    foreach (var modulesProcess in _listModulesProcess)
                    {
                        // если текущий модуль текущего процесса уже есть в списке
                        if (modulesProcess.Module.szModule == moduleEntry32.szModule)
                        {
                            // получаем индекс текущего модуля в списке
                            index = _listModulesProcess.IndexOf(modulesProcess);
                            isAddModule = false;
                            break;
                        }
                    } // foreach (var modulesProcess in ListModulesProcess)
                    // если текущий модуль текущего процесса еще не был добавлен в список
                    if (isAddModule)
                        // добавляем модуль в список
                        _listModulesProcess.Add(new ModulesProcess
                        {
                            Module = moduleEntry32,
                            Processes = new List<ProcessEntry32> { processEntry32 }
                        });
                    // если текущий модуль текущего процесса уже есть в списке
                    else
                    {
                        bool isAddProc = true;
                        // перебираем процессы, на которые ссылается модуль
                        foreach (var proc in _listModulesProcess[index].Processes)
                        {
                            // если текущий процесс модуля совпадает с просматриваемым в данный момент процессом
                            if (proc.th32ProcessID == processEntry32.th32ProcessID)
                            {
                                isAddProc = false;
                                break;
                            }
                        }
                        if (isAddProc)
                            _listModulesProcess[index].Processes.Add(processEntry32);
                    }
                } // foreach (var moduleEntry32 in tool.GetModuleList(processEntry32.th32ProcessID))
            } // foreach (var processEntry32 in tool.GetProcessList())

            // сортируем результирующий список модулей по убыванию их количества процессов
            _listModulesProcess = _listModulesProcess.OrderByDescending(x => x.Count).ToList();

            PrintToTreeView(tw);
        }
    }
}
