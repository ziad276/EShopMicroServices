# Entity Framework Migrations for Ordering Service

## Quick Commands

### Using dotnet CLI (Recommended)

Navigate to the `src\Services\Ordering` directory and run:

**Add Migration:**
```powershell
cd src\Services\Ordering
dotnet ef migrations add <MigrationName> --project Ordering.Infrastructure\Ordering.Infrastructure.csproj --startup-project Ordering.API\Ordering.API.csproj --output-dir Data\Migrations
```

**Update Database:**
```powershell
cd src\Services\Ordering
dotnet ef database update --project Ordering.Infrastructure\Ordering.Infrastructure.csproj --startup-project Ordering.API\Ordering.API.csproj
```

**List Migrations:**
```powershell
cd src\Services\Ordering
dotnet ef migrations list --project Ordering.Infrastructure\Ordering.Infrastructure.csproj --startup-project Ordering.API\Ordering.API.csproj
```

### Using Package Manager Console

If using Visual Studio Package Manager Console, make sure you're in the `src` directory (where `eshop-microservices.sln` is located):

```powershell
Update-Database -Project Ordering.Infrastructure -StartupProject Ordering.API
```

**Note:** If you encounter SDK toolset errors in Package Manager Console, use the dotnet CLI instead.

## Connection String

The connection string is configured in:
- `Ordering.API\appsettings.json`
- `Ordering.API\appsettings.Development.json`

Default connection string points to:
```
Server=localhost;Database=OrderDb;User Id=sa;Password=SwN12345678;Encrypt=False;TrustServerCertificate=True
```

## Design-Time DbContext Factory

The `ApplicationDbContextFactory` class in `Ordering.Infrastructure\Data\ApplicationDbContextFactory.cs` is used by EF Core tools to create the DbContext at design time (for migrations).

