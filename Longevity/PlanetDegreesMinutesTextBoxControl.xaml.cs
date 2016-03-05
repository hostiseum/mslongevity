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
        public delegate void DegreesMinutesChangedEventHandler(object sender, EventArgs e);
        public event EventHandler DegreesMinutesChanged;

        public PlanetDegreesMinutesTextBoxControl()
        {
            InitializeComponent();
            Degree.TextChanged += Degree_TextChanged;    
        }

        private void Degree_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(DegreesMinutesChanged != null)
            {
                DegreesMinutesChanged(this, e);
            }
        }
    }
}
