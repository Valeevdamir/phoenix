using System;
using System.Collections.Generic;
using System.Text;

namespace Курсовая_работа_
{
    public class Truck
    {
        public int TruckId { get;  set; }
        public double FuelConsumption { get; private set; }
        public double Tonnage { get; private set; }
        public string Name { get; private set; }
        public Truck() { }
        public Truck(string name, double fuel, double tonnage)
        {
            Name = name;
            FuelConsumption = fuel;
            Tonnage = tonnage;
        }



    }
}
