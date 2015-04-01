using System.ComponentModel;

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
