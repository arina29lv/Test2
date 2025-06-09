using Microsoft.EntityFrameworkCore;
using Test2.Domain.Interfaces;
using Test2.Domain.Models;
using Test2.Infrastructure.Persistence;

namespace Test2.Infrastructure.Repositories;

public class ProgramRepository : IProgramRepository
{
    private readonly AppDbContext _context;

    public ProgramRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<WashingProgram>> GetByNamesAsync(List<string> names)
    {
        return await _context.Programs
            .Where(p => names.Contains(p.Name))
            .ToListAsync();
    }
}