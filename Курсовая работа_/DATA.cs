using System;
using System.Collections.Generic;
using System.Text;

namespace Курсовая_работа_
{
    public class DATA
    {
        public int DATAId { get; set; }
        public string track { set; get; }
        public string driver { set; get; }
        public string driver2 { set; get; }
        public string truck { get; set; }
        public int payment { set; get; }
        public int profit { get; set; }
        public bool isaward { get; set; }
        public DateTime departure_time { get; set; }
        public DateTime arrived_time { get; set; }

       
        public DATA() { }
        public DATA(string track, string driver, string driver2, string truck, int payment, int profit, DateTime depa, DateTime arri, bool isaward )
        {
            this.track = track ?? throw new ArgumentNullException(nameof(track));
            this.driver = driver ?? throw new ArgumentNullException(nameof(driver));
            this.driver2 = driver2;
            this.truck = truck ?? throw new ArgumentNullException(nameof(truck));
            this.payment = payment;
            this.profit = profit;
            departure_time = depa;
            arrived_time = arri;
            this.isaward = isaward;
        }
    }
}
