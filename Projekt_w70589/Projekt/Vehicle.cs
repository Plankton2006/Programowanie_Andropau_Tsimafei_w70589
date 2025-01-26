using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public abstract class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public int[] Rows { get; set; }
        public int[] Columns { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }

        public Vehicle(string registrationNumber, int[] rows, int[] cols)
        {
            RegistrationNumber = registrationNumber;
            Rows = rows;
            Columns = cols;
            ArrivalTime = DateTime.Now;
        }

        public abstract string GetVehicleType();

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Typ: {GetVehicleType()} | Rejestracja: {RegistrationNumber}");
            Console.Write($"Zajmowane pola: ");
            for (int i = 0; i < Rows.Length; i++)
            {
                Console.Write($"({Rows[i]}, {Columns[i]}) ");
            }
            Console.WriteLine();
            Console.WriteLine($"Przyjazd: {ArrivalTime}");
            if (DepartureTime != null)
            {
                Console.WriteLine($"Odjazd: {DepartureTime}");
            }
        }
    }
}
