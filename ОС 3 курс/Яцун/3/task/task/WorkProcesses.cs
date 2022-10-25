using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace task
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct PROCESSENTRY32
    {
        const int MAX_PATH = 260;
        public uint dwSize;
        public uint cntUsage;
        public uint th32ProcessID;
        public IntPtr th32DefaultHeapID;
        public uint th32ModuleID;
        public uint cntThreads;
        public uint th32ParentProcessID;
        public int pcPriClassBase;
        public uint dwFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
        public string szExeFile;

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            str.Append("Информация о процессе:").Append(Environment.NewLine)
                .Append(Environment.NewLine)
                .Append("Имя: ").Append(szExeFile).Append(Environment.NewLine)
                .Append("Идентификатор процесса: ").Append(th32ProcessID).Append(Environment.NewLine);

            return str.ToString();
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct HEAPLIST32
    {
        public uint dwSize;
        public uint th32ProcessID;
        public uint th32HeapID;
        public uint dwFlags;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct HEAPENTRY32
    {
        public uint dwSize;
        public IntPtr hHandle;
        public uint dwAddress;
        public uint dwBlockSize;
        public uint dwFlags;
        public uint dwLockCount;
        public uint dwResvd;
        public uint th32ProcessID;
        public uint th32HeapID;
    }

    class WorkProcesses
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

        // [Flags]
        /* internal enum BlockHeapFlags : uint
         {
             LF32_FIXED = 0x00000001,
             LF32_FREE = 0x00000002,
             LF32_MOVEABLE = 0x00000004
         }*/

        public const uint LF32_FIXED = 0x00000001;
        public const uint LF32_FREE = 0x00000002;
        public const uint LF32_MOVEABLE = 0x00000004;

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
                    }
                    while (Process32Next(handleToSnapshot, ref procEntry));
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

        private static List<HEAPENTRY32> GetBlocks()
        {
            List<HEAPENTRY32> blocks = new List<HEAPENTRY32>();

            HEAPLIST32 hl = new HEAPLIST32();
            hl.dwSize = (UInt32)Marshal.SizeOf(typeof(HEAPLIST32));
            HEAPENTRY32 he = new HEAPENTRY32();
            he.dwSize = (UInt32)Marshal.SizeOf(typeof(HEAPENTRY32));

            IntPtr curSnap = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, 0);

            if (Heap32ListFirst(curSnap, ref hl))
            {
                do
                {
                    try
                    {
                        if (Heap32First(ref he, hl.th32ProcessID, hl.th32HeapID))
                        {
                            do
                            {
                                blocks.Add(he);
                            }
                            while (Heap32Next(ref he));
                        }
                    }
                    catch (AccessViolationException) { }
                }
                while (Heap32ListNext(curSnap, ref hl));
            }
            CloseHandle(curSnap);
            return blocks;
        }

        public static List<PROCESSENTRY32> maxProcesses;
        public static uint maxSize;

        public static void GetMaxProcesses()
        {
            List<PROCESSENTRY32> allProcesses = GetProcessList().ToList();
            List<HEAPENTRY32> blocks = GetBlocks();
            maxProcesses = new List<PROCESSENTRY32>();
            List<uint> sizes = new List<uint>();

            maxSize = 0;
            uint currSize = 0;
            foreach (PROCESSENTRY32 process in allProcesses)
            {
                foreach (HEAPENTRY32 block in blocks)
                {
                    if (block.th32ProcessID == process.th32ProcessID && block.dwFlags == LF32_FIXED)
                    {
                        currSize += block.dwBlockSize;
                    }
                }
                sizes.Add(currSize);

                if (currSize > maxSize)
                    maxSize = currSize;
            }

            for (int i = 0; i < sizes.Count; i++)
                if (sizes[i] == maxSize)
                    maxProcesses.Add(allProcesses[i]);
        }
    }
}
