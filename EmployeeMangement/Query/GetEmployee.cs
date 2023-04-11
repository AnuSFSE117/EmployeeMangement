using EmployeeMangement.Models;
using MediatR;

namespace EmployeeMangement.Query
{
    public class GetEmployee:IRequest<EmployeeModel>
    {
        public class GetEmployeeHandler: IRequest<GetEmployee,List<EmployeeModel>>
        {
            private readonly EmployeeDbcontext EmployeeDbcontextobj;
            public GetEmployeeHandler(EmployeeDbcontext obj)
            {
                EmployeeDbcontextobj = obj;
            }
            public Task<GetEmployee, List<EmployeeModel>>Handle(GetEmployee request,CancellationToken cancellationToken)
            {
                return Task.FromResult(EmployeeDbcontextobj.GetEmployee());
            }
        }
    }
}
