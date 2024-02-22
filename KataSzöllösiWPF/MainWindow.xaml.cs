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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KataSzöllösiWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SuperheroViewModel superHeroViewModel = new SuperheroViewModel();
        public MainWindow()
        {
            InitializeComponent();

            Superhero hero1 = new Superhero();
            hero1.Name = "Captain America";
            hero1.PowerLevel = 225;
            hero1.IsHuman = true;
            hero1.FirstAppearance = new DateTime(1941, 3, 1);
            hero1.Bild = "captam.jpg";

            Superhero hero2 = new Superhero();
            hero2.Name = "Thor";
            hero2.PowerLevel = 300;
            hero2.IsHuman = false;
            hero2.FirstAppearance = new DateTime(1962, 8, 1);
            hero2.Bild = "thor.jpg";

            Superhero hero3 = new Superhero();
            hero3.Name = "Iron Man";
            hero3.PowerLevel = 150;
            hero3.IsHuman = true;
            hero3.FirstAppearance = new DateTime(1976, 7, 1);
            hero3.Bild = "ironman.jpg";

            Superhero hero4 = new Superhero();
            hero4.Name = "Hulk";
            hero4.PowerLevel = 500000;
            hero4.IsHuman = true;
            hero4.FirstAppearance = new DateTime(1963, 6, 12);
            hero4.Bild = "hulk.jpg";

            Superhero hero5 = new Superhero();
            hero5.Name = "Supergirl";
            hero5.PowerLevel = 90;
            hero5.IsHuman = false;
            hero5.FirstAppearance = new DateTime(1959, 1, 1);
            hero5.Bild = "supergirl.jpg";

            //superHeroViewModel.AddSuperhero(hero1);
            //superHeroViewModel.AddSuperhero(hero2);
            //superHeroViewModel.AddSuperhero(hero3);
            //superHeroViewModel.AddSuperhero(hero4);
            //superHeroViewModel.AddSuperhero(hero5);
            this.DataContext = superHeroViewModel;
        }

        private void AddNewSuperhero_Click(object sender, RoutedEventArgs e)
        {
            AddNewSuperheroWindow addNewSuperheroWindow = new AddNewSuperheroWindow();
            //SuperheroViewModel svm = new SuperheroViewModel();
            addNewSuperheroWindow.DataContext = this.DataContext;
            addNewSuperheroWindow.ShowDialog();
        }

        private void RemoveSuperhero_Click(object sender, RoutedEventArgs e)
        {
            superHeroViewModel.RemoveSuperhero(superHeroViewModel.SelectedSuperhero);
        }

        private void OpenSuchWindow_Click(object sender, RoutedEventArgs e)
        {
            SuchWindow suche = new SuchWindow();
            superHeroViewModel.SearchString = "";
            suche.DataContext = superHeroViewModel;
            superHeroViewModel.SearchResult = new System.Collections.ObjectModel.ObservableCollection<Superhero>();

            suche.Show();
        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            // Überprüfen, ob ein Produkt ausgewählt wurde
            if (superHeroViewModel.SelectedSuperhero != null)
            {
                // Erstellen einer Kopie des ausgewählten Produkts
                Superhero copiedSuperhero = new Superhero()
                {
                    Name = superHeroViewModel.SelectedSuperhero.Name,
                    PowerLevel = superHeroViewModel.SelectedSuperhero.PowerLevel,
                    IsHuman = superHeroViewModel.SelectedSuperhero.IsHuman,
                    FirstAppearance = superHeroViewModel.SelectedSuperhero.FirstAppearance,
                    Bild = superHeroViewModel.SelectedSuperhero.Bild
                };

                // Füge die Kopie zum ObservableCollection hinzu
                superHeroViewModel.AddSuperhero(copiedSuperhero);
            }
        }
    }
}
