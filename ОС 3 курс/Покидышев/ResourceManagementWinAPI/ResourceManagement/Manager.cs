using System.Collections.Generic;
using System.Threading;
using System;

#pragma warning disable 618

namespace ResourceManagement
{
    // Управляет ресурсом
    internal class Manager
    {
        private readonly Queue<uint> _queue = new Queue<uint>();
        private bool _busy;
        private WinMessages.Message _message;

        public uint ThreadID;

        public Manager()
        {
            var t = new Thread(Run)
            {
                Name = "Manager",
                Priority = ThreadPriority.AboveNormal
            };
            t.Start();
        }

        private void Run()
        {
            ThreadID = (uint)AppDomain.GetCurrentThreadId();
            WinMessages.PeekMessage(out _message, IntPtr.Zero, 0x400, 0x400, 0x0000);

            while (true)
            {
                if (!WinMessages.PeekMessage(out _message, new IntPtr(-1), 0, 0, 0x0001))
                    continue;

                switch (_message.message)
                {
                    case (uint) CustomMessages.WmRequest:
                        if (!_busy)
                        {
                            WinMessages.PostThreadMessage((uint) _message.wParam.ToInt32(), (uint) CustomMessages.WmGranted);
                            _busy = true;
                        }
                        else
                        {
                            _queue.Enqueue((uint) _message.wParam.ToInt32());
                        }
                        break;
                    case (uint) CustomMessages.WmFinished:
                        _busy = false;
                        if (_queue.Count != 0)
                        {
                            _busy = true;
                            WinMessages.PostThreadMessage(_queue.Dequeue(), (uint) CustomMessages.WmGranted);
                        }
                        break;
                }
            }
        }

    }
}
