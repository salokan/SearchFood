using System.Collections.Generic;
using System.Linq;

namespace SearchFoodServer.CAD
{
    public class CommentairesCad
    {
        public List<Commentaire> GetCommentaires()
        {
            List<Commentaire> commentaires;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from c in bdd.Commentaire
                              select c;

                commentaires = requete.ToList();
            }
            return commentaires;      
        }

        public Commentaire GetCommentaire(int id)
        {
            Commentaire commentaire;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from c in bdd.Commentaire
                              where c.Id_Commentaire == id
                              select c;

                commentaire = requete.FirstOrDefault();
            }

            return commentaire;
        }

        public void AddCommentaires(Commentaire c)
        {
            using (var bdd = new searchfoodEntities())
            {
                bdd.Commentaire.Add(c);
                bdd.SaveChanges();
            }
        }

        public void DeleteCommentaires(int id)
        {
            using (var bdd = new searchfoodEntities())
            {
                var requete = from c in bdd.Commentaire
                              where c.Id_Commentaire == id
                              select c;

                Commentaire commentaire = requete.FirstOrDefault();

                if (commentaire != null)
                {
                    bdd.Commentaire.Remove(commentaire);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateCommentaires(Commentaire c)
        {
            using (var bdd = new searchfoodEntities())
            {
                Commentaire commentaire = bdd.Commentaire.Find(c.Id_Commentaire);

                if (commentaire != null)
                {
                    bdd.Entry(commentaire).CurrentValues.SetValues(c);
                    bdd.SaveChanges();
                }
            }
        }
    }
}