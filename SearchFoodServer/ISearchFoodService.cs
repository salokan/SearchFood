using System.Collections.Generic;
using System.ServiceModel;
using SearchFoodServer.CompositeClass;

namespace SearchFoodServer
{
    [ServiceContract]
    public interface ISearchFoodService
    {
        #region Categories
        [OperationContract]
        List<CompositeCategories> GetCategories();
        [OperationContract]
        CompositeCategories GetCategorie(int id);
        [OperationContract]
        void AddCategories(Categorie c);
        [OperationContract]
        void DeleteCategories(int id);
        [OperationContract]
        void UpdateCategories(Categorie c);
        #endregion

        #region Commentaires
        [OperationContract]
        List<CompositeCommentaires> GetCommentaires();
        [OperationContract]
        CompositeCommentaires GetCommentaire(int id);
        [OperationContract]
        List<CompositeCommentaires> GetCommentairesByRestaurant(int idRestaurant);
        [OperationContract]
        CompositeCommentaires GetCommentaireByUserAndRestaurant(int idUser, int idRestaurant);
        [OperationContract]
        void AddCommentaires(Commentaire c);
        [OperationContract]
        void DeleteCommentaires(int id);
        [OperationContract]
        void UpdateCommentaires(Commentaire c);
        #endregion

        #region Historique
        [OperationContract]
        List<CompositeHistorique> GetHistoriques();
        [OperationContract]
        CompositeHistorique GetHistorique(int id);
        [OperationContract]
        List<CompositeHistorique> GetHistoriqueByUser(int idUser);
        [OperationContract]
        void AddHistorique(Historique h);
        [OperationContract]
        void DeleteHistorique(int id);
        [OperationContract]
        void UpdateHistorique(Historique h);
        #endregion

        #region Notes
        [OperationContract]
        List<CompositeNotes> GetNotes();
        [OperationContract]
        CompositeNotes GetNote(int id);
        [OperationContract]
        CompositeNotes GetNoteByUserAndRestaurant(int idUser, int idRestaurant);
        [OperationContract]
        List<CompositeNotes> GetNoteByRestaurant(int idRestaurant);
        [OperationContract]
        List<CompositeNotes> GetNoteByUser(int idUser);
        [OperationContract]
        float GetMoyenneNoteRestaurant(int idRestaurant);
        [OperationContract]
        void AddNotes(Note n);
        [OperationContract]
        void DeleteNotes(int id);
        [OperationContract]
        void UpdateNotes(Note n);
        #endregion

        #region Restaurants
        [OperationContract]
        List<CompositeRestaurants> GetRestaurants();
        [OperationContract]
        CompositeRestaurants GetRestaurant(int id);
        [OperationContract]
        void AddRestaurants(Restaurant r);
        [OperationContract]
        void DeleteRestaurants(int id);
        [OperationContract]
        void UpdateRestaurants(Restaurant r);
        #endregion

        #region TypesCuisine
        [OperationContract]
        List<CompositeTypesCuisine> GetTypesCuisine();
        [OperationContract]
        CompositeTypesCuisine GetTypeCuisine(int id);
        [OperationContract]
        void AddTypesCuisine(Type_Cuisine tc);
        [OperationContract]
        void DeleteTypesCuisine(int id);
        [OperationContract]
        void UpdateTypesCuisine(Type_Cuisine tc);
        #endregion

        #region Utilisateurs
        [OperationContract]
        List<CompositeUtilisateurs> GetUtilisateurs();
        [OperationContract]
        CompositeUtilisateurs GetUtilisateur(int id);
        [OperationContract]
        CompositeUtilisateurs AuthentificationUtilisateur(string pseudo, string password);
        [OperationContract]
        string AddUtilisateurs(Utilisateur u);
        [OperationContract]
        void DeleteUtilisateurs(int id);
        [OperationContract]
        void UpdateUtilisateurs(Utilisateur u);
        [OperationContract]
        bool ExistePseudo(string pseudo);
        [OperationContract]
        bool ExisteMail(string mail);
        #endregion
    }
}
