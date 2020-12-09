using System;
using System.Collections.Generic;
using System.Text;

namespace Курсовая_работа_
{
   public class OneDriver : AbstractWorkDone
    {

        public OneDriver(Driver driver, Track track, DateTime dateTime)
            :base(driver,track,dateTime)
        {
            
        }

        override public double Award()
        {
            double award = driver.Expirience * 10 + track.Distance;
            return award;
        }
        public override double Pay()
        {
            if (track.Isaward)
                return Award() + track.Payment *0.1 + driver.Expirience * 10;
            else
                return track.Payment + driver.Expirience * 10;
        }





    }

    
}
