using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SearchFood.SearchFoodServiceReference;

namespace SearchFood.Webservices
{
    public class TypesCuisineCad
    {
        SearchFoodServiceClient _client;

        public TypesCuisineCad(SearchFoodServiceClient client)
        {
            _client = client;
        }

        public async Task<List<Type_Cuisine>> GetTypesCuisines()
        {
            ObservableCollection<CompositeTypesCuisine> typesCuisineList;
            List<Type_Cuisine> typesCuisines = new List<Type_Cuisine>();

            typesCuisineList = await _client.GetTypesCuisineAsync();

            foreach (CompositeTypesCuisine tc in typesCuisineList)
            {
                Type_Cuisine typeCuisine = new Type_Cuisine();
                typeCuisine.Id_Type_Cuisine = tc.IdTypesCuisineValue;
                typeCuisine.Type_Cuisine1 = tc.TypesCuisineValue;

                typesCuisines.Add(typeCuisine);
            }

            return typesCuisines;   
        }

        public async Task<Type_Cuisine> GetTypeCuisine(int id)
        {
            Type_Cuisine typeCuisine = new Type_Cuisine();

            CompositeTypesCuisine typeCuisineComposite = await _client.GetTypeCuisineAsync(id);

            typeCuisine.Id_Type_Cuisine = typeCuisineComposite.IdTypesCuisineValue;
            typeCuisine.Type_Cuisine1 = typeCuisineComposite.TypesCuisineValue;

            return typeCuisine;
        }

        public async void AddTypesCuisine(Type_Cuisine tc)
        {
            await _client.AddTypesCuisineAsync(tc);
        }

        public async void DeleteTypesCuisine(int id)
        {
            await _client.DeleteTypesCuisineAsync(id);
        }

        public async void UpdateTypesCuisine(Type_Cuisine tc)
        {
            await _client.UpdateTypesCuisineAsync(tc);
        }
    }
}
