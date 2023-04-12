using EmployeeMangement.Modules.EmployeeManagement.command.create;
using EmployeeMangement.Modules.EmployeeManagement.command.Delete;
using EmployeeMangement.Modules.EmployeeManagement.command.Update;
using EmployeeMangement.Modules.EmployeeManagement.Query;
using EmployeeMangement.Modules.EmployeeManagement.Query.Get;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMangement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator mediator;
        public EmployeeController(IMediator _mediator)
        {
            mediator = _mediator;
        }

        
        [HttpPost]
        public async Task<IActionResult>Create(CreateEmployee createEmployeeobj)
        {
            return Ok(await mediator.Send(createEmployeeobj));
        }
        [HttpPut]
        public async Task<IActionResult> Update(updateEmployee updateEmployeeobj)
        {
            return Ok(await mediator.Send(updateEmployeeobj));
        }
        [HttpGet]
        public async Task<IActionResult> Getall()
        {
            return Ok(await mediator.Send( new GetEmployee()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetById(int id)
        {
            return Ok(await mediator.Send(new GetEmployeebyId{ Id = id }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new DeleteEmployee { Id = id }));
        }


    }
    
}

