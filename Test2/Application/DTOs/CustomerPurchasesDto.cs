namespace Test2.Application.DTOs;

public class CustomerPurchasesDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    public List<PurchaseDto> Purchases { get; set; } = new();
}