using System;
using System.Collections.Generic;
using System.Text;

namespace Курсовая_работа_
{
    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get; private set; }
        public double Distance { get; private set; }
        public int Day_value { get; private set; }
        public double Payment { get; private set; }
        public bool Isaward { get; private set; }
        public Track() { }
        public Track(string name, double distance, int Day_value,
            double Payment,bool Isaward)
        {
            
            if (distance > 0 && Payment > 0 && Day_value > 0)
            {
                this.Isaward = Isaward;
                this.Name = name;
                this.Day_value = Day_value;
                this.Payment = Payment;
                this.Distance = distance;
            }
            else
                throw new Exception("Неккоректная инициализация полей");
        }

        public double Profit(Truck truck, AbstractWorkDone abstractWork)
        {
            double costs = truck.FuelConsumption / 100 * Distance * 45 + abstractWork.Pay();
            return Payment - costs;
        }
        
   


    }


}
