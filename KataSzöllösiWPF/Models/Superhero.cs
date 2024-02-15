using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataSzöllösiWPF.Models
{
    internal class Superhero :INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyGui(string propname)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }


        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private double _powerLevel;
        public double PowerLevel
        {
            get { return _powerLevel; }
            set { _powerLevel = value; }
        }

        private bool _isHuman;
        public bool IsHuman
        {
            get { return _isHuman; }
            set { _isHuman = value; }
        }

        private DateTime _firstAppearance;
        public DateTime FirstAppearance
        {
            get { return _firstAppearance; }
            set { _firstAppearance = value; }
        }

        private string _bild;
        public string Bild
        {
            get { return _bild; }
            set
            {
                _bild = value;
            }
        }
    }
}
