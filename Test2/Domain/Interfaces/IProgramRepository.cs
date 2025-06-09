using Test2.Domain.Models;

namespace Test2.Domain.Interfaces;

public interface IProgramRepository
{
    Task<List<WashingProgram>> GetByNamesAsync(List<string> names);
}