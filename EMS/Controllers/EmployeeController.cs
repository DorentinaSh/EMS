using EMS.Interfaces;
using EMS.Core.Contract;
using Microsoft.AspNetCore.Mvc;
using EMS.Core.Contract.Employee.Request;

namespace EMS.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await _employeeService.GetEmployees(cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _employeeService.GetEmployeeById(id, cancellationToken));
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create(CreateEmployeeCommand createEmployeeCommand, CancellationToken cancellationToken)
    {
        return Ok(await _employeeService.CreateEmployee(createEmployeeCommand, cancellationToken));
    }

    [HttpPut]
    public async Task<ActionResult<bool>> Update(UpdateEmployeeCommand updateEmployeeCommand, CancellationToken cancellationToken)
    {
        return Ok(await _employeeService.UpdateEmployee(updateEmployeeCommand, cancellationToken));
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> Delete(Guid id, DeleteEntityCommand deleteEntityCommand, CancellationToken cancellationToken)
    {
        return Ok(await _employeeService.DeleteEmployee(id, deleteEntityCommand, cancellationToken));
    }
}