using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace task3
{
    public struct ProcessesThread
    {
        public ProcessEntry32 Proc;
        public List<ThreadEntry32> Threads;

        public ProcessesThread(ProcessEntry32 _proc, List<ThreadEntry32> _threads)
        {
            Proc = _proc;
            Threads = _threads;
        }
    }

    public class ToolHelp32
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
        private static extern IntPtr CreateToolhelp32Snapshot([In]uint dwFlags, [In]uint th32ProcessId);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool Process32First([In]IntPtr hSnapshot, ref ProcessEntry32 lppe);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool Process32Next([In]IntPtr hSnapshot, ref ProcessEntry32 lppe);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool Thread32First([In]IntPtr hSnapshot, ref ThreadEntry32 lpte);

        [DllImport("kernel32", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool Thread32Next([In]IntPtr hSnapshot, ref ThreadEntry32 lpte);

        [DllImport("kernel32", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle([In] IntPtr hObject);

        #endregion

        /*public IEnumerable<ProcessEntry32> GetProcessList()
        {
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ProcessEntry32 procEntry = new ProcessEntry32 { dwSize = (uint)Marshal.SizeOf(typeof(ProcessEntry32)) };
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, 0);

                if (Process32First(handleToSnapshot, ref procEntry))
                    do
                    {
                        yield return procEntry;
                    } while (Process32Next(handleToSnapshot, ref procEntry));
                else
                    throw new ApplicationException($"Failed with win32 error code {Marshal.GetLastWin32Error()}");
            }
            finally { CloseHandle(handleToSnapshot); }
        }


        public IEnumerable<ThreadEntry32> GetThreadList()
        {
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ThreadEntry32 threadEntry = new ThreadEntry32
                {
                    dwSize = (uint)Marshal.SizeOf(typeof(ThreadEntry32))
                };
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, 0);
                if (Thread32First(handleToSnapshot, ref threadEntry))
                    do
                        yield return threadEntry;
                    while (Thread32Next(handleToSnapshot, ref threadEntry));
                else
                    throw new ApplicationException($"Failed with win32 error code { Marshal.GetLastWin32Error() }");
            }
            finally { CloseHandle(handleToSnapshot); }
        } // GetThreadsList

        public IEnumerable<ThreadEntry32> GetThreadList(ProcessEntry32 procEntry)
        {
            Random random = new Random();
            IntPtr handleToSnapshot = IntPtr.Zero;
            try
            {
                ThreadEntry32 threadEntry = new ThreadEntry32
                {
                    dwSize = (uint)Marshal.SizeOf(typeof(ThreadEntry32))
                };
                handleToSnapshot = CreateToolhelp32Snapshot((uint)SnapshotFlags.All, 0);

                if (Thread32First(handleToSnapshot, ref threadEntry))
                    do
                    {
                        threadEntry.cntUsage = (uint)random.Next(10);
                        if (threadEntry.th32OwnerProcessID == procEntry.th32ProcessID)
                            yield return threadEntry;
                    } while (Thread32Next(handleToSnapshot, ref threadEntry));
                else
                    throw new ApplicationException($"Failed with win32 error code {Marshal.GetLastWin32Error()}");
            }
            finally { CloseHandle(handleToSnapshot); }
        }
        */
        public static List<ProcessesThread> GetProcList()
        {
            List<ProcessesThread> ProcThr = new List<ProcessesThread>();
            IntPtr handleToSnapshotProc = IntPtr.Zero;
            IntPtr handleToSnapshotThr = IntPtr.Zero;
            try
            {
                ProcessEntry32 procEntry = new ProcessEntry32();
                procEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ProcessEntry32));
                handleToSnapshotProc = CreateToolhelp32Snapshot((uint)SnapshotFlags.Process, 0);
                handleToSnapshotThr = CreateToolhelp32Snapshot((uint)SnapshotFlags.Thread, 0);
                if (Process32First(handleToSnapshotProc, ref procEntry))
                {
                    do
                        ProcThr.Add(new ProcessesThread(procEntry, GetThreadList(procEntry.th32ProcessID, handleToSnapshotThr)));
                    while (Process32Next(handleToSnapshotProc, ref procEntry));
                }
                else
                {
                    throw new ApplicationException(string.Format("Снимок пуст"));
                }
            }
            catch { new ApplicationException(string.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error())); }
            finally
            {
                CloseHandle(handleToSnapshotProc);
                CloseHandle(handleToSnapshotThr);
            }
            return ProcThr;
        }

        public static List<ThreadEntry32> GetThreadList(uint th32ProcessID, IntPtr snapshot)
        {
            List<ThreadEntry32> res = new List<ThreadEntry32>();
            try
            {
                ThreadEntry32 thrEntry = new ThreadEntry32();
                thrEntry.dwSize = (UInt32)Marshal.SizeOf(typeof(ThreadEntry32));
                if (Thread32First(snapshot, ref thrEntry))
                    do
                        if (thrEntry.th32OwnerProcessID == th32ProcessID)
                            res.Add(thrEntry);
                    while (Thread32Next(snapshot, ref thrEntry));
                else
                    throw new ApplicationException(string.Format("Снимок пуст"));
            }
            catch { new ApplicationException(string.Format("Failed with win32 error code {0}", Marshal.GetLastWin32Error())); };
            return res;
        }

        public static List<string> GetTaskResult(List<ProcessesThread> lst)
        {
            List<string> taskProcesses = new List<string>();
            foreach (ProcessesThread proc in lst)
            {
                foreach (ThreadEntry32 proc_tr in proc.Threads)
                {
                    try
                    {
                        if (proc_tr.cntUsage >= 0)
                        {
                            taskProcesses.Add("Процесс: " + proc.Proc.szExeFile + "; ID потока: " + proc_tr.th32ThreadID);
                           // break;
                        }
                    }
                    catch { new ApplicationException(string.Format("Ошибка получения данных о потоке")); };
                }
            }
            return taskProcesses;
        }
        public static void GetTreeProcesses(ref TreeView tv, ref List<ProcessesThread> processes)
        {
            for (int i = 0; i < processes.Count; i++)
            {
                TreeNode[] tn_proc = new TreeNode[processes[i].Threads.Count];
                for (int j = 0; j < processes[i].Threads.Count; j++)
                    tn_proc[j] = new TreeNode(processes[i].Proc.szExeFile + processes[i].Threads[j].th32ThreadID.ToString());
                tv.Nodes.Add(new TreeNode(processes[i].Proc.szExeFile, tn_proc));
            }
        }

    } // class
} // namespace