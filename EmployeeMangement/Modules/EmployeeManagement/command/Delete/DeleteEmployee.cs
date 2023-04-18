using EmployeeMangement.Exceptions;
using EmployeeMangement.Models;
using MediatR;

namespace EmployeeMangement.Modules.EmployeeManagement.command.Delete
{
    public class DeleteEmployee : IRequest<ResponseModel>
    {
        public int Id { get; set; }

    }
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, ResponseModel>
    {
       
        private readonly EmployeeDbcontext employeeDbcontextobj;
        public DeleteEmployeeHandler(EmployeeDbcontext obj)
        {
            employeeDbcontextobj = obj;
        }
        public async Task<ResponseModel> Handle(DeleteEmployee request, CancellationToken cancellationToken)
        {
            var EmployeeDetails = employeeDbcontextobj.Employeetable.Where(a => a.Id == request.Id).FirstOrDefault();
            ResponseModel responseModel = new ResponseModel();
            if (EmployeeDetails != null)
            {
                employeeDbcontextobj.Employeetable.Remove(EmployeeDetails);
                await employeeDbcontextobj.SaveChangesAsync();
                int res = responseModel.Id = EmployeeDetails.Id;
                responseModel.Additionalinfo = "one row is affected" ;
                
            }
            else
            {
                throw new IdNotFoundException();
            }
            return responseModel;
        }
    }
}
