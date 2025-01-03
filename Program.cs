using InteriorDesign.Context;
using InteriorDesign.Utils;
using InteriorDesign.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InteriorDesignDbContext>(options =>
{
    string Env = "";
    if (builder.Environment.IsDevelopment())
    {
        Env = "Development";
    }
    else if (builder.Environment.IsStaging())
    {
        Env = "Staging";
    }
    else if (builder.Environment.IsProduction())
    {
        Env = "Production";
    }
    options.UseSqlServer(ConnectionStringProvider.GetConnectionString(Env, "InteriorDesign"));
}, ServiceLifetime.Transient);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IAuthService, AuthService>();
//builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<TokenAuthorizationAttribute>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
