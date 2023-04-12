using EmployeeMangement.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangement.CQRS.Query
{
    public class GetEmployeebyId : IRequest<int>
    {
        public int Id { get; set; }
        public class GetEmployeeHandler : IRequestHandler<GetEmployeebyId, int>
        {
            private readonly EmployeeDbcontext employeeDbcontextobj;
            public GetEmployeeHandler(EmployeeDbcontext obj)
            {
                employeeDbcontextobj = obj;
            }
            public async Task<int> Handle(GetEmployeebyId request, CancellationToken cancellationToken)
            {
                var result = await employeeDbcontextobj.Employeetable.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                return result.Id;

            }

        }

    }
}
