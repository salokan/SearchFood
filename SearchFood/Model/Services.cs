using SearchFood.SearchFoodServiceReference;
using SearchFood.Webservices;

namespace SearchFood.Model
{
    public class Services
    {
        SearchFoodServiceClient _client;

        public CategoriesCad _categories { get; set; }
        public CommentairesCad _commentaires { get; set; }
        public CommentairesCad _historique { get; set; }
        public CommentairesCad _notes { get; set; }
        public CommentairesCad _restaurants { get; set; }
        public CommentairesCad _typesCuisines { get; set; }
        public CommentairesCad _utilisateurs { get; set; }

        public Services()
        {     
            InitWebservices();
        }

        public void InitWebservices()
        {
            _client = new SearchFoodServiceClient();

            _categories = new CategoriesCad(_client);

            _commentaires = new CommentairesCad(_client);

            _historique = new CommentairesCad(_client);

            _notes = new CommentairesCad(_client);

            _restaurants = new CommentairesCad(_client);

            _typesCuisines = new CommentairesCad(_client);

            _utilisateurs = new CommentairesCad(_client);
        }
    }
}
