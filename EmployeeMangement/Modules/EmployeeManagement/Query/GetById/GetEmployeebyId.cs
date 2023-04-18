using EmployeeMangement.Exceptions;
using EmployeeMangement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangement.Modules.EmployeeManagement.Query.GetById
{
    public class GetEmployeebyId : IRequest<EmployeeModel>
    {
        public int Id { get; set; }
        public class GetEmployeeHandler : IRequestHandler<GetEmployeebyId, EmployeeModel>
        {
            private readonly EmployeeDbcontext employeeDbcontextobj;
            ResponseModel responseModel = new ResponseModel();
            public GetEmployeeHandler(EmployeeDbcontext obj)
            {
                employeeDbcontextobj = obj;
            }
            public async Task<EmployeeModel> Handle(GetEmployeebyId request, CancellationToken cancellationToken)
            {

                var EmployeeResult = await employeeDbcontextobj.Employeetable.Where(a => a.Id == request.Id).FirstOrDefaultAsync();

                if (EmployeeResult != null)
                {
                    return EmployeeResult;
                }


                else
                {
                    throw new IdNotFoundException();

                }

            }

        }

    }

}


