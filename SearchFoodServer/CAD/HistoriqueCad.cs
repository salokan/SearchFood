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

        public Historique GetHistorique(int id)
        {
            Historique historique;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from h in bdd.Historique
                              where h.Id_Historique == id
                              select h;

                historique = requete.FirstOrDefault();
            }

            return historique;
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