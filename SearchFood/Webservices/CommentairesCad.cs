using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SearchFood.SearchFoodServiceReference;

namespace SearchFood.Webservices
{
    public class CommentairesCad
    {
        SearchFoodServiceClient _client;

        public CommentairesCad(SearchFoodServiceClient client)
        {
            _client = client;
        }

        public async Task<List<Commentaire>> GetCommentaires()
        {
            List<Commentaire> commentaires = new List<Commentaire>();

            ObservableCollection<CompositeCommentaires> commentairesList = await _client.GetCommentairesAsync();

            foreach (CompositeCommentaires c in commentairesList)
            {
                Commentaire commentaire = new Commentaire();
                commentaire.Id_Commentaire = c.IdCommentairesValue;
                commentaire.Id_Restaurant = c.IdRestaurantsValue;
                commentaire.Id_Utilisateur = c.IdUtilisateursValue;
                commentaire.Commentaire1 = c.CommentairesValue;

                commentaires.Add(commentaire);
            }

            return commentaires;           
        }

        public async Task<Commentaire> GetCommentaires(int id)
        {
            Commentaire commentaire = new Commentaire();

            CompositeCommentaires commentaireComposite = await _client.GetCommentaireAsync(id);

            commentaire.Id_Commentaire = commentaireComposite.IdCommentairesValue;
            commentaire.Id_Restaurant = commentaireComposite.IdRestaurantsValue;
            commentaire.Id_Utilisateur = commentaireComposite.IdUtilisateursValue;
            commentaire.Commentaire1 = commentaireComposite.CommentairesValue;

            return commentaire;
        }

        public async Task<List<Commentaire>> GetCommentairesByRestaurant(int idRestaurant)
        {
            List<Commentaire> commentaires = new List<Commentaire>();

            ObservableCollection<CompositeCommentaires> commentairesList = await _client.GetCommentairesByRestaurantAsync(idRestaurant);

            foreach (CompositeCommentaires c in commentairesList)
            {
                Commentaire commentaire = new Commentaire();
                commentaire.Id_Commentaire = c.IdCommentairesValue;
                commentaire.Id_Restaurant = c.IdRestaurantsValue;
                commentaire.Id_Utilisateur = c.IdUtilisateursValue;
                commentaire.Commentaire1 = c.CommentairesValue;

                commentaires.Add(commentaire);
            }

            return commentaires;
        }

        public async Task<Commentaire> GetCommentairesByUserAndRestaurant(int idUser, int idRestaurant)
        {
            Commentaire commentaire = new Commentaire();

            CompositeCommentaires commentaireComposite = await _client.GetCommentaireByUserAndRestaurantAsync(idUser, idRestaurant);

            commentaire.Id_Commentaire = commentaireComposite.IdCommentairesValue;
            commentaire.Id_Restaurant = commentaireComposite.IdRestaurantsValue;
            commentaire.Id_Utilisateur = commentaireComposite.IdUtilisateursValue;
            commentaire.Commentaire1 = commentaireComposite.CommentairesValue;

            return commentaire;
        }

        public async void AddCommentaires(Commentaire c)
        {
            await _client.AddCommentairesAsync(c);
        }

        public async void DeleteCommentaires(int id)
        {
            await _client.DeleteCommentairesAsync(id);
        }

        public async void UpdateCommentaires(Commentaire c)
        {
            await _client.UpdateCommentairesAsync(c);
        }
    }
}
