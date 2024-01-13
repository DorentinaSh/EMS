using EMS.Entities.Core;

namespace EMS.Entities;

public class Employee : SoftDeleteEntity
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public decimal Salary { get; set; }
    public Guid? PositionId { get; set; }
    public Position? Position { get; set; }
}