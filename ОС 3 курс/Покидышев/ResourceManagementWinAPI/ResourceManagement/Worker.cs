using System;
using System.Threading;

#pragma warning disable 618

namespace ResourceManagement
{ 
    internal enum WorkerState
    {
        Idle,
        Waiting,
        Working
    }

    // Пользователь ресурсов
    internal class Worker : IWorker
    {
        private static readonly Random Rnd = new Random();
        private static int _n;
        private WorkerState _state;
        private WinMessages.Message _message;
        // id менеджера
        private readonly uint _managerID;

        protected int Attempts { get; private set; }
        // Callback на изменение состояния
        protected Action OnStateChanged { get; set; }
        
        // ресурс, с которым производится работа
        public Resource Resource { get; }
        // номер работника
        public int N { get; }
        // имя работника
        public string Name { get; set; }
        // Текущее состояние 
        public WorkerState State
        {
            get { return _state; }
            private set
            {
                _state = value;
                OnStateChanged?.Invoke(); 
            }
        }

        // Инициализирует новый экземпляр работника
        public Worker(Resource resource, int attempts, uint threadID, string name = "")
        {
            N = _n++;
            Name = name;
            State = WorkerState.Idle;
            Resource = resource;
            Attempts = attempts;
            _managerID = threadID;
        }

        // Работа с ресурсом
        public void Work()
        {
            WinMessages.PeekMessage(out _message, IntPtr.Zero, 0x400, 0x400, 0x0000);
            while (Attempts > 0)
            {
                switch (State)
                {
                    case WorkerState.Idle:
                        // "Take a rest" for a while
                        Thread.Sleep(N*1000 + Rnd.Next(1000));
                        // Then send a request for writing
                        WinMessages.PostThreadMessage(
                            _managerID,
                            (uint) CustomMessages.WmRequest,
                            new IntPtr(AppDomain.GetCurrentThreadId())
                        );
                        // Wait for permission
                        State = WorkerState.Waiting;
                        break;
                    case WorkerState.Waiting:
                        while (!WinMessages.PeekMessage(out _message, new IntPtr(-1), 0, 0, 0x0001) ||
                               _message.message != (uint) CustomMessages.WmGranted)
                        { /* Wait for permission */ }

                        // Do its job
                        State = WorkerState.Working;
                        Thread.Sleep(1600);
                        Resource.Write("Writer " + N + " wrote " + Attempts--);

                        // Tell manager that the job is finished
                        WinMessages.PostThreadMessage(_managerID, (uint)CustomMessages.WmFinished);
                        State = WorkerState.Idle;
                        break;
                }
            }
        }
    }
}
