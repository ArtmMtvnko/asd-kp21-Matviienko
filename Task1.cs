using System;
using System.Globalization;

class Card
{
    static void Main(string[] args)
    {
        const int pi = 180;

        double x = 2;
        double y = 1;
        double z = 3;

        double a = 0;
        double b = 0;

        double angleTan = (Math.Pow(x, (-y)) + (z / (y * y + 1)) + Math.Round(Math.Pow(y / (x * z + 2), (0.333)), 1));
        double radianTan = angleTan * (Math.PI / 180);
        a = Math.Tan(radianTan);

        double angleSin = (x + pi * y) / z;
        double radianSin = angleSin * (Math.PI / 180);
        b = Math.Sin(radianSin);

        a = Math.Round(a, 4);
        b = Math.Round(b, 4);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);



        /* x = 2, y = 1, z = 3 
         * 
         * ===operations start====
         * a = tan(x^-y + z/(x^2 + 1) + (y/(xz + 2))^1/3)
         * b = a/(sin((x+pi*y)/z)
         * ===perations end====
         * 
         * output a = 0.04366, b = 0.871*/

    }

}