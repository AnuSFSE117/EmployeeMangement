using EmployeeMangement.Models;
using MediatR;

namespace EmployeeMangement.Modules.EmployeeManagement.Query.Get
{
    public class GetEmployee : IRequest<List<EmployeeModel>>
    {
        public class GetEmployeeHandler : IRequestHandler<GetEmployee, List<EmployeeModel>>
        {
            private readonly EmployeeDbcontext employeeDbcontext;
            
            public GetEmployeeHandler(EmployeeDbcontext context)
            {
                employeeDbcontext = context;
            }
            public Task<List<EmployeeModel>> Handle(GetEmployee request, CancellationToken cancellationToken)
            {

                return Task.FromResult(employeeDbcontext.Employeetable.ToList());
            }
        }
    }
}
