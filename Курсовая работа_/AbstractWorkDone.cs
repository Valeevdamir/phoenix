using System;

namespace Курсовая_работа_
{
    public abstract class AbstractWorkDone : IWorkDone
    {
        public Driver driver;
        public Track track;
        public DateTime date_departure;
        public DateTime date_arrive;
        public int Salary { get; private set; }
        
        public AbstractWorkDone(Driver driver, Track track, DateTime dateTime)
        {
            this.driver = driver;
            this.track = track;
            date_departure = dateTime;
            date_arrive = date_departure.AddDays(track.Day_value);
        }

        abstract public double Pay();
        abstract public double Award();
        




    }
}
