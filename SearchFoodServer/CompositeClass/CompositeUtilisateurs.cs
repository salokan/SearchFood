using System.Runtime.Serialization;

namespace SearchFoodServer.CompositeClass
{
    [DataContract]
    public class CompositeUtilisateurs
    {
        int _idUtilisateurs;
        string _pseudo;
        string _password;
        string _mail;
        string _prenom;
        string _nom;

        [DataMember]
        public int IdUtilisateurValue
        {
            get { return _idUtilisateurs; }
            set { _idUtilisateurs = value; }
        }

        [DataMember]
        public string PseudoValue
        {
            get { return _pseudo; }
            set { _pseudo = value; }
        }

        [DataMember]
        public string PasswordValue
        {
            get { return _password; }
            set { _password = value; }
        }

        [DataMember]
        public string MailValue
        {
            get { return _mail; }
            set { _mail = value; }
        }

        [DataMember]
        public string PrenomValue
        {
            get { return _prenom; }
            set { _prenom = value; }
        }

        [DataMember]
        public string NomValue
        {
            get { return _nom; }
            set { _nom = value; }
        }
    }
}