using System;
using System.Collections.Generic;
using System.Linq;
//zad1
public class Osoba
{
    private string imie;
    private string nazwisko;
    private int wiek;

    public Osoba(string imie, string nazwisko, int wiek)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        Wiek = wiek;
    }

    public string Imie
    {
        get { return imie; }
        set
        {
            if (value.Length >= 2)
            {
                imie = value;
            }
            else
            {
                throw new ArgumentException("Imię musi mieć 2 znaki i więcej");
            }
        }
    }
    public string Nazwisko
    {
        get { return nazwisko; }
        set
        {
            if (value.Length >= 2)
            {
                nazwisko = value;
            }
            else
            {
                throw new ArgumentException("Nazwisko musi mieć minimum 2 znaki");
            }
        }
    }
    public int Wiek
    {
        get { return wiek; }
        set
        {
            if (value > 0)
            {
                wiek = value;
            }
            else
            {
                throw new ArgumentException("Wiek musi być liczbą dodatnią");
            }
        }
    }
    public void WyswietlInformacje()
    {
        Console.WriteLine($"Imię: {Imie}, Nazwisko: {Nazwisko}, Wiek: {Wiek}");
    }
}
class Program
{
    static void Main()
    {
        try
        {
            Osoba osoba = new Osoba("Arnold", "Schwarzenegger", 15);
            osoba.WyswietlInformacje();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
    }
}

//zad2
public class BankAccount
{
    private decimal saldo;

    public BankAccount(string wlasciciel, decimal poczatkoweSaldo)
    {
        Wlasciciel = wlasciciel;
        saldo = poczatkoweSaldo;
    }

    public decimal Saldo
    {
        get { return saldo; }
    }

    public string Wlasciciel { get; private set; }

    public void Wplata(decimal kwota)
    {
        if (kwota <= 0)
        {
            throw new ArgumentException("Kwota musi być >0");
        }
        saldo += kwota;
    }
    public void Wyplata(decimal kwota)
    {
        if (kwota <= 0)
        {
            throw new ArgumentException("Kwota musi być >0");
        }
        if (kwota > saldo)
        {
            throw new InvalidOperationException("Niewystarczające środki na koncie");
        }
        saldo -= kwota;
    }
}
class Programm
{
    static void Main()
    {
        try
        {
            BankAccount konto = new BankAccount("Sylvester Stallone", 1000);
            konto.Wplata(500);
            konto.Wyplata(200);
            Console.WriteLine($"Właściciel:{konto.Wlasciciel},Saldo: {konto.Saldo}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Błąd: " + ex.Message);
        }
    }
}
//zad3
public class Student
{
    public string Imie { get; private set; }
    public string Nazwisko { get; private set; }
    private List<int> oceny;
    public Student(string imie, string nazwisko)
    {
        Imie = imie;
        Nazwisko = nazwisko;
        oceny = new List<int>();
    }
    public double SredniaOcen
    {
        get
        {
            if (oceny.Count == 0)
                return 0;
            return oceny.Average();
        }
    }
    public void DodajOcene(int ocena)
    {
        if (ocena >= 1 && ocena <= 5)
        {
            oceny.Add(ocena);
        }
        else
        {
            throw new ArgumentException("Ocena musi być w zakresie od 1 do 5.");
        }
    }
}
class Program
{
    static void Main()
    {
        Student student = new Student("Jan", "Kowalski");
        student.DodajOcene(3);
        student.DodajOcene(3);
        student.DodajOcene(4);

        Console.WriteLine($"Student: {student.Imie} {student.Nazwisko}");
        Console.WriteLine($"Średnia ocen: {student.SredniaOcen}");
    }
}
//zad4
public class Licz
{
    private int value;
    public Licz(int initialValue)
    {
        value = initialValue;
    }
    public void Dodaj(int liczba)
    {
        value += liczba;
    }
    public void Odejmij(int liczba)
    {
        value -= liczba;
    }
    public void WypiszStan()
    {
        Console.WriteLine($"Aktualna wartość: {value}");
    }
}
class Program
{
    static void Main()
    {
        Licz licz1 = new Licz(0);
        Licz licz2 = new Licz(2);

        licz1.Dodaj(5);
        licz1.WypiszStan();

        licz2.Odejmij(10);
        licz2.WypiszStan();

        licz1.Odejmij(3);
        licz1.WypiszStan();

        licz2.Dodaj(7);
        licz2.WypiszStan();
    }
}
//zad5
public class Sumator
{
    private int[] Liczby;

    public Sumator(int[] liczby)
    {
        Liczby = liczby;
    }

    public int Suma()
    {
        return Liczby.Sum();
    }
    public int SumaPodziel2()
    {
        return Liczby.Where(x => x % 2 == 0).Sum();
    }
    public int IleElementów()
    {
        return Liczby.Length;
    }
    public void WypiszWszystkieElementy()
    {
        Console.WriteLine("Elementy tablicy: " + string.Join(", ", Liczby));
    }
    public void WypiszElementyWZakresie(int lowIndex, int highIndex)
    {
        Console.WriteLine("Elementy w zakresie od " + lowIndex + " do " + highIndex + ":");

        for (int i = Math.Max(0, lowIndex); i <= Math.Min(highIndex, Liczby.Length - 1); i++)
        {
            Console.Write(Liczby[i] + " ");
        }
        Console.WriteLine();
    }
}
class Program
{
    static void Main()
    {
        int[] liczby = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        Sumator sumator = new Sumator(liczby);

        Console.WriteLine("Suma wszystkich liczb: " + sumator.Suma());
        Console.WriteLine("Suma liczb podzielnych przez 2: " + sumator.SumaPodziel2());
        Console.WriteLine("Liczba elementów w tablicy: " + sumator.IleElementów());

        sumator.WypiszWszystkieElementy();

        sumator.WypiszElementyWZakresie(3, 7);

        sumator.WypiszElementyWZakresie(-2, 15);
    }
}