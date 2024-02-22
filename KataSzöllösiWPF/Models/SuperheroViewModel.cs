using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataSzöllösiWPF.Models
{
    internal class SuperheroViewModel : INotifyPropertyChanged
    {
        private SuperheroDBContext2 dbContext2 = new SuperheroDBContext2();    
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyGui(string propname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }

        public ObservableCollection<Superhero> ObsSuperheroes { get; set; } 

        public SuperheroViewModel() 
        {
            ObsSuperheroes = new ObservableCollection<Superhero>();
            var mySuperheroesLocalFromDb = dbContext2.Superheroes.ToList();
            foreach (var superero in mySuperheroesLocalFromDb)
            {
                ObsSuperheroes.Add(superero);
            }
            SearchResult = new ObservableCollection<Superhero>();
            ChangeStatusText();
        }

        public int AddSuperhero(Superhero newSuperhero)
        {
            dbContext2.Superheroes.Add(newSuperhero);
            ObsSuperheroes.Add(newSuperhero);
            dbContext2.SaveChanges();
            ChangeStatusText();
            StatusText2 = newSuperhero.Name + " Welcome our crew";
            NotifyGui("StatusText2");
            return newSuperhero.Id;
        }

        internal void RemoveSuperhero(Superhero selectedSuperhero)
        {
            ObsSuperheroes.Remove(selectedSuperhero);
            dbContext2.Superheroes.Remove(selectedSuperhero);
            ChangeStatusText();
            StatusText3 = selectedSuperhero.Name + " sorry, you are not sufficient...";
            NotifyGui("StatusText3");
            dbContext2.SaveChanges();
        }

        public string StatusText { get; set; }
        public string StatusText2 { get; set; }
        public string StatusText3 { get; set; }
        private void ChangeStatusText()
        {
            StatusText = "Momentan sind " + dbContext2.Superheroes.ToList().Count.ToString() + " Superhero in DB";
            NotifyGui("StatusText");
        }

        private Superhero _selectedSuperhero;

        public Superhero SelectedSuperhero
        {
            get { return _selectedSuperhero; }
            set { _selectedSuperhero = value;
                NotifyGui("SelectedSuperhero");
            }
        }

        private Superhero _newSuperhero;

        public Superhero NewSuperhero
        {
            get { return _newSuperhero; }
            set { _newSuperhero = value;
                NotifyGui("NewSuperhero");
            }
        }

        public ObservableCollection<Superhero> SearchResult { get; set; }

        private string _searchString;

        public string SearchString
        {
            get { return _searchString; }
            set { _searchString = value.ToLower();
                SearchResult.Clear();
                foreach (var item in ObsSuperheroes)
                {
                    if (item.Name.ToLower().Contains(_searchString))
                    {
                        SearchResult.Add(item);
                    }
                }
            }
        }


        private int _selectedSuperheroPowerLevel;

        public int SelectedSuperheroPowerLevel
        {
            get { return _selectedSuperheroPowerLevel; }
            set
            {
                _selectedSuperheroPowerLevel = value;
                NotifyGui("SelectedSuperheroPowerLevel");

                if (SelectedSuperhero != null)
                {
                    SelectedSuperhero.PowerLevel = value;
                }
                
            }
        }
    }
}
