using EMS.Entities;
using EMS.Interfaces;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace EMS.DAL;

public class EmsContext : DbContext, IEmsContext
{
    public EmsContext(DbContextOptions<EmsContext> options)
        : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
    
    public DbSet<Employee> Employes => Set<Employee>();
    public DbSet<Position> Positions => Set<Position>();
}