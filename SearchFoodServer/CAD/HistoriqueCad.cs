using System.Collections.Generic;
using System.Linq;
using SearchFoodServer.CompositeClass;

namespace SearchFoodServer.CAD
{
    public class HistoriqueCad
    {
        public List<CompositeHistorique> GetHistoriques()
        {
            List<CompositeHistorique> historiqueList = new List<CompositeHistorique>();

            List<Historique> historiques;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from h in bdd.Historique
                              select h;

                historiques = requete.ToList();
            }

            if (historiques.Count > 0)
            {
                foreach (Historique h in historiques)
                {
                    CompositeHistorique composite = new CompositeHistorique();
                    composite.IdHistoriqueValue = h.Id_Historique;
                    composite.IdRestaurantsValue = h.Id_Restaurant;
                    composite.IdUtilisateursValue = h.Id_Utilisateur;
                    composite.DateValue = h.Date;
                    historiqueList.Add(composite);
                }
            }

            return historiqueList;
        }

        public CompositeHistorique GetHistorique(int id)
        {
            CompositeHistorique compositeHistorique = new CompositeHistorique();
            Historique historique;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from h in bdd.Historique
                              where h.Id_Historique == id
                              select h;

                historique = requete.FirstOrDefault();
            }

            if (historique != null)
            {
                compositeHistorique.IdHistoriqueValue = historique.Id_Historique;
                compositeHistorique.IdRestaurantsValue = historique.Id_Restaurant;
                compositeHistorique.IdUtilisateursValue = historique.Id_Utilisateur;
                compositeHistorique.DateValue = historique.Date;
            }

            return compositeHistorique;
        }

        public List<CompositeHistorique> GetHistoriqueByUser(int idUser)
        {
            List<CompositeHistorique> historiqueList = new List<CompositeHistorique>();
            List<Historique> historiques;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from h in bdd.Historique
                              where h.Id_Utilisateur == idUser
                              select h;

                historiques = requete.ToList();
            }

            if (historiques.Count > 0)
            {
                foreach (Historique h in historiques)
                {
                    CompositeHistorique composite = new CompositeHistorique();
                    composite.IdHistoriqueValue = h.Id_Historique;
                    composite.IdRestaurantsValue = h.Id_Restaurant;
                    composite.IdUtilisateursValue = h.Id_Utilisateur;
                    composite.DateValue = h.Date;
                    historiqueList.Add(composite);
                }
            }

            return historiqueList;
        }

        public void AddHistorique(Historique h)
        {
            using (var bdd = new searchfoodEntities())
            {
                bdd.Historique.Add(h);
                bdd.SaveChanges();
            }
        }

        public void DeleteHistorique(int id)
        {
            using (var bdd = new searchfoodEntities())
            {
                var requete = from h in bdd.Historique
                              where h.Id_Historique == id
                              select h;

                Historique historique = requete.FirstOrDefault();

                if (historique != null)
                {
                    bdd.Historique.Remove(historique);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateHistorique(Historique h)
        {
            using (var bdd = new searchfoodEntities())
            {
                Historique historique = bdd.Historique.Find(h.Id_Historique);

                if (historique != null)
                {
                    bdd.Entry(historique).CurrentValues.SetValues(h);
                    bdd.SaveChanges();
                }
            }
        }
    }
}