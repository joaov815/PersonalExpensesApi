using AutoMapper;
using PersonalExpensesApi.Dtos;
using PersonalExpensesApi.Models;

namespace PersonalExpensesApi.Profiles;

public class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        CreateMap<CreateExpenseDto, Expense>();
        CreateMap<UpdateExpenseDto, Expense>().ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}
