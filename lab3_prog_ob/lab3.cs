using System;
using System.Collections.Generic;

class Person
{
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private int Age { get; set; }

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public virtual void View()
    {
        Console.WriteLine($"Person: {FirstName} {LastName}, Age: {Age}");
    }
}

class Book
{
    public string Title { get; set; }
    protected Person Author { get; set; }
    protected DateTime PublicationDate { get; set; }

    public Book(string title, Person author, DateTime publicationDate)
    {
        Title = title;
        Author = author;
        PublicationDate = publicationDate;
    }

    public virtual void View()
    {
        Console.WriteLine($"Book: {Title}, Author: {Author}, Published: {PublicationDate.ToShortDateString()}");
    }
}

class AdventureBook : Book
{
    private string AdventureType { get; set; }

    public AdventureBook(string title, Person author, DateTime publicationDate, string adventureType)
        : base(title, author, publicationDate)
    {
        AdventureType = adventureType;
    }

    public override void View()
    {
        base.View();
        Console.WriteLine($"Adventure Type: {AdventureType}");
    }
}

class DocumentaryBook : Book
{
    private string Topic { get; set; }

    public DocumentaryBook(string title, Person author, DateTime publicationDate, string topic)
        : base(title, author, publicationDate)
    {
        Topic = topic;
    }

    public override void View()
    {
        base.View();
        Console.WriteLine($"Topic: {Topic}");
    }
}

class Reader : Person
{
    private List<Book> ReadBooks { get; set; } = new List<Book>();
    public Reader(string firstName, string lastName, int age) : base(firstName, lastName, age) { }
    public void AddBook(Book book)
    {
        ReadBooks.Add(book);
    }

    public void ViewBooks()
    {
        Console.WriteLine("Read books:");
        foreach (var book in ReadBooks)
        {
            book.View();
        }
    }

    public override void View()
    {
        base.View();
        ViewBooks();
    }
}

class Reviewer : Reader
{
    public Reviewer(string firstName, string lastName, int age) : base(firstName, lastName, age) { }

    public void WriteReviews()
    {
        Console.WriteLine("Reviews:");
        Random random = new Random();
        foreach (var book in new List<Book>())
        {
            Console.WriteLine($"{book.Title} - Rating: {random.Next(1, 6)}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person author1 = new Person("Tomas", "Harris", 45);
        Person author2 = new Person("Margaret", "Mitchell", 37);

        Book book1 = new Book("C# Programming", author1, new DateTime(2020, 5, 15));
        AdventureBook book2 = new AdventureBook("The silence of the lambs", author2, new DateTime(2021, 6, 10), "Mountaineering");
        DocumentaryBook book3 = new DocumentaryBook("Gone with the wind", author1, new DateTime(2019, 9, 20), "Climate Change");

        Reader reader1 = new Reader("Adam", "Nowicki", 25);
        Reader reader2 = new Reader("Ewa", "Kowalska", 30);

        Reviewer reviewer1 = new Reviewer("Robert", "Lewandowski", 35);
        Reviewer reviewer2 = new Reviewer("Anna", "Zielińska", 40);

        reader1.AddBook(book1);
        reader1.AddBook(book2);
        reader2.AddBook(book3);

        reviewer1.AddBook(book1);
        reviewer1.AddBook(book2);

        reviewer2.AddBook(book3);

        List<Person> people = new List<Person> { reader1, reader2, reviewer1, reviewer2 };
        foreach (var person in people)
        {
            person.View();
            Console.WriteLine();
        }
        reviewer1.WriteReviews();
        reviewer2.WriteReviews();
    }
}
class Samochod
{
    public string Marka { get; set; }
    public string Model { get; set; }
    public string Nadwozie { get; set; }
    public string Kolor { get; set; }
    public int RokProdukcji { get; set; }
    private int przebieg;
    public int Przebieg
    {
        get { return przebieg; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Przebieg nie może być ujemny!");
            przebieg = value;
        }
    }
    public Samochod()
    {
        Console.Write("Podaj markę: ");
        Marka = Console.ReadLine();
        Console.Write("Podaj model: ");
        Model = Console.ReadLine();
        Console.Write("Podaj nadwozie: ");
        Nadwozie = Console.ReadLine();
        Console.Write("Podaj kolor: ");
        Kolor = Console.ReadLine();
        Console.Write("Podaj rok produkcji: ");
        RokProdukcji = int.Parse(Console.ReadLine());
        Console.Write("Podaj przebieg: ");
        Przebieg = int.Parse(Console.ReadLine());
    }
    public Samochod(string marka, string model, string nadwozie, string kolor, int rokProdukcji, int przebieg)
    {
        Marka = marka;
        Model = model;
        Nadwozie = nadwozie;
        Kolor = kolor;
        RokProdukcji = rokProdukcji;
        Przebieg = przebieg;
    }
    public virtual void WyswietlInformacje()
    {
        Console.WriteLine($"Samochód: {Marka} {Model}, Nadwozie: {Nadwozie}, Kolor: {Kolor}, Rok produkcji: {RokProdukcji}, Przebieg: {Przebieg} km");
    }
}

class SamochodOsobowy : Samochod
{
    public double Waga { get; set; } 
    public double PojemnoscSilnika { get; set; } 
    public int IloscOsob { get; set; }
    public SamochodOsobowy() : base()
    {
        Console.Write("Podaj wagę (2-4,5 t): ");
        Waga = double.Parse(Console.ReadLine());
        if (Waga < 2 || Waga > 4.5)
            throw new ArgumentException("Waga musi być z przedziału 2-4,5 t!");

        Console.Write("Podaj pojemność silnika (0,8-3,0): ");
        PojemnoscSilnika = double.Parse(Console.ReadLine());
        if (PojemnoscSilnika < 0.8 || PojemnoscSilnika > 3.0)
            throw new ArgumentException("Pojemność silnika musi być z przedziału 0,8-3,0!");

        Console.Write("Podaj ilość osób: ");
        IloscOsob = int.Parse(Console.ReadLine());
    }
    public override void WyswietlInformacje()
    {
        base.WyswietlInformacje();
        Console.WriteLine($"Waga: {Waga} t, Pojemność silnika: {PojemnoscSilnika} l, Ilość osób: {IloscOsob}");
    }
}

class Programa
{
    static void Main(string[] args)
    {
        Console.WriteLine("Tworzenie samochodu osobowego:");
        SamochodOsobowy osobowy = new SamochodOsobowy();

        Console.WriteLine("\nTworzenie pierwszego samochodu:");
        Samochod samochod1 = new Samochod();

        Console.WriteLine("\nTworzenie drugiego samochodu:");
        Samochod samochod2 = new Samochod("Toyota", "Corolla", "Sedan", "Czarny", 2020, 50000);

        Console.WriteLine("\nInformacje o samochodach:");
        osobowy.WyswietlInformacje();
        samochod1.WyswietlInformacje();
        samochod2.WyswietlInformacje();
    }
}