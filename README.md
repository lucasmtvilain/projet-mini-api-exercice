# projet-mini-api-exercice
Excercice api dotnet core


Une fois le projet ouvert dans Visual Studio 2022, lancez la commande suivante dans la console de gestionnaire de package : 

PM> cd .\projet-mini-api

Si les vairables d'environnement sont configurées dans votre Visual studio 2022, allez modifier la configuration de la base de données dans appsettings.Development.json
si ce n'est pas le cas modifiez la configuration dans appsettings.json. Les informations a modifiées sont dans le noeud suivant : 

"ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQL2K19;Database=projet_mini_api;Trusted_Connection=true;TrustServerCertificate=true;"
  }
  
Une fois la configuration de la base établie, lancez la commande suivante dans la console de gestionnaire de package : 

PM> dotnet ef database update

Cette commande va créer la base de données sur votre instance de SqlServer configurée dans le DefaultConnection du appsettings.json. Si la commande "dotnet ef" est inconnue, suivez les
inscrtuctions du document "Documentation excercice API themealdb.docx".