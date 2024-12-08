using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;
//zad1
class Program
{
    static void Main()
    {
        string numerAlbumu = "w70589";

        Console.Write("Podaj nazwę pliku do zapisu (z rozszerzeniem, np. '.txt'): ");
        string nazwaPliku = Console.ReadLine();

        try
        {
            File.WriteAllText(nazwaPliku, $"Numer albumu: {numerAlbumu}");
            Console.WriteLine($"Numer albumu został zapisany do pliku: {nazwaPliku}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas zapisywania pliku: {ex.Message}");
        }
    }
}
//zad2
class Programa
{
    static void Main()
    {
        Console.Write("Podaj nazwę pliku do odczytu (z rozszerzeniem, np. '.txt'): ");
        string nazwaPliku = Console.ReadLine();

        try
        {
            string zawartosc = File.ReadAllText(nazwaPliku);
            Console.WriteLine("Zawartość pliku:");
            Console.WriteLine(zawartosc);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik o podanej nazwie nie istnieje.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas odczytu pliku: {ex.Message}");
        }
    }
}
//zad3
class Programm
{
    static void Main()
    {
        string plik = "pesels.txt";

        try
        {
            if (!File.Exists(plik))
            {
                Console.WriteLine($"Plik '{plik}' nie istnieje. Upewnij się, że został wygenerowany.");
                return;
            }

            string[] pesels = File.ReadAllLines(plik);

            Console.WriteLine("Wczytane numery PESEL:");
            foreach (var pesel in pesels)
            {
                Console.WriteLine(pesel);
            }

            int iloscZen = pesels.Count(IsFemalePesel);

            Console.WriteLine($"\nLiczba żeńskich PESEL-i: {iloscZen}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd podczas przetwarzania pliku: {ex.Message}");
        }
    }
    static bool IsFemalePesel(string pesel)
    {
        if (pesel.Length != 11 || !pesel.All(char.IsDigit))
        {
            Console.WriteLine($"Nieprawidłowy numer PESEL: {pesel}");
            return false;
        }

        int ostatniaCyfra = int.Parse(pesel[9].ToString());
        return ostatniaCyfra % 2 == 0; 
    }
}
//zad4
class Programka
{
    static void Main()
    {
        string dbPath = "db.json";

        if (!File.Exists(dbPath))
        {
            Console.WriteLine($"Plik '{dbPath}' nie istnieje.");
            return;
        }

        try
        {
            string jsonData = File.ReadAllText(dbPath);
            var populationData = JsonSerializer.Deserialize<Dictionary<string, Dictionary<int, long>>>(jsonData);

            if (populationData == null)
            {
                Console.WriteLine("Błąd wczytywania danych.");
                return;
            }

            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Różnica populacji Indii (1970-2000)");
                Console.WriteLine("2. Różnica populacji USA (1965-2010)");
                Console.WriteLine("3. Różnica populacji Chin (1980-2018)");
                Console.WriteLine("4. Wyświetl populację wybranego kraju w wybranym roku");
                Console.WriteLine("5. Sprawdź różnicę populacji dla zakresu lat i kraju");
                Console.WriteLine("6. Procentowy wzrost populacji dla każdego kraju");
                Console.WriteLine("7. Wyjście");
                Console.Write("Wybierz opcję: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayPopulationDifference(populationData, "India", 1970, 2000);
                        break;
                    case "2":
                        DisplayPopulationDifference(populationData, "USA", 1965, 2010);
                        break;
                    case "3":
                        DisplayPopulationDifference(populationData, "China", 1980, 2018);
                        break;
                    case "4":
                        DisplayPopulationForYear(populationData);
                        break;
                    case "5":
                        DisplayPopulationRangeDifference(populationData);
                        break;
                    case "6":
                        DisplayYearlyGrowth(populationData);
                        break;
                    case "7":
                        Console.WriteLine("Koniec programu.");
                        return;
                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }
    }

    static void DisplayPopulationDifference(Dictionary<string, Dictionary<int, long>> data, string country, int year1, int year2)
    {
        if (data.TryGetValue(country, out var years) && years.ContainsKey(year1) && years.ContainsKey(year2))
        {
            long difference = years[year2] - years[year1];
            Console.WriteLine($"Różnica populacji {country} między {year1} a {year2} wynosi: {difference:N0}");
        }
        else
        {
            Console.WriteLine($"Brak danych dla {country} lub lat {year1}/{year2}.");
        }
    }

    static void DisplayPopulationForYear(Dictionary<string, Dictionary<int, long>> data)
    {
        Console.Write("Podaj kraj (USA, India, China): ");
        string country = Console.ReadLine();
        Console.Write("Podaj rok: ");
        if (int.TryParse(Console.ReadLine(), out int year) && data.TryGetValue(country, out var years) && years.ContainsKey(year))
        {
            Console.WriteLine($"Populacja {country} w roku {year}: {years[year]:N0}");
        }
        else
        {
            Console.WriteLine("Brak danych dla podanego kraju lub roku.");
        }
    }

    static void DisplayPopulationRangeDifference(Dictionary<string, Dictionary<int, long>> data)
    {
        Console.Write("Podaj kraj (USA, India, China): ");
        string country = Console.ReadLine();
        Console.Write("Podaj rok początkowy: ");
        bool isYear1Valid = int.TryParse(Console.ReadLine(), out int year1);
        Console.Write("Podaj rok końcowy: ");
        bool isYear2Valid = int.TryParse(Console.ReadLine(), out int year2);

        if (isYear1Valid && isYear2Valid && data.TryGetValue(country, out var years) && years.ContainsKey(year1) && years.ContainsKey(year2))
        {
            long difference = years[year2] - years[year1];
            Console.WriteLine($"Różnica populacji {country} między {year1} a {year2} wynosi: {difference:N0}");
        }
        else
        {
            Console.WriteLine("Brak danych dla podanego kraju lub lat.");
        }
    }

    static void DisplayYearlyGrowth(Dictionary<string, Dictionary<int, long>> data)
    {
        foreach (var country in data.Keys)
        {
            Console.WriteLine($"\nProcentowy wzrost populacji dla {country}:");
            var years = data[country];
            var sortedYears = years.Keys.OrderBy(y => y).ToList();

            for (int i = 1; i < sortedYears.Count; i++)
            {
                int previousYear = sortedYears[i - 1];
                int currentYear = sortedYears[i];

                long previousPopulation = years[previousYear];
                long currentPopulation = years[currentYear];

                double growth = ((double)(currentPopulation - previousPopulation) / previousPopulation) * 100;
                Console.WriteLine($"  {previousYear} -> {currentYear}: {growth:F2}%");
            }
        }
    }
}
//zad5
public interface IPersonRepository
{
    void AddPerson(Person person);
    void RemovePersonById(Guid id);
    Person GetPersonById(Guid id);
    List<Person> GetAllPeople();
    void UpdatePerson(Person person);
}
public record Person(Guid Id, string FirstName, string LastName, int Age);
public class FilePersonRepository : IPersonRepository
{
    private readonly string _filePath;

