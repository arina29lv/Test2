using System.ComponentModel.DataAnnotations;

namespace Test2.Domain.Models;

public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }

    public ICollection<PurchaseHistory> Purchases { get; set; }
}