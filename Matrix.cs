using System;
using System.Globalization;
using System.Numerics;
using System.Runtime.InteropServices;

class ASD
{
    static void Main(string[] args)
    {
        /* 1) input --> розмір матриці N та M 
         * 
         * 2) вивід самої матриці у консоль
         * 
         * 3) алгоритм з обходом матриці
         * 
         * 4) вивід значень комірок матриці відповідно до шляху обходу нижньої половини матриці
         * 
         * 5) вивід максимального значення нижньої половини матриці
         * 
         * 6) алгоритм з порівнянням максимального числа нижньої половини матриці
         * з всіми значеннями перхньої половини (відповідно до шляху обходу)
         * 
         * 7) вивід значень відповідно до шляху обходу вернньої половини матриці
         * 
         * 8) вивід значень верхньої половини матриці які менше за максимальне
         * значення нижньої половини матриці
         */


        Console.WriteLine("Введiть парну кiлькiсть рядкiв: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введiть кiлькiсть стовпцiв: ");
        int m = int.Parse(Console.ReadLine());

        while (n % 2 != 0 || n <= 0 || m <= 0)
        {
            Console.WriteLine("Помилка введення, спробуйте iнакше: ");
            Console.WriteLine("Введiть парну кiлькiсть рядкiв: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть стовпцiв: ");
            m = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Введiть дiапазон чисел, якими навмання \n буде заповнюватись матриця (рекомендовано 0-9):");
        Console.WriteLine("Мiнiмальне значення:");
        int min = int.Parse(Console.ReadLine());
        Console.WriteLine("Максимальне значення:");
        int max = int.Parse(Console.ReadLine());

        while (min < 0 || max < 0 || min > max)
        {
            Console.WriteLine("Помилка введення, спробуйте iнакше: ");
            Console.WriteLine("Введiть дiапазон чисел, якими навмання \n буде заповнюватись матриця (рекомендовано 0-9):");
            Console.WriteLine("Мiнiмальне значення:");
            min = int.Parse(Console.ReadLine());
            Console.WriteLine("Максимальне значення:");
            max = int.Parse(Console.ReadLine());
        }

        int x = (n - 1);
        int y = 0;

        int[,] matrix = new int[n, m];

        Random randomNumber = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = randomNumber.Next(min, max+1);
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine(matrix[x, 0]);


        while (x != n / 2 && y != m - 1)
        {
            if (x == n - 1)
            {
                if (y != m - 1)
                {
                    y++;
                }
                Console.Write(matrix[x, y] + " ");
                while (y != 0 || x != n / 2)
                {
                    x--;
                    y--;
                    Console.Write(matrix[x, y] + " ");
                    if (x == n / 2 || y == 0)
                    {
                        break;
                    }
                }
            }
            if (y == 0)
            {
                x--;
                Console.Write(matrix[x, y] + " ");
                while (x != n - 1)
                {
                    x++;
                    y++;
                    Console.Write(matrix[x, y] + " ");
                    if (x == n - 1 || y == m - 1)
                    {
                        break;
                    }
                }
            }
            if (x == n / 2)
            {
                y++;
                Console.Write(matrix[x, y] + " ");
                while (x != n - 1)
                {
                    x++;
                    y++;
                    Console.Write(matrix[x, y] + " ");
                    if (x == n - 1 || y == m - 1)
                    {
                        break;
                    }
                }
            }
            if (y == m - 1)
            {
                x--;
                Console.Write(matrix[x, y] + " ");
                while (x != n / 2)
                {
                    x--;
                    y--;
                    Console.Write(matrix[x, y] + " ");
                    if (x == n / 2)
                    {
                        break;
                    }
                }
            }
            if (x == n / 2 && y == m - 3)
            {
                y++;
                Console.Write(matrix[x, y] + " ");
                x++;
                y++;
                Console.Write(matrix[x, y] + " ");
                x--;
                Console.Write(matrix[x, y] + " ");
            }
        }

        Console.WriteLine("Finish");
    }

}
