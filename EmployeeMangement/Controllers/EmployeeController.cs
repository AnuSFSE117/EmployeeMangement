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
        /// <remarks>
        /// 
        /// Example Value
        /// ------- -----
        /// 
        /// {
        /// 
        ///    "Name"="Anu" 
        ///    
        ///    "Phonenumber "= 9791211302
        ///    
        ///    "Email" = "anu26@gmail.com"
        ///    
        ///    "City" = "Chennai"
        ///    
        ///    "Pincode" = 629179
        ///    
        ///    "Salary" = 10000
        ///    
        /// }
        ///    
        /// </remarks>
        /// <returns>Employee details</returns> 

        [HttpPost]
         
        public async Task<IActionResult> Create(CreateEmployee createEmployeeobj)
        {
            return Ok(await mediator.Send(createEmployeeobj));
        }

        /// <summary>  
        /// update Employee  
        /// </summary>
        /// <remarks>
        ///   Id=1
        ///   "Name" = "shalini"
        ///   "Phonenumber" = 7598275737
        ///   "Email" = "anu2611@gmail.com"
        ///   "City" = "Chennai"
        ///   "Pincode" = 600040
        ///   "Salary" = 15000
        /// 
        /// </remarks>
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
        /// <remarks> Id=1 </remarks>
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
        /// <remarks> Id=1 </remarks>
        /// <param name="id">id</param>  
        /// <returns>Employee details </returns> 
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new DeleteEmployee { Id = id }));
        }


    }
    
}

