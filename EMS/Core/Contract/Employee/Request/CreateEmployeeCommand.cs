using System.ComponentModel.DataAnnotations;

namespace EMS.Core.Contract.Employee.Request;

public class CreateEmployeeCommand
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public decimal Salary { get; set; }
    [Display(Name = "Position")]
    public string? PositionId { get; set; }
}