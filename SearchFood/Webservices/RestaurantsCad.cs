using System.Collections.Generic;
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

        public async Task<List<Restaurant>> GetRestaurants()
        {
            ObservableCollection<CompositeRestaurants> restaurantsList;
            List<Restaurant> restaurants = new List<Restaurant>();

            restaurantsList = await _client.GetRestaurantsAsync();

            foreach (CompositeRestaurants r in restaurantsList)
            {
                Restaurant restaurant = new Restaurant();
                restaurant.Id_Restaurant = r.IdRestaurantsValue;
                restaurant.Nom = r.NomRestaurantsValue;
                restaurant.Site_Web = r.SitesWebValue;
                restaurant.Mail = r.MailValue;
                restaurant.Adresse = r.AdresseValue;
                restaurant.Code_Postal = r.CodePostalValue;
                restaurant.Ville = r.VilleValue;
                restaurant.Telephone = r.TelephoneValue;
                restaurant.Latitude = r.LatitudeValue;
                restaurant.Longitude = r.LongitudeValue;
                restaurant.Duree_repas = r.DureeRepasValue;
                restaurant.Prix = r.PrixValue;
                restaurant.Id_Categorie = r.IdCategoriesValue;
                restaurant.Id_Type_Cuisine = r.IdTypesCuisineValue;

                restaurants.Add(restaurant);
            }

            return restaurants;           
        }

        public async Task<Restaurant> GetRestaurants(int id)
        {
            Restaurant restaurant = new Restaurant();

            CompositeRestaurants restaurantsComposite = await _client.GetRestaurantAsync(id);

            restaurant.Id_Restaurant = restaurantsComposite.IdRestaurantsValue;
            restaurant.Nom = restaurantsComposite.NomRestaurantsValue;
            restaurant.Site_Web = restaurantsComposite.SitesWebValue;
            restaurant.Mail = restaurantsComposite.MailValue;
            restaurant.Adresse = restaurantsComposite.AdresseValue;
            restaurant.Code_Postal = restaurantsComposite.CodePostalValue;
            restaurant.Ville = restaurantsComposite.VilleValue;
            restaurant.Telephone = restaurantsComposite.TelephoneValue;
            restaurant.Latitude = restaurantsComposite.LatitudeValue;
            restaurant.Longitude = restaurantsComposite.LongitudeValue;
            restaurant.Duree_repas = restaurantsComposite.DureeRepasValue;
            restaurant.Prix = restaurantsComposite.PrixValue;
            restaurant.Id_Categorie = restaurantsComposite.IdCategoriesValue;
            restaurant.Id_Type_Cuisine = restaurantsComposite.IdTypesCuisineValue;

            return restaurant;   
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
