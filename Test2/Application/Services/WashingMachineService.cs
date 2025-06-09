using Test2.Application.DTOs;
using Test2.Application.Interfaces;
using Test2.Application.Results;
using Test2.Domain.Interfaces;
using Test2.Domain.Models;
using OneOf;

namespace Test2.Application.Services;

public class WashingMachineService : IWashingMachineService
{
    private readonly IWashingMachineRepository _washingMachineRepository;
    private readonly IProgramRepository _programRepository;
    private readonly IAvailableProgramRepository _availableProgramRepository;

    public WashingMachineService(
        IWashingMachineRepository washingMachineRepository,
        IProgramRepository programRepository,
        IAvailableProgramRepository availableProgramRepository)
    {
        _washingMachineRepository = washingMachineRepository;
        _programRepository = programRepository;
        _availableProgramRepository = availableProgramRepository;
    }

    public async Task<OneOf<WashingMachineProgramsDto, ProgramDoesNotExist, ProgramPriceIsIncorrect, WashingMachineExists, WashingMachineWeightIsIncorrect>> AddWashingMachineWithProgramsAsync(AddWashingMachineRequest request)
    {
        if (request.WashingMachine.MaxWeight < 8)
            return new WashingMachineWeightIsIncorrect();
        
        var exists = await _washingMachineRepository.ExistsBySerialNumberAsync(request.WashingMachine.SerialNumber);
        if (exists)
            return new WashingMachineExists();
        
        if (request.AvailablePrograms.Any(p => p.Price > 25))
            return new ProgramPriceIsIncorrect();
        
        var programNames = request.AvailablePrograms.Select(p => p.ProgramName).ToList();
        var existingPrograms = await _programRepository.GetByNamesAsync(programNames);
        if (existingPrograms.Count != programNames.Count)
            return new ProgramDoesNotExist();
        
        var machine = new WashingMachine
        {
            SerialNumber = request.WashingMachine.SerialNumber,
            MaxWeight = request.WashingMachine.MaxWeight
        };
        await _washingMachineRepository.AddAsync(machine);
        
        var availableProgramsToAdd = request.AvailablePrograms
            .Select(dto => new AvailableProgram
            {
                ProgramId = existingPrograms.First(p => p.Name == dto.ProgramName).ProgramId,
                WashingMachineId = machine.WashingMachineId,
                Price = dto.Price
            }).ToList();

        await _availableProgramRepository.AddRangeAsync(availableProgramsToAdd);

        
        return new WashingMachineProgramsDto
        {
            SerialNumber = machine.SerialNumber,
            MaxWeight = machine.MaxWeight,
            AvailablePrograms = request.AvailablePrograms
        };
    }
}