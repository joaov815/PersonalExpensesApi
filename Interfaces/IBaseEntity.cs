namespace PersonalExpensesApi.Interfaces;

public interface IBaseEntity
{
    public string? Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
