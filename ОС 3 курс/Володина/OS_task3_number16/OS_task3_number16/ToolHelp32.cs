using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OS_task3_number16
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ProcessEntry32
    {
        const int MAX_PATH = 260;
        public uint dwSize; // размер записи
        public uint cntUsage; // счетчик ссылок процесса
        public uint th32ProcessID; // идентификационный номер процесса
        public IntPtr th32DefaultHeapID; // идентфикатор для кучи процесса, действующей по умолчанию
        public uint th32ModuleID; // идентифицирует модуль, связанный с процессом 
        public uint cntThreads; // кол-во потоков в данном процессе
        public uint th32ParentProcessID; // идентификатор родительского процесса
        public int pcPriClassBase; // базовый приоритет процесса 
        public uint dwFlags; // зарезервировано
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
        public string szExeFile; // путь к exe файлу или драйверу, связанному с этим процессом

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("Информация о процессе:").Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Имя: ").Append(szExeFile).Append(Environment.NewLine)
                .Append("Идентификатор процесса: ").Append(th32ProcessID).Append(Environment.NewLine)
                .Append("Кол-во потоков процесса: ").Append(cntThreads).Append(Environment.NewLine)
                .Append("Идентификатор родительского процесса: ").Append(th32ParentProcessID).Append(Environment.NewLine);

            /*.Append("dwSize: ").Append(dwSize).Append(" ")
            .Append("cntUsage: ").Append(cntUsage).Append(" ")
            .Append("th32DefaultHeapID: ").Append(th32DefaultHeapID).Append(" ")
            .Append("th32ModuleID: ").Append(th32ModuleID).Append(" ")
            .Append("pcPriClassBase: ").Append(pcPriClassBase).Append(" ")
            .Append("dwFlags: ").Append(dwFlags).Append(" ")*/

            return str.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ModuleEntry32
    {
        const int MAX_PATH = 260;
        public uint dwSize;  // размер записи
        public uint th32ModuleID; // идентификатор модуля
        public uint th32ProcessID; // идентификатор процесса
        public uint GlblcntUsage; // глобальный счетчик ссылок модуля
        public uint ProccntUsage; // счетчик ссылок в контексте процесса-владельца
        public IntPtr modBaseAddr; //  базовый адресс модуля в памяти
        public uint modBaseSize; // размер модуля памяти
        public IntPtr hModule; // дескриптор модуля
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szModule; // название модуля
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
        public string szExePath; // полный путь модуля

        public string ToString(int count)
        {
            StringBuilder str = new StringBuilder();

            str.Append("Информация о модуле:").Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Имя: ").Append(szModule).Append(Environment.NewLine)
                .Append("Базовый адрес: ").Append(modBaseAddr).Append(Environment.NewLine)
                .Append("Размер памяти: ").Append(modBaseSize).Append(" байт").Append(Environment.NewLine)
                .Append("Путь к файлу: ").Append(szExePath).Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Кол-во процессов, использующих модуль: ").Append(count).Append(Environment.NewLine);

            /*.Append("dwSize: ").Append(dwSize).Append(" ")
            .Append("th32ModuleID: ").Append(th32ModuleID).Append(" ")
            .Append("th32ProcessID: ").Append(th32ProcessID).Append(" ")
            .Append("GlblcntUsage: ").Append(GlblcntUsage).Append(" ")
            .Append("ProccntUsage: ").Append(ProccntUsage).Append(" ")                    
            .Append("hModule: ").Append(hModule).Append(" ")
            .Append(Environment.NewLine);*/

            return str.ToString();
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
        /// Функция выводит список всех действующих процессов.
        /// </summary>
        /// <returns>Структура ProcessEntry32, котораяя хранит основную информацию о процессе.</returns>
        public static IEnumerable<ProcessEntry32> GetProcessList()
        {
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ProcessEntry32 procEntry = new ProcessEntry32
                {
                    dwSize = (uint)Marshal.SizeOf(typeof(ProcessEntry32))
                };
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, 0);

                if (Process32First(handleToSnapshot, ref procEntry))
                {
                    do
                    {
                        yield return procEntry;
                    } while (Process32Next(handleToSnapshot, ref procEntry));
                }
                else
                {
                    throw new ApplicationException($"Failed with win32 error code { Marshal.GetLastWin32Error() }");
                }
            }
            finally
            {
                CloseHandle(handleToSnapshot);
            }
        }

        /// <summary>
        /// Функция возвращает список всех модулей.
        /// </summary>
        /// <returns>Структура ModuleEntry32, которая хранит основную информацию о модуле.</returns>
        public static IEnumerable<ModuleEntry32> GetModuleList()
        {
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ModuleEntry32 modEntry = new ModuleEntry32
                {
                    dwSize = (uint)Marshal.SizeOf(typeof(ModuleEntry32))
                };
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, 0);

                if (Module32First(handleToSnapshot, ref modEntry))
                {
                    do
                    {
                        yield return modEntry;
                    } while (Module32Next(handleToSnapshot, ref modEntry));
                }
                else
                {
                    throw new ApplicationException($"Failed with win32 error code { Marshal.GetLastWin32Error() }");
                }
            }
            finally
            {
                CloseHandle(handleToSnapshot);
            }
        }

        /// <summary>
        /// Функция возвращает список модулей, на которые ссылается процесс с ID th32ProcessID
        /// </summary>
        /// <param name="th32ProcessID">ID процесса, для которого будет выведен список модулей</param>
        /// <returns>Структура ModuleEntry32, которая хранит основную информацию о модуле.</returns>
        public static IEnumerable<ModuleEntry32> GetModuleList(uint th32ProcessID)
        {
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ModuleEntry32 modEntry = new ModuleEntry32
                {
                    dwSize = (uint)Marshal.SizeOf(typeof(ModuleEntry32))
                };
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, th32ProcessID);

                if (Module32First(handleToSnapshot, ref modEntry))
                {
                    do
                    {
                        yield return modEntry;
                    } while (Module32Next(handleToSnapshot, ref modEntry));
                }
            }
            finally
            {
                CloseHandle(handleToSnapshot);
            }
        }
    }
}
