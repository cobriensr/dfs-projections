# FantasySports Application

A full-stack fantasy sports application built with C# and .NET, featuring a Blazor frontend and ASP.NET Core Web API backend.

## Prerequisites

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/) with C# extension
- [PostgreSQL](https://www.postgresql.org/)
- Git

## Project Structure

``` bash
FantasySports/
├── FantasySports.sln              # Solution file
├── FantasySports.Api/             # ASP.NET Core Web API
├── FantasySports.Application/     # Application business logic
├── FantasySports.Core/            # Domain entities and interfaces
├── FantasySports.Infrastructure/  # Data access and external services
├── FantasySports.Web/             # Blazor frontend
├── terraform/                     # Infrastructure as Code
├── .gitignore
└── README.md
```

## Getting Started

### 1. Clone the Repository

```bash
git clone <your-repository-url>
cd FantasySports
```

### 2. Restore Dependencies

From the solution root directory, restore all NuGet packages:

```bash
dotnet restore
```

### 3. Configure the Database

#### Update Connection String

1. Navigate to `FantasySports.Api/appsettings.json`
2. Update the connection string to match your local database:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=FantasySportsDb;Trusted_Connection=true;TrustServerCertificate=true"
  }
}
```

#### Run Database Migrations

If using Entity Framework Core, run migrations to create/update the database:

```bash
# Navigate to the API project
cd FantasySports.Api

# Run migrations (if migrations exist)
dotnet ef database update

# Or create initial migration if needed
dotnet ef migrations add InitialCreate -p ../FantasySports.Infrastructure -s .
dotnet ef database update
```

## Building the Application

### Build Entire Solution

From the solution root directory:

```bash
dotnet build
```

### Build Individual Projects

```bash
# Build API
dotnet build FantasySports.Api/

# Build Web
dotnet build FantasySports.Web/
```

## Running the Application

### Option 1: Run Both Projects Simultaneously (Recommended)

#### Using Visual Studio

1. Open `FantasySports.sln` in Visual Studio
2. Right-click on the solution → Properties
3. Select "Multiple startup projects"
4. Set both `FantasySports.Api` and `FantasySports.Web` to "Start"
5. Press F5 or click "Start"

#### Using Command Line

Open two terminal windows:

**Terminal 1 - Run the API:**

```bash
cd FantasySports.Api
dotnet run
```

The API will start on `https://localhost:7XXX` and `http://localhost:5XXX` (note the ports from the output)

**Terminal 2 - Run the Web Frontend:**

```bash
cd FantasySports.Web
dotnet run
```

The Blazor app will start on `https://localhost:7YYY` and `http://localhost:5YYY`

### Option 2: Using Launch Profiles

Create a compound launch configuration:

```bash
# From solution root
dotnet run --project FantasySports.Api --launch-profile "Development" &
dotnet run --project FantasySports.Web --launch-profile "Development"
```

## Configuration

### API Configuration (appsettings.json)

Key configuration areas in `FantasySports.Api/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "your-connection-string"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "CorsOrigins": ["https://localhost:7YYY"]  // Your Blazor app URL
}
```

### Blazor Configuration

Update the API base URL in `FantasySports.Web/wwwroot/appsettings.json`:

```json
{
  "ApiBaseUrl": "https://localhost:7XXX"  // Your API URL
}
```

Or in `Program.cs`:

```csharp
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7XXX/")
});
```

## Common Issues and Solutions

### CORS Issues

If you encounter CORS errors, ensure the API is configured to accept requests from your Blazor app:

In `FantasySports.Api/Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp",
        builder => builder
            .WithOrigins("https://localhost:7YYY") // Your Blazor URL
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// After app.Build()
app.UseCors("AllowBlazorApp");
```

### Certificate Issues

For HTTPS development certificates:

```bash
dotnet dev-certs https --trust
```

### Port Conflicts

Check and modify ports in:

- `FantasySports.Api/Properties/launchSettings.json`
- `FantasySports.Web/Properties/launchSettings.json`

## Development Workflow

### Hot Reload

Both projects support hot reload:

```bash
# Run with hot reload enabled
dotnet watch run
```

### Running Tests

```bash
# Run all tests
dotnet test

# Run with coverage
dotnet test /p:CollectCoverage=true
```

## Production Deployment

### Build for Production

```bash
# Build in Release mode
dotnet publish -c Release -o ./publish
```

### Environment Variables

Set environment variables for production:

- `ASPNETCORE_ENVIRONMENT=Production`
- Update connection strings and API URLs accordingly

## Additional Commands

```bash
# Clean solution
dotnet clean

# List project references
dotnet list reference

# Add package to a project
dotnet add FantasySports.Api package Microsoft.EntityFrameworkCore.SqlServer

# Update packages
dotnet restore --force
```

## Troubleshooting

1. **API not responding**: Check if the API is running on the expected port
2. **Database connection failed**: Verify connection string and SQL Server is running
3. **Blazor can't reach API**: Check CORS configuration and API URL in Blazor settings
4. **Build errors**: Ensure all project references are correct and packages are restored
