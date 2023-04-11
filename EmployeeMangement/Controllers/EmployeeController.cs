using EmployeeMangement.command;
using EmployeeMangement.Query;
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
        public async Task<IActionResult> Update(UpdateEmployee updateemployeeobj)
        {
            return Ok(await mediator.Send(updateemployeeobj));
        }
        [HttpGet]
        //public async Task<IActionResult> Get(List<GetEmployeeById>,GetEmployeeByIdobj)
        //{
        //    return Ok(await mediator.Send(GetEmployeeByIdobj));
        //}


    }
}
