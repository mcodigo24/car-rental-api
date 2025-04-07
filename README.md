# Car Rental API

This is the API for the car rental system, built with .NET 8 and using SQL Server as the database engine.

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (local or remote)
- A code editor like Visual Studio, Rider, or VS Code

## Getting Started

1. Clone the repository.
2. Copy the settings file: cp appsettings.example.json appsettings.json
3. Edit the new `appsettings.json` file and replace the connection string with your own SQL Server configuration.
4. Apply the database migrations: update-database
5. Run the API: dotnet run
6. Once the server is running, you can test all available endpoints using Swagger at: https://localhost:44329/swagger

## Notes

- If you make changes to the data models, remember to add a new migration and update the database accordingly.
- This API is intended to work with the Angular frontend, but it can be tested independently via Swagger.
