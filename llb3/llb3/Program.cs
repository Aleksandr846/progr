using lb7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lb7
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
        public void Move(int offset, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + offset;
            }
            else if (direction == Direction.LEFT)
            {
                x = x - offset;
            }
            else if (direction == Direction.UP)
            {
                y = y - offset;
            }
            else if (direction == Direction.DOWN)
            {
                y = y + offset;
            }
        }
        public void Clear()
        {
            sym1 = ' ';
            Draw();
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
    enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
    class Snake : Figure
    {
        Direction direction;

        public Snake(Point tail, int length, Direction _direction)
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }
        public void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);
            tail.Clear();
            head.Draw();
        }
        private Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Walls walls = new Walls(121, 30);
            walls.Draw();
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            while (true)
            {
                if (walls.IsHit(snake))
                {
                    Console.WriteLine("Вы проиграли");
                    Console.ReadKey();
                    break;
                }
                snake.Move();
                Thread.Sleep(100);
            }
        }
    }
}
