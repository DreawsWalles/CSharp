using System;
using System.Runtime.InteropServices;
using System.Windows;

namespace ResourceManagement
{
    internal enum CustomMessages
    {
        WmRequest = 0x400 + 0x001,
        WmGranted = WmRequest + 0x001,
        WmFinished = WmGranted + 0x001,
    }

    internal static class WinMessages
    {
        [StructLayout(LayoutKind.Sequential)]
        internal struct Message
        {
            public IntPtr hahdler;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public Point pt;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostThreadMessage(uint threadID, uint msg, IntPtr wParam = default(IntPtr), IntPtr lParam = default(IntPtr));

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out Message lpMessage, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax, uint wRemoveMsg);
    }
}
