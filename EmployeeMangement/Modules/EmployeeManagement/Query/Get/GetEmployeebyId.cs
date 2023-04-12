using EmployeeMangement.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangement.Modules.EmployeeManagement.Query.Get
{
    public class GetEmployeebyId : IRequest<string>
    {
        public int Id { get; set; }
        public class GetEmployeeHandler : IRequestHandler<GetEmployeebyId, string>
        {
            private readonly EmployeeDbcontext employeeDbcontextobj;
            public GetEmployeeHandler(EmployeeDbcontext obj)
            {
                employeeDbcontextobj = obj;
            }
            public async Task<string> Handle(GetEmployeebyId request, CancellationToken cancellationToken)
            {
                var result = await employeeDbcontextobj.Employeetable.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    return "success";
                }
                else
                {
                   throw new Exception("Invalid id");
                }

            }

        }

    }
}
