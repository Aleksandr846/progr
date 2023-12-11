using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace llb3
{
    class Point
    {
        int x;
        int y;
        string sym = "-----";
        public void SetX(int x)
        {
            if (x >= 0)
                this.x = x;
            else
                throw new Exception("Значение x не может быть отрицательным");
        }
        public void SetY(int y)
        {
            if (y >= 0)
                this.y = y;
            else
                throw new Exception("Значение y не может быть отрицательным");
        }
        public void Draw(string sym)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
            y = y + 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point a = new Point();
            Console.Write("Введите координату x: ");
            try
            {
                a.SetX(Convert.ToInt32(Console.ReadLine()));
            }
            catch (System.Exception)
            {
                Console.WriteLine("Значение x не может быть отрицательным");
                Console.WriteLine("Введите координату x: ");
                a.SetX(Convert.ToInt32(Console.ReadLine()));
            }
            Console.Write("Введите координату y: ");
            try
            {
                a.SetY(Convert.ToInt32(Console.ReadLine()));
            }
            catch (System.Exception)
            {
                Console.WriteLine("Значение y не может быть отрицательным ");
                Console.WriteLine("Введите координату y: ");
                a.SetY(Convert.ToInt32(Console.ReadLine()));
            }
            a.Draw("()");
            a.Draw("||");
            a.Draw("/\\");
            Console.WriteLine("\nНажмите любую клавишу, чтобы завершить программу...");
            Console.ReadKey();
        }
    }
}
