using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using PersonalExpensesApi.Data;
using PersonalExpensesApi.Models;

namespace PersonalExpensesApi.Middlewares;

public class EnsureUserMiddleware(RequestDelegate next, IServiceScopeFactory serviceScopeFactory)
{
    private readonly RequestDelegate _next = next;
    private readonly IServiceScopeFactory _serviceScopeFactory = serviceScopeFactory;

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var keycloakId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = context.User.FindFirst(ClaimTypes.Email)?.Value;
            var username = context.User.Identity?.Name ?? "UnknownUser";

            using var scope = _serviceScopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            if (string.IsNullOrEmpty(keycloakId))
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                return;
            }

            var account = await dbContext.Accounts.FirstOrDefaultAsync(a =>
                a.KeycloakId == keycloakId
            );

            if (account == null)
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

            context.Items["CurrentAccount"] = account;
        }

        await _next(context);
    }
}
