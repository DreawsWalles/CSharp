using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
using System.ComponentModel;

namespace Lab2
{
    class DirectoryMethods
    {
        #region Для задачи
        public static int CountHidden(string path)
        {
            //Число скрытых файлов
            int count = 0;
            // Структура в которую функции FindFirstFile и FindNextFile возвращают
            // информацию о текущем файле.
            WIN32_FIND_DATA findData;
            // Получаем информацию о текущем файле и дескриптор перечислителя.
            // Этот дескриптор требуется передавать функции FindNextFile для плучения
            // следующих файлов.
            IntPtr findHandle = FindFirstFile(MakePath(path), out findData);

            //  Если произошла ошибка, то
            // нужно вынуть информацию об ошибке и перепаковать ее в исключение.
            if (findHandle == INVALID_HANDLE_VALUE)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            try
            {
                do
                    if ((findData.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory && 
                        findData.cFileName != "." && 
                        findData.cFileName != "..")
                        count += CountHidden(path + "\\" + findData.cFileName);
                    else if ((findData.dwFileAttributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                        ++count;
                while (FindNextFile(findHandle, out findData));
            }
            finally
            {
                FindClose(findHandle);
            }

            return count;
        }
        #endregion

        #region Support

        /// <summary>
        /// Формирует путь требуемый функцией FindFirstFile.
        /// </summary>
        private static string MakePath(string path)
        {
            return Path.Combine(path, "*");
        }

        #endregion

        #region Импорт из kernel32

        private const int MAX_PATH = 260;

        [Serializable]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        [BestFitMapping(false)]
        private struct WIN32_FIND_DATA
        {
            public FileAttributes dwFileAttributes;
            public FILETIME ftCreationTime;
            public FILETIME ftLastAccessTime;
            public FILETIME ftLastWriteTime;
            public int nFileSizeHigh;
            public int nFileSizeLow;
            public int dwReserved0;
            public int dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternate;
        }

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr FindFirstFile(string lpFileName,
            out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool FindNextFile(IntPtr hFindFile,
            out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FindClose(IntPtr hFindFile);

        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        #endregion
    }
}