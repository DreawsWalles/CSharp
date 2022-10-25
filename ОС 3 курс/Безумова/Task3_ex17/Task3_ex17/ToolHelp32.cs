using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Task3_ex17
{
    /// <summary>
    /// Структура для характеристик процесса
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ProcessEntry32
    {
        const int MAX_PATH = 260;
        public uint dwSize; // размер записи
        public uint cntUsage; // счетчик ссылок процесса
        public uint th32ProcessID; // идентификационный номер процесса
        public IntPtr th32DefaultHeapID; // идентификатор кучи процесса
        public uint th32ModuleID; // идентифицирует модуль связанный с процессом 
        public uint cntThreads; // кол-во потоков в данном процессе
        public uint th32ParentProcessID; // идентификатор родительского процесса
        public int pcPriClassBase; // базовый приоритет процесса 
        public uint dwFlags; // зарезервировано
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)] 
        public string szExeFile; // путь к exe файлу или драйверу связанному с этим процессом

        /// <summary>
        /// Перевод структуры в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = "";

            str += ("Имя: ") + szExeFile.ToString() + Environment.NewLine +
                "Идентификатор процесса: " + th32ProcessID.ToString() + Environment.NewLine;

            return str;
        }
    }

    /// <summary>
    /// Структура для модуля процесса
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ModuleEntry32
    {
        const int MAX_PATH = 260;
        public uint dwSize;  // размер записи
        public uint th32ModuleID; // идентификатор модуля
        public uint th32ProcessID; // идентификатор процесса
        public uint GlblcntUsage; // глобальный счетчик ссылок
        public uint ProccntUsage; // счетчик ссылок в контексте процессора
        public IntPtr modBaseAddr; //  базовый адресс модуля в памяти
        public uint modBaseSize; // размер модуля памяти
        public IntPtr hModule; // дескриптор модуля
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szModule; // название модуля
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
        public string szExePath; // полный путь модуля

        /// <summary>
        /// Перевод структуры в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string str = "";

            str += "Информация о модуле:" + Environment.NewLine +
                "Имя: " + szModule.ToString() + Environment.NewLine +
                "Базовый адрес: " + modBaseAddr.ToString() + Environment.NewLine +
                "Размер памяти: " + modBaseSize.ToString() + " байт" + Environment.NewLine +
                "Путь к файлу: " + szExePath.ToString() + Environment.NewLine;

            return str;
        }
    }

    internal class ToolHelp32
    {

        [Flags]
        internal enum SnapshotFlags : uint
        {
            HeapList = 0x00000001,
            Process = 0x00000002,
            Thread = 0x00000004,
            Module = 0x00000008,
            Module32 = 0x00000010,
            Inherit = 0x80000000,
            All = 0x0000001F,
            NoHeaps = 0x40000000
        }

        #region Import from kernel32

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr CreateToolhelp32Snapshot([In]UInt32 dwFlags, [In]UInt32 th32ProcessID);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Process32First([In]IntPtr hSnapshot, ref ProcessEntry32 lppe);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Process32Next([In]IntPtr hSnapshot, ref ProcessEntry32 lppe);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern bool Module32First([In]IntPtr hSnapshot, ref ModuleEntry32 lpme);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern bool Module32Next([In]IntPtr hSnapshot, ref ModuleEntry32 lpme);

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle([In] IntPtr hObject);

        #endregion

        /// <summary>
        /// Получение перечисления всех процессов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProcessEntry32> GetProcessList()
        {
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ProcessEntry32 procEntry = new ProcessEntry32(); //создаем экземпляр ProcessEntry
                procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ProcessEntry32)); //выделяем для него память
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, 0); //создаем снимок оперативной памяти

                if (Process32First(handleToSnapshot, ref procEntry)) //если есть хотя бы один процесс
                {
                    do
                    {
                        yield return procEntry; //возвращаем процесс
                    } while (Process32Next(handleToSnapshot, ref procEntry)); //пока они все не закончатся
                }
                else //если не удалось получить ни один процесс, кидаем исключение
                {
                    throw new ApplicationException("Failed with win32 error code {0}" + Marshal.GetLastWin32Error().ToString());
                }
            }
            finally
            {
                CloseHandle(handleToSnapshot); //уничтожаем снимок
            }
        }

        /// <summary>
        /// Получение перечисления всех модулей
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ModuleEntry32> GetModuleList()
        {
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ModuleEntry32 modEntry = new ModuleEntry32(); //создаем экземпляр структуры-модуля
                modEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ModuleEntry32)); //выделяем под него память
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, 0); //создаем снимок оперативной памяти

                if (Module32First(handleToSnapshot, ref modEntry)) //если есть хотя бы один модуль
                {
                    do
                    {
                        yield return modEntry; //возвращаем модуль
                    } while (Module32Next(handleToSnapshot, ref modEntry)); //пока не вернем все
                }
                else //если не получили ни одного, кидаем исключение
                {
                    throw new ApplicationException(string.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error()));
                }
            }
            finally
            {
                CloseHandle(handleToSnapshot); //уничтожаем снимок
            }
        }

        /// <summary>
        /// Получение всех модулей, используемых каким-либо процессом
        /// </summary>
        /// <param name="th32ProcessID"></param>
        /// <returns></returns>
        public IEnumerable<ModuleEntry32> GetModuleList(uint th32ProcessID)
        {
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ModuleEntry32 modEntry = new ModuleEntry32(); //создаем экземпляр структуры-модуля
                modEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ModuleEntry32)); //выделяем под него память
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, th32ProcessID); //создаем снимок заданного процесса

                if (Module32First(handleToSnapshot, ref modEntry)) //получаем первый модуль
                {
                    do
                    {
                        yield return modEntry; //и возвращаем все последующие
                    } while (Module32Next(handleToSnapshot, ref modEntry)); // пока они еще есть
                }
                else //если не оказалось ни одного, ничего не возвращаем
                {
                    yield break;
                }
            }
            finally
            {
                CloseHandle(handleToSnapshot); //уничтожаем снимок
            }
        }

        #region Task
        /// <summary>
        /// Получает перечисление всех процессов
        /// </summary>
        public IEnumerable<ProcessEntry32> GetProcessesInIdRange()
        {
            foreach (ProcessEntry32 pe in this.GetProcessList())
                yield return pe;
        }

        /// <summary>
        /// Считает количество модулей, с которыми работает заданный процесс
        /// </summary>
        /// <param name="processId">ID процесса</param>
        /// <returns>Количество модулей</returns>
        public int CountModuleLength(uint processId)
        {
            int res=0;
            foreach (ModuleEntry32 me in this.GetModuleList(processId))
                ++res;
            return res;
        }    

        /// <summary>
        /// Модуль максимального размера в данном процессе
        /// </summary>
        /// <param name="processId">ID процесса</param>
        /// <returns>Количество модулей</returns>
        public long CountModuleMemSize(uint processId)
        {
            long tmp = 0;
            long res = 0;
            foreach (ModuleEntry32 me in this.GetModuleList(processId))
            {
                tmp = me.modBaseSize;
                if (tmp > res)
                    res = tmp;
            }
            return res;
        }

        /// <summary>
        /// Максимальный размер модуля среди всех процессов
        /// </summary>
        public long MaxModuleMemSize()
        {
            long max = 0; //Максимальный размер
            long curr = 0; //текущий
            foreach (ProcessEntry32 pe in this.GetProcessesInIdRange())
            {
                curr = this.CountModuleMemSize(pe.th32ProcessID);
                if (curr > max)
                    max = curr;
            }
            return max;
        }
        #endregion

    }
}
