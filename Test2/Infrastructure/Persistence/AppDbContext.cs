using Microsoft.EntityFrameworkCore;
using Test2.Domain.Models;

namespace Test2.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<WashingProgram> Programs { get; set; }
    public DbSet<WashingMachine> WashingMachines { get; set; }
    public DbSet<AvailableProgram> AvailablePrograms { get; set; }
    public DbSet<PurchaseHistory> PurchaseHistories { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        
        modelBuilder.Entity<Customer>()
            .HasData(new Customer
            {
                CustomerId = 1,    
                FirstName = "Arina",    
                LastName = "Liubas",    
                PhoneNumber = null
            });
        
        modelBuilder.Entity<WashingProgram>()
            .HasData(new WashingProgram 
                { 
                    ProgramId = 1, 
                    Name = "Quick Wash", 
                    DurationMinutes = 30, 
                    TemperatureCelsius = 40 },    
                new WashingProgram
                {
                    ProgramId = 2, 
                    Name = "Cotton Cycle", 
                    DurationMinutes = 90, 
                    TemperatureCelsius = 60
                },    
                new WashingProgram
                {
                    ProgramId = 3, 
                    Name = "Synthetic", 
                    DurationMinutes = 45, 
                    TemperatureCelsius = 50
                });

        modelBuilder.Entity<AvailableProgram>()
            .HasData(new AvailableProgram
            {
                AvailableProgramId = 1,
                WashingMachineId = 1,
                ProgramId = 1,
                Price = 1001
            });

        modelBuilder.Entity<WashingMachine>()
            .HasData(new WashingMachine
            {
                WashingMachineId = 1,
                MaxWeight = 15,
                SerialNumber = "a2"
            });

        modelBuilder.Entity<PurchaseHistory>()
            .HasData(new PurchaseHistory
            {
                AvailableProgramId = 1,
                CustomerId = 1,
                PurchaseDate = new DateTime(2004, 03, 29),
                Rating = 5
            });
        
        
        // modelBuilder.Entity<PurchaseHistory>(entity =>
        // {
        //     
        // })
        
        modelBuilder.Entity<PurchaseHistory>()
            .HasKey(ph => new { ph.CustomerId, ph.AvailableProgramId });
        
        modelBuilder.Entity<PurchaseHistory>()
            .HasOne(ph => ph.Customer)
            .WithMany(c => c.Purchases)
            .HasForeignKey(ph => ph.CustomerId);

        modelBuilder.Entity<PurchaseHistory>()
            .HasOne(ph => ph.AvailableProgram)
            .WithMany(ap => ap.Purchases)
            .HasForeignKey(ph => ph.AvailableProgramId);

        modelBuilder.Entity<AvailableProgram>()
            .HasOne(ap => ap.Program)
            .WithMany(p => p.AvailablePrograms)
            .HasForeignKey(ap => ap.ProgramId);

        modelBuilder.Entity<AvailableProgram>()
            .HasOne(ap => ap.WashingMachine)
            .WithMany(wm => wm.AvailablePrograms)
            .HasForeignKey(ap => ap.WashingMachineId);

        modelBuilder.Entity<WashingMachine>()
            .HasIndex(wm => wm.SerialNumber)
            .IsUnique();
    }
}