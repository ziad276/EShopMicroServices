using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
// Creates a new WebApplication builder, setting up configuration, logging, DI container, etc.

var builder = WebApplication.CreateBuilder(args);

// Gets the assembly (DLL) that contains the Program class — used for scanning types.
var assembly = typeof(Program).Assembly;


// Adds MediatR and registers all handlers, requests, and notifications from the given assembly.
// Also adds a pipeline behavior (ValidationBehavior) for centralizing validation logic.
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

// Registers all FluentValidation validators found in this assembly.
builder.Services.AddValidatorsFromAssembly(assembly);

// Adds Carter — a minimal API framework for building modular endpoints.
builder.Services.AddCarter();

// Configures Marten (PostgreSQL document store/ORM) using the connection string from config.
// Uses lightweight sessions (no identity tracking for faster reads).
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();
if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();

// Registers a custom exception handler for global error handling.
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks().
    AddNpgSql(builder.Configuration.GetConnectionString("Database")!);

// Builds the application pipeline and service container.
var app = builder.Build();

// Maps Carter endpoints into the request pipeline.
app.MapCarter();

// Configures built-in exception handling middleware.
// Currently empty — can be used to customize error responses if desired.
app.UseExceptionHandler(options =>{ });

app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

// Starts the application and begins listening for incoming HTTP requests.
app.Run();
