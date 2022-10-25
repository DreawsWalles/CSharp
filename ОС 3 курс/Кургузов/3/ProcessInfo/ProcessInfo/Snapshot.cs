using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProcessInfo
{
    public class Snapshot
    {
        #region Fields

        /// <summary>
        /// Информация о процессе
        /// </summary>
        private Process _process = null;

        /// <summary>
        /// Структура для описания процесса
        /// </summary>
        private PROCESSENTRY32 _pr32;

        /// <summary>
        /// Указатель на очередной процесс
        /// </summary>
        private IntPtr _handleToSnapshot = IntPtr.Zero;

        #endregion

        #region Properties

        /// <summary>
        /// Название процесса
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// ID процесса
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Занятая память
        /// </summary>
        public long MemorySize { get; set; }

        #endregion

        #region Constructor/destructor

        /// <summary>
        /// Конструктор
        /// </summary>
        public Snapshot()
        {
            _pr32 = new PROCESSENTRY32();

            try
            {
                _pr32.dwSize = (UInt32)Marshal.SizeOf(typeof(PROCESSENTRY32));
                _handleToSnapshot = CreateToolhelp32Snapshot(SnapshotFlags.Process, 0);

                if (Process32First(_handleToSnapshot, ref _pr32))
                {
                    do
                    {
                        try
                        {
                            _process = Process.GetProcessById((int)_pr32.th32ProcessID);
                        }
                        catch (Exception)
                        {

                        }
                        if (_process.WorkingSet64 > MemorySize)
                        {
                            MemorySize = _process.WorkingSet64;
                            Caption = _process.ProcessName;
                            ID = _process.Id;
                        }
                    }
                    while (Process32Next(_handleToSnapshot, ref _pr32));
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                CloseHandle(_handleToSnapshot);
            }
        }

        #endregion

        #region DLL import/Win API
        /// <summary>
        /// Метод получения моментального снимка 
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="th32ProcessID"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateToolhelp32Snapshot(SnapshotFlags dwFlags, uint th32ProcessID);

        /// <summary>
        /// Метод получения первого процесса 
        /// </summary>
        /// <param name="hSnapshot"></param>
        /// <param name="lppe"></param>
        /// <returns></returns>
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Process32First([In]IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        /// <summary>
        /// Метод получения очередного процесса
        /// </summary>
        /// <param name="hSnapshot"></param>
        /// <param name="lppe"></param>
        /// <returns></returns>
        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool Process32Next([In]IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        /// <summary>
        /// Метод закрытия обработчика для работы с моментальными снимками
        /// </summary>
        /// <param name="hObject"></param>
        /// <returns></returns>
        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle([In] IntPtr hObject);

        /// <summary>
        /// Структура описания процесса
        /// </summary>
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct PROCESSENTRY32
        {
            internal const int MAX_PATH = 260;
            internal UInt32 dwSize;
            internal UInt32 cntUsage;
            internal UInt32 th32ProcessID;
            internal IntPtr th32DefaultHeapID;
            internal UInt32 th32ModuleID;
            internal UInt32 cntThreads;
            internal UInt32 th32ParentProcessID;
            internal Int32 pcPriClassBase;
            internal UInt32 dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            internal string szExeFile;
        }

        /// <summary>
        /// Перечислимый тип 
        /// для типа информации 
        /// из блока памяти
        /// </summary>
        [Flags]
        private enum SnapshotFlags : uint
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
        #endregion
    }
}
