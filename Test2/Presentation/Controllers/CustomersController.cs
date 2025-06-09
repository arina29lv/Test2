using Microsoft.AspNetCore.Mvc;
using Test2.Application.Services;

namespace Test2.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _service;

    public CustomersController(CustomerService service)
    {
        _service = service;
    }

    [HttpGet("{id}/purchases")]
    public async Task<IActionResult> GetPurchases(int id)
    {
        var result = await _service.GetCustomerPurchasesAsync(id);
        return result == null ? NotFound(new {error = "Customer not found."}) : Ok(result);
    }
}