using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalExpensesApi.Models;
using PersonalExpensesApi.Services;

namespace PersonalExpensesApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public sealed class PaymentKindController(PaymentKindService paymentKindService)
    : CrudController<PaymentKind, PaymentKind, PaymentKind>(paymentKindService)
{ }
