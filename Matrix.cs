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

        // ВВодимо розмір матриці
        Console.WriteLine("Введiть парну кiлькiсть рядкiв: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Введiть кiлькiсть стовпцiв: ");
        int m = int.Parse(Console.ReadLine());

        // Перевірка на коректність данних
        while (n % 2 != 0 || n <= 0 || m <= 0)
        {
            Console.WriteLine("Помилка введення, спробуйте iнакше: ");
            Console.WriteLine("Введiть парну кiлькiсть рядкiв: ");
            n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введiть кiлькiсть стовпцiв: ");
            m = int.Parse(Console.ReadLine());
        }

        // Вводимо діапазон випадкових чисел
        Console.WriteLine("Введiть дiапазон чисел, якими навмання \n буде заповнюватись матриця (рекомендовано 0-9):");
        Console.WriteLine("Мiнiмальне значення:");
        int min = int.Parse(Console.ReadLine());
        Console.WriteLine("Максимальне значення:");
        int max = int.Parse(Console.ReadLine());

        // Перевірка на коректість введення діапазону
        while (min < 0 || max < 0 || min > max)
        {
            Console.WriteLine("Помилка введення, спробуйте iнакше: ");
            Console.WriteLine("Введiть дiапазон чисел, якими навмання \n буде заповнюватись матриця (рекомендовано 0-9):");
            Console.WriteLine("Мiнiмальне значення:");
            min = int.Parse(Console.ReadLine());
            Console.WriteLine("Максимальне значення:");
            max = int.Parse(Console.ReadLine());
        }

        // Ствонюємо глобальні змінні - це комірки массиву або ж "координати" елементів
        int x = (n - 1);
        int y = 0;

        // Створюємо двовимірний массив
        int[,] matrix = new int[n, m];

        // Генеруємо псевдовипадкові числа, та виводиму матрицю у консоль
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

        // Створюємо глобальну змінну, яка буде змінюватись при кожному знайденому большому елементі
        int maxValue = 0;

        // Цикл для робить обхід "зигзагом" у нижній половині та виводить шлях обходу
        Console.Write(matrix[x, 0] + " ");
        while (x != n / 2 || y != m - 1)
        {
            // Ці перевірки (if) зробленні для надання поведінки руху обходу 

            // Якщо ми у нижній частині пів-матриці
            if (x == n - 1)
            {
                if (y != m - 1)
                {
                    y++;
                    // Перевірка на максимальний елемент, вона далі буде часто повторюватись
                    if (matrix[x, y] > maxValue)
                    {
                        maxValue = matrix[x, y];
                    }
                }
                Console.Write(matrix[x, y] + " ");
                while (y != 0 && x != n / 2)
                {
                    // Йдемо по діагоналі вверх-вліво поки не упремося
                    x--;
                    y--;
                    if (matrix[x, y] > maxValue)
                    {
                        maxValue = matrix[x, y];
                    }
                    Console.Write(matrix[x, y] + " ");
                }
            }
            // Якщо ми з лівого краю пів-матриці
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
                    // Йдемо по діагоналі вниз-праворуч поки не упремося
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
            // Якщо ми у верхній частині пів-матриці
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
                    // Йдемо по діагоналі вниз-праворуч поки не упремося
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
            // Якщо у крайній правій частині пів-матриці
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
                    // Йдемо по діагоналі вверх-вліво поки не упремося
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
        }

        Console.WriteLine("\n Найбiльше значення нижньої половини матрицi: " + maxValue);

        Console.WriteLine("\n");
        Console.WriteLine("Шлях обходу верхньої половини: ");

        // Обхід верхньої частини матриці "змійкою" та виведення шляху обходу

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

        // Той самий цикл, але тепер він тільки порівнює значення з максимальним

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
// Деякі не зрозумілі перевірки (if) на перший погляд не зрозумілі, але вони потрібні для обхіду зигзагом
// у випадку якщо висота нижньої півматриці парна або НЕпарна, звідти і деякі перевірки.
// Це стосується і верхньої половини

// Половина рядків коду загалом для красивого оформлення тому код громісткий,
// Але вцілому функціональних у половину менше