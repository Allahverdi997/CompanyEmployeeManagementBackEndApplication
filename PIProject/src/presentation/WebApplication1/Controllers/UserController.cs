using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RusMProject.Persistance.Features.Commands.Employee;
using RusMProject.Persistance.Features.Commands.User;
using RusMProject.Persistance.Features.Queries.Department;
using RusMProject.Persistance.Features.Queries.User;
using RusMProject.WebAPI.Attributes;
using RusMProjectApplication.DTOs;
using RusMProjectApplication.Registration.CreateDSO;

namespace RusMProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IMediator Mediator { get; set; }
        public UserController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [HttpPost("Login")]
        [AnonymousUser]
        public async Task<IActionResult> Login(CancellationToken cancellationToken, UserLoginDTO userLogin)
        {
            var query = new GetUserQuery(userLogin.UserName,userLogin.Password);
            var model = await Mediator.Send(query);
            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CancellationToken cancellationToken, [FromBody] UserDSO userDSO)
        {
            var command = new CreateUserCommand(userDSO);
            return Ok(await Mediator.Send(command));
        }
    }
}
