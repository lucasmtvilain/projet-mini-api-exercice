namespace projet_mini_api.Dto
{
    public static class MealDtoExtension
    {
        public static MealDto? ToSigleDto(this MealDtoApi mailDtoApi)
        {
            if (mailDtoApi is not null
                && mailDtoApi.Meals is not null
                && mailDtoApi.Meals.Any())
            {
                return mailDtoApi.Meals.FirstOrDefault();
            }
            return null;
        }
    }
}
