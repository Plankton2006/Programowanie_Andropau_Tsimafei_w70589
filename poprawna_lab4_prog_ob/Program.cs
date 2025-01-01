//zad1
using System;
using System.Collections.Generic;

public class Shape
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }

    public virtual void Draw() { }
}

public class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysuję prostokąt");
    }
}

public class Triangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysuję trójkąt");
    }
}

public class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Rysuję koło");
    }
}

class ProgramZad1
{
    static void Main()
    {
        List<Shape> shapes = new List<Shape>
        {
            new Rectangle(),
            new Triangle(),
            new Circle()
        };

        foreach (var shape in shapes)
        {
            shape.Draw();
        }
    }
}

//zad2
public class Osoba
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Pesel { get; set; }

    public void SetFirstName(string firstName) => FirstName = firstName;
    public void SetLastName(string lastName) => LastName = lastName;
    public void SetPesel(string pesel) => Pesel = pesel;

    public int GetAge()
    {
        int yearOfBirth = int.Parse(Pesel.Substring(0, 2));
        int currentYear = DateTime.Now.Year;
        int century = (yearOfBirth > 20) ? 1900 : 2000;  
        int birthYear = century + yearOfBirth;

        return currentYear - birthYear;
    }

    public string GetGender()
    {
        int genderDigit = int.Parse(Pesel.Substring(9, 1));
        return genderDigit % 2 == 0 ? "Kobieta" : "Mężczyzna";
    }

    public string GetFullName() => $"{FirstName} {LastName}";

    public virtual bool CanGoAloneToHome() => false;
}

public class Uczen : Osoba
{
    public string School { get; set; }
    public bool MozeSamWracacDoDomu { get; set; }

    public void SetSchool(string school) => School = school;
    public void ChangeSchool(string newSchool) => School = newSchool;

    public override bool CanGoAloneToHome() => GetAge() >= 12 || MozeSamWracacDoDomu;
}

public class Nauczyciel : Uczen
{
    public string TytulNaukowy { get; set; }
    public List<Uczen> PodwladniUczniowie { get; set; } = new List<Uczen>();

    public void WhichStudentCanGoHomeAlone(DateTime dateToCheck)
    {
        foreach (var uczen in PodwladniUczniowie)
        {
            if (uczen.CanGoAloneToHome())
                Console.WriteLine(uczen.GetFullName());
        }
    }
}

class ProgramZad2
{
    static void Main()
    {
        var uczen1 = new Uczen { FirstName = "Janek", LastName = "Jobs", Pesel = "12345678901", School = "Szkoła A", MozeSamWracacDoDomu = false };
        var uczen2 = new Uczen { FirstName = "Ruslan", LastName = "Ludmil", Pesel = "23456789012", School = "Szkoła B", MozeSamWracacDoDomu = true };
        var nauczyciel = new Nauczyciel { FirstName = "Tim", LastName = "Ron", Pesel = "34567890123", TytulNaukowy = "Dr", School = "Szkoła C" };

        nauczyciel.PodwladniUczniowie.Add(uczen1);
        nauczyciel.PodwladniUczniowie.Add(uczen2);

        nauczyciel.WhichStudentCanGoHomeAlone(DateTime.Now);
    }
}

//zad3
public interface IOsoba
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string GetFullName();
}

public class OsobaClass : IOsoba
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string GetFullName() => $"{FirstName} {LastName}";
}

class ProgramZad3
{
    static void Main()
    {
        List<IOsoba> osoby = new List<IOsoba>
        {
            new OsobaClass { FirstName = "Jana", LastName = "Olegowna" },
            new OsobaClass { FirstName = "Aleksiy", LastName = "Haval" }
        };

        foreach (var osoba in osoby)
        {
            Console.WriteLine(osoba.GetFullName());
        }
    }
}

//zad3b
public static class Extensions
{
    public static void WypiszOsoby(this List<IOsoba> osoby)
    {
        foreach (var osoba in osoby)
        {
            Console.WriteLine(osoba.GetFullName());
        }
    }
}

class ProgramZad3b
{
    static void Main()
    {
        List<IOsoba> osoby = new List<IOsoba>
        {
            new OsobaClass { FirstName = "Jan", LastName = "Kowalski" },
            new OsobaClass { FirstName = "Anna", LastName = "Nowak" }
        };

        osoby.WypiszOsoby();
    }
}

//zad3c
public static class ExtensionsSort
{
    public static void PosortujOsobyPoNazwisku(this List<IOsoba> osoby)
    {
        osoby.Sort((x, y) => x.LastName.CompareTo(y.LastName));
    }
}

class ProgramZad3c
{
    static void Main()
    {
        List<IOsoba> osoby = new List<IOsoba>
        {
            new OsobaClass { FirstName = "Roman", LastName = "Mask" },
            new OsobaClass { FirstName = "Judit", LastName = "Polgar" }
        };

        osoby.PosortujOsobyPoNazwisku();
        foreach (var osoba in osoby)
        {
            Console.WriteLine(osoba.GetFullName());
        }
    }
}

//zad3d
public interface IStudent : IOsoba
{
    string Uczelnia { get; set; }
    string Kierunek { get; set; }
    string Rok { get; set; }
    string Semestr { get; set; }
    string WypiszPelnaNazweIUczelnie();
}

public class StudentClass : IStudent
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Uczelnia { get; set; }
    public string Kierunek { get; set; }
    public string Rok { get; set; }
    public string Semestr { get; set; }

    public string GetFullName() => $"{FirstName} {LastName}";
    public string WypiszPelnaNazweIUczelnie() => $"{GetFullName()} – {Rok} {Kierunek} {Semestr} {Uczelnia}";
}

class ProgramZad3d
{
    static void Main()
    {
        var student = new StudentClass
        {
            FirstName = "Rico",
            LastName = "Kowalski",
            Uczelnia = "WSIiZ",
            Kierunek = "Informatyka",
            Rok = "4",
            Semestr = "II"
        };

        Console.WriteLine(student.WypiszPelnaNazweIUczelnie());
    }
}

//zad3e
public class StudentWSIiZ : StudentClass
{
    public string WypiszPelnaNazweIUczelnie() => $"{GetFullName()} – {Rok} {Kierunek} {Semestr} WSIiZ";
}

class ProgramZad3e
{
    static void Main()
    {
        var studentWSIiZ = new StudentWSIiZ
        {
            FirstName = "Robert",
            LastName = "Lewandowski",
            Uczelnia = "WSIiZ",
            Kierunek = "Zarządzanie",
            Rok = "2",
            Semestr = "I"
        };

        Console.WriteLine(studentWSIiZ.WypiszPelnaNazweIUczelnie());
    }
}
