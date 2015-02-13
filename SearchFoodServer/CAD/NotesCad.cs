using System.Collections.Generic;
using System.Linq;

namespace SearchFoodServer.CAD
{
    public class NotesCad
    {
        public List<Note> GetNotes()
        {
            List<Note> notes;
            using (var bdd = new searchfoodEntities())
            {
                var requete = from h in bdd.Note
                              select h;

                notes = requete.ToList();
            }
            return notes;
        }

        public Note GetNote(int id)
        {
            Note note;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from n in bdd.Note
                              where n.Id_Note == id
                              select n;

                note = requete.FirstOrDefault();
            }

            return note;
        }

        public List<Note> GetNoteByRestaurant(int idRestaurant)
        {
            List<Note> notes;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from h in bdd.Note
                              where h.Id_Utilisateur == idRestaurant
                              select h;

                notes = requete.ToList();
            }
            return notes;
        }

        public List<Note> GetNoteByUser(int idUser)
        {
            List<Note> notes;

            using (var bdd = new searchfoodEntities())
            {
                var requete = from h in bdd.Note
                              where h.Id_Utilisateur == idUser
                              select h;

                notes = requete.ToList();
            }
            return notes;
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