using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
using System.ComponentModel;

namespace Task2
{
    class DirectoryHandler
    {
        /// <summary>
        /// Формирует путь для использования в функции FindFirstFile
        /// </summary>
        private static string MakePath(string path)
        {
            return Path.Combine(path, "*");
        }

        /// <summary>
        /// Возвращает список файлов или каталогов находящихся в директории
        /// </summary>
        /// <param name="path">Директория, в которой производится поиск</param>
        /// <param name="getDirs">
        /// True - функция возвращает список каталогов, False - список файлов
        /// </param>
        /// <returns>Список файлов или каталогов</returns>
        private static IEnumerable<string> GetInternal(string path, bool getDirs)
        {
            WIN32_FIND_DATA findData;

            IntPtr findHandle = FindFirstFile(MakePath(path), out findData);
            
            if (findHandle == INVALID_HANDLE_VALUE)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            try
            {
                do
                    if (getDirs
                        ? (findData.dwFileAttributes & FileAttributes.Directory) != 0
                        : (findData.dwFileAttributes & FileAttributes.Directory) == 0)
                        yield return findData.cFileName;
                while (FindNextFile(findHandle, out findData));
            }
            finally
            {
                FindClose(findHandle);
            }
        }

        /// <summary>
        /// Проверка, является ли файл скрытым
        /// </summary>
        /// <param name="path">Путь к директории файла</param>
        /// <param name="filename"Имя файла</param>
        /// <returns>True - файл скрытый, False - нет</returns>
        public static bool Hidden(string path, string filename)
        {
            WIN32_FIND_DATA findData;
            IntPtr findHandle = FindFirstFile(MakePath(path), out findData);

            bool result = false;

            if (findHandle == INVALID_HANDLE_VALUE)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            try
            {
                do
                {
                    if (filename == findData.cFileName)
                        result = (findData.dwFileAttributes & FileAttributes.Hidden) != 0;
                }
                while (FindNextFile(findHandle, out findData));
            }
            finally
            {
                FindClose(findHandle);
            }
            return result;
        }

        /// <summary>
        /// Возвращает список файлов для некоторого пути.
        /// </summary>
        /// <param name="path">
        /// Каталог для которого нужно получить список файлов.
        /// </param>
        /// <returns>Список файлов каталога.</returns>
        public static IEnumerable<string> GetFiles(string path)
        {
            return GetInternal(path, false);
        }

        /// <summary>
        /// Поиск списка каталогов в директории
        /// </summary>
        /// <param name="path">
        /// Ддиректория, в которой производится поиск
        /// </param>
        /// <returns>Список каталогов</returns>
        public static IEnumerable<string> GetDirectories(string path)
        {
            return GetInternal(path, true);
        }

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
