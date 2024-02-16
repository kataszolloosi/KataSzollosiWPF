using KataSzöllösiWPF.Models;
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
using System.Windows.Shapes;

namespace KataSzöllösiWPF
{
    /// <summary>
    /// Interaction logic for AddNewSuperheroWindow.xaml
    /// </summary>
    public partial class AddNewSuperheroWindow : Window
    {
        SuperheroViewModel svm = new SuperheroViewModel();
        public AddNewSuperheroWindow()
        {
            InitializeComponent();    
        }

        Superhero newhero = new Superhero();
        void BlackPanther_Click(object sender, RoutedEventArgs e)
        {
            //Superhero newhero = new Superhero();
            newhero.Name = "Black Panther";
            newhero.PowerLevel = 175;
            newhero.IsHuman = false;
            newhero.FirstAppearance = new DateTime(1968, 7, 27);
            newhero.Bild = "blackpanther.jpg";

            svm = this.DataContext as SuperheroViewModel;
            svm.AddSuperhero(newhero);
            this.Close();
        }

        private void Spiderman_Click(object sender, RoutedEventArgs e)
        {
            newhero.Name = "Spiderman";
            newhero.PowerLevel = 155;
            newhero.IsHuman = true;
            newhero.FirstAppearance = new DateTime(1988, 7, 22);
            newhero.Bild = "spiderman.jpg";

            svm = this.DataContext as SuperheroViewModel;
            svm.AddSuperhero(newhero);
            this.Close();
        }

        private void Groot_Click(object sender, RoutedEventArgs e)
        {
            newhero.Name = "Groot";
            newhero.PowerLevel = 225;
            newhero.IsHuman = false;
            newhero.FirstAppearance = new DateTime(1958, 5, 22);
            newhero.Bild = "groot.jpg";

            svm = this.DataContext as SuperheroViewModel;
            svm.AddSuperhero(newhero);
            this.Close();
        }

        private void Hawkeye_Click(object sender, RoutedEventArgs e)
        {
            newhero.Name = "Hawkeye";
            newhero.PowerLevel = 145;
            newhero.IsHuman = true;
            newhero.FirstAppearance = new DateTime(1965, 9, 22);
            newhero.Bild = "Hawkeye.jpg";

            svm = this.DataContext as SuperheroViewModel;
            svm.AddSuperhero(newhero);
            this.Close();
        }

        private void Loki_Click(object sender, RoutedEventArgs e)
        {
            newhero.Name = "Loki";
            newhero.PowerLevel = 255;
            newhero.IsHuman = false;
            newhero.FirstAppearance = new DateTime(1963, 11, 11);
            newhero.Bild = "loki.jpg";

            svm = this.DataContext as SuperheroViewModel;
            svm.AddSuperhero(newhero);
            this.Close();
        }

        private void Blackwidow_Click(object sender, RoutedEventArgs e)
        {
            newhero.Name = "Black Widow";
            newhero.PowerLevel = 135;
            newhero.IsHuman = true;
            newhero.FirstAppearance = new DateTime(1968, 12, 28);
            newhero.Bild = "blackwidow.jpg";

            svm = this.DataContext as SuperheroViewModel;
            svm.AddSuperhero(newhero);
            this.Close();
        }
    }
}
