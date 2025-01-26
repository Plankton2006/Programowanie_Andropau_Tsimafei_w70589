using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.ConstrainedExecution;

namespace ParkingSystem
{
    public class FileManager
    {
        private const string SpotsFile = "spots.txt";
        private const string VehiclesFile = "vehicles.txt";
        private const string EventsFile = "events.txt";

        public void LoadParkingData(List<ParkingSpot> spots, List<Vehicle> vehicles, List<ParkingEvent> events)
        {
            if (File.Exists(SpotsFile))
            {
                var lines = File.ReadAllLines(SpotsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 3)
                    {
                        int row = int.Parse(parts[0]);
                        int col = int.Parse(parts[1]);
                        bool occupied = bool.Parse(parts[2]);
                        var spot = spots.Find(s => s.Row == row && s.Column == col);
                        if (spot != null)
                        {
                            spot.IsOccupied = occupied;
                        }
                    }
                }
            }
            if (File.Exists(VehiclesFile))
            {
                var lines = File.ReadAllLines(VehiclesFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 6)
                    {
                        string type = parts[0];
                        string reg = parts[1];
                        DateTime arrival = DateTime.Parse(parts[2]);
                        DateTime? departure = string.IsNullOrEmpty(parts[3])
                                                ? (DateTime?)null
                                                : DateTime.Parse(parts[3]);

                        int[] rows = Array.ConvertAll(parts[4].Split(','), int.Parse);
                        int[] cols = Array.ConvertAll(parts[5].Split(','), int.Parse);

                        Vehicle v = null;
                        switch (type)
                        {
                            case "Motocykl":
                                v = new Motorcycle(reg, rows, cols);
                                break;
                            case "Samochód osobowy":
                                v = new Car(reg, rows, cols);
                                break;
                            case "Autobus":
                                v = new Bus(reg, rows, cols);
                                break;
                        }
                        if (v != null)
                        {
                            v.ArrivalTime = arrival;
                            v.DepartureTime = departure;
                            vehicles.Add(v);
                        }
                    }
                }
            }
            if (File.Exists(EventsFile))
            {
                var lines = File.ReadAllLines(EventsFile);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length == 4)
                    {
                        string reg = parts[0];
                        DateTime arrival = DateTime.Parse(parts[1]);
                        DateTime? departure = string.IsNullOrEmpty(parts[2])
                                                ? (DateTime?)null
                                                : DateTime.Parse(parts[2]);
                        string vehicleType = parts[3];

                        var ev = new ParkingEvent(reg, arrival, vehicleType);
                        ev.DepartureTime = departure;
                        events.Add(ev);
                    }
                }
            }
        }

        public void SaveParkingData(List<ParkingSpot> spots, List<Vehicle> vehicles, List<ParkingEvent> events)
        {
            List<string> spotsLines = new List<string>();
            foreach (var s in spots)
            {
                spotsLines.Add($"{s.Row};{s.Column};{s.IsOccupied}");
            }
            File.WriteAllLines(SpotsFile, spotsLines);

            List<string> vehiclesLines = new List<string>();
            foreach (var v in vehicles)
            {
                string type = v.GetVehicleType();
                string departureStr = v.DepartureTime.HasValue ? v.DepartureTime.Value.ToString() : "";
                string rowsStr = string.Join(",", v.Rows);
                string colsStr = string.Join(",", v.Columns);
                vehiclesLines.Add($"{type};{v.RegistrationNumber};{v.ArrivalTime};{departureStr};{rowsStr};{colsStr}");
            }
            File.WriteAllLines(VehiclesFile, vehiclesLines);

            List<string> eventsLines = new List<string>();
            foreach (var e in events)
            {
                string departureStr = e.DepartureTime.HasValue ? e.DepartureTime.Value.ToString() : "";
                eventsLines.Add($"{e.RegistrationNumber};{e.ArrivalTime};{departureStr};{e.VehicleType}");
            }
            File.WriteAllLines(EventsFile, eventsLines);
        }
    }
}
