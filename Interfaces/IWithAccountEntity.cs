using PersonalExpensesApi.Models;

namespace PersonalExpensesApi.Interfaces;

public interface IWithAccountEntity : IBaseEntity
{
    public string? AccountId { get; set; }
    public Account? Account { get; set; }
}
