using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ResourceManagement
{
    internal class Controller
    {
        private const int ToWrite = 3;

        private readonly List<WorkerDraw> _workers;
        private readonly ResourceDraw _resourse = new ResourceDraw("log.txt", 180, 180);
        private readonly Graphics _graphics;

        public Controller(Control pb)
        {
            _workers = new List<WorkerDraw>
            {
                new WorkerDraw(_resourse, ToWrite, "N", 200, 50),
                new WorkerDraw(_resourse, ToWrite, "S", 200, 350),
                new WorkerDraw(_resourse, ToWrite, "W", 50, 200),
                new WorkerDraw(_resourse, ToWrite, "E", 350, 200),

                new WorkerDraw(_resourse, ToWrite, "SE", 300, 300),
                new WorkerDraw(_resourse, ToWrite, "NE", 300, 100),
                new WorkerDraw(_resourse, ToWrite, "NW", 100, 100),
                new WorkerDraw(_resourse, ToWrite, "SW", 100, 300)
            };

            _graphics = pb.CreateGraphics();
            var control = new Thread(Run) {Name = "Controller"};
            control.Start();
        }

        private void Run()
        {
            var draw = new Thread(Draw) {Name = "Draw"};
            draw.Start();

            foreach (var worker in _workers)
            {
                var t = new Thread(worker.Work) {Name = "Worker " + worker.N};
                t.Start();
                Thread.Sleep(1000);
            }
        }

        private void Draw()
        {
            while (true)
            {
                bool ownerChanged = false;
                foreach (var worker in _workers)
                {
                    if (worker.State == Worker.WorkerState.Working)
                    {
                        _resourse.Owner = "Worker " + worker.Name;
                        ownerChanged = true;
                    }
                    worker.Draw(_graphics);
                }
                if (!ownerChanged) _resourse.Owner = "";
                _resourse.Draw(_graphics);
                Thread.Sleep(200);
            }
            // ReSharper disable once FunctionNeverReturns
        }
    }
}