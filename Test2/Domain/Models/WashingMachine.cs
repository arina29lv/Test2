using System.ComponentModel.DataAnnotations;

namespace Test2.Domain.Models;

public class WashingMachine
{
    [Key]
    public int WashingMachineId { get; set; }
    public decimal MaxWeight { get; set; }
    public string SerialNumber { get; set; } = string.Empty;

    public ICollection<AvailableProgram> AvailablePrograms { get; set; } = new List<AvailableProgram>();
}