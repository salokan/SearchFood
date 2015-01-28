using System.Collections.Generic;

namespace SearchFoodServer.CAD
{
    public class RestaurantsCad
    {
        public List<int> GetRestaurants()
        {
            //var requete = from restaurants in bdd.Restaurants
            //              select restaurants;

            return new List<int>();
        }

        public int GetRestaurant(int id)
        {
            //var requete = from restaurants in bdd.Restaurants
            //              where restaurants.Id == id
            //              select restaurants;
            return 0;
        }

        public void AddRestaurants()
        {
            //using (Restaurants bdd = new Restaurants())
            //{
            //    EditeurInformatique OReilly = new EditeurInformatique()
            //    {
            //        Id = "OReilly",
            //        NombreLivresInfoEdites = 1800
            //    };

            //    bdd.AddToEditeur(OReilly);
            //    bdd.SaveChanges();
            //}
        }

        public void DeleteRestaurants()
        {
            //using (Modele bdd = new Modele())
            //{
            //    var requete = from c in bdd.Client
            //                  where c.Nom == "Oliver"
            //                  select c;

            //    var client = requete.FirstOrDefault();

            //    if (client != null)
            //    {
            //        bdd.DeleteObject(client);
            //        bdd.SaveChanges();
            //    }
            //}
        }

        public void UpdateRestaurants()
        {
            //using (Modele bdd = new Modele())
            //{
            //    Client client = (from c in bdd.Client
            //                     where c.Nom == "Oliver"
            //                     select c).FirstOrDefault();
            //    if (client != null)
            //    {
            //        client.Ville = "Bruxelles";
            //        client.Pays = "Belgique";
            //        bdd.SaveChanges();
            //    }
            //}
        }
    }
}