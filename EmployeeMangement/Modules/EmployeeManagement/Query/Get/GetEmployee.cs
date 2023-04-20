using EmployeeMangement.Exceptions;
using EmployeeMangement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            public async Task<List<EmployeeModel>> Handle(GetEmployee request, CancellationToken cancellationToken)
            {
                var Employee = await employeeDbcontext.Employeetable.ToListAsync();
                //Returns all Employee Details from Database 
                if (Employee.Count!=0)
                {
                    return Employee;

                }
                //Throws an Exception if the id is not found
                else
                {
                    throw new RecordsNotFoundException();

                }

                
            }
        }
    }
}
