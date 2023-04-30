using projet_mini_api.Dto;

namespace projet_mini_api.Services.RestaurantServices
{
    public interface IRestaurantServices
    {
        Task<List<RestaurantSimpleDto>> GetAllRestaurant();
        Task<List<MealDto?>> GetListPlatsRestaurant(int id);
        Task<ResponseDto> AddRestaurant(RestaurantSimpleDto restaurantDto);
        Task<ResponseDto> AddPlat(int id, AddMealDto addMealDto);
    }
}
