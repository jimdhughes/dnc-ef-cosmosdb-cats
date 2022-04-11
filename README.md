# Cats and Cosmos

## Setup

1. Add your cosmosdb connection information in `Api/appsettings.json`
2. Run with `dotnet run`
3. Go to the swagger instance and play with the API: `https://localhost:5001/swagger` by default

## Organization

1. API: The API controllers, custom DTO's and permissions layer
2. Data: Connecting to the database and setting up the repositories and database contexts
3. Domain: Entity organization
