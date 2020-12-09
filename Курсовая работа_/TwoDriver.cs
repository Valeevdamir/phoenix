using System;
using System.Collections.Generic;
using System.Text;

namespace Курсовая_работа_
{
    public class TwoDriver:AbstractWorkDone
    {
        Driver driver1;
        public TwoDriver(Driver driver, Driver driver1, Track track, DateTime dateTime)
           : base(driver, track, dateTime)
        {
            this.driver1 = driver1;
        }

        override public  double Award()
        {
            double award = (driver.Expirience * 10 + track.Distance)*2;
            return award;
        }

        public override double Pay()
        {
            if (track.Isaward)
                return Award()*2 + track.Payment * 0.1*2
                    + driver.Expirience*10 + driver1.Expirience*10;
            else
                return track.Payment * 2*0.1
                    + driver.Expirience * 10 + driver1.Expirience * 10;
        }


    }
}
