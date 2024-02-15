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
        private SuperheroDBContext dbContext = new SuperheroDBContext();    
        
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
            var mySuperheroesLocalFromDb = dbContext.Superheroes.ToList();
            foreach (var superero in mySuperheroesLocalFromDb)
            {
                ObsSuperheroes.Add(superero);
            }
            SearchResult = new ObservableCollection<Superhero>();
            ChangeStatusText();
        }

        public int AddSuperhero(Superhero newSuperhero)
        {
            dbContext.Superheroes.Add(newSuperhero);
            ObsSuperheroes.Add(newSuperhero);
            dbContext.SaveChanges();
            return newSuperhero.Id;
        }

        internal void RemoveSuperhero(Superhero selectedSuperhero)
        {
            ObsSuperheroes.Remove(selectedSuperhero);
            dbContext.Superheroes.Remove(selectedSuperhero);
            ChangeStatusText();
            dbContext.SaveChanges();
        }

        public string StatusText { get; set; }
        private void ChangeStatusText()
        {
            StatusText = "Momentan sind " + dbContext.Superheroes.ToList().Count.ToString() + " Superhero in DB";
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
            set { _searchString = value;
                SearchResult.Clear();
                foreach (var item in ObsSuperheroes)
                {
                    if (item.Name.Contains(_searchString))
                    {
                        SearchResult.Add(item);
                    }
                }
            }
        }
    }
}
