using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class Bus : Vehicle
    {
        public Bus(string registrationNumber, int[] rows, int[] cols)
            : base(registrationNumber, rows, cols)
        {
        }

        public override string GetVehicleType()
        {
            return "Autobus";
        }
    }
}