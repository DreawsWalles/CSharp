using System;
using System.Threading;

namespace ResourceManagement
{
    // Пользователь ресурсов
    internal class Worker
    {
        internal enum WorkerState
        {
            Idle,
            Waiting,
            Working
        }

        private static readonly Random Rnd = new Random();
        private static int _n;

        private int _attempts;
        private WorkerState _state;

        protected int NWrite;

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
        
        // Callback на изменение состояния
        public Action OnStateChanged { get; set; }

        // Инициализирует новый экземпляр работника
        public Worker(Resource resource, int attempts, string name = "")
        {
            Name = name;
            State = WorkerState.Idle;
            N = _n++;
            Resource = resource;
            NWrite = _attempts = attempts;
        }

        // Работа с ресурсом
        public void Work()
        {
            while (_attempts > 0)
            {
                State = WorkerState.Waiting;
                _attempts--;
                Resource.Manager.WannaUse(this, () =>
                {
                    State = WorkerState.Working;
                    Resource.Write("Writer " + N + " wrote " + NWrite--);
                    Thread.Sleep(Rnd.Next(2000, 3000));
                    State = NWrite == _attempts ? WorkerState.Idle : WorkerState.Waiting;
                    Resource.Manager.StoppedUsing(this);
                });
                Thread.Sleep(Rnd.Next(3000, 4000));
            }
        }
    }
}
