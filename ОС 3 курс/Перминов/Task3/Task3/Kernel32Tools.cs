using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Task3
{
    /// <summary>
    /// Структура, содержащая информацию о процессах
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ProcessEntry32
    {
        public uint dwSize;
        public uint cntUsage;
        public uint th32ProcessID;
        public IntPtr th32DefaultHeapID;
        public uint th32ModuleID;
        public uint cntThreads;
        public uint th32ParentProcessID;
        public int pcPriClassBase;
        public uint dwFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)] 
        public string szExeFile;
    }

    /// <summary>
    /// Структура, содержащая информацию о потоках
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ThreadEntry32
    {
        public uint dwSize;
        public uint cntUsage;
        public uint th32ThreadID;
        public uint th32OwnerProcessID;
        public int tpBasePri;
        public int tpDeltaPri;
        public uint dwFlags;
    }

    internal class Kernel32Tools
    {
        // Набор флагов Snapshot'а
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
        static extern bool Thread32First([In]IntPtr hSnapshot, ref ThreadEntry32 lpte);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Thread32Next([In]IntPtr hSnapshot, ref ThreadEntry32 lpte);

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle([In] IntPtr hObject);

        #endregion

        /// <summary>
        /// Получение списка процессов
        /// </summary>
        /// <returns>Список процессов</returns>
        public IEnumerable<ProcessEntry32> GetProcessList()
        {
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ProcessEntry32 procEntry = new ProcessEntry32();
                procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ProcessEntry32));
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

        /// <summary>
        /// Получение списка потоков, выполняемых данным процессом
        /// </summary>
        /// <returns>Список потоков</returns>
        public IEnumerable<ThreadEntry32> GetThreadList(ProcessEntry32 procEntry)
        {
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ThreadEntry32 threadEntry = new ThreadEntry32();
                threadEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ThreadEntry32));
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, 0);

                if (Thread32First(handleToSnapshot, ref threadEntry))
                {
                    do
                    {
                        if (threadEntry.th32OwnerProcessID == procEntry.th32ProcessID)
                            yield return threadEntry;
                    } while (Thread32Next(handleToSnapshot, ref threadEntry));
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
    }
}
