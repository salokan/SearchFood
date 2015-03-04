using System.Collections.Generic;
using System.Linq;
using SearchFoodServer.CompositeClass;

namespace SearchFoodServer.CAD
{
    public class RestaurantsCad
    {
        public List<CompositeRestaurants> GetRestaurants()
        {
            List<CompositeRestaurants> restaurantsList = new List<CompositeRestaurants>();

            List<Restaurant> restaurant;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from r in bdd.Restaurant
                              select r;

                restaurant = requete.ToList();
            }


            if (restaurant.Count > 0)
            {
                foreach (Restaurant r in restaurant)
                {
                    CompositeRestaurants composite = new CompositeRestaurants();
                    composite.IdRestaurantsValue = r.Id_Restaurant;
                    composite.NomRestaurantsValue = r.Nom;
                    composite.SitesWebValue = r.Site_Web;
                    composite.MailValue = r.Mail;
                    composite.AdresseValue = r.Adresse;
                    composite.CodePostalValue = r.Code_Postal;
                    composite.VilleValue = r.Ville;
                    composite.TelephoneValue = r.Telephone;
                    composite.LatitudeValue = r.Latitude;
                    composite.LongitudeValue = r.Longitude;
                    composite.DureeRepasValue = r.Duree_repas;
                    composite.PrixValue = r.Prix;
                    composite.IdCategoriesValue = r.Id_Categorie;
                    composite.IdTypesCuisineValue = r.Id_Type_Cuisine;
                    restaurantsList.Add(composite);
                }
            }

            return restaurantsList;
        }

        public CompositeRestaurants GetRestaurant(int id)
        {
            CompositeRestaurants compositeRestaurants = new CompositeRestaurants();
            Restaurant restaurant;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from r in bdd.Restaurant
                              where r.Id_Restaurant == id
                              select r;

                restaurant = requete.FirstOrDefault();
            }

            if (restaurant != null)
            {
                compositeRestaurants.IdRestaurantsValue = restaurant.Id_Restaurant;
                compositeRestaurants.NomRestaurantsValue = restaurant.Nom;
                compositeRestaurants.SitesWebValue = restaurant.Site_Web;
                compositeRestaurants.MailValue = restaurant.Mail;
                compositeRestaurants.AdresseValue = restaurant.Adresse;
                compositeRestaurants.CodePostalValue = restaurant.Code_Postal;
                compositeRestaurants.VilleValue = restaurant.Ville;
                compositeRestaurants.TelephoneValue = restaurant.Telephone;
                compositeRestaurants.LatitudeValue = restaurant.Latitude;
                compositeRestaurants.LongitudeValue = restaurant.Longitude;
                compositeRestaurants.DureeRepasValue = restaurant.Duree_repas;
                compositeRestaurants.PrixValue = restaurant.Prix;
                compositeRestaurants.IdCategoriesValue = restaurant.Id_Categorie;
                compositeRestaurants.IdTypesCuisineValue = restaurant.Id_Type_Cuisine;
            }

            return compositeRestaurants;
        }

        public void AddRestaurants(Restaurant r)
        {
            using (var bdd = new searchfoodEntities())
            {
                bdd.Restaurant.Add(r);
                bdd.SaveChanges();
            }
        }

        public void DeleteRestaurants(int id)
        {
            using (var bdd = new searchfoodEntities())
            {
                var requete = from r in bdd.Restaurant
                              where r.Id_Restaurant == id
                              select r;

                Restaurant restaurant = requete.FirstOrDefault();

                if (restaurant != null)
                {
                    bdd.Restaurant.Remove(restaurant);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateRestaurants(Restaurant r)
        {
            using (var bdd = new searchfoodEntities())
            {
                Restaurant restaurant = bdd.Restaurant.Find(r.Id_Restaurant);

                if (restaurant != null)
                {
                    bdd.Entry(restaurant).CurrentValues.SetValues(r);
                    bdd.SaveChanges();
                }
            }
        }
    }
}