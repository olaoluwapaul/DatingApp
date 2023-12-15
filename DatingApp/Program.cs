using DatingApp.Data;
using DatingApp.Extentions;
using DatingApp.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);


var app = builder.Build();


    //Configure the HTTP request pipeline

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder
    .AllowAnyHeader()
    .AllowAnyMethod()
    .WithOrigins("https://localhost:4200"));

// asks if you have a valid token
app.UseAuthentication();


// ok, you have a valid token, what are you allowed to do?
app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    //var context = services.GetRequiredService<AppDbContext>();
    //await context.Database.MigrateAsync();
    //await Seed.SeedUsers(context);

    var context = services.GetRequiredService<AppDbContext>();

    if (context.Database.IsSqlite()) await context.Database.MigrateAsync();

    await Seed.SeedUsers(context);
}
catch (Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.Run();

