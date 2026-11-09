# RaceDay – Part 2 API + Part 3 MVC application

This source package contains two separate ASP.NET Core 8 projects:

- **RaceDay.API** – REST API, SQL Server/EF Core data access, JWT authentication, role authorization, and Azure Blob Storage integration.
- **RaceDay.MVC** – Bootstrap MVC user interface. It calls the API through `ApiClient`; it contains no EF Core package, database connection, SQL, or direct Azure SDK access. The MVC app stores the API bearer token, user ID, display name and role in ASP.NET Core session.

## Requirements and implementation

- Registration and login call `POST api/auth/register` and `POST api/auth/login`.
- MVC session keeps the API token and role across requests; role-specific navigation and controller checks protect organiser and participant pages. Logout clears the session.
- Public event discovery and event detail/category display; participant enrolment, enrolment list, result history and profile update.
- Organiser dashboard, event create/edit/delete, category creation, enrolment listing and result entry.
- Event banner upload is sent by MVC to the API; the API stores it in Azure Blob Storage and persists the public blob URL on the event.
- Bootstrap responsive layout, consistent RaceDay styling and colour-coded enrolment/result statuses.
- Dockerfiles are supplied for both projects and `docker-compose.yml` runs them together.

## Run locally in VS Code

1. Install the .NET 8 SDK and SQL Server/LocalDB. Open the extracted root folder in VS Code.
2. Configure `RaceDay.API/appsettings.json` connection string and a long random JWT key. To use Azure images, set `AzureBlobStorage:ConnectionString` to your Azure Storage connection string. The container name defaults to `raceday-images`.
3. In a terminal run:
   ```bash
   cd RaceDay.API
   dotnet restore
   dotnet tool install --global dotnet-ef
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   dotnet run
   ```
4. Note the API HTTPS URL printed in the terminal. Edit `RaceDay.MVC/appsettings.json` so `ApiSettings:BaseUrl` matches it (include the trailing slash).
5. In a second terminal:
   ```bash
   cd RaceDay.MVC
   dotnet restore
   dotnet run
   ```
6. Open the MVC URL printed by the second terminal. Register an Organiser account and a Participant account to test both experiences.

The MVC API client uses the configured base URL. If the API is running on a different port, update `ApiSettings:BaseUrl` before starting MVC.

## Run with Docker

Docker Compose expects a SQL Server instance reachable at `host.docker.internal` and uses the `SA_PASSWORD` environment variable. Set `SA_PASSWORD` to a strong SQL Server SA password and optionally `AZURE_BLOB_CONNECTION` to the Azure Storage connection string. Then from the repository root run:

```bash
docker compose up --build
```

Open the MVC site at `http://localhost:8080`; the API is exposed at `http://localhost:8081`. To run only the MVC container after building, the single-container command is:

```bash
docker run --rm -p 8080:8080 -e ApiSettings__BaseUrl=http://host.docker.internal:8081/ raceday-mvc
```

The API must be running and reachable at the configured URL. The Docker setup does not create a SQL Server container; it connects to an existing SQL Server host. Apply EF migrations against that database before first use. For production, use HTTPS, managed identity/Key Vault for secrets, persistent/distributed session storage, secure cookies, and a production SQL Server service.

## Important configuration and assessment notes

- `RaceDay.API` is the only project that references EF Core and Azure Blob Storage. Do not add database/Azure SDK access to `RaceDay.MVC`.
- Azure banner upload returns a clear 503 message until a Blob Storage connection string is configured. The storage container is created by the API when the first upload occurs. Configure the container for public blob read access or use a private container plus SAS/CDN URLs before deployment.
- The current API baseline from Part 2 includes Users, Events, Categories, Enrolments and Results. Compare it with the approved Part 1 ERD; Route and WeatherForecast tables are not included in this baseline.
- The requested profile-picture upload and full organiser event/category editing are not yet fully implemented in the supplied API baseline. Profile text editing is wired. Category creation is wired; category edit/delete endpoints exist in the API but corresponding MVC screens are not yet supplied. Add these before claiming every rubric item is complete.
- The API currently returns all events to the MVC client. The organiser dashboard uses the API's organiser-scoped enrolment endpoint for its totals; event ownership is enforced by API endpoints.
- The projects have been source-generated but **not compiled or runtime-tested in this environment**, because the .NET SDK is unavailable here. Run `dotnet build` on both projects and resolve any SDK/package or environment-specific issues before submission.
