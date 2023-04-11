using EmployeeMangement.command;
using EmployeeMangement.Models;
using MediatR;

namespace EmployeeMangement.Query
{
    public class GetEmployeeById : IRequest<EmployeeModel>
    {
        public int Id { get; set; }
       
        public class GetEmployeeByIdHandler : IRequestHandler<GetEmployee, EmployeeModel>
        {
            private readonly EmployeeDbcontext EmployeeDbcontextobj;
            public GetEmployeeByIdHandler(EmployeeDbcontext obj)
            {
                EmployeeDbcontextobj = obj;
            }
            public async Task<int> Handle(GetEmployeeById getEmployeebyidobj, CancellationToken cancellationToken)
            {
                var Emp = await EmployeeDbcontextobj.Employeetable.Where(a => a.Id == getEmployeebyidobj.Id).

                await EmployeeDbcontextobj.SaveChangesAsync();
                return Emp.Id;
            }


        }


    }
}

    

