using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longevity
{
    public class Planet
    {
        private TimeSpan planetTimeSpan;

        private string planetName;

        private int degree = 1;

        private int minutes;

        private string durationCalculationType = "Full";


        public string DurationCalculationType
        {
            get
            {
                return durationCalculationType;
            }

            set
            {
                this.durationCalculationType = value;
            }
        }


        public string PlanetName
        {
            get
            {
                return this.planetName;
            }
            set
            {
                this.planetName = value;
            }
        }

        public int Degrees
        {
            get
            {
                return this.degree;
            }
            set
            {
                this.degree = value;
            }
        }

        public int DegreeMinutes
        {
            get
            {
                return this.minutes;
            }
            set
            {
                this.minutes = value;
            }
        }

        public TimeSpan PlanetTotalTimeSpan
        {
            get
            {
                return this.planetTimeSpan;
            }
        }

        public decimal Years
        {
            get
            {
                return Math.Floor(this.planetTimeSpan.Days / 365.242m);
            }
        }

        public decimal Months
        {
            get
            {
                return Math.Floor((this.planetTimeSpan.Days - this.Years * 365.242m) / 30m);
            }
        }

        public decimal Days
        {
            get
            {
                return Math.Floor((this.planetTimeSpan.Days - this.Years * 365.242m) % 30m);
            }
        }

        public int Hours
        {
            get
            {
                return this.planetTimeSpan.Hours;
            }
        }

        public int Minutes
        {
            get
            {
                return this.planetTimeSpan.Minutes;
            }
        }

        public Planet(string name)
        {
            this.planetName = name;
        }

        public Planet(string name, int degrees, int minute)
        {
            this.planetName = name;
            this.degree = degrees;
            this.minutes = minute;
            this.planetTimeSpan = PlanetDuration.Calculate(this.degree, this.minutes);
        }

        public TimeSpan HalfPlanetDuration()
        {
            this.planetTimeSpan = this.planetTimeSpan.Subtract(new TimeSpan(this.planetTimeSpan.Ticks / 2L));
            this.durationCalculationType = "Half";
            return this.planetTimeSpan.Subtract(new TimeSpan(this.planetTimeSpan.Ticks / 2L));
        }

        public TimeSpan TwoThirdPlanetDuration()
        {
            this.durationCalculationType = "Two Third";
            this.planetTimeSpan = this.planetTimeSpan.Subtract(new TimeSpan(this.planetTimeSpan.Ticks / 3L));
            return this.planetTimeSpan.Subtract(new TimeSpan(this.planetTimeSpan.Ticks / 3L));
        }

        public TimeSpan AddPlanetDuration(int times)
        {
            this.durationCalculationType = string.Format("{0} times", times);
            this.planetTimeSpan = this.planetTimeSpan.Add(new TimeSpan(this.planetTimeSpan.Ticks * (long)(--times)));
            return this.planetTimeSpan.Add(new TimeSpan(this.planetTimeSpan.Ticks * (long)(--times)));
        }

        public void CalculateDuration()
        {
            this.planetTimeSpan = PlanetDuration.Calculate(this.degree, this.DegreeMinutes);
        }

        public string DurationToString(TimeSpan ts)
        {
            return string.Format("{0} Y {1} M {2} D {3}:{4}", new object[]
            {
                this.GetYears(ts),
                this.GetMonths(ts),
                this.GetDays(ts),
                ts.Hours,
                ts.Minutes
            });
        }

        public string DurationToString()
        {
            TimeSpan ts = planetTimeSpan;
            return string.Format("{0} Y {1} M {2} D {3}:{4}", new object[]
            {
                this.GetYears(ts),
                this.GetMonths(ts),
                this.GetDays(ts),
                ts.Hours,
                ts.Minutes
            });
        }

        private decimal GetYears(TimeSpan ts)
        {
            return Math.Floor(ts.Days / 365.242m);
        }

        private decimal GetMonths(TimeSpan ts)
        {
            return Math.Floor((ts.Days - this.GetYears(ts) * 365.242m) / 30m);
        }

        private decimal GetDays(TimeSpan ts)
        {
            return Math.Floor((ts.Days - this.GetYears(ts) * 365.242m) % 30m);
        }
    }
}
