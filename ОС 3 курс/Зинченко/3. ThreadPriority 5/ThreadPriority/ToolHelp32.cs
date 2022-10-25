using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices; //
using System.Threading.Tasks;

namespace ThreadPriority
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
                "Идентификатор процесса: " + th32ProcessID.ToString() + Environment.NewLine +
            "Кол-во потоков процесса: " + cntThreads.ToString() + Environment.NewLine +
            "Базовый приоритет процесса: " + pcPriClassBase.ToString() + Environment.NewLine;
            //    "Идентификатор родительского процесса: "+th32ParentProcessID.ToString() + Environment.NewLine;

            /*.Append("dwSize: ").Append(dwSize).Append(" ")
            .Append("cntUsage: ").Append(cntUsage).Append(" ")
            .Append("th32DefaultHeapID: ").Append(th32DefaultHeapID).Append(" ")
            .Append("th32ModuleID: ").Append(th32ModuleID).Append(" ")
            .Append("pcPriClassBase: ").Append(pcPriClassBase).Append(" ")
            .Append("dwFlags: ").Append(dwFlags).Append(" ")*/
            return str;
        }
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ThreadEntry32
    {
        //const int MAX_PATH = 260;
        public uint dwSize; // размер записи
        public uint cntUsage; // счетчик ссылок процесса
        //public uint th32ProcessID; // идентификатор процесса
        public uint th32ThreadID; // идентификационный номер процесса
        public uint th32OwnerProcessID; // идентификационный номер процесса
        public int tpBasePri; // базовый приоритет процесса 
        public int tpDeltaPri; // базовый приоритет процесса 
        public uint dwFlags; // зарезервировано 

        public override string ToString()
        {
            string str = "";
            str += "Информация о потоке: " + Environment.NewLine +
                 "ID: " + th32ThreadID.ToString() + Environment.NewLine +
                 "ID Процессора: " + th32OwnerProcessID.ToString() + Environment.NewLine +
                 "Приоритет: " + tpBasePri.ToString() + Environment.NewLine;
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
            // "Кол-во процессов использующих модуль: "+count.ToString() + Environment.NewLine;

            /*.Append("dwSize: ").Append(dwSize).Append(" ")
            .Append("th32ModuleID: ").Append(th32ModuleID).Append(" ")
            .Append("th32ProcessID: ").Append(th32ProcessID).Append(" ")
            .Append("GlblcntUsage: ").Append(GlblcntUsage).Append(" ")
            .Append("ProccntUsage: ").Append(ProccntUsage).Append(" ")                    
            .Append("hModule: ").Append(hModule).Append(" ")
            .Append(Environment.NewLine);*/
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

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern bool Thread32First([In]IntPtr hSnapshot, ref ThreadEntry32 lpte);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static public extern bool Thread32Next([In]IntPtr hSnapshot, ref ThreadEntry32 lpte);

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle([In] IntPtr hObject);

        #endregion

        /// <summary>
        /// Получение перечисления всех процессов
        /// </summary>
        /// <returns></returns>
        /// 

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
                    } while (Process32Next(handleToSnapshot, ref procEntry)); //пока таковые не закончатся
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

        public IEnumerable<ThreadEntry32> GetThreadList(uint th32ProcessID)
        {
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ThreadEntry32 thEntry = new ThreadEntry32();
                thEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ThreadEntry32));
                //thEntry.th32OwnerProcessID = th32ProcessID;
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, th32ProcessID);


                if (Thread32First(handleToSnapshot, ref thEntry))
                {
                    do {
                        if (thEntry.th32OwnerProcessID == th32ProcessID)
                            yield return thEntry;
                    }
                    while (Thread32Next(handleToSnapshot, ref thEntry));
                }
                else
                {
                    yield break;//throw new ApplicationException(string.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error()));
                }
            }
            finally { CloseHandle(handleToSnapshot); }
        }

        public int CountMaxPriorityByProcess(uint processId)
        {
            int max = 0;
            {
                foreach (ThreadEntry32 thEntry in GetThreadList(processId))
                {
                    int curr_prior = thEntry.tpBasePri;
                    if (curr_prior > max)
                        max = curr_prior;
                }
            }
            return max;
        }

        public int MaxPriority()
        {
            int max = 0; 
            int curr = 0; 
            foreach (ProcessEntry32 pe in GetProcessList())
            {
                curr = CountMaxPriorityByProcess(pe.th32ProcessID);
                if (curr > max)
                    max = curr;
            }
            return max;
        }



        public IEnumerable<ProcessEntry32> GetProccessesMaxPriorInRange(long len)
        {
            foreach (ProcessEntry32 pe in GetProcessList())
                if (CountMaxPriorityByProcess(pe.th32ProcessID) == len)
                    yield return pe;
        }
    }
}
