using AutoMapper;
using projet_mini_api.Data;
using projet_mini_api.Dto;

namespace projet_mini_api.Services.RestaurantServices
{
    public class RestaurantServices : IRestaurantServices
    {
        /// <summary>
        /// Context ORM d'entityFramework Core.
        /// </summary>
        private readonly DataContext _context;

        /// <summary>
        /// Mapper entre une classe model et DTO.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="context">Context de l'ORM d'entityFramework Core.</param>
        public RestaurantServices(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        /// <summary>
        /// Liste tous les restaurants de la abse.
        /// </summary>
        /// <returns></returns>
        public async Task<List<RestaurantSimpleDto>> GetAllRestaurant()
        {
            // Recherche avec liaison Meals.
            List<Restaurant> restaurants = await _context.Restaurants.ToListAsync();

            // Retours des restaurant convertie en DTO.
            return restaurants.Select(r => _mapper.Map<RestaurantSimpleDto>(r)).ToList();
        }

        /// <summary>
        /// Retourne la liste des plats servis dans un restaurant.
        /// </summary>
        /// <param name="id">Identifiant du restaurant.</param>
        /// <returns>Liste des plats en dto</returns>
        public async Task<List<MealDto>?> GetListPlatsRestaurant(int id)
        {
            // Recherche du restaurant.
            Restaurant restaurant = await _context.Restaurants.Include(c => c.Meals).FirstOrDefaultAsync(m => m.Id == id);

            // Retours des plats convertie en DTO.
            return restaurant?.Meals?.Select(m => _mapper.Map<MealDto>(m)).ToList();
        }

        /// <summary>
        /// Ajout un restaurants et revoie une respnse à l'utilisateur dernier à l'utilisateur.
        /// </summary>
        /// <param name="restaurantDto"></param>
        /// <returns></returns>
        public async Task<ResponseDto> AddRestaurant(RestaurantSimpleDto restaurantToSaveDto)
        {
            Restaurant restaurantDb = null;
            try
            {
                // Convertion DTO automatique.
                restaurantDb = _mapper.Map<Restaurant>(restaurantToSaveDto);

                // Ajout du restaurant au context.
                _context.Restaurants.Add(restaurantDb);

                // Sauvegarde du context.
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return new ResponseDto() { Success = false, Message = $"Une erreure est survenu : {ex.Message}" };
            }
            return new ResponseDto() { Success = true, Message = $"Restaurant enregistré avec succè. Id : {restaurantDb?.Id}" };
        }

        /// <summary>
        /// Vérifie si le plat existe bien sur www.themealdb.com et l'enregistre/update en base. Fait en suite la liaison avec le restaurant en fonction de 
        /// l'id en entré.
        /// </summary>
        /// <param name="id">Id du restaurant.</param>
        /// <param name="addMealDto">Plat à jouter à la liste des plats du restaurants.</param>
        /// <returns>La liste complète des plats du restaurants.</returns>
        public async Task<ResponseDto> AddPlat(int id, AddMealDto addMealDto)
        {
            // Récupéation du plat avec css plats liées.
            Restaurant restaurant = await _context.Restaurants.Include(c => c.Meals).FirstOrDefaultAsync(m => m.Id == id);

            // Si le restaurant n'existe pas alors on renvoit un message d'erreur.
            if (restaurant == null)
            {
                return new ResponseDto() { Success = false, Message = "Restaurant inconnus" };
            }

            // Vérification de la données envoyées grace à l'API www.themealdb.com.
            MealService.MealService mealService = new MealService.MealService(new HttpClient() { BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/") });

            // Récupération du plat exacte via l'api www.themealdb.com.
            MealDto mealDto = await mealService.GetMealById(addMealDto.IdMealAPI);

            // Si le plat existe sur l'API alors on l'enregistre en base.
            if (mealDto is not null)
            {
                try
                {
                    // Vérifiation existance en base.
                    Meal mealEnbase = await _context.Meals.FirstOrDefaultAsync(m => m.IdMealAPI == mealDto.IdMealAPI);

                    // Si le plat n'est pas enregistré alors on le créer.
                    if (mealEnbase is null)
                    {
                        mealEnbase = _mapper.Map<Meal>(mealDto);
                        _context.Meals.Add(mealEnbase);
                    }
                    // Si le plat exite déjà alors on le mets à jour.
                    else
                    {
                        // Update le plat en base a partir de la DTO.
                        _mapper.Map(mealDto, mealEnbase);
                    }

                    // sauvegarde en base.
                    await _context.SaveChangesAsync();

                    // Ajout du plats à la liste des plats servis par le restaurant.
                    if (!restaurant.Meals.Contains(mealEnbase))
                    {
                        restaurant.Meals.Add(mealEnbase);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    return new ResponseDto() { Success = false, Message = ex.Message };
                }
            }
            else
            {
                return new ResponseDto() { Success = false, Message = "Le plat n'existe pas sur l'api www.themealdb.com." };
            }

            return new ResponseDto() { Success = true, Message = $"Le plat a été ajouté à la liste des plats du restaurant {restaurant.Name}." }; ;
        }
        
    }
}
