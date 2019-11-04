# DemoGenesis
WebApi in .NET

- Create migration
dotnet ef migrations add InitialCreate -p ContactsApi/ContactsApi.csproj

- Apply migration
dotnet ef database update -p ContactsApi/ContactsApi.csproj

- Run tests
dotnet test ./DemoGenesis.sln 

- Run API project
dotnet run ./ContactsApi/ContactsApi.csproj 


Open Swagger page in browser:  https://localhost:5001/swagger/


To do:
 - transform Address class as Owned Entity Types: https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities
 - use AutoMapper to separate DB model from API model
 - return IActionResult instead of actual objects.
 - add some tests. I only verified with Swagger.