using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longevity
{
    internal class PlanetDuration
    {
        private static TimeSpan OneDegree = new TimeSpan(108, 0, 0, 0);

        private static TimeSpan OneMinute = new TimeSpan(1, 19, 12, 0);

        public static TimeSpan Calculate(int degrees, int minutes)
        {
            return TimeSpan.FromTicks(PlanetDuration.OneDegree.Ticks * (long)degrees).Add(TimeSpan.FromTicks(PlanetDuration.OneMinute.Ticks * (long)minutes));
        }
    }
}
