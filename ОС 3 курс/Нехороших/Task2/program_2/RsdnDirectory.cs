﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
using System.ComponentModel;

namespace program_2
{

    public class RsdnDirectory
    {
        #region Импорт kernel32
        [Serializable]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        [BestFitMapping(false)]

        //структура из методички
        private struct WIN32_FIND_DATA
        {
            //атрибуты найденного файла
            public FileAttributes dwFileAttributes;
            //время создания
            public FILETIME ftCreationTime;
            //последний доступ к файлу
            public FILETIME ftLastAccessTime;
            //последняя модификация
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

        //метод реализуется вне кода си шарп
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

        #region Решение задачи
        public static int CountReadOnly(string path)
        {
            //Число ро файлов
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
                        count += CountReadOnly(path + "\\" + findData.cFileName);
                    else if ((findData.dwFileAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
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
        //возвращает путь, требуемый для FindFirst
        private static string MakePath(string path)
        {
            return Path.Combine(path, "*");
        }
        /*
        /// <summary>
        /// Возвращает список файлов или каталогов находящихся по заданному пути path.
        /// </summary>
        /// <param name="path">Путь для которого нужно возвратить список.</param>
        /// <param name="isGetDirs">
        /// Если true - функция возвращает список каталогов, иначе файлов.
        /// </param>
        /// <returns>Список файлов или каталогов.</returns>
        private static IEnumerable<string> GetInternal(string path, bool isGetDirs)
        {
            //здесь инфа о найденном файле с помощью функций фф и фн
            WIN32_FIND_DATA findData;

            // Получаем информацию о текущем файле и дескриптор перечислителя.
            // Этот дескриптор требуется передавать функции FindNextFile для плучения
            // следующих файлов.
            IntPtr findHandle = FindFirstFile(MakePath(path), out findData);
            try
            {
                if (findHandle == INVALID_HANDLE_VALUE)
                    throw new Win32Exception(Marshal.GetLastWin32Error());
            }
            catch (Win32Exception e)
            {

            }

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
        /// Каталог для которого нужно получить список подкаталогов.
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
            foreach (string subDir in GetDirectories(path))
            {
                //игнорируем имя текущего каталога и родительского.
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
        }*/
    }
}
