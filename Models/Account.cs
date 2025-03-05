namespace PersonalExpensesApi.Models;

public class Account : BaseEntity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string KeycloakId { get; set; }
}