    public FilePersonRepository(string filePath)
    {
        _filePath = filePath;
        if (!File.Exists(_filePath))
        {
            File.Create(_filePath).Close(); 
        }
    }
    public void AddPerson(Person person)
    {
        var allPeople = GetAllPeople();
        allPeople.Add(person);
        SaveAllPeople(allPeople);
    }
    public void RemovePersonById(Guid id)
    {
        var allPeople = GetAllPeople();
        var personToRemove = allPeople.FirstOrDefault(p => p.Id == id);
        if (personToRemove == null)
        {
            throw new KeyNotFoundException($"Osoba z ID {id} nie została znaleziona.");
        }

        allPeople.Remove(personToRemove);
        SaveAllPeople(allPeople);
    }
    public Person GetPersonById(Guid id)
    {
        var allPeople = GetAllPeople();
        var person = allPeople.FirstOrDefault(p => p.Id == id);
        if (person == null)
        {
            throw new KeyNotFoundException($"Osoba z ID {id} nie została znaleziona.");
        }

        return person;
    }
    public List<Person> GetAllPeople()
    {
        if (!File.Exists(_filePath))
        {
            return new List<Person>();
        }

        var lines = File.ReadAllLines(_filePath);
        return lines.Select(line => JsonSerializer.Deserialize<Person>(line)).Where(p => p != null).ToList();
    }
    public void UpdatePerson(Person person)
    {
        var allPeople = GetAllPeople();
        var existingPersonIndex = allPeople.FindIndex(p => p.Id == person.Id);
        if (existingPersonIndex == -1)
        {
            throw new KeyNotFoundException($"Osoba z ID {person.Id} nie została znaleziona.");
        }

        allPeople[existingPersonIndex] = person;
        SaveAllPeople(allPeople);
    }
    private void SaveAllPeople(List<Person> people)
    {
        var lines = people.Select(p => JsonSerializer.Serialize(p)).ToList();
        File.WriteAllLines(_filePath, lines);
    }
}
class Programochka
{
    static void Main()
    {
        string filePath = "people_db.json";
        IPersonRepository personRepository = new FilePersonRepository(filePath);

        while (true)
        {
            Console.WriteLine("\n--- MENU ---");
            Console.WriteLine("1. Dodaj osobę");
            Console.WriteLine("2. Usuń osobę");
            Console.WriteLine("3. Wyświetl osobę po ID");
            Console.WriteLine("4. Wyświetl wszystkie osoby");
            Console.WriteLine("5. Zaktualizuj osobę");
            Console.WriteLine("6. Wyjście");
            Console.Write("Wybierz opcję: ");

            string choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Imię: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Nazwisko: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Wiek: ");
                        int age = int.Parse(Console.ReadLine());

                        var newPerson = new Person(Guid.NewGuid(), firstName, lastName, age);
                        personRepository.AddPerson(newPerson);
                        Console.WriteLine("Osoba dodana.");
                        break;

                    case "2":
                        Console.Write("Podaj ID osoby do usunięcia: ");
                        Guid removeId = Guid.Parse(Console.ReadLine());
                        personRepository.RemovePersonById(removeId);
                        Console.WriteLine("Osoba usunięta.");
                        break;

                    case "3":
                        Console.Write("Podaj ID osoby: ");
                        Guid getId = Guid.Parse(Console.ReadLine());
                        var person = personRepository.GetPersonById(getId);
                        Console.WriteLine($"Osoba: {person}");
                        break;

                    case "4":
                        var allPeople = personRepository.GetAllPeople();
                        Console.WriteLine("Wszystkie osoby:");
                        foreach (var p in allPeople)
                        {
                            Console.WriteLine(p);
                        }
                        break;

                    case "5":
                        Console.Write("Podaj ID osoby do zaktualizowania: ");
                        Guid updateId = Guid.Parse(Console.ReadLine());
                        Console.Write("Nowe imię: ");
                        string newFirstName = Console.ReadLine();
                        Console.Write("Nowe nazwisko: ");
                        string newLastName = Console.ReadLine();
                        Console.Write("Nowy wiek: ");
                        int newAge = int.Parse(Console.ReadLine());

                        var updatedPerson = new Person(updateId, newFirstName, newLastName, newAge);
                        personRepository.UpdatePerson(updatedPerson);
                        Console.WriteLine("Dane osoby zaktualizowane.");
                        break;

                    case "6":
                        Console.WriteLine("Koniec programu.");
                        return;

                    default:
                        Console.WriteLine("Nieprawidłowy wybór. Spróbuj ponownie.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }
        }
    }
}