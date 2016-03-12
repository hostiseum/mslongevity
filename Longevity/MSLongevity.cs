using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Longevity
{
    class MSLongevity
    {
        private List<Planet> planets = new List<Planet>();

        public List<Planet> Planets
        {
            get
            {
                return this.planets;
            }
        }

        public MSLongevity()
        {
            this.planets = this.createPlanets();
        }

        private List<Planet> createPlanets()
        {
            Planet item = new Planet("Sun");
            Planet item2 = new Planet("Moon");
            Planet item3 = new Planet("Mars");
            Planet item4 = new Planet("Mercury");
            Planet item5 = new Planet("Jupiter");
            Planet item6 = new Planet("Venus");
            Planet item7 = new Planet("Saturn");
            return new List<Planet>
            {
                item,
                item2,
                item3,
                item4,
                item5,
                item6,
                item7
            };
        }

        public void SetDegreesToPlanet(string planetName, int degrees, int minutes)
        {
            Planet expr_29 = (from p in this.planets
                              where p.PlanetName == planetName
                              select p).FirstOrDefault<Planet>();
            expr_29.Degrees = degrees;
            expr_29.DegreeMinutes = minutes;
            expr_29.CalculateDuration();
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
