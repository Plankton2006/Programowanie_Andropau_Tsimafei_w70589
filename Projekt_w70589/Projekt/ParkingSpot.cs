using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSystem
{
    public class ParkingSpot
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsOccupied { get; set; }

        public ParkingSpot(int row, int column)
        {
            Row = row;
            Column = column;
            IsOccupied = false;
        }

        public override string ToString()
        {
            return $"({Row}, {Column}){(IsOccupied ? " [Zajęte]" : " [Wolne]")}";
        }
    }
}
