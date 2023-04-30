using projet_mini_api.Dto;

namespace projet_mini_api.Services.MealService
{
    public interface IMealService
    {
        Task<MealDto> GetMealById(int id);

        Task<MealDtoApi> GetMealByName(string name);
    }
}
