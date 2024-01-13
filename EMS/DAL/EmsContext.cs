using EMS.Entities;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace EMS.DAL;

public class EmsContext : DbContext
{
    public EmsContext(DbContextOptions<EmsContext> options) 
        : base(options) { }

    public DbSet<Employee> Employes { get; set; }
    public DbSet<Position> Positions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}