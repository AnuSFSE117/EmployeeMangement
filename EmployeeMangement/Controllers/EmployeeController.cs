using EmployeeMangement.Models;
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
        ///       "Name"="Test" ,
        ///    
        ///       "Phonenumber "= 9791211302,
        ///    
        ///       "Email" = "TestUser@gmail.com",
        ///    
        ///       "City" = "Chennai",
        ///    
        ///       "Pincode" = 629179,
        ///    
        ///       "Salary" = 10000
        ///    
        /// }
        ///    
        /// </remarks>
        /// <returns>Employee details</returns> 

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
         
        public async Task<EntityModel> Create(CreateEmployee createEmployee)
        {
            var result= await mediator.Send(createEmployee);
            return result;
        }

        /// <summary>  
        /// update Employee  
        /// </summary>
        /// <remarks>
        ///   Example Value
        /// ------- -----
        /// 
        /// {
        /// 
        ///        "Name"="Test" ,
        ///    
        ///        "Phonenumber "= 7598275737,
        ///    
        ///        "Email" = "Test@gmail.com",
        ///    
        ///        "City" = "Chennai",
        ///    
        ///        "Pincode" = 629179,
        ///    
        ///        "Salary" = 10000
        ///    
        /// }
        /// 
        /// </remarks>
        /// <returns>updated Employee details </returns>  

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<EntityModel> Update(UpdateEmployee updateEmployee)
        {
            var result=await mediator.Send(updateEmployee);
            return result;
        }

       
        
        /// <summary>  
        /// Get all Employee  
        /// </summary>  
        /// <returns>List of Employee</returns>  
        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<IActionResult> Getall()
        {
            return Ok(await mediator.Send(new GetEmployee()));
        }

        /// <summary>  
        /// Get Employee By ID  
        /// </summary>
        /// <remarks>
        ///  Example Value
        /// ------- -----
        /// 
        /// {
        /// 
        ///      "Id"=1
        /// 
        /// }
        /// </remarks>
        /// <param name="id"> id</param>  
        /// <returns>Employee details based on id </returns> 
        [HttpGet]
        [Route("GetEmployeebyId")]
        [ProducesResponseType(StatusCodes.Status200OK)]


        public async Task<IActionResult>SGetById(int id)
        {
            return Ok(await mediator.Send(new GetEmployeebyId{ Id = id }));
            
        }


        /// <summary>  
        /// delete Employee  
        /// </summary> 
        ///  <remarks> 
        /// Example Value
        /// ------- -----
        /// 
        /// {
        /// 
        ///         "Id"=1
        /// 
        /// }
        /// </remarks>
        /// <param name="id">id</param>  
        /// <returns>Employee details </returns> 
        [HttpDelete]
        
        public async Task<EntityModel> Delete(int id)
        {
           var result=await mediator.Send(new DeleteEmployee { Id = id });
            return result;
        }


    }
    
}

