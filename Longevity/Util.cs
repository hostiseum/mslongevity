using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longevity
{
    class Util
    {
        public static string DurationStringFromTimespan(TimeSpan ts)
        {
            return string.Format("{0} Y {1} M {2} D {3}:{4}", new object[]
            {
                GetYears(ts),
                GetMonths(ts),
                GetDays(ts),
                ts.Hours,
                ts.Minutes
            });
        }

        private static decimal GetYears(TimeSpan ts)
        {
            return Math.Floor(ts.Days / 365.242m);
        }

        private static decimal GetMonths(TimeSpan ts)
        {
            return Math.Floor((ts.Days - GetYears(ts) * 365.242m) / 30m);
        }

        private static decimal GetDays(TimeSpan ts)
        {
            return Math.Floor((ts.Days - GetYears(ts) * 365.242m) % 30m);
        }
    }
}
