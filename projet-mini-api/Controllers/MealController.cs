using Microsoft.AspNetCore.Mvc;
using projet_mini_api.Dto;
using projet_mini_api.Models;
using projet_mini_api.Services.MealService;

namespace projet_mini_api.Controllers
{

    [ApiController] //attribut qui permet de traité la class comme http api response
    [Route("api/[controller]")]//Spécifie la route à utilisé pour appler le contrôleur    
    public class MealController : ControllerBase
    {
        /// <summary>
        /// Class de ervices des meals.
        /// </summary>
        private readonly IMealService _mealService;

        /// <summary>
        /// Constructeur.
        /// </summary>
        /// <param name="mealService">Service de la classe meal implémenté dans le builder.Services.AddScoped</param>
        public MealController(IMealService mailService)
        {
            _mealService = mailService;
        }

        /// <summary>
        /// Affiche directement les données d'un plat depuis l'API www.themealdb.com. Utile pour afficher le détail d'un plat
        /// </summary>
        /// <param name="id">IdMail du plat sur l'API.</param>
        /// <returns>Le plat associé à l'id meal.</returns>

        [HttpGet("id/{id}")]
        public async Task<ActionResult<MealDto>> GetMealById(int id)
        {
            MealDto meal;
            meal = await _mealService.GetMealById(id);
            if (meal is null)
                return NotFound("Meal not found.");

            return Ok(meal);
        }

        /// <summary>
        /// Affiche directement les données d'un plat depuis l'API www.themealdb.com. Utile pour afficher le détail d'un plat
        /// </summary>
        /// <param name="name">Nom du plat à rechrcher.</param>
        /// <returns>Le plat associé à l'id meal.</returns>
        [HttpGet("name/{name}")]
        public async Task<ActionResult<MealDtoApi>> GetMealByName(string name)
        {
            MealDtoApi listMeal;
            listMeal = await _mealService.GetMealByName(name);

            if (listMeal is null)
                return NotFound("Meals not found.");
            return Ok(listMeal);
        }
    }
}
