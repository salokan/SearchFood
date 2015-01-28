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

        public async Task<string> GetCategories()
        {
            return await _client.GetCategoriesAsync();           
        }

        public async Task<int> GetCategorie(int id)
        {
            return await _client.GetCategorieAsync(id);    
        }

        public async void AddCategories()
        {
            await _client.AddCategoriesAsync();
        }

        public async void DeleteCategories()
        {
            await _client.DeleteCategoriesAsync();
        }

        public async void UpdateCategories()
        {
            await _client.UpdateCategoriesAsync();
        }
    }
}
