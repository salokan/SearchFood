using System.Collections.Generic;
using SearchFoodServer.CAD;

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
        public string GetCategories()
        {
            return "coucou";
            //return _categories.GetCategories();
        }

        public int GetCategorie(int id)
        {
            return _categories.GetCategorie(id);
        }

        public void AddCategories()
        {
            _categories.AddCategories();
        }

        public void DeleteCategories()
        {
            _categories.DeleteCategories();
        }

        public void UpdateCategories()
        {
            _categories.UpdateCategories();
        }
        #endregion

        #region Commentaires
        public List<int> GetCommentaires()
        {
            return _commentaires.GetCommentaires();
        }

        public int GetCommentaire(int id)
        {
           return  _commentaires.GetCommentaire(id);
        }

        public void AddCommentaires()
        {
            _commentaires.AddCommentaires();
        }

        public void DeleteCommentaires()
        {
           _commentaires.DeleteCommentaires();
        }

        public void UpdateCommentaires()
        {
            _commentaires.UpdateCommentaires();
        }
        #endregion

        #region Historique
        public int GetHistorique()
        {
           return _historique.GetHistorique();
        }

        public void AddHistorique()
        {
            _historique.AddHistorique();
        }

        public void DeleteHistorique()
        {
            _historique.DeleteHistorique();
        }

        public void UpdateHistorique()
        {
            _historique.UpdateHistorique();
        }
        #endregion

        #region Notes
        public List<int> GetNotes()
        {
            return _notes.GetNotes();
        }

        public int GetNote(int id)
        {
            return _notes.GetNote(id);
        }

        public void AddNotes()
        {
            _notes.AddNotes();
        }

        public void DeleteNotes()
        {
            _notes.DeleteNotes();
        }

        public void UpdateNotes()
        {
            _notes.UpdateNotes();
        }
        #endregion

        #region Restaurants
        public List<int> GetRestaurants()
        {
            return _restaurants.GetRestaurants();
        }

        public int GetRestaurant(int id)
        {
            return _restaurants.GetRestaurant(id);
        }

        public void AddRestaurants()
        {
            _restaurants.AddRestaurants();
        }

        public void DeleteRestaurants()
        {
            _restaurants.DeleteRestaurants();
        }

        public void UpdateRestaurants()
        {_restaurants.UpdateRestaurants();
        }
        #endregion

        #region Types Cuisine
        public List<int> GetTypesCuisine()
        {
            return _typesCuisine.GetTypesCuisine();
        }

        public int GetTypeCuisine(int id)
        {
            return _typesCuisine.GetTypeCuisine(id);
        }

        public void AddTypesCuisine()
        {
            _typesCuisine.AddTypesCuisine();
        }

        public void DeleteTypesCuisine()
        {
            _typesCuisine.DeleteTypesCuisine();
        }

        public void UpdateTypesCuisine()
        {
            _typesCuisine.UpdateTypesCuisine();
        }
        #endregion

        #region Utilisateurs
        public List<int> GetUtilisateurs()
        {
            return _utilisateurs.GetUtilisateurs();
        }

        public int GetUtilisateur(int id)
        {
            return _utilisateurs.GetUtilisateur(id);
        }

        public void AddUtilisateurs()
        {
            _utilisateurs.AddUtilisateurs();
        }

        public void DeleteUtilisateurs()
        {
            _utilisateurs.DeleteUtilisateurs();
        }

        public void UpdateUtilisateurs()
        {
            _utilisateurs.UpdateUtilisateurs();
        }
        #endregion
    }
}
