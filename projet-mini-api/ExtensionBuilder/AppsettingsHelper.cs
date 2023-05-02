namespace projet_mini_api.ExtensionBuilder
{
    /// <summary>
    /// Helper de gestion de configuration.
    /// </summary>
    public static class AppsettingsHelper
    {
        /// <summary>
        /// Configuration des variables du AppSetting.
        /// </summary>
        /// <param name="host">Builder de l'application.</param>
        /// <returns>Builder avec la configuration du appSetting.</returns>
        public static IHostBuilder ConfigureAppSettings(this IHostBuilder host)
        {
            // Récupération du type de l'enrionnement.
            var enviroment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            host.ConfigureAppConfiguration((context, builder) =>
            {
                builder.AddJsonFile("appsettings.json", false, true);
                builder.AddJsonFile($"appsettings.{enviroment}.json", true, true);
                builder.AddEnvironmentVariables();
            });

            return host;
        }
    }
}
