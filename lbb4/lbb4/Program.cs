using System;
using System.Collections.Generic;

class Point
{
    int x;
    int y;
    char sym;

    public Point(int x, int y, char sym)
    {
        this.x = x;
        this.y = y;
        this.sym = sym;
    }

    public void Draw()
    {
        Console.SetCursorPosition(x, y);
        Console.Write(sym);
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
    HorizontalLine topLine = new HorizontalLine(1, 10, 1, '*');
    HorizontalLine bottomLine = new HorizontalLine(1, 10, 5, '*');
    VerticalLine leftLine = new VerticalLine(1, 5, 1, '*');
    VerticalLine rightLine = new VerticalLine(1, 5, 10, '*');

    topLine.Draw();
    bottomLine.Draw();
    leftLine.Draw();
    rightLine.Draw();

    Console.ReadKey();
}
}

