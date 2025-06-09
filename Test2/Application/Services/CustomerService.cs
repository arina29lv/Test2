using Test2.Application.DTOs;
using Test2.Application.Interfaces;
using Test2.Domain.Interfaces;

namespace Test2.Application.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerPurchasesDto?> GetCustomerPurchasesAsync(int id)
    {
        var customer = await _repository.GetCustomerPurchasesAsync(id);
        if (customer == null) return null;

        return new CustomerPurchasesDto
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            PhoneNumber = customer.PhoneNumber,
            Purchases = customer.Purchases.Select(p => new PurchaseDto
            {
                Date = p.PurchaseDate,
                Rating = p.Rating,
                Price = p.AvailableProgram.Price,
                Program = new ProgramDto
                {
                    Name = p.AvailableProgram.Program.Name,
                    Duration = p.AvailableProgram.Program.DurationMinutes
                },
                WashingMachine = new WashingMachineDto
                {
                    SerialNumber = p.AvailableProgram.WashingMachine.SerialNumber,
                    MaxWeight = p.AvailableProgram.WashingMachine.MaxWeight
                }
            }).ToList()
        };
    }
}