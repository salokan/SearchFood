using System.Collections.Generic;
using System.Linq;
using SearchFoodServer.CompositeClass;

namespace SearchFoodServer.CAD
{
    public class NotesCad
    {
        public List<CompositeNotes> GetNotes()
        {
            List<CompositeNotes> notesList = new List<CompositeNotes>();

            List<Note> notes;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from n in bdd.Note
                              select n;

                notes = requete.ToList();
            }

            if (notes.Count > 0)
            {
                foreach (Note n in notes)
                {
                    CompositeNotes composite = new CompositeNotes();
                    composite.IdNotesValue = n.Id_Note;
                    composite.IdRestaurantsValue = n.Id_Restaurant;
                    composite.IdUtilisateursValue = n.Id_Utilisateur;
                    composite.NotesValue = n.Note1;
                    notesList.Add(composite);
                }
            }

            return notesList;
        }

        public CompositeNotes GetNote(int id)
        {
            CompositeNotes compositeNotes = new CompositeNotes();
            Note note;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from n in bdd.Note
                              where n.Id_Note == id
                              select n;

                note = requete.FirstOrDefault();
            }

            if (note != null)
            {
                compositeNotes.IdNotesValue = note.Id_Note;
                compositeNotes.IdRestaurantsValue = note.Id_Restaurant;
                compositeNotes.IdUtilisateursValue = note.Id_Utilisateur;
                compositeNotes.NotesValue = note.Note1;
            }

            return compositeNotes;
        }

        public List<CompositeNotes> GetNoteByRestaurant(int idRestaurant)
        {
            List<CompositeNotes> notesList = new List<CompositeNotes>();

            List<Note> notes;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from n in bdd.Note
                              where n.Id_Utilisateur == idRestaurant
                              select n;

                notes = requete.ToList();
            }

            if (notes.Count > 0)
            {
                foreach (Note n in notes)
                {
                    CompositeNotes composite = new CompositeNotes();
                    composite.IdNotesValue = n.Id_Note;
                    composite.IdRestaurantsValue = n.Id_Restaurant;
                    composite.IdUtilisateursValue = n.Id_Utilisateur;
                    composite.NotesValue = n.Note1;
                    notesList.Add(composite);
                }
            }

            return notesList;
        }

        public List<CompositeNotes> GetNoteByUser(int idUser)
        {
            List<CompositeNotes> notesList = new List<CompositeNotes>();

            List<Note> notes;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from n in bdd.Note
                              where n.Id_Utilisateur == idUser
                              select n;

                notes = requete.ToList();
            }

            if (notes.Count > 0)
            {
                foreach (Note n in notes)
                {
                    CompositeNotes composite = new CompositeNotes();
                    composite.IdNotesValue = n.Id_Note;
                    composite.IdRestaurantsValue = n.Id_Restaurant;
                    composite.IdUtilisateursValue = n.Id_Utilisateur;
                    composite.NotesValue = n.Note1;
                    notesList.Add(composite);
                }
            }

            return notesList;
        }

        public void AddNotes(Note n)
        {
            using (var bdd = new searchfoodEntities())
            {
                bdd.Note.Add(n);
                bdd.SaveChanges();
            }
        }

        public void DeleteNotes(int id)
        {
            using (var bdd = new searchfoodEntities())
            {
                var requete = from n in bdd.Note
                              where n.Id_Note == id
                              select n;

                Note note = requete.FirstOrDefault();

                if (note != null)
                {
                    bdd.Note.Remove(note);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateNotes(Note n)
        {
            using (var bdd = new searchfoodEntities())
            {
                Note note = bdd.Note.Find(n.Id_Note);

                if (note != null)
                {
                    bdd.Entry(note).CurrentValues.SetValues(n);
                    bdd.SaveChanges();
                }
            }
        }
    }
}