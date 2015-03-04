using SearchFood.SearchFoodServiceReference;
using SearchFood.Webservices;

namespace SearchFood.Model
{
    public class Services
    {
        SearchFoodServiceClient _client;

        public CategoriesCad _categories { get; set; }
        public CommentairesCad _commentaires { get; set; }
        public HistoriqueCad _historique { get; set; }
        public NotesCad _notes { get; set; }
        public RestaurantsCad _restaurants { get; set; }
        public TypesCuisineCad _typesCuisines { get; set; }
        public UtilisateursCad _utilisateurs { get; set; }

        public Services()
        {     
            InitWebservices();
        }

        public void InitWebservices()
        {
            _client = new SearchFoodServiceClient();

            _categories = new CategoriesCad(_client);

            _commentaires = new CommentairesCad(_client);

            _historique = new HistoriqueCad(_client);

            _notes = new NotesCad(_client);

            _restaurants = new RestaurantsCad(_client);

            _typesCuisines = new TypesCuisineCad(_client);

            _utilisateurs = new UtilisateursCad(_client);
        }
    }
}
