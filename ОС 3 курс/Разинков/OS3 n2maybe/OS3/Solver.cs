using System;
using System.Collections.Generic;
using System.Linq;

namespace OS3
{
    static class Solver
    {
        public static string GetModulesWithMaxSize()
        {
            List<ProcessEntry32> Processes = ToolHelp32.GetProcessList().ToList();
            string result = "";
            foreach(ProcessEntry32 proc in Processes)
            {
                List<ModuleEntry32> Modules = ToolHelp32.GetModuleList(proc.th32ProcessID).ToList();
                result += proc.szExeFile + ": ";
                if (Modules.Count > 0)
                {
                    var MaxSize = Modules[0].szModule;
                    foreach (var module in Modules)
                        if (WinApiStringToStr(module.szExePath) > WinApiStringToStr(MaxSize))
                            MaxSize = module.szModule;
                    result += MaxSize + Environment.NewLine;
                }
                else
                    result += "Процесс не имеет подключенных модулей" + Environment.NewLine;
            }
            return result;
        }

        static int WinApiStringToStr(string str)
        {
            int result = 0;
            int i = 0;
            bool sign = str[i] == '-';
            if (sign)
                ++i;
            for (; i < str.Length; ++i)
                result = result * 10 + Convert.ToInt32(str[i]);
            return sign ? -result : result;
        }
    }
}
