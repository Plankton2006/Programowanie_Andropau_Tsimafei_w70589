using System;
using System.Collections.Generic;

enum Operacja
{
    Dodawanie,
    Odejmowanie,
    Mnożenie,
    Dzielenie
}

class Kalkulator
{
    private List<double> historiaWynikow = new List<double>();

    public void Uruchom()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Kalkulator");
            Console.WriteLine("1. Dodawanie");
            Console.WriteLine("2. Odejmowanie");
            Console.WriteLine("3. Mnożenie");
            Console.WriteLine("4. Dzielenie");
            Console.WriteLine("5. Pokaż historię wyników");
            Console.WriteLine("6. Wyjdź");
            Console.Write("Wybierz operację: ");

            try
            {
                int wybor = int.Parse(Console.ReadLine());
                if (wybor == 6)
                    break;

                if (wybor == 5)
                {
                    PokazHistorie();
                    continue;
                }

                if (wybor < 1 || wybor > 4)
                {
                    Console.WriteLine("Nieprawidłowy wybór operacji.");
                    Console.ReadKey();
                    continue;
                }

                Operacja operacja = (Operacja)(wybor - 1);
                Console.Write("Podaj pierwszą liczbę: ");
                double liczba1 = double.Parse(Console.ReadLine());

                Console.Write("Podaj drugą liczbę: ");
                double liczba2 = double.Parse(Console.ReadLine());

                double wynik = WykonajOperacje(operacja, liczba1, liczba2);
                Console.WriteLine($"Wynik: {wynik}");
                historiaWynikow.Add(wynik);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Błąd: próba dzielenia przez zero.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Błąd: nieprawidłowy format liczby.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wystąpił nieoczekiwany błąd: {ex.Message}");
            }

            Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
            Console.ReadKey();
        }
    }

    private double WykonajOperacje(Operacja operacja, double liczba1, double liczba2)
    {
        return operacja switch
        {
            Operacja.Dodawanie => liczba1 + liczba2,
            Operacja.Odejmowanie => liczba1 - liczba2,
            Operacja.Mnożenie => liczba1 * liczba2,
            Operacja.Dzielenie when liczba2 != 0 => liczba1 / liczba2,
            Operacja.Dzielenie => throw new DivideByZeroException(),
            _ => throw new InvalidOperationException("Nieprawidłowa operacja")
        };
    }

    private void PokazHistorie()
    {
        Console.WriteLine("Historia wyników:");
        if (historiaWynikow.Count == 0)
        {
            Console.WriteLine("Brak zapisanych wyników.");
        }
        else
        {
            for (int i = 0; i < historiaWynikow.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {historiaWynikow[i]}");
            }
        }
        Console.WriteLine("Naciśnij dowolny klawisz, aby wrócić do menu.");
        Console.ReadKey();
    }
}

class Program
{
    static void Main()
    {
        Kalkulator kalkulator = new Kalkulator();
        kalkulator.Uruchom();
    }
}

enum StatusZamowienia
{
    Oczekujące,
    Przyjęte,
    Zrealizowane,
    Anulowane
}

class Sklep
{
    private Dictionary<int, (StatusZamowienia, List<string>)> zamowienia = new();

    public void DodajZamowienie(int numerZamowienia, List<string> produkty)
    {
        if (zamowienia.ContainsKey(numerZamowienia))
        {
            Console.WriteLine("Zamówienie o tym numerze już istnieje.");
            return;
        }

        zamowienia[numerZamowienia] = (StatusZamowienia.Oczekujące, produkty);
        Console.WriteLine($"Zamówienie nr {numerZamowienia} zostało dodane.");
    }

