using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;

namespace task
{
    public class RsdnDirectory
    {
        #region WIN32_FIND_DATA
        const int MAX_PATH = 260;

        [Serializable]
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        [BestFitMapping(false)]
        struct WIN32_FIND_DATA
        {
            public FileAttributes dwFileAttributes;
            public FILETIME ftCreationTime;
            public FILETIME ftLastAccesTime;
            public FILETIME ftLastWriteTime;
            public int nFileSizeHigh;
            public int nFileSizeLow;
            public int dwReserved0;
            public int dwReserved1;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string cFileName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 114)]
            public string cAlternate;
        }

        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern IntPtr FindFirstFile(string lpFileName, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern bool FindNextFile(IntPtr hFindFile, out WIN32_FIND_DATA lpFindFileData);

        [DllImport("kernel32", SetLastError = true)]
        private static extern IntPtr FindClose(IntPtr hFindFile);

        private static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        #endregion

        static string MakePatch(string path)
        {
            return path + "*";
        }

        static IEnumerable<string> GetInternal(string path, bool isGetDirs)
        {
            WIN32_FIND_DATA findData;
            IntPtr findHadnle = FindFirstFile(MakePatch(path), out findData);

            try
            {
                if (findHadnle == INVALID_HANDLE_VALUE)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
            catch (Win32Exception e) { }

            try
            {
                do
                {
                    if (isGetDirs ? (findData.dwFileAttributes & FileAttributes.Directory) != 0 : (findData.dwFileAttributes & FileAttributes.Directory) == 0)
                        yield return findData.cFileName;
                }
                while (FindNextFile(findHadnle, out findData));
            }
            finally
            {
                FindClose(findHadnle);
            }            
        }

        public static IEnumerable<string> GetFiles(string path)
        {
            return GetInternal(path, false);
        }

        public static IEnumerable<string> GetDirectories(string path)
        {
            return GetInternal(path, true);
        }

        public static IEnumerable<string> GetAllDirectories(string path)
        {
            

            {
                foreach (string subDir in GetDirectories(path))
                {
                    if (subDir == ".." || subDir == ".")
                        continue;

                    string relativePath = path + subDir + @"\";

                    yield return relativePath;

                    foreach (string subDir2 in GetAllDirectories(relativePath))
                        yield return subDir2;
                }
            }

            
        }

        public static string[] GetAllFilesFromAllDirectories(string path)
        {
            string[] directories = RsdnDirectory.GetAllDirectories(path).ToArray<string>();
            string[] allFiles = new string[0];

            foreach (string subDir in directories)
            {
                string[] files = RsdnDirectory.GetFiles(subDir).ToArray<string>();
                allFiles = allFiles.Concat(files).ToArray();
            }

            return allFiles;
        }

        public static List<string> FindUniqDirectories(string path1, string path2, out List<string> allDirectories1, out List<string> allDirectories2)
        {
            allDirectories1 = RsdnDirectory.GetAllDirectories(path1).ToList();
            //allDirectories1.ForEach(x => x = GetLastDirectoryFromPath(x));
            for (int i = 0; i < allDirectories1.Count; i++)
                allDirectories1[i] = GetLastDirectoryFromPath(allDirectories1[i]);
            allDirectories1 = allDirectories1.Distinct().ToList();

            List<string> unique = new List<string>(allDirectories1);
            allDirectories2 = new List<string>();

            foreach (string directory in GetAllDirectories(path2))
            {
                string str = GetLastDirectoryFromPath(directory);
                allDirectories2.Add(str);
                if (unique.RemoveAll(x => x == str) == 0)
                    unique.Add(str);
            }

            allDirectories2 = allDirectories2.Distinct().ToList();

            return unique;
        }

        static string GetLastDirectoryFromPath(string path)
        {
            int pos2 = path.Length - 1;
            int pos1 = 0;

            for(int i = pos2 - 1; i>0;i--)
            {
                if(path[i] == '\\')
                {
                    pos1 = i;
                    break;
                }
            }

            string dir = path.Substring(pos1 + 1, pos2 - pos1 - 1);
            return dir;
        }
    }
}
