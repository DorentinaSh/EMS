using EMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Interfaces;

public interface IEmsContext
{
     Task<int> SaveChangesAsync(CancellationToken cancellationToken);
     DbSet<Employee> Employees { get; }
     DbSet<Position> Positions { get; }
}