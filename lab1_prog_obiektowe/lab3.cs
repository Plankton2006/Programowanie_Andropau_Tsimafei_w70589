using System;

class Program
{
    static void Main()
    {
        double[] liczby = new double[10];

        for (int i = 0; i < liczby.Length; i++)
        {
            Console.Write($"Podaj liczbę {i + 1}: ");
            while (!double.TryParse(Console.ReadLine(), out liczby[i]))
            {
                Console.WriteLine("Niepoprawna wartość. Spróbuj ponownie.");
                Console.Write($"Podaj liczbę {i + 1}: ");
            }
        }

        Console.WriteLine("\nTablica od pierwszego do ostatniego indeksu:");
        for (int i = 0; i < liczby.Length; i++)
        {
            Console.Write(liczby[i] + " ");
        }

        Console.WriteLine("\n\nTablica od ostatniego do pierwszego indeksu:");
        for (int i = liczby.Length - 1; i >= 0; i--)
        {
            Console.Write(liczby[i] + " ");
        }

        Console.WriteLine("\n\nElementy o nieparzystych indeksach:");
        for (int i = 1; i < liczby.Length; i += 2)
        {
            Console.Write(liczby[i] + " ");
        }

        Console.WriteLine("\n\nElementy o parzystych indeksach:");
        for (int i = 0; i < liczby.Length; i += 2)
        {
            Console.Write(liczby[i] + " ");
        }
    }
}
