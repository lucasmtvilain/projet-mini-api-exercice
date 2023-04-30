namespace projet_mini_api.Models
{
    public class RestaurantDto
    {        

        /// <summary>
        /// Nom du restaurant.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// adresses
        /// </summary>
        public string Adresse { get; set; } = string.Empty;

        /// <summary>
        /// descritpion du restaurant.
        /// </summary>
        public string? Description { get; set; } = string.Empty;

        /// <summary>
        /// Liste des plats du restaurants.
        /// </summary>
        public List<MealDto>? Meals { get; set; }

    }
}
