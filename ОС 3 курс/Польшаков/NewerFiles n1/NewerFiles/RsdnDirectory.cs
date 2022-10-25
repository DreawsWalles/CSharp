using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
using System.ComponentModel;

namespace NewerFiles
{
    [Serializable]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    [BestFitMapping(false)]
    public struct WIN32_FIND_DATA
    {
        public FileAttributes dwFileAttributes;
        public FILETIME ftCreationTime;
        public FILETIME ftLastAccessTime;
        public FILETIME ftLastWriteTime;
        public int nFileSizeHigh;
        public int nFileSizeLow;
        public int dwReserved0;
        public int dwReserved1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string cFileName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
        public string cAlternate;
    }

    public class RsdnDirectory
    {
        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr FindFirstFile(string lpFileName,
            out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool FindNextFile(IntPtr hFindFile,
            out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FindClose(IntPtr hFindFile);

        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        private static string MakePath(string path)
        {
            return Path.Combine(path, "*");
        }

        // Получить вложенные файлы или директории
        private static IEnumerable<string> GetInternal(string path, bool isGetDirs)
        {
            WIN32_FIND_DATA findData;
            IntPtr findHandle = FindFirstFile(MakePath(path), out findData);

            if (findHandle == INVALID_HANDLE_VALUE)
                throw new Win32Exception(Marshal.GetLastWin32Error());

            try
            {
                do
                    if (isGetDirs
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

        public static IEnumerable<string> GetFiles(string path)
        {
            return GetInternal(path, false);
        }

        // получить директории первого уровня вложенности
        public static IEnumerable<string> GetDirectories(string path)
        {
            return GetInternal(path, true);
        }

        public static IEnumerable<string> GetAllDirectories(string path)
        {
            // Сначала перебираем подкаталоги первого уровня вложенности
            foreach (string subDir in GetDirectories(path))
            {
                // Игнорируем имя текущего каталога и родительского
                if (subDir == ".." || subDir == ".")
                    continue;

                // Комбинируем базовый путь и имя подкаталога
                string relativePath = Path.Combine(path, subDir);

                // Возвращаем пользователю относительный путь
                yield return relativePath;

                foreach (string subDir2 in GetAllDirectories(relativePath))
                    yield return subDir2;
            }
        }
    }
}



