using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;

namespace Task3._7
{


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct HeapListEntry32
    {
        const int MAX_PATH = 260;
        public uint dwSize; // размер записи
        public uint th32ProcessID;//идентификатор ID процесса-владельца
        public uint th32HeapID;//ID кучи
        public uint dwFlags; // зарезервировано

        public override string ToString()
        {
            return base.ToString();
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct HeapEntry32
    {
        public uint dwSize; // размер записи
        public IntPtr hHandle; //дескриптор этого блока кучи
        public uint dwAdress;//линейный адрес начала блока
        public uint dwBlockSize; //размер блока в байтах
        public uint dwFlags;//признак, опред. тип блока кучи
        public uint dwLockCount;//счетчик блокировок блока памяти
        public uint dwResvd;//зраезервированно и пока не должно исп.
        public uint th32ProcessID;//идентификатор процесса-владельца
        public uint th32HeapID;//идентификатор кучи, кот. пренадлежит блок
       

        public override string ToString()
        {
            return base.ToString();
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]


    class ToolHelp32
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
        static extern bool Heap32ListFirst([In]IntPtr hSnapshot, ref HeapListEntry32 lppe);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Heap32ListNext([In]IntPtr hSnapshot, ref HeapListEntry32 lppe);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Heap32First(ref HeapEntry32 lppe, [In]UInt32 th32ProcessID, [In]UInt32 th32HeapID);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Heap32Next(ref HeapEntry32 lppe);

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle([In] IntPtr hObject);



        #endregion

        /// <summary>
        /// Проходим все кучи и получаем информацию обо всех блоках внутри отдельной кучи.
        /// </summary>
        /// <returns>HeapEntry32</returns>
        public IEnumerable<HeapEntry32> GetHeapInfo()
        {
            IntPtr handleToSnapshot = IntPtr.Zero;

            try
            {
                HeapListEntry32 heapListEntry32 = new HeapListEntry32();
                heapListEntry32.dwSize = (UInt32)Marshal.SizeOf(typeof(HeapListEntry32));
                HeapEntry32 heapEntry32 = new HeapEntry32();
                heapEntry32.dwSize = (UInt32)Marshal.SizeOf(typeof(HeapEntry32));

                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, 0);



                if (Heap32ListFirst(handleToSnapshot, ref heapListEntry32))
                {
                    do
                    {
                        if(Heap32First(ref heapEntry32,heapListEntry32.th32ProcessID,heapListEntry32.th32HeapID))
                        {
                            do
                            {
                                yield return heapEntry32;

                            } while (Heap32Next(ref heapEntry32));
                        }
                        
                    } while (Heap32ListNext(handleToSnapshot, ref heapListEntry32));
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
