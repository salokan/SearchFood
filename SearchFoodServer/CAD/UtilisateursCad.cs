using System.Collections.Generic;
using System.Linq;

namespace SearchFoodServer.CAD
{
    public class UtilisateursCad
    {
        public List<Utilisateur> GetUtilisateurs()
        {
            List<Utilisateur> utilisateurs;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from u in bdd.Utilisateur
                              select u;

                utilisateurs = requete.ToList();
            }
            return utilisateurs;
        }

        public Utilisateur GetUtilisateur(int id)
        {
            Utilisateur utilisateur;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from u in bdd.Utilisateur
                              where u.Id_Utilisateur == id
                              select u;

                utilisateur = requete.FirstOrDefault();
            }

            return utilisateur;
        }

        public void AddUtilisateurs(Utilisateur u)
        {
            using (var bdd = new searchfoodEntities())
            {
                bdd.Utilisateur.Add(u);
                bdd.SaveChanges();
            }
        }

        public void DeleteUtilisateurs(int id)
        {
            using (var bdd = new searchfoodEntities())
            {
                var requete = from u in bdd.Utilisateur
                              where u.Id_Utilisateur == id
                              select u;

                Utilisateur utilisateur = requete.FirstOrDefault();

                if (utilisateur != null)
                {
                    bdd.Utilisateur.Remove(utilisateur);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateUtilisateurs(Utilisateur u)
        {
            using (var bdd = new searchfoodEntities())
            {
                Utilisateur utilisateur = bdd.Utilisateur.Find(u.Id_Utilisateur);

                if (utilisateur != null)
                {
                    bdd.Entry(utilisateur).CurrentValues.SetValues(u);
                    bdd.SaveChanges();
                }
            }
        }
    }
}