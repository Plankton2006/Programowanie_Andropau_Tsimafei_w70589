using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class Parking
    {
        private List<ParkingSpot> Spots;
        private List<Vehicle> Vehicles;
        private List<ParkingEvent> Events;
        private readonly int Rows;
        private readonly int Columns;

        public Parking(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            Spots = new List<ParkingSpot>();
            Vehicles = new List<Vehicle>();
            Events = new List<ParkingEvent>();

            for (int r = 1; r <= rows; r++)
            {
                for (int c = 1; c <= columns; c++)
                {
                    Spots.Add(new ParkingSpot(r, c));
                }
            }

            LoadData();
        }

        public bool AddVehicle(Vehicle vehicle)
        {
            foreach (var spot in GetSpotsForVehicle(vehicle))
            {
                if (spot == null || spot.IsOccupied)
                {
                    return false; 
                }
            }

            foreach (var spot in GetSpotsForVehicle(vehicle))
            {
                spot.IsOccupied = true;
            }

            Vehicles.Add(vehicle);

            Events.Add(new ParkingEvent(vehicle.RegistrationNumber, vehicle.ArrivalTime, vehicle.GetVehicleType()));

            return true;
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            var vehicle = Vehicles.FirstOrDefault(v => v.RegistrationNumber == registrationNumber);
            if (vehicle == null) return false;

            foreach (var spot in GetSpotsForVehicle(vehicle))
            {
                if (spot != null)
                {
                    spot.IsOccupied = false;
                }
            }

            vehicle.DepartureTime = DateTime.Now;

            var ev = Events.FirstOrDefault(e => e.RegistrationNumber == registrationNumber && e.DepartureTime == null);
            if (ev != null)
            {
                ev.DepartureTime = vehicle.DepartureTime;
            }

            Vehicles.Remove(vehicle);
            return true;
        }

        public void DisplayAllVehicles()
        {
            Console.WriteLine("=== LISTA POJAZDÓW NA PARKINGU ===");
            foreach (var v in Vehicles)
            {
                v.DisplayInfo();
                Console.WriteLine("---------------------------");
            }
        }

        public void DisplayParkingVisualization()
        {

            Console.WriteLine("=== WIZUALIZACJA PARKINGU ===");
            for (int r = 1; r <= Rows; r++)
            {
                for (int c = 1; c <= Columns; c++)
                {
                    var spot = Spots.FirstOrDefault(s => s.Row == r && s.Column == c);
                    if (spot == null)
                    {
                        Console.Write("?");
                    }
                    else
                    {
                        if (r % 2 == 1)
                        {
                            Console.Write('-');
                        }
                        else
                        {
                            if (spot.IsOccupied) Console.Write('X');
                            else Console.Write('.');
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        public List<ParkingEvent> SearchVehicle(string option, string query)
        {

            switch (option)
            {
                case "1":
                    return Events.Where(e => e.RegistrationNumber.Contains(query)).ToList();
                case "2":
                    if (DateTime.TryParse(query, out DateTime arrival))
                    {
                        return Events.Where(e => e.ArrivalTime.Date == arrival.Date).ToList();
                    }
                    break;
                case "3":
                    if (DateTime.TryParse(query, out DateTime departure))
                    {
                        return Events.Where(e => e.DepartureTime.HasValue && e.DepartureTime.Value.Date == departure.Date).ToList();
                    }
                    break;
            }
            return new List<ParkingEvent>();
        }

        private List<ParkingSpot> GetSpotsForVehicle(Vehicle vehicle)
        {
            List<ParkingSpot> spotsList = new List<ParkingSpot>();
            for (int i = 0; i < vehicle.Rows.Length; i++)
            {
                var spot = Spots.FirstOrDefault(s => s.Row == vehicle.Rows[i] && s.Column == vehicle.Columns[i]);
                spotsList.Add(spot);
            }
            return spotsList;
        }
        public void LoadData()
        {
            FileManager fm = new FileManager();
            fm.LoadParkingData(this.Spots, this.Vehicles, this.Events);
        }

        public void SaveData()
        {
            FileManager fm = new FileManager();
            fm.SaveParkingData(this.Spots, this.Vehicles, this.Events);
        }
    }
}
