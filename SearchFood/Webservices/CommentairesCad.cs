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

        public async Task<ObservableCollection<Commentaire>> GetCommentaires()
        {
            return await _client.GetCommentairesAsync();           
        }

        public async Task<Commentaire> GetCommentaires(int id)
        {
            return await _client.GetCommentaireAsync(id);    
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
