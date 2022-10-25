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
    public class Passenger : IPassenger
    {
        public MoveObject MoveObject { get; } = MoveObject.Passenger;

        private PictureBox[] pictures;
        public PictureBox picture { get; set; }
        private Panel field;
        public Point CurrentLocation { get; set; }

        private IBus bus;

        private Dictionary<Point, Direction> directions = new Dictionary<Point, Direction>()
        {
            { new Point { X = -1, Y = 0}, Direction.left },
            { new Point { X = 1, Y = 0}, Direction.right }
        };

        enum Direction
        {
            left = 0,
            right = 1
        };
        public Passenger(Panel field)
        {
            this.field = field;
            pictures = new PictureBox[]
            {
                new PictureBox()
                {
                    Image = Properties.Resources.man_left,
                    Size = new Size(50, 51),
                    SizeMode = PictureBoxSizeMode.Zoom
                },
                new PictureBox()
                {
                    Image = Properties.Resources.man_right,
                    Size = new Size(50, 51),
                    SizeMode = PictureBoxSizeMode.Zoom
                }
            };
            picture = null;
            bus = null;
            CurrentLocation = new Point()
            {
                X = 0,
                Y = 0
            };
        }
        public void Dispose()
        {
            if (picture == null)
                throw new Exception("Класс не инициализиррован");
            picture.Dispose();
            picture = null;
        }

        public void Hide()
        {
            if (picture == null)
                throw new Exception("Класс не инициализиррован");
            picture.Visible = false;
        }

        public void Initialization(object location)
        {
            if(picture == null)
            {
                picture = pictures[(int)Direction.right];
                field.Controls.Add(picture);
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
                while (current.X < tmp.X)
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
            foreach (Point p in oldRoute)
                if (current != p)
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

        public bool Loading(object obj)
        {
            bus = (IBus)((object[])obj)[0];
            List<Point> route = new List<Point>();
            route.Add(CurrentLocation);
            route.Add(bus.CurrentLocation);
            route = BuildRoute(route);
            Move(new object[] { route.ToArray() });
            return true;
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
                field.Update();
                Thread.Sleep(50);
            }
        }

        public void Show()
        {
            if (picture == null)
                throw new Exception("Класс не инициализиррован");
            picture.Visible = true;
        }
    }
}
