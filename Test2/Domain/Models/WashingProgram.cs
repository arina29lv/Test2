using System.ComponentModel.DataAnnotations;

namespace Test2.Domain.Models;

public class WashingProgram
{
    [Key]
    public int ProgramId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public int TemperatureCelsius { get; set; }

    public ICollection<AvailableProgram> AvailablePrograms { get; set; } = new List<AvailableProgram>();
}