namespace projet_mini_api.Dto
{
    /// <summary>
    /// DTO restaurant sans la liste des plats.
    /// </summary>
    public class RestaurantSimpleDto
    {
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
    }
}
