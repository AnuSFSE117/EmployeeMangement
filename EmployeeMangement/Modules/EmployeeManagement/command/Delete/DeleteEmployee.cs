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
            var Result = employeeDbcontextobj.Employeetable.Where(a => a.Id == request.Id).FirstOrDefault();
            ResponseModel responseModel = new ResponseModel();
            if (Result != null)
            {
                employeeDbcontextobj.Employeetable.Remove(Result);
                await employeeDbcontextobj.SaveChangesAsync();
                return responseModel;
            }
            else
            {
                throw new Exception("Invalid id");
            }

        }
    }
}
