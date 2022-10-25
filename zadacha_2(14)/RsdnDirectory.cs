using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_2
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
        /// <param name="path">Путь, для которого нужно возвратить список.</param>
        /// <param name="isGetDirs">
        /// Если true - функция возвращает список каталогов, иначе файлов.
        /// </param>
        /// <returns>Список файлов или каталогов.</returns>
        private static IEnumerable<string> GetInternal(string path, bool isGetDirs)
        {
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
        /// Возвращает список объектов типа FInfo для файлов, находящихся по заданному пути path.
        /// </summary>
        /// <param name="path">Путь, для которого нужно возвратить список.</param>
        /// <returns>Список объектов FInfo</returns>
        private static IEnumerable<FInfo> GetInternalAll(string path)
        {
            foreach (string file in GetFiles(path))
            {
                string subPath = path + "\\" + file;
                FInfo info = new FInfo
                {
                    FileName = file,
                    FileAttr = File.GetAttributes(subPath)
                };
                yield return info;
            }

        }

        /// <summary>
        /// Функция меняет атрибуты файлов по заданному пути согласно условию задачи.
        /// Функция не меняет атрибуты файлов во внутренних каталогах.
        /// </summary>
        /// <param name="path">Путь, в котором будут изменены атрибуты файлов.</param>
        private static void ChangeInternal(string path)
        {
            foreach (string file in GetFiles(path))
            {
                string subPath = path + "\\" + file;
                // получаем все атрибуты файла
                FileAttributes attributes = File.GetAttributes(subPath);
                if ((attributes & FileAttributes.ReadOnly) != 0)
                {
                    // снимаем атрибут ReadOnly
                    attributes = attributes & ~FileAttributes.ReadOnly;
                    // устанавливаем атрибут Hidden
                    File.SetAttributes(subPath, attributes | FileAttributes.Hidden);
                }
            }
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
        /// Возвращает список каталогов для некоторого пути. Функция не перебирает
        /// вложенные подкаталоги!
        /// </summary>
        /// <param name="path">
        /// Каталог, для которого нужно получить список подкаталогов.
        /// </param>
        /// <returns>Список файлов каталога.</returns>
        public static IEnumerable<string> GetDirectories(string path)
        {
            return GetInternal(path, true);
        }

        /// <summary>
        /// Функция возвращает список относительных путей ко всем подкаталогам
        /// (в том числе и вложенным) заданного пути.
        /// </summary>
        /// <param name="path">Путь для которого унжно получить подкаталоги.</param>
        /// <returns>Список подкатлогов.</returns>
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

                // Создаем, рекурсивно, итератор для каждого подкаталога и...
                // возвращаем каждый его элемент в качестве элементов текущего итератора.
                // Этот прием позволяет обойти ограничение итераторов C# 2.0 связанное
                // с невозможностью вызовов "yield return" из функций вызваемых из 
                // функции итератора. К сожалению это приводит к созданию временного
                // вложенного итератора на каждом шаге рекурсии, но затраты на создание
                // такого объекта относительно не велики, а удобство очень даже ощутимо.
                foreach (string subDir2 in GetAllDirectories(relativePath))
                    yield return subDir2;
            }
        }

        /// <summary>
        /// Возвращает список объектов типа FInfo для файлов и каталогов, находящихся по заданному пути path.
        /// </summary>
        /// <param name="path">Путь, для которого нужно возвратить список.</param>
        /// <returns>Список объектов FInfo</returns>
        public static IEnumerable<FInfo> GetFilesAttributes(string path)
        {
            // возвращаем атрибуты файлов, находящихся непосредственно в каталоге
            foreach (var item in GetInternalAll(path))
                yield return item;
            // возвращаем атрибуты файлов во всех внутренних директориях
            foreach (string dir in GetAllDirectories(path))
            {
                foreach (var item in GetInternalAll(dir))
                    yield return item;
            }
        }

        /// <summary>
        /// Функция меняет атрибуты файлов по заданному пути согласно условию задачи.
        /// </summary>
        /// <param name="path">Путь, в котором будут изменены атрибуты файлов.</param>
        public static void ChangeFileAttributes(string path)
        {
            // меняем атрибуты файлов, находящихся непосредственно в каталоге
            ChangeInternal(path);
            // меняем атрибуты файлов во всех внутренних директориях
            foreach (string dir in GetAllDirectories(path))
            {
                ChangeInternal(dir);
            }
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
