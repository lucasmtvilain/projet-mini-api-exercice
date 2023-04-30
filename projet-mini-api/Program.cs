global using Microsoft.EntityFrameworkCore;
global using projet_mini_api.Models;
using projet_mini_api.Data;
using projet_mini_api.Services.MealService;
using projet_mini_api.Services.RestaurantServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Définie l'implémentation des interfaces pour chaque services.
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IRestaurantServices, RestaurantServices>();

// Met en place le context de connexion à la bdd en fonction des infos du appsettings.json.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Définie l'implémenation de Meal service par defaut pour tout le projet.
builder.Services.AddHttpClient<IMealService, MealService>(httpClient =>
{    
    httpClient.BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/");
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
