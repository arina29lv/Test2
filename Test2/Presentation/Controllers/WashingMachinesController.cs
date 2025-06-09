using Microsoft.AspNetCore.Mvc;
using Test2.Application.DTOs;
using Test2.Application.Interfaces;

namespace Test2.Presentation.Controllers;

[ApiController]
[Route("washing-machines")]
public class WashingMachinesController : ControllerBase
{
    private readonly IWashingMachineService _service;

    public WashingMachinesController(IWashingMachineService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddWashingMachine([FromBody] AddWashingMachineRequest request)
    {
        var result = await _service.AddWashingMachineWithProgramsAsync(request);

        return result.Match<IActionResult>(
            _ => CreatedAtAction(nameof(AddWashingMachine), result),
            _ => NotFound(new { error = "Program not found." }),
            _ => BadRequest(new { error = "Program price is not valid." }),
            _ => BadRequest(new { error = "Washing machine is already added." }),
            _ => BadRequest(new { error = "Washing Machine weight is incorrect" })
        );
    }
}