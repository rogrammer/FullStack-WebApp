using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Data;
using ProjectManagementAPI.Services;
using ProjectManagementAPI.Utilities;

var builder = WebApplication.CreateBuilder(args);

// add DBContext
builder.Services.AddDbContext<TaskManagerDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// add Services
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<TaskService>();


// add Controllers
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// add Swager
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
/* 
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TaskManagerDBContext>();

    try
    {
        // 1. Apply any pending migrations
        await context.Database.MigrateAsync();

        // 2. Run the seeding method
        await DbInitializer.SeedInitialDataAsync(context);
    }
    catch (Exception ex)
    {
        // Log any errors that occur during migration or seeding
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred during database migration or seeding.");
    }
} */


// enable swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
