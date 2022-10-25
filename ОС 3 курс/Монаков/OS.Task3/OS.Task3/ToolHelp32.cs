using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OS.Task3
{
    

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ProcessEntry32
    {
        const int MAX_PATH = 260;
        public uint dwSize; // размер записи
        public uint cntUsage; // счетчик ссылок процесса
        public uint th32ProcessID; // идентификационный номер процесса
        public IntPtr th32DefaultHeapID; // 
        public uint th32ModuleID; // идентифицирует модуль связанный с процессом 
        public uint cntThreads; // кол-во потоков в данном процессе
        public uint th32ParentProcessID; // идентификатор родительского процесса
        public int pcPriClassBase; // базовый приоритет проыесса 
        public uint dwFlags; // зарезервировано
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)] // 
        public string szExeFile; // путь к exe файлу или драйверу связанному с этим процессом

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


    [StructLayout(LayoutKind.Sequential)]
    public struct HEAPLIST32
    {
         /** The size of the structure, in bytes. **/
         internal UInt32 dwSize;
         /** The identifier of the process to be examined **/
         internal UInt32 th32ProcessID;
         /** The heap identifier. This is not a handle, and has meaning only to the tool help functions **/
         internal UInt32 th32HeapID;
         /** This member can be one of the following values.
         HF32_DEFAULT      1  // process's default heap
         HF32_SHARED       2  // is shared heap **/
         internal UInt32 dwFlags;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct HEAPENTRY32
    {
        /** The size of the structure, in bytes **/
        internal UInt32 dwSize;
        /** A handle to the heap block **/
        internal IntPtr hHandle;
        /** The linear address of the start of the block **/
        internal UIntPtr dwAddress;
        /** The size of the heap block, in bytes **/
        internal UInt32 dwBlockSize;
     
        internal UInt32 dwFlags;
        /** This member is no longer used and is always set to zero. **/
        internal UInt32 dwLockCount;
        /** Reserved; do not use or alter **/
        internal UInt32 dwResvd;
        /** The identifier of the process that uses the heap **/
        internal UInt32 th32ProcessID;
        /** The heap identifier. This is not a handle, and has meaning only to the tool help functions **/
        internal UIntPtr th32HeapID;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    

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
        const int FREE_SPACE = 2;

        #region Import from kernel32

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr CreateToolhelp32Snapshot([In]UInt32 dwFlags, [In]UInt32 th32ProcessID);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Process32First([In]IntPtr hSnapshot, ref ProcessEntry32 lppe);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Process32Next([In]IntPtr hSnapshot, ref ProcessEntry32 lppe);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]

        static extern bool Heap32ListFirst([In]IntPtr hSnapshot, ref HEAPLIST32 heaplist);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]

        static extern bool Heap32ListNext([In]IntPtr hSnapshot, ref HEAPLIST32 heaplist);


        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]

        static extern bool Heap32First(ref HEAPENTRY32 heapentry, UInt32 th32ProccessID, UInt32 th32HeapID);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]

        static extern bool Heap32Next(ref HEAPENTRY32 heapentry);

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle([In] IntPtr hObject);

        #endregion

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

        public IEnumerable<HEAPLIST32> GetHeapList()
        {
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                HEAPLIST32 heaplist = new HEAPLIST32();
                heaplist.dwSize = (UInt32)Marshal.SizeOf(typeof(HEAPLIST32));
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, 0);

                if (Heap32ListFirst(handleToSnapshot, ref heaplist))
                {
                    do
                    {
                        yield return heaplist;
                    } while (Heap32ListNext(handleToSnapshot, ref heaplist));
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


        public ulong CountFreeSpaceInHeap(UInt32 ProccessID, UInt32 HeapID)
        {
            HEAPENTRY32 HE = new HEAPENTRY32();
            HE.dwSize = (UInt32)Marshal.SizeOf(typeof(HEAPENTRY32));
            ulong free_space = 0;
            if (Heap32First(ref HE, ProccessID, HeapID))
            {
                do
                {
                    if (HE.dwFlags == FREE_SPACE)
                    {
                        free_space += HE.dwBlockSize ;
                    }
                } while (Heap32Next(ref HE));
            }
            else throw new ApplicationException(string.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error()));
            return free_space;
        }
    }
}
