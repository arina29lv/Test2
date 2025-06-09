using Test2.Domain.Interfaces;
using Test2.Domain.Models;
using Test2.Infrastructure.Persistence;

namespace Test2.Infrastructure.Repositories;

public class AvailableProgramRepository : IAvailableProgramRepository
{
    private readonly AppDbContext _context;

    public AvailableProgramRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AvailableProgram program)
    {
        await _context.AvailablePrograms.AddAsync(program);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(List<AvailableProgram> programs)
    {
        await _context.AvailablePrograms.AddRangeAsync(programs);
        await _context.SaveChangesAsync();
    }
}