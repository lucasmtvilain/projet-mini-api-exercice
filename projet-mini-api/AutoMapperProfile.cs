namespace projet_mini_api
{
    using AutoMapper;
    using projet_mini_api.Dto;

    /// <summary>
    /// Classe qui configure les mapping de DTO pour tous le projet.
    /// </summary>

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<RestaurantDto, Restaurant>();
            CreateMap<Restaurant, RestaurantSimpleDto>();
            CreateMap<RestaurantSimpleDto, Restaurant>();
            CreateMap<MealDto, Meal>();
            CreateMap<Meal, MealDto>();
        }
    }
}
