using EMS.Interfaces;
using EMS.Core.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Core.Contract.Employee.Request;

namespace EMS.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IPositionService _positionService;

    public EmployeeController(IEmployeeService employeeService, IPositionService positionService)
    {
        _employeeService = employeeService;
        _positionService = positionService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        return View(await _employeeService.GetEmployees(cancellationToken));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        return View(await _employeeService.GetEmployeeById(id, cancellationToken));
    }

    [HttpGet]
    public async Task<ActionResult> Create(CancellationToken cancellationToken)
    {
        var positions = await _positionService.GetPositions(cancellationToken);
        var mappedPositions = positions.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
        ViewData["Positions"] = mappedPositions;

        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromForm] CreateEmployeeCommand createEmployeeCommand, CancellationToken cancellationToken)
    {
        await _employeeService.CreateEmployee(createEmployeeCommand, cancellationToken);

        return RedirectToAction("Index");
    }

    [HttpPut]
    public async Task<ActionResult<bool>> Update(UpdateEmployeeCommand updateEmployeeCommand, CancellationToken cancellationToken)
    {
        return Ok(await _employeeService.UpdateEmployee(updateEmployeeCommand, cancellationToken));
    }

    [HttpPost("{id}")]
    public async Task Delete(Guid id, [FromForm] DeleteEntityCommand deleteEntityCommand, CancellationToken cancellationToken)
    {
        await _employeeService.DeleteEmployee(id, deleteEntityCommand, cancellationToken);
    }
}