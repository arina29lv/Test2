using Microsoft.EntityFrameworkCore;
using Test2.Domain.Interfaces;
using Test2.Domain.Models;
using Test2.Infrastructure.Persistence;

namespace Test2.Infrastructure.Repositories;

public class WashingMachineRepository : IWashingMachineRepository
{
    private readonly AppDbContext _context;

    public WashingMachineRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ExistsBySerialNumberAsync(string serialNumber)
    {
        return await _context.WashingMachines.AnyAsync(w => w.SerialNumber == serialNumber);
    }

    public async Task AddAsync(WashingMachine washingMachine)
    {
        await _context.WashingMachines.AddAsync(washingMachine);
        await _context.SaveChangesAsync();
    }
}