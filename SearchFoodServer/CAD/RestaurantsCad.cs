using System.Collections.Generic;
using System.Linq;

namespace SearchFoodServer.CAD
{
    public class RestaurantsCad
    {
        public List<Restaurant> GetRestaurants()
        {
            List<Restaurant> restaurant;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from r in bdd.Restaurant
                              select r;

                restaurant = requete.ToList();
            }
            return restaurant;
        }

        public Restaurant GetRestaurant(int id)
        {
            Restaurant restaurant;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from r in bdd.Restaurant
                              where r.Id_Restaurant == id
                              select r;

                restaurant = requete.FirstOrDefault();
            }

            return restaurant;
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