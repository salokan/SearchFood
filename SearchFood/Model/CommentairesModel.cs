using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchFood.Model
{
    public class CommentairesModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _commentaire;
        public string Commentaire
        {
            get
            {
                return _commentaire;
            }

            set
            {
                if (_commentaire != value)
                {
                    _commentaire = value;
                    OnPropertyChanged("Commentaire");
                }
            }
        }

        private string _utilisateur;
        public string Utilisateur
        {
            get
            {
                return _utilisateur;
            }

            set
            {
                if (_utilisateur != value)
                {
                    _utilisateur = value;
                    OnPropertyChanged("Utilisateur");
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
