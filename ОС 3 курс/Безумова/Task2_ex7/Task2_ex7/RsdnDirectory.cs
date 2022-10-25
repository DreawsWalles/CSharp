using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace Task2_ex7
{
    public class RsdnDirectory
    {
        /// <summary>
        /// Формирует путь требуемый функцией FindFirstFile.
        /// </summary>
        private static string MakePath(string path)
        {
            return Path.Combine(path, "*");
        }

        /// <summary>
        /// Возвращает список файлов или каталогов находящихся по заданному пути path.
        /// </summary>
        /// <param name="path">Путь для которого нужно возвратить список.</param>
        /// <param name="isGetDirs">Если true - функция возвращает список каталогов, иначе файлов.</param>
        /// <returns>Список файлов или каталогов.</returns>
        private static IEnumerable<string> GetInternal(string path, bool isGetDirs)
        {
            // Структура в которую функции FindFirstFile и FindNextFile возвращают информацию о текущем файле.
            Win32FindData findData;
            // Получаем информацию о текущем файле и дескриптор перечислителя.
            // Этот дескриптор требуется передавать функции FindNextFile для плучения следующих файлов.
            IntPtr findHandle = FindFirstFile(MakePath(path), out findData);

            //  Если произошла ошибка, то нужно вынуть информацию об ошибке и перепаковать ее в исключение.
            if (findHandle == InvalidHandleValue)
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

        /// <summary>
        /// Возвращает список файлов для некоторого пути.
        /// </summary>
        /// <param name="path">Каталог для которого нужно получить список файлов.</param>
        /// <returns>Список файлов каталога.</returns>
        public static IEnumerable<string> GetFilse(string path)
        {
            return GetInternal(path, false);
        }

        /// <summary>
        /// Возвращает список каталогов для некоторого пути (функция не перебирает вложенные подкаталоги)
        /// </summary>
        /// <param name="path">Каталог для которого нужно получить список подкаталогов.</param>
        /// <returns>Список файлов каталога.</returns>
        public static IEnumerable<string> GetDirectories(string path)
        {
            return GetInternal(path, true);
        }

        /// <summary>
        /// Функция возвращает список относительных путей по всем подкаталогам (в том числе и вложенным) заданного пути.
        /// </summary>
        /// <param name="path">Путь для которого унжно получить подкаталоги.</param>
        /// <returns>Список подкаталогов.</returns>
        public static IEnumerable<string> GetAllDirectories(string path)
        {
            // Сначала перебираем подкаталоги первого уровня вложенности...
            foreach (string subDir in GetDirectories(path))
            {
                // игнорируем имя текущего каталога и родительского.
                if (subDir == ".." || subDir == ".")
                    continue;

                // Комбинируем базовый путь и имя подкаталога.
                string relativePath = Path.Combine(path, subDir);

                // возвращаем пользователю относительный путь.
                yield return relativePath;

                // Создаем, рекурсивно, итератор для каждого подкаталога и возвращаем каждый его элемент в качестве
                // элементов текущего итератора. Этот прием позволяет обойти ограничение итераторов C# 2.0 связанное
                // с невозможностью вызовов "yield return" из функций вызваемых из функции итератора. К сожалению
                // это приводит к созданию временного вложенного итератора на каждом шаге рекурсии, но затраты
                // на создание такого объекта относительно не велики, а удобство очень даже ощутимо.
                foreach (var subDir2 in GetAllDirectories(relativePath))
                    yield return subDir2;
            }
        }

        #region Импорт из kernel32

        private const int MaxPath = 260;

        [Serializable]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        [BestFitMapping(false)]
        private struct Win32FindData
        {
            public readonly FileAttributes dwFileAttributes;
            private readonly System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
            private readonly System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
            private readonly System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
            private readonly int nFileSizeHigh;
            private readonly int nFileSizeLow;
            private readonly int dwReserved0;
            private readonly int dwReserved1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MaxPath)] public readonly string cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)] private readonly string cAlternate;
        }

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr FindFirstFile(string lpFileName,
            out Win32FindData lpFindFileData);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool FindNextFile(IntPtr hFindFile,
            out Win32FindData lpFindFileData);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool FindClose(IntPtr hFindFile);

        private static readonly IntPtr InvalidHandleValue = new IntPtr(-1);

        #endregion
    }
}