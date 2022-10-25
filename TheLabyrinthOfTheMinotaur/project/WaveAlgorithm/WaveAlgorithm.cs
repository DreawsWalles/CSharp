using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaveAlgorithmLib
{
    public struct Cell
    {
        public int Pos;
        public int MeaningCell;
    }
    public struct CellMove
    {
        public int Pos;
        public int Value;
        public int Grenade;
    }
    public class WaveAlgorithm
    {

        public static int[] Test();
        //Примерная идея

        //Проходимся первый раз, ищем возможный путь без использования гранат (нужно убрать создание матрицы больших размеров)
        //Смотрим, встречали ли мы преграды на своем пути. Если встречали, то составляем ещё раз волну, при этом смотрим, короче этот путь или нет (Map[point.Y, point.X] < map[y,x] + 1)


        //Смотрим, если даже после этого у нас нет пути до конечной точки, то возвращаем null, в обратном случае просто ищем обратный путь
        public static int[] GetWay(Cell[,] parametrs, int m, int n, int l, Point start, Point finish)
        {
            Queue<Point> Qgood = new Queue<Point>();
            Queue<Point> Qbad = new Queue<Point>();
            InitMap(parametrs, out Cell[,] Map, out CellMove[,] MapMoves, m, n);
            start = new Point(++start.X, ++start.Y);
            finish = new Point(++finish.X, ++finish.Y);
            MapMoves[start.Y, start.X].Value = 1;
            MapMoves[start.Y, start.X].Grenade = 0;
            Qgood.Enqueue(start);
            int CurGrenade = 0;
            //ищет путь без использования гранат, если нашли, значит выходим, если не нашли
            //удаляем все стены, что попались нам на пути, а дальше проходимся ещё раз, вычисляя волну
            do
            {
                do
                {
                    NextWave(ref MapMoves, ref Qgood, ref Qbad, Map, CurGrenade);
                }while(Qgood.Count() > 0 && MapMoves[finish.Y, finish.X].Value > 0);//поправить условие

                if (MapMoves[finish.Y, finish.X].Value == 0)
                {
                    if (CurGrenade == l) // при удалении заграждения нет проверки на то, есть ли ещё гранаты.
                        return null;
                    else
                        DestroyWall(ref Qgood, ref Qbad, ref MapMoves, ref CurGrenade);
                }
            }while(!(MapMoves[finish.Y, finish.X].Value > 0));
            return GetWay(MapMoves, Map, start, finish);
        }

        private static int[] GetWay(CellMove[,] MapMoves, Cell[,] Map, Point start, Point finish)
        {
            int x = finish.X;
            int y = finish.Y;
            int length = MapMoves[y, x].Value;
            int[] result = new int[length];
            do
            {
                result[length - 1] = Map[y, x].Pos;
                NextStep(ref x, ref y, MapMoves, Map);
                length--;
            }while(!(x == start.X && y == start.Y));
            return result;
        }

        private static void NextStep(ref int x, ref int y, CellMove[,] MapMoves, Cell[,] Map)
        {
            bool ok = false;
            int step = 0;
            Point point;
            do
            {
                point = NextCell(x, y, Direction[step]);
                if (Map[y, x].MeaningCell == 1)
                    ok = (MapMoves[y, x].Grenade - MapMoves[point.Y, point.X].Grenade == 1);
                else
                    ok = (MapMoves[y, x].Value - MapMoves[point.Y, point.X].Value == 1) && (MapMoves[y, x].Grenade == MapMoves[point.Y, point.X].Grenade);
                if(ok)
                {
                    x = point.X;
                    y = point.Y;
                }
                step++;
            } while (!ok);
        }

        private static Dictionary<int, Point> Direction = new Dictionary<int, Point>()
        {
            { 0, new Point(){X = 0, Y = -1} },
            { 1, new Point(){X = 0, Y = 1} },
            { 2, new Point(){X = -1, Y = 0} },
            { 3, new Point(){X = 1, Y = 0} }
        };
        private static Point NextCell(int x, int y, Point step) => new Point() { X = x + step.X, Y = y + step.Y };

        private static void NextWave(ref CellMove[,] MapMoves, ref Queue<Point> Qgood, ref Queue<Point> Qbad, Cell[,] Map, int grenade)
        {
            Point point = Qgood.Dequeue();
            int x = point.X;
            int y = point.Y;
            for(int k =0; k < 4; k++)
            {
                point = NextCell(x, y, Direction[k]);
                if(MapMoves[point.Y, point.X]. Value == 0)
                    switch(Map[point.Y, point.X].MeaningCell)
                    {
                        case 0:
                            MapMoves[point.Y, point.X].Value = MapMoves[y, x].Value + 1;
                            MapMoves[point.Y, point.X].Grenade = grenade;
                            Qgood.Enqueue(point);
                            break;
                        case 1:
                            MapMoves[point.Y, point.X].Value = -MapMoves[y, x].Value - 1;
                            MapMoves[point.Y, point.X].Grenade = grenade + 1;
                            Qbad.Enqueue(point);
                            break;
                    }
            }
        }
        private static void DestroyWall(ref Queue<Point> Qgood, ref Queue<Point> Qbad, ref CellMove[,] MapMoves, ref int CurGrenade )
        {
            CurGrenade++;
            Qgood.Clear();
            while(Qbad.Any())
            {
                Point point = Qbad.Dequeue();
                MapMoves[point.Y, point.X].Value = (-1) * MapMoves[point.Y, point.X].Value;
                Qgood.Enqueue(point);
            }
        }
        private static void InitMap(Cell[,] InMap, out Cell[,] Map, out CellMove[,] MapMoves, int m, int n)
        {
            MapMoves = new CellMove[m + 2, n + 2];
            Map = new Cell[m + 2, n + 2];
            for(int i = 0; i < m + 2; i++)
            {
                MapMoves[i, 0] = new CellMove() { Value = -1, Grenade = -1 };
                MapMoves[0, i] = new CellMove() { Value = -1, Grenade = -1 };
                MapMoves[m + 1, i] = new CellMove() { Value = -1, Grenade = -1 };
                MapMoves[i, n + 1] = new CellMove() { Value = -1, Grenade = -1 };
                Map[i, 0] = new Cell() { MeaningCell = -1 };
                Map[0, i] = new Cell() { MeaningCell = -1 };
                Map[i, n + 1] = new Cell() { MeaningCell = -1 };
                Map[m + 1, i] = new Cell() { MeaningCell = -1 };
            }
            for(int i = 1; i < m + 1; i++)
                for(int j = 1; j < n + 1; j++)
                {
                    MapMoves[i, j] = new CellMove() { Value = 0, Grenade = -1, Pos = InMap[i - 1, j - 1].Pos };
                    Map[i, j] = InMap[i - 1, j - 1];
                }
        }   
    }
}
