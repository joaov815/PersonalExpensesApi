using AutoMapper;
using PersonalExpensesApi.Data;
using PersonalExpensesApi.Dtos;
using PersonalExpensesApi.Models;

namespace PersonalExpensesApi.Services;

public class PaymentKindService(AppDbContext context, IMapper mapper)
    : CrudService<PaymentKind, PaymentKind, PaymentKind>(context, mapper) { }
