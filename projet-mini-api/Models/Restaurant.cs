namespace projet_mini_api.Models
{
    public class Restaurant
    {
        /// <summary>
        /// Constructeur.
        /// </summary>
        public Restaurant()
        {
            Meals = new List<Meal>();
        }
        /// <summary>
        /// Id utilisé comme identifiant primaire par EntityFramework Core.
        /// </summary>
        public int Id { get; set; }

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
        public List<Meal>? Meals { get; set; }

    }
}
