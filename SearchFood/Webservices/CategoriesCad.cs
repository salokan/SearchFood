using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SearchFood.SearchFoodServiceReference;

namespace SearchFood.Webservices
{
    public class CategoriesCad
    {
        SearchFoodServiceClient _client;

        public CategoriesCad(SearchFoodServiceClient client)
        {
            _client = client;
        }

        public async Task<List<Categorie>> GetCategories()
        {
            ObservableCollection<CompositeCategories> categoriesList;
            List<Categorie> categories = new List<Categorie>();

            categoriesList = await _client.GetCategoriesAsync();

            foreach (CompositeCategories c in categoriesList)
            {
                Categorie categorie = new Categorie();
                categorie.Id_Categorie = c.IdCategorieValue;
                categorie.Nom_Categorie = c.NomCategorieValue;

                categories.Add(categorie);
            }

            return categories;
        }

        public async Task<Categorie> GetCategorie(int id)
        {
            Categorie categorie = new Categorie();

            CompositeCategories categorieComposite = await _client.GetCategorieAsync(id);

            categorie.Id_Categorie = categorieComposite.IdCategorieValue;
            categorie.Nom_Categorie = categorieComposite.NomCategorieValue;

            return categorie;
        }

        public async void AddCategories(Categorie c)
        {
            await _client.AddCategoriesAsync(c);
        }

        public async void DeleteCategories(int id)
        {
            await _client.DeleteCategoriesAsync(id);
        }

        public async void UpdateCategories(Categorie c)
        {
            await _client.UpdateCategoriesAsync(c);
        }
    }
}
