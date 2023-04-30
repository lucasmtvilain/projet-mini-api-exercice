using Newtonsoft.Json;

namespace projet_mini_api.Dto
{
    /// <summary>
    /// DTO utilisé pour récypérer les resultat de l'API.
    /// </summary>
    public class MealDtoApi
    {
        [JsonProperty("meals")]
        public MealDto[] Meals { get; set; }
    }
}
