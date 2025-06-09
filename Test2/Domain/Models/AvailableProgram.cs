using System.ComponentModel.DataAnnotations;

namespace Test2.Domain.Models;

public class AvailableProgram
{
    [Key]
    public int AvailableProgramId { get; set; }

    public int WashingMachineId { get; set; }
    public WashingMachine WashingMachine { get; set; }

    public int ProgramId { get; set; }
    public WashingProgram Program { get; set; }

    public decimal Price { get; set; }

    public ICollection<PurchaseHistory> Purchases { get; set; } = new List<PurchaseHistory>();
}