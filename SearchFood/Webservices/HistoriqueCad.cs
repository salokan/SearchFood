using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SearchFood.SearchFoodServiceReference;

namespace SearchFood.Webservices
{
    public class HistoriqueCad
    {
        SearchFoodServiceClient _client;

        public HistoriqueCad(SearchFoodServiceClient client)
        {
            _client = client;
        }

        public async Task<List<Historique>> GetHistorique()
        {
            ObservableCollection<CompositeHistorique> historiquesList;
            List<Historique> historiques = new List<Historique>();

            historiquesList = await _client.GetHistoriquesAsync();

            foreach (CompositeHistorique h in historiquesList)
            {
                Historique historique = new Historique();
                historique.Id_Historique = h.IdHistoriqueValue;
                historique.Id_Restaurant = h.IdRestaurantsValue;
                historique.Id_Utilisateur = h.IdUtilisateursValue;
                historique.Date = h.DateValue;

                historiques.Add(historique);
            }

            return historiques;
        }

        public async Task<Historique> GetHistorique(int id)
        {
            Historique historique = new Historique();

            CompositeHistorique historiqueComposite = await _client.GetHistoriqueAsync(id);

            historique.Id_Historique = historiqueComposite.IdHistoriqueValue;
            historique.Id_Restaurant = historiqueComposite.IdRestaurantsValue;
            historique.Id_Utilisateur = historiqueComposite.IdUtilisateursValue;
            historique.Date = historiqueComposite.DateValue;

            return historique;
        }

        public async Task<List<Historique>> GetHistoriqueByUser(int idUser)
        {
            ObservableCollection<CompositeHistorique> historiquesList;
            List<Historique> historiques = new List<Historique>();

            historiquesList = await _client.GetHistoriqueByUserAsync(idUser);

            foreach (CompositeHistorique h in historiquesList)
            {
                Historique historique = new Historique();
                historique.Id_Historique = h.IdHistoriqueValue;
                historique.Id_Restaurant = h.IdRestaurantsValue;
                historique.Id_Utilisateur = h.IdUtilisateursValue;
                historique.Date = h.DateValue;

                historiques.Add(historique);
            }

            return historiques;
        }

        public async void AddHistorique(Historique h)
        {
            await _client.AddHistoriqueAsync(h);
        }

        public async void DeleteHistorique(int id)
        {
            await _client.DeleteHistoriqueAsync(id);
        }

        public async void UpdateHistorique(Historique h)
        {
            await _client.UpdateHistoriqueAsync(h);
        }
    }
}
