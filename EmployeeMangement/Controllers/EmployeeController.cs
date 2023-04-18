using EmployeeMangement.Modules.EmployeeManagement.command.create;
using EmployeeMangement.Modules.EmployeeManagement.command.Delete;
using EmployeeMangement.Modules.EmployeeManagement.command.Update;
using EmployeeMangement.Modules.EmployeeManagement.Query.Get;
using EmployeeMangement.Modules.EmployeeManagement.Query.GetById;
using MediatR;
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
        /// <summary>  
        /// add Employee  
        /// </summary>  
        /// <returns>Employee details</returns> 

        [HttpPost]
         
        public async Task<IActionResult> Create(CreateEmployee createEmployeeobj)
        {
            return Ok(await mediator.Send(createEmployeeobj));
        }
        
        /// <summary>  
        /// update Employee  
        /// </summary>  
        /// <returns>updated Employee details </returns>  

        [HttpPut]
        
        public async Task<IActionResult> Update(updateEmployee updateEmployeeobj)
        {
            return Ok(await mediator.Send(updateEmployeeobj));
        }

        /// <summary>  
        /// Get all Employee  
        /// </summary>  
        /// <returns>List of Employee</returns>  
        [HttpGet]
        
        public async Task<IActionResult> Getall()
        {
            return Ok(await mediator.Send( new GetEmployee()));
        }

        /// <summary>  
        /// Get Employee By ID  
        /// </summary>  
        /// <param name="id"> id</param>  
        /// <returns>Employee details based on id </returns> 
        [HttpGet("{id}")]
        
       
        public async Task<IActionResult>GetById(int id)
        {
            return Ok(await mediator.Send(new GetEmployeebyId{ Id = id }));
        }
        

        /// <summary>  
        /// delete Employee  
        /// </summary>  
        /// <param name="id">id</param>  
        /// <returns>Employee details </returns> 
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new DeleteEmployee { Id = id }));
        }


    }
    
}

