using Test2.Application.DTOs;

namespace Test2.Application.Interfaces;

public interface ICustomerService
{
    Task<CustomerPurchasesDto?> GetCustomerPurchasesAsync(int id);
}