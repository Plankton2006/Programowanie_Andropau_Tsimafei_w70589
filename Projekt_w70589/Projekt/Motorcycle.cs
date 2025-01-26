using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(string registrationNumber, int[] rows, int[] cols)
            : base(registrationNumber, rows, cols)
        {
        }

        public override string GetVehicleType()
        {
            return "Motocykl";
        }
    }
}