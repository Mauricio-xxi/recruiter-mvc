# RecruiterApp

RecruiterApp is an ASP.NET Core MVC application for managing candidate information, including experiences. This project uses SQL Server for data storage.

## Table of Contents

- [Requirements](#requirements)
- [Setup](#setup)
- [Configuration](#configuration)
- [Build and Run](#build-and-run)
- [Database Migration](#database-migration)
- [Running Tests](#running-tests)
- [Project Structure](#project-structure)

## Requirements

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Setup

1. Clone the repository:

   ```sh
   git clone https://github.com/your-username/RecruiterApp.git
   cd RecruiterApp
   ```

2. Restore the dependencies:
   ```sh
   dotnet restore
   ```

## Configuration

1. Configure the connection string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=your_sql_server;Database=RecruiterAppDb;User Id=your_user;Password=your_password;"
     }
   }
   ```

## Build and Run

1. Build the project:

   ```sh
   dotnet build
   ```

2. Run the application:

   ```sh
   dotnet run --project src/RecruiterApp.Api/RecruiterApp.Api.csproj
   ```

   The application should now be running on `https://localhost:5001`.

## Database Migration

1. Add a new migration:

   ```sh
   dotnet ef migrations add InitialCreate --project src/RecruiterApp.Infrastructure/ --startup-project src/RecruiterApp.Api/
   ```

2. Update the database:
   ```sh
   dotnet ef database update --project src/RecruiterApp.Infrastructure/ --startup-project src/RecruiterApp.Api/
   ```

## Running Tests

Run the tests using the following command:

```sh
dotnet test
```

## Project Structure

The project structure is as follows:

```
RecruiterApp/
│
├── src/
│   ├── RecruiterApp.Api/
│   │   ├── Controllers/
│   │   ├── Models/
│   │   ├── Views/
│   │   ├── wwwroot/
│   │   ├── appsettings.json
│   │   ├── Program.cs
│   │   └── Startup.cs
│   │
│   ├── RecruiterApp.Application/
│   │   ├── CreateCandidate/
│   │   ├── DeleteCandidate/
│   │   ├── GetCandidate/
│   │   ├── GetCandidatesList/
│   │   ├── UpdateCandidate/
│   │   └── Application.csproj
│   │
│   ├── RecruiterApp.Domain/
│   │   ├── Entities/
│   │   ├── Interfaces/
│   │   └── Domain.csproj
│   │
│   ├── RecruiterApp.Infrastructure/
│   │   ├── Contexts/
│   │   ├── Repositories/
│   │   ├── Migrations/
│   │   └── Infrastructure.csproj
│   │
│   └── RecruiterApp.Tests/
│       ├── Application/
│       ├── Infrastructure/
│       └── Tests.csproj
│
└── RecruiterApp.sln
```
