using System.Collections.Generic;
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

        public async Task<List<Note>> GetNotes()
        {
            ObservableCollection<CompositeNotes> notesList;
            List<Note> notes = new List<Note>();

            notesList = await _client.GetNotesAsync();

            foreach (CompositeNotes n in notesList)
            {
                Note note = new Note();
                note.Id_Note = n.IdNotesValue;
                note.Id_Restaurant = n.IdRestaurantsValue;
                note.Id_Utilisateur = n.IdUtilisateursValue;
                note.Note1 = n.NotesValue;

                notes.Add(note);
            }

            return notes;   
        }

        public async Task<Note> GetNote(int id)
        {
            Note note = new Note();

            CompositeNotes noteComposite = await _client.GetNoteAsync(id);

            note.Id_Note = noteComposite.IdNotesValue;
            note.Id_Restaurant = noteComposite.IdRestaurantsValue;
            note.Id_Utilisateur = noteComposite.IdUtilisateursValue;
            note.Note1 = noteComposite.NotesValue;

            return note;
        }

        public async Task<Note> GetNoteByUserAndRestaurant(int idUser, int idRestaurant)
        {
            Note note = new Note();

            CompositeNotes noteComposite = await _client.GetNoteByUserAndRestaurantAsync(idUser, idRestaurant);

            note.Id_Note = noteComposite.IdNotesValue;
            note.Id_Restaurant = noteComposite.IdRestaurantsValue;
            note.Id_Utilisateur = noteComposite.IdUtilisateursValue;
            note.Note1 = noteComposite.NotesValue;

            return note;
        }

        public async Task<List<Note>> GetNoteByRestaurant(int idRestaurant)
        {
            ObservableCollection<CompositeNotes> notesList;
            List<Note> notes = new List<Note>();

            notesList = await _client.GetNoteByRestaurantAsync(idRestaurant);

            foreach (CompositeNotes n in notesList)
            {
                Note note = new Note();
                note.Id_Note = n.IdNotesValue;
                note.Id_Restaurant = n.IdRestaurantsValue;
                note.Id_Utilisateur = n.IdUtilisateursValue;
                note.Note1 = n.NotesValue;

                notes.Add(note);
            }

            return notes;
        }

        public async Task<List<Note>> GetNotesByUser(int idUser)
        {
            ObservableCollection<CompositeNotes> notesList;
            List<Note> notes = new List<Note>();

            notesList = await _client.GetNoteByUserAsync(idUser);

            foreach (CompositeNotes n in notesList)
            {
                Note note = new Note();
                note.Id_Note = n.IdNotesValue;
                note.Id_Restaurant = n.IdRestaurantsValue;
                note.Id_Utilisateur = n.IdUtilisateursValue;
                note.Note1 = n.NotesValue;

                notes.Add(note);
            }

            return notes;
        }

        public async Task<float> GetMoyenneNotesRestaurant(int idRestaurant)
        {
            return await _client.GetMoyenneNoteRestaurantAsync(idRestaurant);
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
