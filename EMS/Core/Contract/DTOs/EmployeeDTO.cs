using EMS.Entities;

namespace EMS.Core.Contract.DTOs
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public decimal Salary { get; set; }
        public Guid? PositionId { get; set; }
        public Position? Position { get; set; }
    }
}
