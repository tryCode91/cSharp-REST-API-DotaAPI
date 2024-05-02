Steps to run the project
1. Download the git repository
2. Open SMSS and create a database "dota"
3. Open the dota solution file with visual studio
4. Enter your connection string in the appsettings.json
5. Open terminal and write:
-dotnet ef migrations add InitialCreate (creates a migration)
-dotnet ef database update (creates tables)
-dotnet run seeddata (seeds the database with some data)

I hope you liked this API :)

Let me know if there is anything that needs to be changed.
