using EmployeeMangement.Models;
using MediatR;

namespace EmployeeMangement.command
{
    public class DeleteEmployee:IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, int>
        {
            private readonly EmployeeDbcontext employeeDbcontextobj;
            public DeleteEmployeeHandler(EmployeeDbcontext obj)
            {
                employeeDbcontextobj = obj;
            }
            public  async Task<int> Handle(DeleteEmployee request, CancellationToken cancellationToken)
            {
                var Result = employeeDbcontextobj.Employeetable.Where(a => a.Id == request.Id).FirstOrDefault();
                if (Result==null)
                {
                    return default;
                }
                else
                {
                    employeeDbcontextobj.Employeetable.Remove(Result);
                    await employeeDbcontextobj.SaveChangesAsync();
                    return Result.Id;
                }
                
            }
        }


    }
}
