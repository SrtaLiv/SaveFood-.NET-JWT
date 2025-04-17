using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyConsoleApp.Services;
using Primer.Proyecto.Bd;
using Primer.Proyecto.Models;
using Primer.Proyecto.Repositories;
using Primer.Proyecto.Services;

var builder = WebApplication.CreateBuilder(args);

// JWT 
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero // Opcional: reduce tolerancia de expiración
        };
    });

// Agrega Autorizacion
builder.Services.AddAuthorization();

// Agregar el DbContext al contenedor de servicios
builder.Services.AddDbContext<BloggingContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("MySqlConnection"), 
        new MySqlServerVersion(new Version(8, 0, 29))
    ));

builder.Services.AddControllers();

// Agregar servicios y repositorios
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<IFoodRepository, FoodRepository>();

// Configuración Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
app.Run();