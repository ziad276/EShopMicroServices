
var builder = WebApplication.CreateBuilder(args);

// Add Services Container
var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));

});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);// Use the connection string named "Database" from appsettings.json to connect Marten to PostgreSQL
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName); // Use UserName as the identity for ShoppingCart
}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>(); // Register the BasketRepository as a scoped service

var app = builder.Build();

// Configure the HTTP request pipeline

app.MapCarter(); // Registers all Carter modules

app.Run();
