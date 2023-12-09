using DatingApp.Extentions;
using DatingApp.Middleware;

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

app.Run();

