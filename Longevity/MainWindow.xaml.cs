using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Longevity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string ROW_TEMPLATE = @"<tr>
                        < td style=""width:120px;border: 1px solid #ccc"">{0}</td>
                        <td style= ""width:150px; border: 1px solid #ccc"">{1}</td>
                        <td style= ""width:120px; border: 1px solid #ccc"">{2}</td>
                        <td style= ""width:150px; border: 1px solid #ccc"">{3}</td>
                        <td style= ""width:120px; border: 1px solid #ccc"">{4}</td>
                    </tr>";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ctrlSun_DegreesMinutesLostFocus(object sender, EventArgs e)
        {
            //MessageBox.Show(((PlanetDegreesMinutesTextBoxControl)sender).Planet);
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            totalDuration.Text = CalculateTotal();

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {

            string html = GetHtml();

            PDFExport.GeneratePDF(html);
        }

        private string GetHtml()
        {
            StringBuilder sb = new StringBuilder();


            string htmlTemplate = @"<div id = ""Grid"">
                <table cellspacing=""0"" cellpadding=""2"" style=""border-collapse: collapse;border: 1px solid #ccc;font-size: 9pt;"">
                    
                    <tr>
                        <th style=""background-color: #B8DBFD;border: 1px solid #ccc"">Planet name</th>
                        <th style=""background-color: #B8DBFD;border: 1px solid #ccc"">Degrees</th>
                        <th style=""background-color: #B8DBFD;border: 1px solid #ccc"">Minutes</th>
                        <th style=""background-color: #B8DBFD;border: 1px solid #ccc"">Term</th>
                        <th style=""background-color: #B8DBFD;border: 1px solid #ccc"">Duration</th>
                    </tr>
                    {0}
                </table>
                <div>Generated at: {1}</div>
           </div>";


            sb.Append(planetHtml(ctrlSun.Planet, "Sun"));
            sb.Append(planetHtml(ctrlMoon.Planet, "Moon"));
            sb.Append(planetHtml(ctrlMercury.Planet, "Mercury"));
            sb.Append(planetHtml(ctrlMars.Planet, "Mars"));
            sb.Append(planetHtml(ctrlJupiter.Planet, "Jupiter"));
            sb.Append(planetHtml(ctrlVenus.Planet, "Venus"));
            sb.Append(planetHtml(ctrlSaturn.Planet, "Saturn"));
            sb.Append(string.Format(ROW_TEMPLATE, string.Empty, string.Empty, string.Empty, "Total", CalculateTotal()));

            htmlTemplate = string.Format(htmlTemplate, sb.ToString(), DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss"));

            //totalDuration.Text = Util.DurationStringFromTimespan(total);

            return htmlTemplate;
        }

        private string CalculateTotal()
        {
            TimeSpan total = ctrlSun.Planet.PlanetTotalTimeSpan
                .Add(ctrlMoon.Planet.PlanetTotalTimeSpan)
           .Add(ctrlMercury.Planet.PlanetTotalTimeSpan)
           .Add(ctrlMars.Planet.PlanetTotalTimeSpan)
           .Add(ctrlJupiter.Planet.PlanetTotalTimeSpan)
           .Add(ctrlVenus.Planet.PlanetTotalTimeSpan)
           .Add(ctrlSaturn.Planet.PlanetTotalTimeSpan);

           return Util.DurationStringFromTimespan(total);
        }

        private string planetHtml(Planet planet, string planetName)
        {
            return string.Format(ROW_TEMPLATE, planetName, planet.Degrees, planet.DegreeMinutes, planet.DurationCalculationType, planet.DurationToString());
        }
        /*   private void CalculateLongevity()
           {
               string text = (sender as TextBox).Text;
               string name = (sender as TextBox).Name;
               TextBox textBox;
               if (name.Contains("2"))
               {
                   textBox = (base.Controls.Find((sender as TextBox).Name, true)[0] as TextBox);
               }
               else
               {
                   textBox = (base.Controls.Find((sender as TextBox).Name + "2", true)[0] as TextBox);
               }
               if (this.Valid(text) && this.Valid(textBox.Text))
               {
                   if (name.Contains("Sun"))
                   {
                       this.l.SetDegreesToPlanet("Sun", int.Parse(this.txtSun.Text), int.Parse(this.txtSun2.Text));
                       IEnumerable<Planet> arg_F6_0 = this.l.Planets;
                       Func<Planet, bool> arg_F6_1;
                       if ((arg_F6_1 = Form1.<> c.<> 9__12_0) == null)
                       {
                           arg_F6_1 = (Form1.<> c.<> 9__12_0 = new Func<Planet, bool>(Form1.<> c.<> 9.< txtSun_TextChanged > b__12_0));
                       }
                       this.FillBoxes(arg_F6_0.Where(arg_F6_1).FirstOrDefault<Planet>());
                   }
                   else if (name.Contains("Mars"))
                   {
                       this.l.SetDegreesToPlanet("Mars", int.Parse(this.txtMars.Text), int.Parse(this.txtMars2.Text));
                       IEnumerable<Planet> arg_172_0 = this.l.Planets;
                       Func<Planet, bool> arg_172_1;
                       if ((arg_172_1 = Form1.<> c.<> 9__12_1) == null)
                       {
                           arg_172_1 = (Form1.<> c.<> 9__12_1 = new Func<Planet, bool>(Form1.<> c.<> 9.< txtSun_TextChanged > b__12_1));
                       }
                       this.FillBoxes(arg_172_0.Where(arg_172_1).FirstOrDefault<Planet>());
                   }
                   else if (name.Contains("Moon"))
                   {
                       this.l.SetDegreesToPlanet("Moon", int.Parse(this.txtMoon.Text), int.Parse(this.txtMoon2.Text));
                       IEnumerable<Planet> arg_1EE_0 = this.l.Planets;
                       Func<Planet, bool> arg_1EE_1;
                       if ((arg_1EE_1 = Form1.<> c.<> 9__12_2) == null)
                       {
                           arg_1EE_1 = (Form1.<> c.<> 9__12_2 = new Func<Planet, bool>(Form1.<> c.<> 9.< txtSun_TextChanged > b__12_2));
                       }
                       this.FillBoxes(arg_1EE_0.Where(arg_1EE_1).FirstOrDefault<Planet>());
                   }
                   else if (name.Contains("Saturn"))
                   {
                       this.l.SetDegreesToPlanet("Saturn", int.Parse(this.txtSaturn.Text), int.Parse(this.txtSaturn2.Text));
                       IEnumerable<Planet> arg_26A_0 = this.l.Planets;
                       Func<Planet, bool> arg_26A_1;
                       if ((arg_26A_1 = Form1.<> c.<> 9__12_3) == null)
                       {
                           arg_26A_1 = (Form1.<> c.<> 9__12_3 = new Func<Planet, bool>(Form1.<> c.<> 9.< txtSun_TextChanged > b__12_3));
                       }
                       this.FillBoxes(arg_26A_0.Where(arg_26A_1).FirstOrDefault<Planet>());
                   }
                   else if (name.Contains("Venus"))
                   {
                       this.l.SetDegreesToPlanet("Venus", int.Parse(this.txtVenus.Text), int.Parse(this.txtVenus2.Text));
                       IEnumerable<Planet> arg_2E6_0 = this.l.Planets;
                       Func<Planet, bool> arg_2E6_1;
                       if ((arg_2E6_1 = Form1.<> c.<> 9__12_4) == null)
                       {
                           arg_2E6_1 = (Form1.<> c.<> 9__12_4 = new Func<Planet, bool>(Form1.<> c.<> 9.< txtSun_TextChanged > b__12_4));
                       }
                       this.FillBoxes(arg_2E6_0.Where(arg_2E6_1).FirstOrDefault<Planet>());
                   }
                   else if (name.Contains("Jupiter"))
                   {
                       this.l.SetDegreesToPlanet("Jupiter", int.Parse(this.txtJupiter.Text), int.Parse(this.txtJupiter2.Text));
                       IEnumerable<Planet> arg_362_0 = this.l.Planets;
                       Func<Planet, bool> arg_362_1;
                       if ((arg_362_1 = Form1.<> c.<> 9__12_5) == null)
                       {
                           arg_362_1 = (Form1.<> c.<> 9__12_5 = new Func<Planet, bool>(Form1.<> c.<> 9.< txtSun_TextChanged > b__12_5));
                       }
                       this.FillBoxes(arg_362_0.Where(arg_362_1).FirstOrDefault<Planet>());
                   }
                   else if (name.Contains("Mercury"))
                   {
                       this.l.SetDegreesToPlanet("Mercury", int.Parse(this.txtMercury.Text), int.Parse(this.txtMercury2.Text));
                       IEnumerable<Planet> arg_3DB_0 = this.l.Planets;
                       Func<Planet, bool> arg_3DB_1;
                       if ((arg_3DB_1 = Form1.<> c.<> 9__12_6) == null)
                       {
                           arg_3DB_1 = (Form1.<> c.<> 9__12_6 = new Func<Planet, bool>(Form1.<> c.<> 9.< txtSun_TextChanged > b__12_6));
                       }
                       this.FillBoxes(arg_3DB_0.Where(arg_3DB_1).FirstOrDefault<Planet>());
                   }
               }
               this.CalculateLongevity();
           }*/

        /* private void FillBoxes(Planet p)
         {
             string text = string.Format("{0} years {1} months {2} days", p.Years, p.Months, p.Days);
             string planetName = p.PlanetName;
             uint num = < PrivateImplementationDetails >< LongevityWin.exe >.ComputeStringHash(planetName);
             if (num <= 1180344712u)
             {
                 if (num != 921805286u)
                 {
                     if (num != 1121507073u)
                     {
                         if (num != 1180344712u)
                         {
                             return;
                         }
                         if (!(planetName == "Mars"))
                         {
                             return;
                         }
                         this.MarsDuration.Text = text;
                         this.txtMarsHalf.Text = p.DurationToString(p.HalfPlanetDuration());
                         this.txtMarsDouble.Text = p.DurationToString(p.AddPlanetDuration(2));
                         this.txtMarsTriple.Text = p.DurationToString(p.AddPlanetDuration(3));
                         this.txtMarsTwoThird.Text = p.DurationToString(p.TwoThirdPlanetDuration());
                         return;
                     }
                     else
                     {
                         if (!(planetName == "Sun"))
                         {
                             return;
                         }
                         this.SunDuration.Text = text;
                         this.txtSunHalf.Text = p.DurationToString(p.HalfPlanetDuration());
                         this.txtSunDouble.Text = p.DurationToString(p.AddPlanetDuration(2));
                         this.txtSunTriple.Text = p.DurationToString(p.AddPlanetDuration(3));
                         this.txtSunTwoThird.Text = p.DurationToString(p.TwoThirdPlanetDuration());
                         return;
                     }
                 }
                 else
                 {
                     if (!(planetName == "Jupiter"))
                     {
                         return;
                     }
                     this.JupiterDuration.Text = text;
                     this.txtJupiterHalf.Text = p.DurationToString(p.HalfPlanetDuration());
                     this.txtJupiterDouble.Text = p.DurationToString(p.AddPlanetDuration(2));
                     this.txtJupiterTriple.Text = p.DurationToString(p.AddPlanetDuration(3));
                     this.txtJupiterTwoThird.Text = p.DurationToString(p.TwoThirdPlanetDuration());
                     return;
                 }
             }
             else if (num <= 1482966368u)
             {
                 if (num != 1196921158u)
                 {
                     if (num != 1482966368u)
                     {
                         return;
                     }
                     if (!(planetName == "Moon"))
                     {
                         return;
                     }
                     this.MoonDuration.Text = text;
                     this.txtMoonHalf.Text = p.DurationToString(p.HalfPlanetDuration());
                     this.txtMoonDouble.Text = p.DurationToString(p.AddPlanetDuration(2));
                     this.txtMoonTriple.Text = p.DurationToString(p.AddPlanetDuration(3));
                     this.txtMoonTwoThird.Text = p.DurationToString(p.TwoThirdPlanetDuration());
                     return;
                 }
                 else
                 {
                     if (!(planetName == "Venus"))
                     {
                         return;
                     }
                     this.VenusDuration.Text = text;
                     this.txtVenusHalf.Text = p.DurationToString(p.HalfPlanetDuration());
                     this.txtVenusDouble.Text = p.DurationToString(p.AddPlanetDuration(2));
                     this.txtVenusTriple.Text = p.DurationToString(p.AddPlanetDuration(3));
                     this.txtVenusTwoThird.Text = p.DurationToString(p.TwoThirdPlanetDuration());
                     return;
                 }
             }
             else if (num != 2296796206u)
             {
                 if (num != 2677462550u)
                 {
                     return;
                 }
                 if (!(planetName == "Saturn"))
                 {
                     return;
                 }
                 this.SaturnDuration.Text = text;
                 this.txtSaturnHalf.Text = p.DurationToString(p.HalfPlanetDuration());
                 this.txtSaturnDouble.Text = p.DurationToString(p.AddPlanetDuration(2));
                 this.txtSaturnTriple.Text = p.DurationToString(p.AddPlanetDuration(3));
                 this.txtSaturnTwoThird.Text = p.DurationToString(p.TwoThirdPlanetDuration());
                 return;
             }
             else
             {
                 if (!(planetName == "Mercury"))
                 {
                     return;
                 }
                 this.MercuryDuration.Text = text;
                 this.txtMercuryHalf.Text = p.DurationToString(p.HalfPlanetDuration());
                 this.txtMercuryDouble.Text = p.DurationToString(p.AddPlanetDuration(2));
                 this.txtMercuryTriple.Text = p.DurationToString(p.AddPlanetDuration(3));
                 this.txtMercuryTwoThird.Text = p.DurationToString(p.TwoThirdPlanetDuration());
                 return;
             }
         }
         private bool Valid(string number)
         {
             if (!string.IsNullOrEmpty(number))
             {
                 int num = 0;
                 return int.TryParse(number, out num);
             }
             return false;
         }
         private void CalculateLongevity()
         {
             TimeSpan timeSpan = default(TimeSpan);
             TimeSpan timeSpan2 = default(TimeSpan);
             TimeSpan timeSpan3 = default(TimeSpan);
             TimeSpan timeSpan4 = default(TimeSpan);
             TimeSpan timeSpan5 = default(TimeSpan);
             TimeSpan timeSpan6 = default(TimeSpan);
             TimeSpan ts = default(TimeSpan);
             foreach (Control control in this.durations.Controls)
             {
                 if (control is CheckBox)
                 {
                     CheckBox checkBox = control as CheckBox;
                     if (checkBox.Checked)
                     {
                         if (checkBox.Name.Contains("Sun"))
                         {
                             timeSpan = this.GetPlanetDurationSelection("Sun", checkBox.Name);
                         }
                         if (checkBox.Name.Contains("Moon"))
                         {
                             timeSpan2 = this.GetPlanetDurationSelection("Moon", checkBox.Name);
                         }
                         if (checkBox.Name.Contains("Mars"))
                         {
                             timeSpan3 = this.GetPlanetDurationSelection("Mars", checkBox.Name);
                         }
                         if (checkBox.Name.Contains("Mercury"))
                         {
                             timeSpan4 = this.GetPlanetDurationSelection("Mercury", checkBox.Name);
                         }
                         if (checkBox.Name.Contains("Jupiter"))
                         {
                             timeSpan5 = this.GetPlanetDurationSelection("Jupiter", checkBox.Name);
                         }
                         if (checkBox.Name.Contains("Venus"))
                         {
                             timeSpan6 = this.GetPlanetDurationSelection("Venus", checkBox.Name);
                         }
                         if (checkBox.Name.Contains("Saturn"))
                         {
                             ts = this.GetPlanetDurationSelection("Saturn", checkBox.Name);
                         }
                     }
                 }
             }
             TimeSpan ts2 = timeSpan.Add(timeSpan2.Add(timeSpan3.Add(timeSpan4.Add(timeSpan5.Add(timeSpan6.Add(ts))))));
             this.lblTotalLongevity.Text = this.l.DurationToString(ts2);
         }*/
    }
}
