using EmployeeMangement.Exceptions;
using EmployeeMangement.Models;
using MediatR;

namespace EmployeeMangement.Modules.EmployeeManagement.command.Delete
{
    public class DeleteEmployee : IRequest<ResponseModel>
    {
        //Request for DeleteEmployee
        public int Id { get; set; }

    }
    //Handler For DeleteEmployee
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, ResponseModel>
    {
       
        private readonly EmployeeDbcontext employeeDbcontext;
        public DeleteEmployeeHandler(EmployeeDbcontext context)
        {
            employeeDbcontext = context;
        }
        public async Task<ResponseModel> Handle(DeleteEmployee request, CancellationToken cancellationToken)
        {
            var EmployeeDetails = employeeDbcontext.Employeetable.Where(a => a.Id == request.Id).FirstOrDefault();
            ResponseModel responseModel = new ResponseModel();
            //delete the Record if the given id is Exist in database
            if (EmployeeDetails != null)
            {
                employeeDbcontext.Employeetable.Remove(EmployeeDetails);
                await employeeDbcontext.SaveChangesAsync();
                int res= EmployeeDetails.Id;
                responseModel.Additionalinfo = "one row is affected" ;
                
            }
            //Throws an Exception if the id is not found
            else
            {
                throw new IdNotFoundException();
            }
            return responseModel;
        }
    }
}
