using System.Collections.Generic;
using System.Linq;

namespace SearchFoodServer.CAD
{
    public class TypesCuisineCad
    {
        public List<Type_Cuisine> GetTypesCuisine()
        {
            List<Type_Cuisine> typesCuisine;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from tc in bdd.Type_Cuisine
                              select tc;

                typesCuisine = requete.ToList();
            }
            return typesCuisine;
        }

        public Type_Cuisine GetTypeCuisine(int id)
        {
            Type_Cuisine typesCuisine;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from tc in bdd.Type_Cuisine
                              where tc.Id_Type_Cuisine == id
                              select tc;

                typesCuisine = requete.FirstOrDefault();
            }

            return typesCuisine;
        }

        public void AddTypesCuisine(Type_Cuisine tc)
        {
            using (var bdd = new searchfoodEntities())
            {
                bdd.Type_Cuisine.Add(tc);
                bdd.SaveChanges();
            }
        }

        public void DeleteTypesCuisine(int id)
        {
            using (var bdd = new searchfoodEntities())
            {
                var requete = from tc in bdd.Type_Cuisine
                              where tc.Id_Type_Cuisine == id
                              select tc;

                Type_Cuisine typesCuisine = requete.FirstOrDefault();

                if (typesCuisine != null)
                {
                    bdd.Type_Cuisine.Remove(typesCuisine);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateTypesCuisine(Type_Cuisine tc)
        {
            using (var bdd = new searchfoodEntities())
            {
                Type_Cuisine typesCuisine = bdd.Type_Cuisine.Find(tc.Id_Type_Cuisine);

                if (typesCuisine != null)
                {
                    bdd.Entry(typesCuisine).CurrentValues.SetValues(tc);
                    bdd.SaveChanges();
                }
            }
        }
    }
}