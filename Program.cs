using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PersonalExpensesApi.Data;
using PersonalExpensesApi.Extensions;
using PersonalExpensesApi.Middlewares;
using PersonalExpensesApi.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGenWithAuth(configuration);

// Add automapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<ExpenseService, ExpenseService>();

// Add authentication
builder
    .Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false; // Disable in dev
        options.Audience = configuration["Authentication:Audience"];
        options.MetadataAddress = configuration["Authentication:MetadataAddress"]!;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = configuration["Authentication:ValidIssuer"],
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.WebHost.UseUrls($"http://0.0.0.0:{configuration["PORT"] ?? "8090"}");

var app = builder.Build();

app.UseAuthentication();
app.UseMiddleware<EnsureUserMiddleware>();
app.UseAuthorization();
app.MapControllers();

// app.UseHttpsRedirection();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "swagger"; // Ensures Swagger opens at the root
    });
}

app.Run();
