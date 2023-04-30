namespace projet_mini_api.Data
{
    /// <summary>
    /// Classe de context de la base de données
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="optionsBuilder">Builder du context. Le context est paramétré par Program.cs</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        /// <summary>
        /// Table restaurant.
        /// </summary>
        public DbSet<Restaurant> Restaurants { get; set; }

        /// <summary>
        /// Table Meal.
        /// </summary>
        public DbSet<Meal> Meals { get; set; }
    }
}
