using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("Podaj liczbę całkowitą (wpisz liczbę mniejszą od zera, aby zakończyć): ");
            int liczba;

            if (!int.TryParse(Console.ReadLine(), out liczba))
            {
                Console.WriteLine("Nieprawidłowa wartość. Spróbuj ponownie.");
                continue;
            }

            if (liczba < 0)
            {
                Console.WriteLine("Wprowadzono liczbę mniejszą od zera. Kończę działanie.");
                break;
            }

            Console.WriteLine("Wprowadziłeś liczbę: " + liczba);
        }
    }
}
