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
            ResponseModel responseModel = new ResponseModel();
            public GetEmployeeByIdHandler(EmployeeDbcontext context)
            {
                employeeDbcontext = context;
            }
            public async Task<EmployeeModel> Handle(GetEmployeebyId request, CancellationToken cancellationToken)
            {

                var Employee = await employeeDbcontext.Employeetable.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
                //Return the Employee detail if the id is exist in database
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


