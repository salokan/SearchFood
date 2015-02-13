using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SearchFood.SearchFoodServiceReference;

namespace SearchFood.Webservices
{
    public class NotesCad
    {
        SearchFoodServiceClient _client;

        public NotesCad(SearchFoodServiceClient client)
        {
            _client = client;
        }

        public async Task<ObservableCollection<Note>> GetNotes()
        {
            return await _client.GetNotesAsync();           
        }

        public async Task<Note> GetNote(int id)
        {
            return await _client.GetNoteAsync(id);
        }

        public async Task<ObservableCollection<Note>> GetNoteByRestaurant(int idRestaurant)
        {
            return await _client.GetNoteByRestaurantAsync(idRestaurant);
        }

        public async Task<ObservableCollection<Note>> GetNotesByUser(int idUser)
        {
            return await _client.GetNoteByUserAsync(idUser);    
        }

        public async void AddNotes(Note n)
        {
            await _client.AddNotesAsync(n);
        }

        public async void DeleteNotes(int id)
        {
            await _client.DeleteNotesAsync(id);
        }

        public async void UpdateNotes(Note n)
        {
            await _client.UpdateNotesAsync(n);
        }
    }
}
