using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SearchFood.SearchFoodServiceReference;

namespace SearchFood.Webservices
{
    public class TypesCuisineCad
    {
        SearchFoodServiceClient _client;

        public TypesCuisineCad(SearchFoodServiceClient client)
        {
            _client = client;
        }

        public async Task<ObservableCollection<Type_Cuisine>> GetTypesCuisines()
        {
            return await _client.GetTypesCuisineAsync();           
        }

        public async Task<Type_Cuisine> GetTypeCuisine(int id)
        {
            return await _client.GetTypeCuisineAsync(id);    
        }

        public async void AddTypesCuisine(Type_Cuisine tc)
        {
            await _client.AddTypesCuisineAsync(tc);
        }

        public async void DeleteTypesCuisine(int id)
        {
            await _client.DeleteTypesCuisineAsync(id);
        }

        public async void UpdateTypesCuisine(Type_Cuisine tc)
        {
            await _client.UpdateTypesCuisineAsync(tc);
        }
    }
}
