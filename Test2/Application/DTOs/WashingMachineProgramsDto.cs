namespace Test2.Application.DTOs;

public class WashingMachineProgramsDto
{
    public string SerialNumber { get; set; }
    public decimal MaxWeight { get; set; }
    public List<AvailableProgramDto> AvailablePrograms { get; set; } = new();
}