using System.Collections.Generic;
using System.Linq;
using SearchFoodServer.CompositeClass;

namespace SearchFoodServer.CAD
{
    public class UtilisateursCad
    {
        public List<CompositeUtilisateurs> GetUtilisateurs()
        {
            List<CompositeUtilisateurs> utilisateursList = new List<CompositeUtilisateurs>();

            List<Utilisateur> utilisateurs;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from u in bdd.Utilisateur
                              select u;

                utilisateurs = requete.ToList();
            }

            if (utilisateurs.Count > 0)
            {
                foreach (Utilisateur u in utilisateurs)
                {
                    CompositeUtilisateurs composite = new CompositeUtilisateurs();
                    composite.IdUtilisateurValue = u.Id_Utilisateur;
                    composite.PseudoValue = u.Pseudonyme;
                    composite.PasswordValue = u.Password;
                    composite.MailValue = u.Mail;
                    composite.PrenomValue = u.Prenom;
                    composite.NomValue = u.Nom;
                    utilisateursList.Add(composite);
                }
            }

            return utilisateursList;
        }

        public CompositeUtilisateurs GetUtilisateur(int id)
        {
            CompositeUtilisateurs compositeUtilisateurs = new CompositeUtilisateurs();
            Utilisateur utilisateur;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from u in bdd.Utilisateur
                              where u.Id_Utilisateur == id
                              select u;

                utilisateur = requete.FirstOrDefault();
            }

            if (utilisateur != null)
            {
                compositeUtilisateurs.IdUtilisateurValue = utilisateur.Id_Utilisateur;
                compositeUtilisateurs.PseudoValue = utilisateur.Pseudonyme;
                compositeUtilisateurs.PasswordValue = utilisateur.Password;
                compositeUtilisateurs.MailValue = utilisateur.Mail;
                compositeUtilisateurs.PrenomValue = utilisateur.Prenom;
                compositeUtilisateurs.NomValue = utilisateur.Nom;
            }

            return compositeUtilisateurs;
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