using EmployeeMangement.Exceptions;
using EmployeeMangement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangement.Modules.EmployeeManagement.Query.GetById
{
    public class GetEmployeebyId : IRequest<EmployeeModel>
    {
        //Request for GetEmployeebyId
        public int Id { get; set; }

        public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeebyId, EmployeeModel>
        {
            private readonly EmployeeDbcontext employeeDbcontext;
            EntityModel responseModel = new EntityModel();
            public GetEmployeeByIdHandler(EmployeeDbcontext context)
            {
                employeeDbcontext = context;
            }
            public async Task<EmployeeModel> Handle(GetEmployeebyId request, CancellationToken cancellationToken)
            {

                var Employee = await employeeDbcontext.Employeetable.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                //Return the Employee detail if id is exist.
                if (Employee != null)
                {
                    return Employee;
                }

                //Throws an exception if id is not found
                else
                {
                    throw new IdNotFoundException();

                }

            }

        }

    }

}


