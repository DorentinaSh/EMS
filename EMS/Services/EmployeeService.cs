using AutoMapper;
using EMS.Entities;
using EMS.Interfaces;
using EMS.Core.Contract;
using EMS.Core.Common.Exception;
using Microsoft.EntityFrameworkCore;
using EMS.Core.Contract.Employee.Request;
using EMS.Core.Contract.DTOs;

namespace EMS.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmsContext _emsContext;
    private readonly IMapper _mapper; 

    public EmployeeService(IEmsContext emsContext, IMapper mapper)
    {
        _emsContext = emsContext;
        _mapper = mapper;
    }

    public async Task<List<EmployeeDTO>> GetEmployees(CancellationToken cancellationToken)
    {
        var employeesList = await _emsContext.Employes
            .AsNoTracking()
            .Include(x => x.Position)
            .OrderByDescending(x => x.CreatedAt)
            .Select(x=> _mapper.Map<EmployeeDTO>(x))
            .ToListAsync(cancellationToken);

        return employeesList;
    }

    public async Task<EmployeeDTO> GetEmployeeById(Guid employeeId, CancellationToken cancellationToken)
    {
        var employee = await _emsContext.Employes.Include(x=>x.Position).FirstOrDefaultAsync(x => x.Id == employeeId, cancellationToken)
            ?? throw  new NotFoundException(nameof(Employee));

        var employeeDto = _mapper.Map<EmployeeDTO>(employee);

        return employeeDto;
    }

    public async Task<Guid> CreateEmployee(CreateEmployeeCommand createEmployeeCommand, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<Employee>(createEmployeeCommand);
        
        try
        {
            _ = await _emsContext.Employes.AddAsync(employee, cancellationToken);
            _ = await _emsContext.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> UpdateEmployee(UpdateEmployeeCommand updateEmployeeCommand, CancellationToken cancellationToken)
    {
        var existingEmployee =
            await _emsContext.Employes.FirstOrDefaultAsync(x => x.Id == updateEmployeeCommand.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Employee));

        _mapper.Map(updateEmployeeCommand, existingEmployee);

        try
        {
            _ = _emsContext.Employes.Update(existingEmployee);
            await _emsContext.SaveChangesAsync(cancellationToken);
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DeleteEmployee(Guid employeeId, DeleteEntityCommand deleteEntityCommand, CancellationToken cancellationToken)
    {
        var employee = 
            await _emsContext.Employes.FirstOrDefaultAsync(x => x.Id == employeeId, cancellationToken) 
            ?? throw new NotFoundException(nameof(Employee));
        
        employee.DeletedAt = DateTime.Now;
        // TODO: Implement currentuser service to get the logged in user.
        employee.DeletedByUserName = "Dorentina";
        employee.DeletedReason = deleteEntityCommand.DeletedReason;

        try
        {
            _ = _emsContext.Employes.Update(employee);
            await _emsContext.SaveChangesAsync(cancellationToken);
            
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}