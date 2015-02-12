using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SearchFood.SearchFoodServiceReference;

namespace SearchFood.Webservices
{
    public class UtilisateursCad
    {
        SearchFoodServiceClient _client;

        public UtilisateursCad(SearchFoodServiceClient client)
        {
            _client = client;
        }

        public async Task<ObservableCollection<Utilisateur>> GetTypesCuisines()
        {
            return await _client.GetUtilisateursAsync();           
        }

        public async Task<Utilisateur> GetUtilisateur(int id)
        {
            return await _client.GetUtilisateurAsync(id);    
        }

        public async void AddUtilisateurs(Utilisateur u)
        {
            await _client.AddUtilisateursAsync(u);
        }

        public async void DeleteUtilisateurs(int id)
        {
            await _client.DeleteUtilisateursAsync(id);
        }

        public async void UpdateUtilisateurs(Utilisateur u)
        {
            await _client.UpdateUtilisateursAsync(u);
        }
    }
}
