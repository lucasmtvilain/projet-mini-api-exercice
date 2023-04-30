using AutoMapper;
using Newtonsoft.Json;
using projet_mini_api.Dto;

namespace projet_mini_api.Services.MealService
{
    /// <summary>
    /// Classe service qui effectue directement les requête à l'API www.themealdb.com.
    /// </summary>
    public class MealService : IMealService
    {
        /// <summary>
        /// Provider de requêtes http client.
        /// </summary>
        private readonly HttpClient _httpClient;

        public MealService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Récupère un plat depuis l'API www.themealdb.com en fonction de son identifiant.
        /// </summary>
        /// <param name="id">identifiant du plat.</param>
        /// <returns>Plat</returns>
        public async Task<MealDto> GetMealById(int id)
        {
            string resultatJson;
            MealDto meal;

            // Requête pour intérroger l'API www.themealdb.com.
            using (Task<HttpResponseMessage> response = _httpClient.GetAsync($"lookup.php?i={id}"))
            {
                resultatJson = await response.Result.Content.ReadAsStringAsync();

                // Convertion du resultat en DTO.
                MealDtoApi mealDtoApi = JsonConvert.DeserializeObject<MealDtoApi>(resultatJson);
                meal = mealDtoApi?.ToSigleDto();
            };
            return meal;
        }

        /// <summary>
        /// Recupère la liste des plats en fonction du nom.
        /// </summary>
        /// <param name="name">nameDish</param>
        /// <returns>Liste des plats.</returns>
        public async Task<MealDtoApi> GetMealByName(string nameDish)
        {
            string resultatJson;
            MealDtoApi mealDtoApi = null;

            using (Task<HttpResponseMessage> response = _httpClient.GetAsync($"search.php?f={nameDish}"))
            {
                resultatJson = await response.Result.Content.ReadAsStringAsync();
                mealDtoApi = JsonConvert.DeserializeObject<MealDtoApi>(resultatJson);
            };
            return mealDtoApi;
        }
    }

}
