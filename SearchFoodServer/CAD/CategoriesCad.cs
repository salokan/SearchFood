using System.Collections.Generic;
using System.Linq;

namespace SearchFoodServer.CAD
{
    public class CategoriesCad
    {
        public List<Categorie> GetCategories()
        {
            List<Categorie> categories;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from c in bdd.Categorie
                    select c;

                categories = requete.ToList();
            }
            return categories;
        }

        public Categorie GetCategorie(int id)
        {
            Categorie categorie;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from c in bdd.Categorie where c.Id_Categorie == id
                              select c;

                categorie = requete.FirstOrDefault();
            }

            return categorie;
        }

        public void AddCategories(Categorie c)
        {
            using (var bdd = new searchfoodEntities())
            {
                bdd.Categorie.Add(c);
                bdd.SaveChanges();
            }
        }

        public void DeleteCategories(int id)
        {
            using (var bdd = new searchfoodEntities())
            {
                var requete = from c in bdd.Categorie
                              where c.Id_Categorie == id
                              select c;

                Categorie categorie = requete.FirstOrDefault();

                if (categorie != null)
                {
                    bdd.Categorie.Remove(categorie);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateCategories(Categorie c)
        {
            using (var bdd = new searchfoodEntities())
            {
                Categorie categorie = bdd.Categorie.Find(c.Id_Categorie);

                if (categorie != null)
                {
                    bdd.Entry(categorie).CurrentValues.SetValues(c);
                    bdd.SaveChanges();
                }   
            }
        }
    }
}