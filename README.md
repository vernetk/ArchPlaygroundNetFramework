Pour pouvoir exécuter la migration il faut:
1. Mettre en projet de démarrage AppServer
2. Mettre en projet par défaut DAlEfNetStandard
3. avoir .net core 3.1 installé
4. Exécuter la commande "dotnet ef database update" dans la console du gestionnaire de package


Add-Migration InitialCreate -o Migrations
Update-Database
Remove-Migration