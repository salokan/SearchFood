using SearchFood.SearchFoodServiceReference;

namespace SearchFood.Webservices
{
    public class Services
    {
        SearchFoodServiceClient _client;

        public CategoriesCad _categories { get; set; }

        public Services()
        {     
            InitWebservices();
        }

        public void InitWebservices()
        {
            _client = new SearchFoodServiceClient();

            _categories = new CategoriesCad(_client);
        }
    }
}
