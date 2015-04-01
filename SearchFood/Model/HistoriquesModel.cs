using System.ComponentModel;

namespace SearchFood.Model
{
    public class HistoriquesModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _nomRestaurant;
        public string NomRestaurant
        {
            get
            {
                return _nomRestaurant;
            }

            set
            {
                if (_nomRestaurant != value)
                {
                    _nomRestaurant = value;
                    OnPropertyChanged("NomRestaurant");
                }
            }
        }

        private string _date;
        public string Date
        {
            get
            {
                return _date;
            }

            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        private string _typeCuisine;
        public string TypeCuisine
        {
            get
            {
                return _typeCuisine;
            }

            set
            {
                if (_typeCuisine != value)
                {
                    _typeCuisine = value;
                    OnPropertyChanged("TypeCuisine");
                }
            }
        }

        private string _categorie;
        public string Categorie
        {
            get
            {
                return _categorie;
            }

            set
            {
                if (_categorie != value)
                {
                    _categorie = value;
                    OnPropertyChanged("Categorie");
                }
            }
        }

        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
