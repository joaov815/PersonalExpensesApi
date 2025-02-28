using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using PersonalExpensesApi.Data;
using PersonalExpensesApi.Models;

namespace PersonalExpensesApi.Middlewares;

public class EnsureUserMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public EnsureUserMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
    {
        _next = next;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Ensure the user is authenticated
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var keycloakId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = context.User.FindFirst(ClaimTypes.Email)?.Value;
            var username = context.User.Identity?.Name ?? "UnknownUser";

            if (!string.IsNullOrEmpty(keycloakId))
            {
                // Use a service scope to resolve the DbContext (avoids scoped dependency issues)
                using var scope = _serviceScopeFactory.CreateScope();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Check if the user exists in the database
                var userExists = await dbContext.Accounts.AnyAsync(u => u.KeycloakId == keycloakId);
                if (!userExists)
                {
                    var newUser = new Account
                    {
                        KeycloakId = keycloakId,
                        Email = email!,
                        Name = username,
                    };

                    dbContext.Accounts.Add(newUser);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        // Continue to the next middleware or request pipeline
        await _next(context);
    }
}
