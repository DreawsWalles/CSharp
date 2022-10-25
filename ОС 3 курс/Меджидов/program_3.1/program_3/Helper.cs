using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace program_3
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct PROCESSENTRY32
    {
        const int MAX_PATH = 260;
        public uint dwSize;                     // размер структуры PROCESSENTRY32
        public uint cntUsage;                   // значение счетчика ссылок процесса
        public uint th32ProcessID;              // id процесса
        public IntPtr th32DefaultHeapID;        // id кучи процесса, действующей по умолчанию
        public uint th32ModuleID;               
        public uint cntThreads;                 // сколько потоков начало выполняться в данном процессе
        public uint th32ParentProcessID;        // родительский процесс
        public int pcPriClassBase;              // базовый приоритет процесса
        public uint dwFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
        public string szExeFile;                // содержится строка с ограничивающим нуль-cpимволoм, которая представляет собой путь
                                                // и имя файла exe-программы или драйвера, связанного с данным процессом

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("Name: ").Append(szExeFile).Append(Environment.NewLine)
                .Append("PID: ").Append(th32ProcessID).Append(Environment.NewLine)
                .Append("PPID: ").Append(th32ParentProcessID).Append(Environment.NewLine);

            return str.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct HEAPLIST32
    {
        public uint dwSize;                     
        public uint th32ProcessID;              // id процесса-владельца
        public uint th32HeapID;                 // id кучи
        public uint dwFlags;                    // тип кучи
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct HEAPENTRY32
    {
        public uint dwSize;
        public IntPtr hHandle;                  // дискриптор блока кучи
        public uint dwAddress;                  // линейный адрес начала блока кучи
        public uint dwBlockSize;                // размер (в байтах) блока кучи
        public uint dwFlags;                    // тип блока кучи
        public uint dwLockCount;                // счетчик блокировок блока памяти
        public uint dwResvd;
        public uint th32ProcessID;              // id процесса-владельца
        public uint th32HeapID;                 // id кучи, которой принадлежит блок
    }

    class Helper
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

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool Heap32ListFirst([In]IntPtr hSnapshot, ref HEAPLIST32 lphl);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool Heap32ListNext([In]IntPtr hSnapshot, ref HEAPLIST32 lphl);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool Heap32First(ref HEAPENTRY32 lphe, [In]uint th32ProcessID, [In]uint th32HeapID);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool Heap32Next(ref HEAPENTRY32 lphe);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr CreateToolhelp32Snapshot([In]UInt32 dwFlags, [In]uint th32ProcessID);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool CloseToolhelp32Snapshot([In]IntPtr hSnapshot);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool CloseHandle([In]IntPtr hObject);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Process32First([In]IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Process32Next([In]IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        public static IEnumerable<PROCESSENTRY32> GetProcessList()
        {
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                PROCESSENTRY32 procEntry = new PROCESSENTRY32();
                procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(PROCESSENTRY32));
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
                    throw new ApplicationException(string.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error()));
                }
            }
            finally
            {
                CloseHandle(handleToSnapshot);
            }
        }

        public static IEnumerable<HEAPENTRY32> GetBlocks(uint pid = 0)
        {
            List<HEAPENTRY32> blocks = new List<HEAPENTRY32>();
            IntPtr curSnap = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, pid);

            try
            {
                HEAPLIST32 hl = new HEAPLIST32();
                hl.dwSize = (UInt32)Marshal.SizeOf(typeof(HEAPLIST32));

                HEAPENTRY32 he = new HEAPENTRY32();
                he.dwSize = (UInt32)Marshal.SizeOf(typeof(HEAPENTRY32));

                if (Heap32ListFirst(curSnap, ref hl))
                {
                    do
                    {
                        if (Heap32First(ref he, hl.th32ProcessID, hl.th32HeapID))
                        {
                            do
                            {
                                yield return he;
                            } while (Heap32Next(ref he));
                        }
                    } while (Heap32ListNext(curSnap, ref hl));
                }
            }
            finally
            {
                CloseHandle(curSnap);
            }
        }
    }
}
