using System;
using System.Runtime.ConstrainedExecution;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Parking parking = new Parking(rows: 6, columns: 6);

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== SYSTEM OBSŁUGI PARKINGU ===");
                Console.WriteLine("1. Dodaj pojazd (przyjazd)");
                Console.WriteLine("2. Wyświetl wszystkie pojazdy");
                Console.WriteLine("3. Usuń pojazd (odjazd)");
                Console.WriteLine("4. Wyszukaj pojazd");
                Console.WriteLine("5. Zobacz wizualizację parkingu");
                Console.WriteLine("6. Wyjście");
                Console.Write("Wybierz opcję: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddVehicleMenu(parking);
                        break;
                    case "2":
                        parking.DisplayAllVehicles();
                        Console.ReadKey();
                        break;
                    case "3":
                        RemoveVehicleMenu(parking);
                        break;
                    case "4":
                        SearchMenu(parking);
                        break;
                    case "5":
                        parking.DisplayParkingVisualization();
                        Console.ReadKey();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Nieznana opcja.");
                        Console.ReadKey();
                        break;
                }
            }

            parking.SaveData();
        }

        static void AddVehicleMenu(Parking parking)
        {
            Console.Clear();
            Console.WriteLine("=== DODAWANIE POJAZDU ===");
            Console.WriteLine("Wybierz typ pojazdu:");
            Console.WriteLine("1. Motocykl");
            Console.WriteLine("2. Samochód osobowy");
            Console.WriteLine("3. Autobus");

            string typeChoice = Console.ReadLine();

            Console.Write("Podaj numer rejestracyjny: ");
            string registrationNumber = Console.ReadLine();

            Console.Write("Podaj wiersz(y) (np. 2 dla jednego pola, lub 2,3 dla autobusu): ");
            string rowInput = Console.ReadLine();
            int[] rows = Array.ConvertAll(rowInput.Split(','), int.Parse);

            Console.Write("Podaj kolumnę(y) (np. 3 dla jednego pola, lub 3,4 dla samochodu): ");
            string columnInput = Console.ReadLine();
            int[] cols = Array.ConvertAll(columnInput.Split(','), int.Parse);

            Vehicle vehicle = null;
            switch (typeChoice)
            {
                case "1":
                    vehicle = new Motorcycle(registrationNumber, rows, cols);
                    break;
                case "2":
                    vehicle = new Car(registrationNumber, rows, cols);
                    break;
                case "3":
                    vehicle = new Bus(registrationNumber, rows, cols);
                    break;
                default:
                    Console.WriteLine("Nieznany typ pojazdu.");
                    return;
            }

            bool result = parking.AddVehicle(vehicle);
            if (result)
                Console.WriteLine("Pojazd dodany pomyślnie.");
            else
                Console.WriteLine("Nie udało się dodać pojazdu (miejsce zajęte lub niepoprawne).");

            Console.ReadKey();
        }

        static void RemoveVehicleMenu(Parking parking)
        {
            Console.Clear();
            Console.WriteLine("=== USUWANIE POJAZDU ===");
            Console.Write("Podaj numer rejestracyjny: ");
            string regNumber = Console.ReadLine();

            bool result = parking.RemoveVehicle(regNumber);
            if (result)
                Console.WriteLine("Pojazd usunięto.");
            else
                Console.WriteLine("Nie znaleziono pojazdu o podanej rejestracji.");

            Console.ReadKey();
        }

        static void SearchMenu(Parking parking)
        {
            Console.Clear();
            Console.WriteLine("=== WYSZUKIWANIE POJAZDU ===");
            Console.WriteLine("1. Wyszukaj po numerze rejestracyjnym");
            Console.WriteLine("2. Wyszukaj po dacie/godzinie przyjazdu");
            Console.WriteLine("3. Wyszukaj po dacie/godzinie odjazdu");
            string choice = Console.ReadLine();

            Console.WriteLine("Wpisz szukaną wartość (np. rejestrację, datę RRRR-MM-DD GG:MM:SS itp.):");
            string query = Console.ReadLine();

            var results = parking.SearchVehicle(choice, query);

            if (results.Count == 0)
            {
                Console.WriteLine("Brak wyników.");
            }
            else
            {
                Console.WriteLine("Znalezione pojazdy:");
                foreach (var ev in results)
                {
                    Console.WriteLine(ev);
                }
            }

            Console.ReadKey();
        }
    }
}
