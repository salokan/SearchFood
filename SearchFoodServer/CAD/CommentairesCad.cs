using System.Collections.Generic;
using System.Linq;
using SearchFoodServer.CompositeClass;

namespace SearchFoodServer.CAD
{
    public class CommentairesCad
    {
        public List<CompositeCommentaires> GetCommentaires()
        {
            List<CompositeCommentaires> commentairesList = new List<CompositeCommentaires>();

            List<Commentaire> commentaires;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from c in bdd.Commentaire
                              select c;

                commentaires = requete.ToList();
            }

            if (commentaires.Count > 0)
            {
                foreach (Commentaire c in commentaires)
                {
                    CompositeCommentaires composite = new CompositeCommentaires();
                    composite.IdCommentairesValue = c.Id_Commentaire;
                    composite.IdRestaurantsValue = c.Id_Restaurant;
                    composite.IdUtilisateursValue = c.Id_Utilisateur;
                    composite.CommentairesValue = c.Commentaire1;
                    commentairesList.Add(composite);
                }
            }

            return commentairesList;      
        }

        public CompositeCommentaires GetCommentaire(int id)
        {
            CompositeCommentaires compositeCommentaires = new CompositeCommentaires();
            Commentaire commentaire;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from c in bdd.Commentaire
                              where c.Id_Commentaire == id
                              select c;

                commentaire = requete.FirstOrDefault();
            }

            if (commentaire != null)
            {
                compositeCommentaires.IdCommentairesValue = commentaire.Id_Commentaire;
                compositeCommentaires.IdRestaurantsValue = commentaire.Id_Restaurant;
                compositeCommentaires.IdUtilisateursValue = commentaire.Id_Utilisateur;
                compositeCommentaires.CommentairesValue = commentaire.Commentaire1;
            }

            return compositeCommentaires;
        }

        public List<CompositeCommentaires> GetCommentaireByRestaurant(int idRestaurant)
        {
            List<CompositeCommentaires> commentairesList = new List<CompositeCommentaires>();

            List<Commentaire> commentaires;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from c in bdd.Commentaire where c.Id_Restaurant == idRestaurant
                              select c;

                commentaires = requete.ToList();
            }

            if (commentaires.Count > 0)
            {
                foreach (Commentaire c in commentaires)
                {
                    CompositeCommentaires composite = new CompositeCommentaires();
                    composite.IdCommentairesValue = c.Id_Commentaire;
                    composite.IdRestaurantsValue = c.Id_Restaurant;
                    composite.IdUtilisateursValue = c.Id_Utilisateur;
                    composite.CommentairesValue = c.Commentaire1;
                    commentairesList.Add(composite);
                }
            }

            return commentairesList;     
        }

        public CompositeCommentaires GetCommentaireByUserAndRestaurant(int idUser, int idRestaurant)
        {
            CompositeCommentaires compositeCommentaires = new CompositeCommentaires();
            Commentaire commentaire;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from c in bdd.Commentaire
                              where c.Id_Utilisateur == idUser && c.Id_Restaurant == idRestaurant
                              select c;

                commentaire = requete.FirstOrDefault();
            }

            if (commentaire != null)
            {
                compositeCommentaires.IdCommentairesValue = commentaire.Id_Commentaire;
                compositeCommentaires.IdRestaurantsValue = commentaire.Id_Restaurant;
                compositeCommentaires.IdUtilisateursValue = commentaire.Id_Utilisateur;
                compositeCommentaires.CommentairesValue = commentaire.Commentaire1;
            }

            return compositeCommentaires;
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