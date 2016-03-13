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
    /// Interaction logic for PlanetDegreesMinutesTextBoxControl.xaml
    /// </summary>
    public partial class PlanetDegreesMinutesTextBoxControl : UserControl
    {
        public delegate void DegreesMinutesLostFocusEventHandler(object sender, EventArgs e);
        public event EventHandler DegreesMinutesLostFocus;
        private List<string> durationTypes = new List<string>();
        private Planet planet = null;

        public PlanetDegreesMinutesTextBoxControl()
        {
            InitializeComponent();
            //Degree.TextChanged += Degree_TextChanged;
            txtDegree.LostFocus += Degree_LostFocus;
            txtMinutes.LostFocus += Degree_LostFocus;

            durationTypes.Add("Full");
            durationTypes.Add("Half");
            durationTypes.Add("Double");
            durationTypes.Add("Triple");
            durationTypes.Add("One third");

            lstDurationType.ItemsSource = durationTypes;
            lstDurationType.SelectedIndex = 0;

            planet = new Planet(PlanetName);

        }

        private void Degree_LostFocus(object sender, RoutedEventArgs e)
        {
           
           
            if (Valid(txtDegree.Text))
            {
                planet.Degrees = int.Parse(txtDegree.Text);
            }

            if (Valid(txtMinutes.Text))
            {
                planet.DegreeMinutes = int.Parse(txtMinutes.Text);
            }

            planet.CalculateDuration();


            if (lstDurationType.SelectedValue.ToString() == "Full") { 

            this.Duration.Text = planet.DurationToString();
            }

            if (lstDurationType.SelectedValue.ToString() == "Half") { 
            this.Duration.Text = planet.DurationToString(planet.HalfPlanetDuration());
            }
            if(lstDurationType.SelectedValue.ToString() == "Double")
            this.Duration.Text = planet.DurationToString(planet.AddPlanetDuration(2));

            if (lstDurationType.SelectedValue.ToString() == "Triple")
                this.Duration.Text = planet.DurationToString(planet.AddPlanetDuration(3));

            if (lstDurationType.SelectedValue.ToString() == "One third")
                this.Duration.Text = planet.DurationToString(planet.TwoThirdPlanetDuration());
            

            if (DegreesMinutesLostFocus != null)
            {
                DegreesMinutesLostFocus(this, e);
            }
        }

        public string PlanetName
        {
            get
            {
                return txtPlanetName.Text;
            }

            set
            {
                txtPlanetName.Text = value;
            }
        }

        public Planet Planet
        {
            get
            {
                return planet;
            }

            set
            {
                planet = value;
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
    }
}
