using System;
using System.Collections.Generic;

namespace ResourceManagement
{
    // Управляет ресурсом
    internal class Manager
    {
        private readonly Queue<WorkerCallback> _queue = new Queue<WorkerCallback>();

        // Запрос доступа к ресурсу
        public void WannaUse(Worker w, Action callback)
        {
            lock (_queue)
            {
                _queue.Enqueue(new WorkerCallback(w, callback));
                if (_queue.Count == 1)
                    NextWorker();
            }
        }

        // Сообщение об окончании работы с ресурсом
        public void StoppedUsing(Worker w)
        {
            lock (_queue)
            {
                if (_queue.Peek().Worker == w)
                {
                    _queue.Dequeue();
                    NextWorker();
                }
            }
        }

        // Разрешить работу следующему запросившему
        private void NextWorker()
        {
            lock (_queue)
            {
                if (_queue.Count != 0)
                    _queue.Peek().Callback();
            }
        }

        private class WorkerCallback
        {
            public Worker Worker { get; }
            public Action Callback { get; }

            public WorkerCallback(Worker w, Action a)
            {
                Worker = w;
                Callback = a;
            }
        }
    }
}
