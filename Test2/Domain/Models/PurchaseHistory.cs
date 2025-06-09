namespace Test2.Domain.Models;

public class PurchaseHistory
{
    public int AvailableProgramId { get; set; }
    public AvailableProgram AvailableProgram { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public DateTime PurchaseDate { get; set; }
    public int? Rating { get; set; }
}