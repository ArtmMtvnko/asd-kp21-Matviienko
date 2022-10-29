using System;
using System.Globalization;

class Card
{
    static void Main(string[] args)
    {
        // Вводимо змінну
        int n = 0;
        Console.WriteLine("Enter the number: ");
        n = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Palindromes are : ");
        // Цикл який пробігається по натуральним числам до n
        for (int i = 1; i <= n; i++)
        {
            // возводиму у квадрат та конвертуємо число у строку для зручної перевідки на паліндром
            string iModivite = (i * i).ToString();
            int L = iModivite.Length;
            string container = "";

            // Цикл який відзеркалює число
            for (int j = L - 1; j >= 0; j--)
            {
                container = container + iModivite[j];
            }
            // якщо відзеркалене число = початковому, число є паліндромом, виводимо який це номер
            if (iModivite == container)
            {
                Console.WriteLine(i);
            }
        }
    }

}