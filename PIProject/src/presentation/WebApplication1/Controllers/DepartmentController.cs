using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RusMProject.Persistance.Features.Commands.Department;
using RusMProject.Persistance.Features.Queries.Department;
using RusMProject.WebAPI.Attributes;
using RusMProjectApplication.Registration.CreateDSO;
using RusMProjectApplication.Registration.UpdateDSO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RusMProject.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    public IMediator Mediator { get; set; }
    public DepartmentController(IMediator mediator)
    {
        Mediator = mediator;
    }

    [HttpGet]
    [AnonymousUser]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllDepartmentQuery();
        var model = await Mediator.Send(query);
        return Ok(model);
    }
    [HttpGet("search/{word}")]
    [AnonymousUser]
    public async Task<IActionResult> SearchDepartments(CancellationToken cancellationToken,string word)
    {
        var query = new SearchDepartmentQuery(word);
        var model = await Mediator.Send(query);
        return Ok(model);
    }
    [HttpGet("{page}/{value}")]
    [AnonymousUser]
    public async Task<IActionResult> GetAllWithPage(int page, int value, CancellationToken cancellationToken)
    {
        var query = new GetAllDepartmentQueryWithPage(page, value);
        var model = await Mediator.Send(query, cancellationToken);
        return Ok(model);
    }

    [HttpGet("{id}")]
    [AnonymousUser]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetDepartmentQuery(id);
        var model = await Mediator.Send(query);
        return Ok(model);
    }

    [HttpPost]
    [SwaggerAuthToken]
    public async Task<IActionResult> Add(DepartmentDSO departmentDSO)
    {
        var command = new CreateDepartmentCommand(departmentDSO);
        return Ok(await Mediator.Send(command));
    }
    [HttpPut]
    [SwaggerAuthToken]
    public async Task<IActionResult> Update(DepartmentUpdateDSO departmentUpdateDSO)
    {
        var command = new UpdateDepartmentCommand(departmentUpdateDSO);
        return Ok(await Mediator.Send(command));
    }
    [HttpDelete("{id}")]
    [SwaggerAuthToken]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteDepartmentCommand(id);
        return Ok(await Mediator.Send(command));
    }
}
