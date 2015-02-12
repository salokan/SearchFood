using System.Collections.Generic;
using System.Linq;

namespace SearchFoodServer.CAD
{
    public class HistoriqueCad
    {
        public List<Historique> GetHistoriques()
        {
            List<Historique> historiques;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from h in bdd.Historique
                              select h;

                historiques = requete.ToList();
            }
            return historiques;
        }

        public List<Historique> GetHistoriqueByUser(int idUser)
        {
            List<Historique> historiques;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from h in bdd.Historique
                              where h.Id_Utilisateur == idUser
                              select h;

                historiques = requete.ToList();
            }
            return historiques;
        }

        public void AddHistorique(Historique h)
        {
            using (var bdd = new searchfoodEntities())
            {
                bdd.Historique.Add(h);
                bdd.SaveChanges();
            }
        }

        public void DeleteHistorique(Historique h)
        {
            using (var bdd = new searchfoodEntities())
            {
                if (h != null)
                {
                    bdd.Historique.Remove(h);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateHistorique(Historique h)
        {
            using (var bdd = new searchfoodEntities())
            {
                var requete = from h2 in bdd.Historique
                              where h2.Id_Restaurant == h.Id_Restaurant && h2.Id_Utilisateur == h.Id_Utilisateur
                              select h2;

                Historique historique = requete.FirstOrDefault();

                if (historique != null)
                {
                    bdd.Entry(historique).CurrentValues.SetValues(h);
                    bdd.SaveChanges();
                }
            }
        }
    }
}