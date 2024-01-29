using System;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography;

class Card
{
    // Методи для роботи аби код був більш читабельний

    // Метод повертає true, якщо виконується умова завдання:
    // "непарні за значенням елементи, які діляться на K націло"
    // Тому і назва - непарні (odd)
    static bool IsOdd(int num, double k)
    {
        if (num % 2 != 0 && num % k == 0)
        {
            return true;
        }
        return false;
    }

    // Метод повертає true, якщо виконується умова завдання:
    // "парні за значенням елементи, для яких остача від ділення на K дорівнює 1"
    // Тому і назва - парні (even)
    static bool IsEven(int num, double k)
    {
        if (num % 2 == 0 && num % k == 1)
        {
            return true;
        }
        return false;
    }

    // Метод виводить массив та фарбує числа у відповідний колір
    static void ShowArr(int[] array, double k)
    {
        foreach (int item in array)
        {
            if (IsOdd(item, k))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(item + " ");
                Console.ResetColor();
            }
            if (IsEven(item, k))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(item + " ");
                Console.ResetColor();
            }
            if (!IsEven(item, k) && !IsOdd(item, k))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(item + " ");
                Console.ResetColor();
            }
        }
    }
    static void Main(string[] args)
    {
        int n = 0;
        double k = 0;
        int min = 0, max = 0;

        // Перевірка на правильність введення
        while (true)
        {
            try
            {
                Console.WriteLine("Write the size of array: ");
                n = Math.Abs(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Input 'K' value: ");
                k = Math.Abs(Convert.ToDouble(Console.ReadLine()));
                Console.WriteLine("Write the lower bound for randomazer: ");
                min = Math.Abs(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Write the high bound for randomazer: ");
                max = Math.Abs(Convert.ToInt32(Console.ReadLine()));
                break;

            }
            catch
            {
                Console.WriteLine("Input Error");
            }
        }

        // Створюємо массив та генеруємо псевдовипадкові числа
        int[] array = new int[n];
        Console.WriteLine("Array filling by random numbers...");

        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            array[i] = random.Next(min, max);
        }

        // Виводимо початковий массим у консоль
        Console.WriteLine("Initial array: ");
        ShowArr(array, k);

        // Список було створенно для того, аби числа, які не відповідають умові (тобто не підлягають сортуванню)
        // було зручно записати у зворотному напрямку
        List<int> otherNums = new List<int>();

        for (int i = 0; i < n; i++)
        {
            if (!IsEven(array[i], k) && !IsOdd(array[i], k))
                otherNums.Add(array[i]);
        }

        //otherNums.Reverse();

        // Алгоритм який "відзеркалює" список
        // Я думаю його можна віднести до "гребінця", оскільки тут також використовується проміжок (gap)
        // та він зменшуеться та прямує до центру ()------(), ()-----(), ()---(), ()-()
        for (int i = 0; i < n; i++)
        {
            if (i >= otherNums.Count - i - 1) break;
            int temp = otherNums[i];
            otherNums[i] = otherNums[otherNums.Count - i - 1];
            otherNums[otherNums.Count - i - 1] = temp;
        }

        // Алгоритм сортування гребінцем, створюємо прапорець (sorted) та проміжок (gap)
        // У цьому алгоритмі йдуть пріорітети чисел, 1) "непарні" 2) "парні" 3) решта
        // "непарні" - непарні числа, які діляться на К націло
        // "парні" - парні числи, у яких при діленні на К остача 1
        // решта - решта)
        bool sorted = false;
        int gap = array.Length; // (n)

        Console.WriteLine("\nSorting...");

        while (!sorted || gap != 1)
        {
            sorted = true;
            gap = Convert.ToInt32(Math.Floor(gap / 1.3));
            if (gap < 1) gap = 1;

            for (int i = 0; i < array.Length - gap; i++)
            {
                // Якщо число 1 - не "непарне", а число 2 - "непарне", то пріорітет у числа 2 більше, 
                // тому міняємо місцями
                if (!IsOdd(array[i], k) && IsOdd(array[i + gap], k))
                {
                    int temp = array[i];
                    array[i] = array[i + gap];
                    array[i + gap] = temp;
                    sorted = false;
                    continue;
                }
                // Якщо обидва "непарні", порівнюємо за значенням
                if (IsOdd(array[i], k) && IsOdd(array[i + gap], k))
                {
                    if (array[i] > array[i + gap])
                    {
                        int temp = array[i];
                        array[i] = array[i + gap];
                        array[i + gap] = temp;
                        sorted = false;
                        continue;
                    }
                    continue;
                }
                // Якщо обидва числа "парні", порівнюємо за значенням
                if (IsEven(array[i], k) && IsEven(array[i + gap], k))
                {
                    if (array[i] > array[i + gap])
                    {
                        int temp = array[i];
                        array[i] = array[i + gap];
                        array[i + gap] = temp;
                        sorted = false;
                        continue;
                    }
                    continue;
                }
                // Якщо число 1 не "непарне" та не "парне" (тобро решта), а число 2 - "парне",
                // міняємо місцями, оскільки пріорітет у "парних" вище
                if (!IsEven(array[i], k) && !IsOdd(array[i], k) && IsEven(array[i + gap], k))
                {
                    int temp = array[i];
                    array[i] = array[i + gap];
                    array[i + gap] = temp;
                    sorted = false;
                    continue;
                }
            }
        }

        // рахуємо з якої позиції починаються "решта" чисел
        int startPosition = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (!IsEven(array[i], k) && !IsOdd(array[i], k))
            {
                startPosition = i;
                break;
            }
        }

        // За допомогою списка, який створили раніше переписуємо "решту" чисел
        // у зворотному порядку відносно початкового массиву
        for (int i = startPosition; i < array.Length; i++)
        {
            array[i] = otherNums[i - startPosition];
        }

        // Виводимо результат у консоль
        Console.WriteLine("Sorted array: ");
        ShowArr(array, k);

    }

}