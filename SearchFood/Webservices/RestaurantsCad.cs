using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SearchFood.SearchFoodServiceReference;

namespace SearchFood.Webservices
{
    public class RestaurantsCad
    {
        SearchFoodServiceClient _client;

        public RestaurantsCad(SearchFoodServiceClient client)
        {
            _client = client;
        }

        public async Task<ObservableCollection<Restaurant>> GetRestaurants()
        {
            return await _client.GetRestaurantsAsync();           
        }

        public async Task<Restaurant> GetRestaurants(int id)
        {
            return await _client.GetRestaurantAsync(id);    
        }

        public async void AddRestaurants(Restaurant r)
        {
            await _client.AddRestaurantsAsync(r);
        }

        public async void DeleteRestaurants(int id)
        {
            await _client.DeleteRestaurantsAsync(id);
        }

        public async void UpdateRestaurants(Restaurant r)
        {
            await _client.UpdateRestaurantsAsync(r);
        }
    }
}
