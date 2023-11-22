using System.Text;
using carstocks.Repository;
using carstocks.services;
using carstocks.Swagger;
using carstocks.utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;


var builder = WebApplication.CreateBuilder(args);
ConfigurationManager config = builder.Configuration;
builder.Services.AddSingleton(typeof(ConfigurationManager), config);
builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("SameDealerPolicy", policy =>
        {
            policy.Requirements.Add(new SameDealerRequirement());
        });
    });
builder.Services.AddScoped<IAuthorizationHandler, SameDealerHandler>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = config["JwtSettings:Issuer"],
        ValidateIssuer = true,
        ValidAudience = config["JwtSettings:Audience"],
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]))
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>,ConfigureSwaggerOptions>();
builder.Services.AddSingleton<ICarService, CarService>();
builder.Services.AddSingleton<ICarRepository, CarRepositoryMemory>();
builder.Services.AddSingleton(typeof(JwtTokenGenerator), new JwtTokenGenerator(config));
var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
