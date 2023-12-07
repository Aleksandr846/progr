using lb6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lb6
{
    class Point
    {
        int x;
        int y;
        char sym1;
        public Point()
        {
        }
        public Point(int x, int y, char sym1)
        {
            this.x = x;
            this.y = y;
            this.sym1 = sym1;
        }
        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym1 = p.sym1;
        }
        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym1);
        }
        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }
    }
    class Figure
    {
        protected List<Point> pList;

        public void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }

        public bool IsHit(Figure figure)
        {
            foreach (var p in pList)
            {
                if (figure.IsHit(p))
                    return true;
            }
            return false;
        }

        private bool IsHit(Point point)
        {
            foreach (var p in pList)
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
    class VerticalLine : Figure
    {
        public VerticalLine(int yUp, int yDown, int x, char sym)
        {
            pList = new List<Point>();
            for (int y = yUp; y <= yDown; y++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
    }

    class HorizontalLine : Figure
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            pList = new List<Point>();
            for (int x = xLeft; x <= xRight; x++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n+ Точки – 1 Линии - 2");
            Walls walls = new Walls(121, 30);
            walls.Draw();
            int bruh = Convert.ToInt32(Console.ReadLine());
            if (bruh == 1)
            {
                Point a = new Point(3, 3, '*');
                a.Draw();
                Point b = new Point(3, 5, '*');
                b.Draw();
                bool z = a.IsHit(b);
                if (z == true)
                {
                    Console.WriteLine("\n+ Точки совпадают");
                }
                else
                {
                    Console.WriteLine("\n+ Точки не совпадают");
                }

            }
            else
            {
                HorizontalLine h1 = new HorizontalLine(1, 6, 3, '*');
                h1.Draw();
                VerticalLine v1 = new VerticalLine(1, 4, 8, '*');
                v1.Draw();
                bool x = h1.IsHit(v1);
                if (x == true)
                {
                    Console.WriteLine("\n+ Линии пересекаются");
                }
                else
                {
                    Console.WriteLine("\n+ Линии не пересекаются");
                }
            }
            Console.WriteLine("\n+ Нажмите любую клавишу, чтобы завершить про-грамму...");
            Console.ReadKey();
        }
    }
}