    public void ZmienStatusZamowienia(int numerZamowienia, StatusZamowienia nowyStatus)
    {
        try
        {
            if (!zamowienia.ContainsKey(numerZamowienia))
                throw new KeyNotFoundException($"Nie znaleziono zamówienia o numerze {numerZamowienia}.");

            var (obecnyStatus, produkty) = zamowienia[numerZamowienia];

            if (obecnyStatus == nowyStatus)
                throw new ArgumentException($"Zamówienie nr {numerZamowienia} już ma status: {nowyStatus}.");

            zamowienia[numerZamowienia] = (nowyStatus, produkty);
            Console.WriteLine($"Status zamówienia nr {numerZamowienia} zmieniono na: {nowyStatus}.");
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }
    }

    public void WyswietlZamowienia()
    {
        if (zamowienia.Count == 0)
        {
            Console.WriteLine("Brak zamówień.");
            return;
        }

        Console.WriteLine("Lista zamówień:");
        foreach (var (numerZamowienia, (status, produkty)) in zamowienia)
        {
            Console.WriteLine($"Zamówienie nr {numerZamowienia}:");
            Console.WriteLine($" - Status: {status}");
            Console.WriteLine($" - Produkty: {string.Join(", ", produkty)}");
        }
    }
}

class Programm
{
    static void Main()
    {
        Sklep sklep = new();
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Zarządzanie zamówieniami w sklepie:");
            Console.WriteLine("1. Dodaj zamówienie");
            Console.WriteLine("2. Zmień status zamówienia");
            Console.WriteLine("3. Wyświetl wszystkie zamówienia");
            Console.WriteLine("4. Wyjdź");
            Console.Write("Wybierz opcję: ");

            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    Console.Write("Podaj numer zamówienia: ");
                    int numer = int.Parse(Console.ReadLine());

                    Console.Write("Podaj produkty (oddzielone przecinkami): ");
                    string produktyInput = Console.ReadLine();
                    List<string> produkty = new List<string>(produktyInput.Split(','));

                    sklep.DodajZamowienie(numer, produkty);
                    break;

                case "2":
                    Console.Write("Podaj numer zamówienia: ");
                    numer = int.Parse(Console.ReadLine());

                    Console.WriteLine("Wybierz nowy status:");
                    foreach (var status in Enum.GetValues(typeof(StatusZamowienia)))
                    {
                        Console.WriteLine($" - {(int)status}: {status}");
                    }

                    int statusWybor = int.Parse(Console.ReadLine());
                    if (Enum.IsDefined(typeof(StatusZamowienia), statusWybor))
                    {
                        sklep.ZmienStatusZamowienia(numer, (StatusZamowienia)statusWybor);
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowy status.");
                    }
                    break;

                case "3":
                    sklep.WyswietlZamowienia();
                    Console.WriteLine("Naciśnij dowolny klawisz, aby kontynuować...");
                    Console.ReadKey();
                    break;

                case "4":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    break;
            }
        }
    }
}

enum Kolor
{
    Czerwony,
    Niebieski,
    Zielony,
    Żółty,
    Fioletowy
}

class GraZGadnijKolor
{
    static void Main()
    {
        List<Kolor> listaKolorów = new List<Kolor>((Kolor[])Enum.GetValues(typeof(Kolor)));

        Random random = new Random();
        Kolor wylosowanyKolor = listaKolorów[random.Next(listaKolorów.Count)];

        Console.WriteLine("Gra: Zgadnij wylosowany kolor!");
        Console.WriteLine("Dostępne kolory: " + string.Join(", ", listaKolorów));

        bool odgadnięto = false;

        while (!odgadnięto)
        {
            Console.Write("Podaj kolor: ");
            string wejscie = Console.ReadLine();

            try
            {
                if (!Enum.TryParse<Kolor>(wejscie, true, out Kolor wybranyKolor))
                {
                    throw new ArgumentException("Wprowadzony kolor nie jest poprawny.");
                }

                if (wybranyKolor == wylosowanyKolor)
                {
                    Console.WriteLine($"Gratulacje! Odgadłeś kolor: {wylosowanyKolor}");
                    odgadnięto = true;
                }
                else
                {
                    Console.WriteLine("Nie zgadłeś! Spróbuj ponownie.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
        }

        Console.WriteLine("Koniec gry.");
    }
}