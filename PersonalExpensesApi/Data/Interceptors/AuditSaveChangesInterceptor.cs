using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PersonalExpensesApi.Data.EntityListeners;
using PersonalExpensesApi.Interfaces;

namespace PersonalExpensesApi.Data.Interceptors;

public class AuditingSaveChangesInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result
    )
    {
        Apply(eventData);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default
    )
    {
        Apply(eventData);

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void Apply(DbContextEventData eventData)
    {
        DbContext? dbContext = eventData.Context;

        foreach (EntityEntry? entry in dbContext?.ChangeTracker.Entries() ?? [])
        {
            if (
                new[] { EntityState.Added, EntityState.Modified }.Contains(entry.State)
                && entry.Entity is IBaseEntity auditable
            )
            {
                if (entry.State == EntityState.Added)
                {
                    ExecuteEntityListeners(auditable, typeof(BeforeInsertAttribute));
                }
                else if (entry.State == EntityState.Modified)
                {
                    ExecuteEntityListeners(auditable, typeof(BeforeUpdateAttribute));
                }
            }
        }
    }

    private static void ExecuteEntityListeners(IBaseEntity entity, Type listener)
    {
        entity
            .GetType()
            .GetMethods()
            .Where(method => method.GetCustomAttributes(listener, false).Length != 0)
            .ToList()
            .ForEach(method => method.Invoke(entity, null));
    }
}
