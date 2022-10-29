using System;
using System.Globalization;

class Card
{
    static void Main(string[] args)
    {
        // константа для роботі з тригонометричними функціями
        const int pi = 180;

        // Введення данних
        Console.WriteLine("Enter x: ");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter y: ");
        double y = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Enter z: ");
        double z = Convert.ToDouble(Console.ReadLine());

        double a = 0;
        double b = 0;

        // перевірка на ОДЗ
        if (x * z == -2)
        {
            Console.WriteLine("Error");
        }
        else
        {
            // обчисленя значення кута
            double angleTan = (Math.Pow(x, (-y)) + (z / (y * y + 1)) + Math.Round(Math.Pow(y / (x * z + 2), (0.333)), 1));
            // переведення кута у радіани
            double radianTan = angleTan * (Math.PI / 180);
            // знаходимо значення "а"
            a = Math.Tan(radianTan);
        }

        // обчисленя значення кута та радіану
        double angleSin = (x + pi * y) / z;
        double radianSin = angleSin * (Math.PI / 180);

        // перевірка на ОДЗ
        if (Math.Sin(radianSin) == 0)
        {
            Console.WriteLine("Error");
        }
        else
        {
            // обчислюємо значення "b"
            b = a / Math.Sin(radianSin);
        }

        // Округлення та виведення значень 
        a = Math.Round(a, 4);
        b = Math.Round(b, 4);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
    }

}