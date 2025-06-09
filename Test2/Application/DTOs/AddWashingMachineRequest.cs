namespace Test2.Application.DTOs;

public class AddWashingMachineRequest
{
    public WashingMachineDto WashingMachine { get; set; }
    public List<AvailableProgramDto> AvailablePrograms { get; set; }
}