using Test2.Application.DTOs;
using OneOf;
using Test2.Application.Results;

namespace Test2.Application.Interfaces;

public interface IWashingMachineService
{
    Task<OneOf<WashingMachineProgramsDto, ProgramDoesNotExist, ProgramPriceIsIncorrect, WashingMachineExists, WashingMachineWeightIsIncorrect>> AddWashingMachineWithProgramsAsync(AddWashingMachineRequest request);
}