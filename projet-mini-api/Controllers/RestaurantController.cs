using Microsoft.AspNetCore.Mvc;
using projet_mini_api.Dto;
using projet_mini_api.Services.RestaurantServices;

namespace projet_mini_api.Controllers
{
    [ApiController] //attribut qui permet de traité la class comme http api response
    [Route("api/[controller]")]//Spécifie la route à utilisé pour appeler le contrôleur    
    public class RestaurantController : ControllerBase
    {
        /// <summary>
        /// Services associé à la classe Restarants.cs.
        /// </summary>
        private readonly IRestaurantServices _restaurantServices;

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="restaurantServices">Service des restaurants implémenté dans le builder.Services.AddScoped</param>
        public RestaurantController(IRestaurantServices restaurantServices)
        {
            _restaurantServices = restaurantServices;
        }

        /// <summary>
        /// Affiche toutes les restaurants. 
        /// ActionResult permet en autre de fournir plus d'information pour le swagger que l'interface IActionResult.
        /// </summary>
        /// <returns></returns>
        [HttpGet]// Sans cet attribut la methode n'apparait pas dans le swagger.
        public async Task<ActionResult<List<RestaurantSimpleDto>>> GetAllRestaurants()
        {
            List<RestaurantSimpleDto> result = await _restaurantServices.GetAllRestaurant();
            return Ok(result);
        }

        /// <summary>
        /// Ajout d'un restaurant.
        /// </summary>
        /// <param name="restaurantToSaveDto">Restautant DTO récupéré depuis le body de la requête http.</param>
        /// <returns>Liste de toutes les restaurants après insertion.</returns>
        [HttpPost("addRestaurant")]
        public async Task<ActionResult<ResponseDto>> AddRestaurant([FromBody] RestaurantSimpleDto restaurantToSaveDto)
        {
            ResponseDto result = await _restaurantServices.AddRestaurant(restaurantToSaveDto);
            return Ok(result);
        }

        ///// <summary>
        /// Ajout d'un plat à un restaurant.
        /// </summary>
        /// <param name="restaurantSaveDto">Restautant DTO récupéré depuis le body de la requête http.</param>
        /// <returns>Liste de toutes les restaurants après insertion.</returns>
        [HttpPost("addmeal/{id}")]
        public async Task<ActionResult<ResponseDto>> AddPlat(int id, [FromBody] AddMealDto addMealDto)
        {
            ResponseDto result = await _restaurantServices.AddPlat(id, addMealDto);
            return Ok(result);
        }

        /// <summary>
        /// Renvoie la liste de tous les tous les plats du restaurant.
        /// </summary>
        /// <param name="id">Id restaurant.</param>
        /// <returns>Liste des plats.</returns>
        [HttpGet("mealsfromrestaurant/{id}")]
        public async Task<ActionResult<List<MealDto>?>> GetListPlatsRestaurant(int id)
        {
            List<MealDto> result = await _restaurantServices.GetListPlatsRestaurant(id);

            if (result is null)
                return NotFound("Restaurant not found.");

            return Ok(result);
        }
    }
}
