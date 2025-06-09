namespace Test2.Application.DTOs;

public class PurchaseDto
{
    public DateTime Date { get; set; }
    public int? Rating { get; set; }
    public decimal Price { get; set; }
    public WashingMachineDto WashingMachine { get; set; }
    public ProgramDto Program { get; set; }
}