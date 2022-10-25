using System;
using System.Drawing;

namespace ResourceManagement
{
    internal interface IDrawingComponent
    {
        int X { get; set; }
        int Y { get; set; }
        Color Color { get; set; }

        void Draw(Graphics gr);
    }

    internal class WorkerDraw : Worker, IDrawingComponent
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }

        public void Draw(Graphics gr)
        {
            gr.FillEllipse(new SolidBrush(Color), X, Y, 30, 30);
            gr.DrawString(NWrite.ToString(), new Font("Arial", 16), new SolidBrush(Color.Black), X + 5, Y + 3);
        }

        public WorkerDraw(Resource resource, int attempts, string name, int x, int y) : base(resource, attempts, name)
        {
            X = x;
            Y = y;
            Color = Color.Gray;

            OnStateChanged = ChangeColor;
        }

        private void ChangeColor()
        {
            switch (State)
            {
                case WorkerState.Idle:
                    Color = Color.Gray;
                    break;
                case WorkerState.Waiting:
                    Color = Color.Yellow;
                    break;
                case WorkerState.Working:
                    Color = Color.Green;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    internal class ManagerDraw : Manager, IDrawingComponent
    {
        public ManagerDraw(int x, int y)
        {
            X = x;
            Y = y;
            Color = Color.Red;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }

        public void Draw(Graphics gr)
        {
            gr.FillEllipse(new SolidBrush(Color), X, Y, 18, 18);
        }
    }

    internal class ResourceDraw : Resource, IDrawingComponent
    {
        public ResourceDraw(string fileName, int x, int y) : base(fileName)
        {
            X = x;
            Y = y;
            Color = Color.Black;
            Owner = "";
        }

        public string Owner { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }

        public void Draw(Graphics gr)
        {
            gr.FillRectangle(new SolidBrush(Color), X, Y, 115, 50);
            gr.DrawString(Owner, new Font("Arial", 16), new SolidBrush(Color.White), X + 4, Y + 12);
        }
    }
}
