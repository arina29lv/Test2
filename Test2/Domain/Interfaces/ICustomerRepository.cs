using Test2.Domain.Models;

namespace Test2.Domain.Interfaces;

public interface ICustomerRepository
{
    Task<Customer?> GetCustomerPurchasesAsync(int customerId);
}