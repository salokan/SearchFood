using System;
using System.Collections.Generic;
using SearchFoodServer.CAD;
using SearchFoodServer.CompositeClass;

namespace SearchFoodServer
{
    public class SearchFoodService : ISearchFoodService
    {
        private readonly CategoriesCad _categories = new CategoriesCad();
        private readonly CommentairesCad _commentaires = new CommentairesCad();
        private readonly HistoriqueCad _historique = new HistoriqueCad();
        private readonly NotesCad _notes = new NotesCad();
        private readonly RestaurantsCad _restaurants = new RestaurantsCad();
        private readonly TypesCuisineCad _typesCuisine = new TypesCuisineCad();
        private readonly UtilisateursCad _utilisateurs = new UtilisateursCad();

        #region Categories
        public List<CompositeCategories> GetCategories()
        {
            return _categories.GetCategories();
        }

        public CompositeCategories GetCategorie(int id)
        {
            return _categories.GetCategorie(id);
        }

        public void AddCategories(Categorie c)
        {
            _categories.AddCategories(c);
        }

        public void DeleteCategories(int id)
        {
            _categories.DeleteCategories(id);
        }

        public void UpdateCategories(Categorie c)
        {
            _categories.UpdateCategories(c);
        }
        #endregion

        #region Commentaires
        public List<CompositeCommentaires> GetCommentaires()
        {
            return _commentaires.GetCommentaires();
        }

        public CompositeCommentaires GetCommentaire(int id)
        {
           return  _commentaires.GetCommentaire(id);
        }

        public List<CompositeCommentaires> GetCommentairesByRestaurant(int idRestaurant)
        {
            return _commentaires.GetCommentaireByRestaurant(idRestaurant);
        }

        public CompositeCommentaires GetCommentaireByUserAndRestaurant(int idUser, int idRestaurant)
        {
            return _commentaires.GetCommentaireByUserAndRestaurant(idUser, idRestaurant);
        }

        public void AddCommentaires(Commentaire c)
        {
            _commentaires.AddCommentaires(c);
        }

        public void DeleteCommentaires(int id)
        {
           _commentaires.DeleteCommentaires(id);
        }

        public void UpdateCommentaires(Commentaire c)
        {
            _commentaires.UpdateCommentaires(c);
        }
        #endregion

        #region Historique
        public List<CompositeHistorique> GetHistoriques()
        {
           return _historique.GetHistoriques();
        }

        public CompositeHistorique GetHistorique(int id)
        {
            return _historique.GetHistorique(id);
        }

        public List<CompositeHistorique> GetHistoriqueByUser(int idUser)
        {
            return _historique.GetHistoriqueByUser(idUser);
        }

        public void AddHistorique(Historique h)
        {
            _historique.AddHistorique(h);
        }

        public void DeleteHistorique(int id)
        {
            _historique.DeleteHistorique(id);
        }

        public void UpdateHistorique(Historique h)
        {
            _historique.UpdateHistorique(h);
        }

        #endregion

        #region Notes
        public List<CompositeNotes> GetNotes()
        {
            return _notes.GetNotes();
        }

        public CompositeNotes GetNote(int id)
        {
            return _notes.GetNote(id);
        }

        public CompositeNotes GetNoteByUserAndRestaurant(int idUser, int idRestaurant)
        {
            return _notes.GetNoteByUserAndRestaurant(idUser, idRestaurant);
        }

        public List<CompositeNotes> GetNoteByRestaurant(int idRestaurant)
        {
            return _notes.GetNoteByRestaurant(idRestaurant);
        }

        public List<CompositeNotes> GetNoteByUser(int idUser)
        {
            return _notes.GetNoteByUser(idUser);
        }

        public float GetMoyenneNoteRestaurant(int idRestaurant)
        {
            return _notes.GetMoyenneNoteRestaurant(idRestaurant);
        }

        public void AddNotes(Note n)
        {
            _notes.AddNotes(n);
        }

        public void DeleteNotes(int id)
        {
            _notes.DeleteNotes(id);
        }

        public void UpdateNotes(Note n)
        {
            _notes.UpdateNotes(n);
        }
        #endregion

        #region Restaurants
        public List<CompositeRestaurants> GetRestaurants()
        {
            return _restaurants.GetRestaurants();
        }

        public CompositeRestaurants GetRestaurant(int id)
        {
            return _restaurants.GetRestaurant(id);
        }

        public void AddRestaurants(Restaurant r)
        {
            _restaurants.AddRestaurants(r);
        }

        public void DeleteRestaurants(int id)
        {
            _restaurants.DeleteRestaurants(id);
        }

        public void UpdateRestaurants(Restaurant r)
        {
            _restaurants.UpdateRestaurants(r);
        }
        #endregion

        #region Types Cuisine
        public List<CompositeTypesCuisine> GetTypesCuisine()
        {
            return _typesCuisine.GetTypesCuisine();
        }

        public CompositeTypesCuisine GetTypeCuisine(int id)
        {
            return _typesCuisine.GetTypeCuisine(id);
        }

        public void AddTypesCuisine(Type_Cuisine tc)
        {
            _typesCuisine.AddTypesCuisine(tc);
        }

        public void DeleteTypesCuisine(int id)
        {
            _typesCuisine.DeleteTypesCuisine(id);
        }

        public void UpdateTypesCuisine(Type_Cuisine tc)
        {
            _typesCuisine.UpdateTypesCuisine(tc);
        }
        #endregion

        #region Utilisateurs
        public List<CompositeUtilisateurs> GetUtilisateurs()
        {
            return _utilisateurs.GetUtilisateurs();
        }

        public CompositeUtilisateurs GetUtilisateur(int id)
        {
            return _utilisateurs.GetUtilisateur(id);
        }

        public CompositeUtilisateurs AuthentificationUtilisateur(string pseudo, string password)
        {
            return _utilisateurs.AuthentificationUtilisateur(pseudo,password);
        }

        public string AddUtilisateurs(Utilisateur u)
        {
            try
            {
                _utilisateurs.AddUtilisateurs(u);
                return "success";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            } 
        }

        public void DeleteUtilisateurs(int id)
        {
            _utilisateurs.DeleteUtilisateurs(id);
        }

        public void UpdateUtilisateurs(Utilisateur u)
        {
            _utilisateurs.UpdateUtilisateurs(u);
        }

        public bool ExistePseudo(string pseudo)
        {
            return _utilisateurs.ExistePseudo(pseudo);
        }

        public bool ExisteMail(string mail)
        {
            return _utilisateurs.ExisteMail(mail);
        }

        #endregion
    }
}
