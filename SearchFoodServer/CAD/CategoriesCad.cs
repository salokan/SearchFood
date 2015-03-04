using System.Collections.Generic;
using System.Linq;
using SearchFoodServer.CompositeClass;

namespace SearchFoodServer.CAD
{
    public class CategoriesCad
    {
        public List<CompositeCategories> GetCategories()
        {
            List<CompositeCategories> categoriesList = new List<CompositeCategories>();

            List<Categorie> categories;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from c in bdd.Categorie
                    select c;

                categories = requete.ToList();
            }

            if (categories.Count > 0)
            {
                foreach (Categorie c in categories)
                {
                    CompositeCategories composite = new CompositeCategories();
                    composite.IdCategorieValue = c.Id_Categorie;
                    composite.NomCategorieValue = c.Nom_Categorie;
                    categoriesList.Add(composite);
                }
            }

            return categoriesList;
        }

        public CompositeCategories GetCategorie(int id)
        {
            CompositeCategories compositeCategorie = new CompositeCategories();
            Categorie categorie;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from c in bdd.Categorie where c.Id_Categorie == id
                              select c;

                categorie = requete.FirstOrDefault();
            }

            if (categorie != null)
            {
                compositeCategorie.IdCategorieValue = categorie.Id_Categorie;
                compositeCategorie.NomCategorieValue = categorie.Nom_Categorie;
            }

            return compositeCategorie;
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