using ESA.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SEA.Data.ContextConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Bind DatabaseOptions from configuration (appsettings.json or other sources)
builder.Services.Configure<DatabaseOptions>(builder.Configuration.GetSection("DatabaseOptions"));

builder.Services.AddRepositories();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Apply migrations conditionally based on the environment
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SeaDbContext>();
    var env = app.Environment;

    if (env.IsDevelopment())
    {
        try
        {
            context.Database.Migrate(); // Applies pending migrations
        }
        catch (Exception ex)
        {
            // Log errors here, e.g., using ILogger
            throw;
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
