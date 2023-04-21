using EmployeeMangement.Exceptions;
using EmployeeMangement.Models;
using MediatR;

namespace EmployeeMangement.Modules.EmployeeManagement.command.Delete
{
    public class DeleteEmployee : IRequest<EntityModel>
    {
        
        public int Id { get; set; }

    }
    
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, EntityModel>
    {
       
        private readonly EmployeeDbcontext employeeDbcontext;
        public DeleteEmployeeHandler(EmployeeDbcontext context)
        {
            employeeDbcontext = context;
        }
        public async Task<EntityModel> Handle(DeleteEmployee request, CancellationToken cancellationToken)
        {
            var EmployeeDetails = employeeDbcontext.Employeetable.Where(a => a.Id == request.Id).FirstOrDefault();
            EntityModel responseModel = new EntityModel();
            //delete the Record if the given id Exists .
            if (EmployeeDetails != null)
            {
                employeeDbcontext.Employeetable.Remove(EmployeeDetails);
                responseModel.ResponseId= await employeeDbcontext.SaveChangesAsync();
                responseModel.Additionalinfo = "Employee record is deleted" ;
                return responseModel;
            }
            //Throws an Exception if the Employee id is not found
            else
            {
                throw new IdNotFoundException();
            }
            
        }
    }
}
