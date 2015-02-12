using System.Collections.Generic;
using System.ServiceModel;

namespace SearchFoodServer
{
    [ServiceContract]
    public interface ISearchFoodService
    {
        #region Categories
        [OperationContract]
        List<Categorie> GetCategories();
        [OperationContract]
        Categorie GetCategorie(int id);
        [OperationContract]
        void AddCategories(Categorie c);
        [OperationContract]
        void DeleteCategories(int id);
        [OperationContract]
        void UpdateCategories(Categorie c);
        #endregion

        #region Commentaires
        [OperationContract]
        List<Commentaire> GetCommentaires();
        [OperationContract]
        Commentaire GetCommentaire(int id);
        [OperationContract]
        void AddCommentaires(Commentaire c);
        [OperationContract]
        void DeleteCommentaires(int id);
        [OperationContract]
        void UpdateCommentaires(Commentaire c);
        #endregion

        #region Historique
        [OperationContract]
        List<Historique> GetHistoriques();
        [OperationContract]
        List<Historique> GetHistoriqueByUser(int idUser);
        [OperationContract]
        void AddHistorique(Historique h);
        [OperationContract]
        void DeleteHistorique(Historique h);
        [OperationContract]
        void UpdateHistorique(Historique h);
        #endregion

        #region Notes
        [OperationContract]
        List<Note> GetNotes();
        [OperationContract]
        List<Note> GetNoteByRestaurant(int idRestaurant);
        [OperationContract]
        List<Note> GetNoteByUser(int idUser);
        [OperationContract]
        void AddNotes(Note n);
        [OperationContract]
        void DeleteNotes(Note n);
        [OperationContract]
        void UpdateNotes(Note n);
        #endregion

        #region Restaurants
        [OperationContract]
        List<Restaurant> GetRestaurants();
        [OperationContract]
        Restaurant GetRestaurant(int id);
        [OperationContract]
        void AddRestaurants(Restaurant r);
        [OperationContract]
        void DeleteRestaurants(int id);
        [OperationContract]
        void UpdateRestaurants(Restaurant r);
        #endregion

        #region TypesCuisine
        [OperationContract]
        List<Type_Cuisine> GetTypesCuisine();
        [OperationContract]
        Type_Cuisine GetTypeCuisine(int id);
        [OperationContract]
        void AddTypesCuisine(Type_Cuisine tc);
        [OperationContract]
        void DeleteTypesCuisine(int id);
        [OperationContract]
        void UpdateTypesCuisine(Type_Cuisine tc);
        #endregion

        #region Utilisateurs
        [OperationContract]
        List<Utilisateur> GetUtilisateurs();
        [OperationContract]
        Utilisateur GetUtilisateur(int id);
        [OperationContract]
        void AddUtilisateurs(Utilisateur u);
        [OperationContract]
        void DeleteUtilisateurs(int id);
        [OperationContract]
        void UpdateUtilisateurs(Utilisateur u);
        #endregion
    }
}
