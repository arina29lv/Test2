using Microsoft.EntityFrameworkCore;
using Test2.Application.Interfaces;
using Test2.Application.Services;
using Test2.Domain.Interfaces;
using Test2.Infrastructure.Persistence;
using Test2.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerService>();

builder.Services.AddScoped<IWashingMachineService, WashingMachineService>();
builder.Services.AddScoped<IWashingMachineRepository, WashingMachineRepository>();
builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
builder.Services.AddScoped<IAvailableProgramRepository, AvailableProgramRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();