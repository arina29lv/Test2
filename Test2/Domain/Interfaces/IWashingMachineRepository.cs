using Test2.Domain.Models;

namespace Test2.Domain.Interfaces;

public interface IWashingMachineRepository
{
    Task<bool> ExistsBySerialNumberAsync(string serialNumber);
    Task AddAsync(WashingMachine washingMachine);
}