using System.Runtime.Serialization;

namespace SearchFoodServer.CompositeClass
{
    [DataContract]
    public class CompositeCommentaires
    {
        int _idCommentaires;
        int _idRestaurants;
        int _idUtilisateurs;
        string _commentaires;

        [DataMember]
        public int IdCommentairesValue
        {
            get { return _idCommentaires; }
            set { _idCommentaires = value; }
        }

        [DataMember]
        public int IdRestaurantsValue
        {
            get { return _idRestaurants; }
            set { _idRestaurants = value; }
        }

        [DataMember]
        public int IdUtilisateursValue
        {
            get { return _idUtilisateurs; }
            set { _idUtilisateurs = value; }
        }

        [DataMember]
        public string CommentairesValue
        {
            get { return _commentaires; }
            set { _commentaires = value; }
        }
    }
}