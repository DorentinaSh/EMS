using EMS.Interfaces;
using EMS.Core.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EMS.Core.Contract.Employee.Request;
using AutoMapper;

namespace EMS.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IPositionService _positionService;
    private readonly IMapper _mapper;

    public EmployeeController(IEmployeeService employeeService, IPositionService positionService, IMapper mapper)
    {
        _employeeService = employeeService;
        _positionService = positionService;
        _mapper = mapper;
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

    [HttpGet("{id}")]
    public async Task<ActionResult> Update(Guid id, CancellationToken cancellationToken)
    {
        var positions = await _positionService.GetPositions(cancellationToken);
        var mappedPositions = positions.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();
        ViewData["Positions"] = mappedPositions;

        var employee = await _employeeService.GetEmployeeById(id, cancellationToken);

        var mappedEmployee = _mapper.Map<UpdateEmployeeCommand>(employee);

        return View(mappedEmployee);
    }

    [HttpPost("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromForm] UpdateEmployeeCommand updateEmployeeCommand, CancellationToken cancellationToken)
    {
        updateEmployeeCommand.Id = id;
        await _employeeService.UpdateEmployee(updateEmployeeCommand, cancellationToken);

        return RedirectToAction("Index");
    }

    [HttpPost("{id}")]
    public async Task Delete(Guid id, [FromForm] DeleteEntityCommand deleteEntityCommand, CancellationToken cancellationToken)
    {
        await _employeeService.DeleteEmployee(id, deleteEntityCommand, cancellationToken);
    }
}