using Microsoft.EntityFrameworkCore;
using Test2.Domain.Interfaces;
using Test2.Domain.Models;
using Test2.Infrastructure.Persistence;

namespace Test2.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Customer?> GetCustomerPurchasesAsync(int customerId)
    {
        return await _context.Customers
            .Include(c => c.Purchases)
            .ThenInclude(p => p.AvailableProgram)
            .ThenInclude(ap => ap.Program)
            
            .Include(c => c.Purchases)
            .ThenInclude(p => p.AvailableProgram)
            .ThenInclude(ap => ap.WashingMachine)
            
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);
    }
}