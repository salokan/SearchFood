﻿using System.Collections.ObjectModel;
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

        public async Task<ObservableCollection<Historique>> GetHistorique()
        {
            return await _client.GetHistoriquesAsync();           
        }

        public async Task<ObservableCollection<Historique>> GetHistoriqueByUser(int idUser)
        {
            return await _client.GetHistoriqueByUserAsync(idUser);    
        }

        public async void AddHistorique(Historique h)
        {
            await _client.AddHistoriqueAsync(h);
        }

        public async void DeleteHistorique(Historique h)
        {
            await _client.DeleteHistoriqueAsync(h);
        }

        public async void UpdateHistorique(Historique h)
        {
            await _client.UpdateHistoriqueAsync(h);
        }
    }
}