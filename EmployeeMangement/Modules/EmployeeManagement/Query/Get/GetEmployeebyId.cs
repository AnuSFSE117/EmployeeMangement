using EmployeeMangement.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EmployeeMangement.Modules.EmployeeManagement.Query.Get
{
    public class GetEmployeebyId : IRequest<EmployeeModel>
    {
        public int Id { get; set; }
        public class GetEmployeeHandler : IRequestHandler <GetEmployeebyId, EmployeeModel>
        {
            private readonly EmployeeDbcontext employeeDbcontextobj;
            ResponseModel responseModel=new ResponseModel();
            public GetEmployeeHandler(EmployeeDbcontext obj)
            {
                employeeDbcontextobj = obj;
            }
            public async Task<EmployeeModel> Handle(GetEmployeebyId request, CancellationToken cancellationToken)
            {

                var result = await employeeDbcontextobj.Employeetable.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                if (result != null)
                {
                    return result;
                }
                else 
                {
                    throw new Exception("Invalid id");
                }
            }

        }

    }
}
