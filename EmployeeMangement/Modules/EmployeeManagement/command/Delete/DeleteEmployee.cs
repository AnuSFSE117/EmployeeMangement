using EmployeeMangement.Exception_Handling;
using EmployeeMangement.Exceptions;
using EmployeeMangement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore.Update;

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
            var Result = employeeDbcontextobj.Employeetable.Where(a => a.Id == request.Id).FirstOrDefault();
            ResponseModel responseModel = new ResponseModel();
            if (Result != null)
            {
                employeeDbcontextobj.Employeetable.Remove(Result);
                await employeeDbcontextobj.SaveChangesAsync();
                int res = responseModel.Id = Result.Id;
                responseModel.Additionalinfo = "one row is affected" ;
                return responseModel;
            }
            else
            {
                throw new IdNotFoundException();
            }

        }
    }
}
