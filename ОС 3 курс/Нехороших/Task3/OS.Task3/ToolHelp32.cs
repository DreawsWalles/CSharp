using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OS.Task3
{
    
    //инфа о процессе
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct ProcessEntry32
    {
        const int MAX_PATH = 260;
        public uint dwSize; // размер записи
        public uint cntUsage; // счетчик ссылок процесса
        public uint th32ProcessID; // идентификационный номер процесса
        public IntPtr th32DefaultHeapID; // ид для кучу процесса
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

            return str.ToString();
        }
    }

    //куча
    [StructLayout(LayoutKind.Sequential)]
    public struct HEAPLIST32
    {
         // размер записи в бт
         internal UInt32 dwSize;
         //ид процесса владельца
         internal UInt32 th32ProcessID;
         /** The heap identifier. This is not a handle, and has meaning only to the tool help functions **/
         internal UInt32 th32HeapID;
         /** This member can be one of the following values.
         HF32_DEFAULT      1  // стандартная куча процесса
         HF32_SHARED       2  // разделяемая обычным способом */
         internal UInt32 dwFlags;
    }

    //отдельные блоки
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
        /** счетчик блокировок блока памяти **/
        internal UInt32 dwLockCount;
        /** Reserved; do not use or alter **/
        internal UInt32 dwResvd;
        /** влаелец **/
        internal UInt32 th32ProcessID;
        /** ид кучи в нем **/
        internal UIntPtr th32HeapID;
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    

    internal class ToolHelp32
    {
         //для снимка
        [Flags]
        internal enum SnapshotFlags : uint
        {
            //СПИСОК КУЧ
            HeapList = 0x00000001,
            //список процессов
            Process = 0x00000002,
            Thread = 0x00000004,
            Module = 0x00000008,
            Module32 = 0x00000010,
            Inherit = 0x80000000,
            All = 0x0000001F,
            NoHeaps = 0x40000000
        }
        //124
        const int FIXED_SPACE = 1;

        #region Import from kernel32

        //снимок системы (тип инфы, ), дескриптор возвращает
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern IntPtr CreateToolhelp32Snapshot([In]UInt32 dwFlags, [In]UInt32 th32ProcessID);
        
        //(дескриптор, инфа о пр)
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Process32First([In]IntPtr hSnapshot, ref ProcessEntry32 lppe);

        //пока не фолс
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Process32Next([In]IntPtr hSnapshot, ref ProcessEntry32 lppe);

        //проход по всем кучам процесса
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]

        static extern bool Heap32ListFirst([In]IntPtr hSnapshot, ref HEAPLIST32 heaplist);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]

        static extern bool Heap32ListNext([In]IntPtr hSnapshot, ref HEAPLIST32 heaplist);


        //инфа обо всех блоках внутри отдельной кучи, ид процесса и куча = листферст
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
                //сюда инфу
                ProcessEntry32 procEntry = new ProcessEntry32();
                //определяем размер
                procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ProcessEntry32));
                //снимок включает инфу про модули, кучи и тд
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, 0);

                //получаем список процессов
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

        //список кучи
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

        //передаем процесс и его кучу, ищем объем фиксированной памяти
        public ulong CountFixedSpaceInHeap(UInt32 ProccessID, UInt32 HeapID)
        {
            //инфа о блоке
            HEAPENTRY32 HE = new HEAPENTRY32();
            HE.dwSize = (UInt32)Marshal.SizeOf(typeof(HEAPENTRY32));
            ulong fixed_space = 0;
            
            //хе, ид процесса и ид кучи
            if (Heap32First(ref HE, ProccessID, HeapID))
            {
                do
                {
                    //считаем свободную память
                    
                    if (HE.dwFlags == FIXED_SPACE)
                    {
                        fixed_space += HE.dwBlockSize ;
                    }
                } while (Heap32Next(ref HE));
            }
            else throw new ApplicationException(string.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error()));
            return fixed_space;
        }
    }
}
