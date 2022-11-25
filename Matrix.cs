﻿using System;
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
                matrix[i, j] = randomNumber.Next(min, max + 1);
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Шлях обходу нижньої половини: ");

        int maxValue = 0;

        Console.Write(matrix[x, 0] + " ");
        while (x != n / 2 || y != m - 1)
        {
            if (x == n - 1)
            {
                if (y != m - 1)
                {
                    y++;
                    if (matrix[x, y] > maxValue)
                    {
                        maxValue = matrix[x, y];
                    }
                }
                Console.Write(matrix[x, y] + " ");
                while (y != 0 && x != n / 2)
                {
                    x--;
                    y--;
                    if (matrix[x, y] > maxValue)
                    {
                        maxValue = matrix[x, y];
                    }
                    Console.Write(matrix[x, y] + " ");
                }
            }
            if (y == 0)
            {
                if (y == 0 && x == n / 2)
                {
                    y++;
                }
                else
                {
                    x--;
                }
                if (matrix[x, y] > maxValue)
                {
                    maxValue = matrix[x, y];
                }
                Console.Write(matrix[x, y] + " ");
                while (x != n - 1)
                {
                    x++;
                    y++;
                    if (matrix[x, y] > maxValue)
                    {
                        maxValue = matrix[x, y];
                    }
                    Console.Write(matrix[x, y] + " ");
                    if (x == n - 1 || y == m - 1)
                    {
                        break;
                    }
                }
            }
            if (x == n / 2)
            {
                if (y == m - 2)
                {
                    y++;
                    if (matrix[x, y] > maxValue)
                    {
                        maxValue = matrix[x, y];
                    }
                    Console.Write(matrix[x, y] + " ");
                    continue;
                }
                y++;
                if (matrix[x, y] > maxValue)
                {
                    maxValue = matrix[x, y];
                }
                Console.Write(matrix[x, y] + " ");
                while (x != n - 1)
                {
                    x++;
                    y++;
                    if (matrix[x, y] > maxValue)
                    {
                        maxValue = matrix[x, y];
                    }
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
                if (matrix[x, y] > maxValue)
                {
                    maxValue = matrix[x, y];
                }
                Console.Write(matrix[x, y] + " ");
                while (x != n / 2)
                {
                    x--;
                    y--;
                    if (matrix[x, y] > maxValue)
                    {
                        maxValue = matrix[x, y];
                    }
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
                if (matrix[x, y] > maxValue)
                {
                    maxValue = matrix[x, y];
                }
                Console.Write(matrix[x, y] + " ");
                x++;
                y++;
                if (matrix[x, y] > maxValue)
                {
                    maxValue = matrix[x, y];
                }
                Console.Write(matrix[x, y] + " ");
                x--;
                if (matrix[x, y] > maxValue)
                {
                    maxValue = matrix[x, y];
                }
                Console.Write(matrix[x, y] + " ");
            }
        }

        Console.WriteLine("\n Найбiльше значення нижньої половини матрицi: " + maxValue);

        Console.WriteLine("\n");
        Console.WriteLine("Шлях обходу верхньої половини: ");

        for (int i = (n / 2) - 1; i >= 0; i--)
        {
            if ((n / 2 - 1) % 2 == 0)
            {
                if (i % 2 == 0)
                {
                    for (int j = m - 1; j >= 0; j--)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }
                else
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }
            }
            else
            {
                if (i % 2 != 0)
                {
                    for (int j = m - 1; j >= 0; j--)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }
                else
                {
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                }
            }
        }

        Console.WriteLine("\n\nЗначення с верхньої половини, якi не перевищюють максимальне з нижньої: ");

        for (int i = (n / 2) - 1; i >= 0; i--)
        {
            if ((n / 2 - 1) % 2 == 0)
            {
                if (i % 2 == 0)
                {
                    for (int j = m - 1; j >= 0; j--)
                    {
                        if (matrix[i, j] < maxValue)
                        {
                            Console.Write(matrix[i, j] + " ");
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] < maxValue)
                        {
                            Console.Write(matrix[i, j] + " ");
                        }
                    }
                }
            }
            else
            {
                if (i % 2 != 0)
                {
                    for (int j = m - 1; j >= 0; j--)
                    {
                        if (matrix[i, j] < maxValue)
                        {
                            Console.Write(matrix[i, j] + " ");
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (matrix[i, j] < maxValue)
                        {
                            Console.Write(matrix[i, j] + " ");
                        }
                    }
                }
            }
        }

        Console.WriteLine("\nFinish");
    }

}
