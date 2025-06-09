using Test2.Domain.Models;

namespace Test2.Domain.Interfaces;

public interface IAvailableProgramRepository
{
    Task AddAsync(AvailableProgram program);
    Task AddRangeAsync(List<AvailableProgram> programs);
}