using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SearchFood.SearchFoodServiceReference;

namespace SearchFood.Webservices
{
    public class CategoriesCad
    {
        SearchFoodServiceClient _client;

        public CategoriesCad(SearchFoodServiceClient client)
        {
            _client = client;
        }

        public async Task<ObservableCollection<Categorie>> GetCategories()
        {
            return await _client.GetCategoriesAsync();           
        }

        public async Task<Categorie> GetCategorie(int id)
        {
            return await _client.GetCategorieAsync(id);    
        }

        public async void AddCategories(Categorie c)
        {
            await _client.AddCategoriesAsync(c);
        }

        public async void DeleteCategories(int id)
        {
            await _client.DeleteCategoriesAsync(id);
        }

        public async void UpdateCategories(Categorie c)
        {
            await _client.UpdateCategoriesAsync(c);
        }
    }
}
