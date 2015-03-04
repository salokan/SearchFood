using System.Collections.Generic;
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

        public async Task<List<Utilisateur>> GetUtilisateurs()
        {
            ObservableCollection<CompositeUtilisateurs> utilisateursList;
            List<Utilisateur> utilisateurs = new List<Utilisateur>();

            utilisateursList = await _client.GetUtilisateursAsync();

            foreach (CompositeUtilisateurs u in utilisateursList)
            {
                Utilisateur utilisateur = new Utilisateur();
                utilisateur.Id_Utilisateur = u.IdUtilisateurValue;
                utilisateur.Pseudonyme = u.PseudoValue;
                utilisateur.Password = u.PasswordValue;
                utilisateur.Mail = u.MailValue;
                utilisateur.Prenom = u.PrenomValue;
                utilisateur.Nom = u.NomValue;

                utilisateurs.Add(utilisateur);
            }

            return utilisateurs;          
        }

        public async Task<Utilisateur> GetUtilisateur(int id)
        {
            Utilisateur utilisateur = new Utilisateur();

            CompositeUtilisateurs utilisateurComposite = await _client.GetUtilisateurAsync(id);

            utilisateur.Id_Utilisateur = utilisateurComposite.IdUtilisateurValue;
            utilisateur.Pseudonyme = utilisateurComposite.PseudoValue;
            utilisateur.Password = utilisateurComposite.PasswordValue;
            utilisateur.Mail = utilisateurComposite.MailValue;
            utilisateur.Prenom = utilisateurComposite.PrenomValue;
            utilisateur.Nom = utilisateurComposite.NomValue;

            return utilisateur;
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
