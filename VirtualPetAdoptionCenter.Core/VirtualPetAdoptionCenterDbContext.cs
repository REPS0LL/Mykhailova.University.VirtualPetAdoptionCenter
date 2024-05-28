using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VirtualPetAdoptionCenter.Models.Account;
using VirtualPetAdoptionCenter.Models.DomainModels;

namespace VirtualPetAdoptionCenter.Core;

public class VirtualPetAdoptionCenterDbContext : DbContext
{
    public VirtualPetAdoptionCenterDbContext(DbContextOptions<VirtualPetAdoptionCenterDbContext> options) : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("YourConnectionString"); // Replace YourConnectionString with your actual connection string
        }
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<PetModel> Pets { get; set; }
    public DbSet<GroomingModel> Groom { get; set; }
    public DbSet<AchievementModel> Achievements { get; set; }
}