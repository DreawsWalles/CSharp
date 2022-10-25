using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ResourceManagement
{
    internal class Controller
    {
        private const int ToWrite = 3;

        private readonly List<IWorker> _workers;
        private readonly ResourceDraw _resourse = new ResourceDraw("out.txt", 180, 180);
        private readonly Graphics _graphics;

        public Controller(Control pb)
        {
            _graphics = pb.CreateGraphics();
            var manager = new Manager();

            _workers = new List<IWorker>
            {
                new WorkerDraw(_resourse, ToWrite, "", 2000, 5000, manager.ThreadID),

                new WorkerDraw(_resourse, ToWrite, "N", 200, 50, manager.ThreadID),
                new WorkerDraw(_resourse, ToWrite, "S", 200, 350, manager.ThreadID),
                new WorkerDraw(_resourse, ToWrite, "W", 50, 200, manager.ThreadID),
                new WorkerDraw(_resourse, ToWrite, "E", 350, 200, manager.ThreadID),

                new WorkerDraw(_resourse, ToWrite, "SE", 300, 300, manager.ThreadID),
                new WorkerDraw(_resourse, ToWrite, "NE", 300, 100, manager.ThreadID),
                new WorkerDraw(_resourse, ToWrite, "NW", 100, 100, manager.ThreadID),
                new WorkerDraw(_resourse, ToWrite, "SW", 100, 300, manager.ThreadID)
            };

            var draw = new Thread(Draw)
            {
                Name = "Draw",
                Priority = ThreadPriority.AboveNormal
            };
            draw.Start();

            foreach (var worker in _workers)
            {
                var t = new Thread(worker.Work)
                {
                    Name = "Worker " + worker.N
                };
                t.Start();
            }
        }

        private void Draw()
        {
            while (true)
            {
                bool ownerChanged = false;
                foreach (var worker in _workers)
                {
                    if (worker.State == WorkerState.Working)
                    {
                        _resourse.Owner = "Worker " + worker.Name;
                        ownerChanged = true;
                    }
                    ((WorkerDraw)worker).Draw(_graphics);
                }
                if (!ownerChanged) _resourse.Owner = "";
                _resourse.Draw(_graphics);
                Thread.Sleep(200);
            }
        }
    }
}