using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class ParkingEvent
    {
        public string RegistrationNumber { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime? DepartureTime { get; set; }
        public string VehicleType { get; set; }

        public ParkingEvent(string regNumber, DateTime arrival, string vehicleType)
        {
            RegistrationNumber = regNumber;
            ArrivalTime = arrival;
            VehicleType = vehicleType;
        }

        public override string ToString()
        {
            string info = $"Pojazd: {VehicleType}, Rejestracja: {RegistrationNumber}, " +
                          $"Przyjazd: {ArrivalTime}";
            if (DepartureTime != null)
            {
                info += $", Odjazd: {DepartureTime}";
            }
            return info;
        }
    }
}
