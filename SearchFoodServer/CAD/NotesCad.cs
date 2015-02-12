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

        public void DeleteNotes(Note n)
        {
            using (var bdd = new searchfoodEntities())
            {
                if (n != null)
                {
                    bdd.Note.Remove(n);
                    bdd.SaveChanges();
                }
            }
        }

        public void UpdateNotes(Note n)
        {   
            using (var bdd = new searchfoodEntities())
            {
                var requete = from n2 in bdd.Note
                              where n2.Id_Restaurant == n.Id_Restaurant && n2.Id_Utilisateur == n.Id_Utilisateur  
                              select n2;

                Note note = requete.FirstOrDefault();

                if (note != null)
                {
                    bdd.Entry(note).CurrentValues.SetValues(n);
                    bdd.SaveChanges();
                }
            }
        }
    }
}