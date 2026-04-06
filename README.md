# Task Orchestrator

A professional-grade Task Management API built with **.NET 10**, demonstrating high-level architectural patterns used in enterprise environments.

## Architecture
This project follows **Clean Architecture** (Onion Architecture) principles to ensure high maintainability and testability:
- **Domain:** Core entities and business logic (Zero dependencies).
- **Application:** Use cases, interfaces, and DTOs.
- **Infrastructure:** Data persistence (EF Core, SQLite) and external services (Hangfire).
- **API:** Minimal controllers acting as the entry point.

## Key Features
- **Clean Architecture:** Strict separation of concerns between layers.
- **Background Orchestration:** Integrated **Hangfire** to handle asynchronous tasks outside the request lifecycle.
- **Database Management:** Used EF Core Migrations for version-controlled database schema.
- **API Documentation:** Fully interactive **Swagger/OpenAPI** UI.

## Tech Stack
- **Backend:** .NET 10, C#
- **Database:** SQLite with Entity Framework Core
- **Tooling:** Hangfire (Background Jobs), xUnit (Testing), Swashbuckle (Swagger)

## Getting Started
1. Clone the repo.
2. Run `dotnet ef database update --project TaskOrchestrator.Infrastructure --startup-project TaskOrchestrator.Api`.
3. Run `dotnet run --project TaskOrchestrator.Api`.
4. Navigate to `/swagger` to explore the API.