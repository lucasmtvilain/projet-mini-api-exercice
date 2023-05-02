global using Microsoft.EntityFrameworkCore;
global using projet_mini_api.Models;
using Microsoft.Extensions.DependencyInjection;
using projet_mini_api.Data;
using projet_mini_api.ExtensionBuilder;
using projet_mini_api.Models.Settings;
using projet_mini_api.Services.MealService;
using projet_mini_api.Services.RestaurantServices;


var builder = WebApplication.CreateBuilder(args);


// Gestion de l'application setting
builder.Host.ConfigureAppSettings();

// Récupération des settings.
DataBaseSettings dataBasesettings = builder.Configuration.GetRequiredSection("ConnectionStrings").Get<DataBaseSettings>();
UrlSettings urlsettings = builder.Configuration.GetRequiredSection("Urlsettings").Get<UrlSettings>();



// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Service d'automapping pour tout le projet.
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Définie l'implémentation des interfaces pour chaque services.
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IRestaurantServices, RestaurantServices>();

// Met en place le context de connexion à la bdd en fonction des infos du appsettings.json.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(dataBasesettings.DefaultConnection));


// Définie l'implémenation de Meal service par defaut.
builder.Services.AddHttpClient<IMealService, MealService>(httpClient =>
{    
    httpClient.BaseAddress = new Uri(urlsettings.BaseURLTheMealDb);
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
