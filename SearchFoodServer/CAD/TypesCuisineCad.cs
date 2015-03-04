using System.Collections.Generic;
using System.Linq;
using SearchFoodServer.CompositeClass;

namespace SearchFoodServer.CAD
{
    public class TypesCuisineCad
    {
        public List<CompositeTypesCuisine> GetTypesCuisine()
        {
            List<CompositeTypesCuisine> typesCuisinesList = new List<CompositeTypesCuisine>();

            List<Type_Cuisine> typesCuisine;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from tc in bdd.Type_Cuisine
                              select tc;

                typesCuisine = requete.ToList();
            }


            if (typesCuisine.Count > 0)
            {
                foreach (Type_Cuisine tc in typesCuisine)
                {
                    CompositeTypesCuisine composite = new CompositeTypesCuisine();
                    composite.IdTypesCuisineValue = tc.Id_Type_Cuisine;
                    composite.TypesCuisineValue = tc.Type_Cuisine1;
                    typesCuisinesList.Add(composite);
                }
            }

            return typesCuisinesList;
        }

        public CompositeTypesCuisine GetTypeCuisine(int id)
        {
            CompositeTypesCuisine compositeTypesCuisine = new CompositeTypesCuisine();
            Type_Cuisine typesCuisine;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from tc in bdd.Type_Cuisine
                              where tc.Id_Type_Cuisine == id
                              select tc;

                typesCuisine = requete.FirstOrDefault();
            }

            if (typesCuisine != null)
            {
                compositeTypesCuisine.IdTypesCuisineValue = typesCuisine.Id_Type_Cuisine;
                compositeTypesCuisine.TypesCuisineValue = typesCuisine.Type_Cuisine1;
            }

            return compositeTypesCuisine;
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