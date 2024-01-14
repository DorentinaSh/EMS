using System.ComponentModel.DataAnnotations;

namespace EMS.Core.Contract.Employee.Request;

public class UpdateEmployeeCommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Lastname { get; set; }
    public decimal Salary { get; set; }
    [Display(Name = "Position")]
    public Guid? PositionId { get; set; }
}