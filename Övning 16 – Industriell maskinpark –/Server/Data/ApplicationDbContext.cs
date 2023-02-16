using Microsoft.EntityFrameworkCore;
using Övning_16___Industriell_maskinpark__.Client.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<IndustrialMachine> IndustrialMachines { get; set; }
}