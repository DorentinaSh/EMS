using EMS.Core.Enums;
using EMS.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.DAL;

public class EmsContextInitializer
{
    private readonly EmsContext _context;

    public EmsContextInitializer(EmsContext context)
    {
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        try
        {
            await SeedPositions();
            await SeedEmployees();
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred while seeding the database.");
            throw;
        }
    }
    
    private async Task SeedPositions()
    {
        var positions = new List<Position>
        {
            new (Enum.GetName(typeof(PositionType), 0), "FEDEV"),
            new (Enum.GetName(typeof(PositionType), 1), "BEDEV"),
            new (Enum.GetName(typeof(PositionType), 2), "FSDEV"),
            new (Enum.GetName(typeof(PositionType), 3), "DBDEV"),
        };
        
        positions.ForEach(position =>
        {
            if (!_context.Positions.Any(x => x.Code == position.Code))
            {
                _context.Positions.Add(position);
            }
        });

        _ = await _context.SaveChangesAsync();
    }
    
    private async Task SeedEmployees()
    {
        var position = _context.Positions.FirstOrDefault();
        var employees = new List<Employee>
        {
            new Employee
            {
                CreatedAt = DateTime.Now,
                CreatedByUserName = "Admin",
                UpdatedAt = DateTime.Now,
                UpdatedByUserName = "Admin",
                Name = "Dorentina",
                Lastname = "Shabani",
                Salary = 100,
                PositionId = position.Id,
            }
        };
       
        _context.Employes.AddRange(employees);

        _ = await _context.SaveChangesAsync();
    }
}