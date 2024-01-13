using EMS.Entities;
using EMS.Core.Contract;
using EMS.Core.Contract.Employee.Request;

namespace EMS.Interfaces;

public interface IEmployeeService
{
    Task<List<Employee>> GetEmployees(CancellationToken cancellationToken);
    Task<Employee> GetEmployeeById(Guid employeeId, CancellationToken cancellationToken);
    Task<Guid> CreateEmployee(CreateEmployeeCommand createEmployeeCommand, CancellationToken cancellationToken);
    Task<bool> UpdateEmployee(UpdateEmployeeCommand updateEmployeeCommand, CancellationToken cancellationToken);
    Task<bool> DeleteEmployee(Guid employeeId, DeleteEntityCommand deleteEntityCommand, CancellationToken cancellationToken);
}