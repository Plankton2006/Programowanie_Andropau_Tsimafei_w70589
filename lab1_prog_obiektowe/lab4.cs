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

        double suma = 0;
        for (int i = 0; i < liczby.Length; i++)
        {
            suma += liczby[i];
        }
        Console.WriteLine("\nSuma elementów tablicy: " + suma);

        double iloczyn = 1;
        for (int i = 0; i < liczby.Length; i++)
        {
            iloczyn *= liczby[i];
        }
        Console.WriteLine("Iloczyn elementów tablicy: " + iloczyn);

        double srednia = suma / liczby.Length;
        Console.WriteLine("Średnia wartość: " + srednia);

        double min = liczby[0];
        for (int i = 1; i < liczby.Length; i++)
        {
            if (liczby[i] < min)
            {
                min = liczby[i];
            }
        }
        Console.WriteLine("Minimalna wartość: " + min);

        double max = liczby[0];
        for (int i = 1; i < liczby.Length; i++)
        {
            if (liczby[i] > max)
            {
                max = liczby[i];
            }
        }
        Console.WriteLine("Maksymalna wartość: " + max);
    }
}
