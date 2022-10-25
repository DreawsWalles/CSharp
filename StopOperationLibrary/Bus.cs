using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskFour;

namespace StopOperationLibrary
{
    public class Bus : IBus
    {
        public MoveObject MoveObject { get; } = MoveObject.Bus; 

        private PictureBox[] pictures;
        public PictureBox picture { get; set; }
        private Panel fied;
        public Point CurrentLocation { get; set; }
        private int capacity;

        private List<IPassenger> passengers;

        private Dictionary<Point, Direction> directions = new Dictionary<Point, Direction>()
        {
            { new Point { X = 0, Y = 1}, Direction.front },
            { new Point { X = 0, Y = -1}, Direction.back },
            { new Point { X = 1, Y = 0}, Direction.right },
            { new Point { X = -1, Y = 0}, Direction.left }
        };

        enum Direction
        {
            left = 0,
            right = 1,
            front = 2,
            back = 3
        };
        public Bus(Panel fied)
        {
            this.fied = fied;
            pictures = new PictureBox[]
            {
                new PictureBox()
                {
                    Image = Properties.Resources.bus_right,
                    Size = new Size(71, 79),
                    SizeMode = PictureBoxSizeMode.Zoom
                },
                new PictureBox()
                {
                    Image = Properties.Resources.bus_left,
                    Size = new Size(71, 79),
                    SizeMode = PictureBoxSizeMode.Zoom
                },
                new PictureBox()
                {
                    Image = Properties.Resources.bus_front,
                    Size = new Size(71, 79),
                    SizeMode = PictureBoxSizeMode.Zoom
                },
                new PictureBox()
                {
                    Image = Properties.Resources.bus_back,
                    Size = new Size(71, 79),
                    SizeMode = PictureBoxSizeMode.Zoom
                }
            };
            picture = null;
            passengers = new List<IPassenger>();
            CurrentLocation = new Point()
            {
                X = 0,
                Y = 0
            };
            capacity = 30;
        }
        public void Initialization(object location)
        {
            if (picture == null)
            {
                picture = pictures[(int)Direction.front];
                fied.Controls.Add(picture);
            }
            picture.Location = (Point)((object[])location)[0];
            CurrentLocation = (Point)((object[])location)[0];
        }
        private List<Point> BuildRoute(List<Point> oldRoute)
        {
            List<Point> result = new List<Point>();
            Point current = CurrentLocation;
            if (current != oldRoute.First())
            {
                Point tmp = oldRoute.First();
                while (current.Y < tmp.Y)
                {
                    current.Y++;
                    result.Add(current);
                }
                while(current.X < tmp.X)
                {
                    current.X++;
                    result.Add(current);
                }
                while (current.Y > tmp.Y)
                {
                    current.Y--;
                    result.Add(current);
                }
                while (current.X > tmp.X)
                {
                    current.X--;
                    result.Add(current);
                }
            }
            foreach(Point p in oldRoute)
                if(current != p)
                {
                    while (current.Y < p.Y)
                    {
                        current.Y++;
                        result.Add(current);
                    }
                    while (current.X < p.X)
                    {
                        current.X++;
                        result.Add(current);
                    }
                    while (current.Y > p.Y)
                    {
                        current.Y--;
                        result.Add(current);
                    }
                    while (current.X > p.X)
                    {
                        current.X--;
                        result.Add(current);
                    }
                }
            return result;
        }
        public void Move(object[] route)
        {
            if (picture == null)
                throw new Exception("Класс не иницизиализирован");
            if (route == null || route.Length == 0)
                throw new Exception("Переданный путь является некорректным");
            List<Point> routes = new List<Point>();
            foreach (object obj in (object[])route[0])
                routes.Add((Point)obj);
            routes = BuildRoute(routes);
            foreach (Point point in routes)
            {
                picture.Image = pictures[(int)directions[CurrentLocation - new Size(point)]].Image;
                CurrentLocation = point;
                picture.Location = point;
                fied.Update();
                Thread.Sleep(50);
            }
        }

        public bool Loading(object obj)
        {
            IPassenger tmp = (IPassenger)((object[])obj)[0];
            if (passengers.Count >= capacity)
                return false;
            tmp.Loading(this);
            passengers.Add(tmp);
            return true;
        }

        public void Hide()
        {
            if (picture == null)
                throw new Exception("Класс не иницизиализирован");
            picture.Visible = false;
        }

        public void Dispose()
        {
            if (picture == null)
                throw new Exception("Класс не иницизиализирован");
            picture.Dispose();
            picture = null;
        }

        public void Show()
        {
            if (picture == null)
                throw new Exception("Класс не иницизиализирован");
            picture.Visible = true;
        }
    }
}
