using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ServiceModel;

namespace SearchFoodServer
{
    [ServiceContract]
    public interface ISearchFoodService
    {
        #region Categories
        [OperationContract]
        string GetCategories();
        [OperationContract]
        int GetCategorie(int id);
        [OperationContract]
        void AddCategories();
        [OperationContract]
        void DeleteCategories();
        [OperationContract]
        void UpdateCategories();
        #endregion

        #region Commentaires
        [OperationContract]
        List<int> GetCommentaires();
        [OperationContract]
        int GetCommentaire(int id);
        [OperationContract]
        void AddCommentaires();
        [OperationContract]
        void DeleteCommentaires();
        [OperationContract]
        void UpdateCommentaires();
        #endregion

        #region Historique
        [OperationContract]
        int GetHistorique();
        [OperationContract]
        void AddHistorique();
        [OperationContract]
        void DeleteHistorique();
        [OperationContract]
        void UpdateHistorique();
        #endregion

        #region Notes
        [OperationContract]
        List<int> GetNotes();
        [OperationContract]
        int GetNote(int id);
        [OperationContract]
        void AddNotes();
        [OperationContract]
        void DeleteNotes();
        [OperationContract]
        void UpdateNotes();
        #endregion

        #region Restaurants
        [OperationContract]
        List<int> GetRestaurants();
        [OperationContract]
        int GetRestaurant(int id);
        [OperationContract]
        void AddRestaurants();
        [OperationContract]
        void DeleteRestaurants();
        [OperationContract]
        void UpdateRestaurants();
        #endregion

        #region TypesCuisine
        [OperationContract]
        List<int> GetTypesCuisine();
        [OperationContract]
        int GetTypeCuisine(int id);
        [OperationContract]
        void AddTypesCuisine();
        [OperationContract]
        void DeleteTypesCuisine();
        [OperationContract]
        void UpdateTypesCuisine();
        #endregion

        #region Utilisateurs
        [OperationContract]
        List<int> GetUtilisateurs();
        [OperationContract]
        int GetUtilisateur(int id);
        [OperationContract]
        void AddUtilisateurs();
        [OperationContract]
        void DeleteUtilisateurs();
        [OperationContract]
        void UpdateUtilisateurs();
        #endregion
    }
}
