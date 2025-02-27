using System.Reflection;
using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using PersonalExpensesApi.Data.Interceptors;
using PersonalExpensesApi.Models;

namespace PersonalExpensesApi.Data;

public class AppDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseKind> ExpenseKinds { get; set; }
    public DbSet<Account> Accounts { get; set; }

    private readonly IConfiguration _configuration = configuration;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));

        optionsBuilder
            .AddInterceptors(new AuditingSaveChangesInterceptor())
            .UseExceptionProcessor();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<BaseEntity>();

        // Ensure PostgreSQL UUID Extension
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        // Unique Constraint for KeycloakId in Account
        modelBuilder.Entity<Account>().HasIndex(a => a.KeycloakId).IsUnique();
        modelBuilder.Entity<PaymentKind>().HasIndex(a => a.Code).IsUnique();
    }
}
