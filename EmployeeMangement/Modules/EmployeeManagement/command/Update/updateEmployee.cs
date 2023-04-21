using EmployeeMangement.Exception_Handling;
using EmployeeMangement.Exceptions;
using EmployeeMangement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangement.Modules.EmployeeManagement.command.Update

{
    public class UpdateEmployee : IRequest<EntityModel>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public long Phonenumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public int Salary { get; set; }

    }
    //Handler for Update Employee
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployee, EntityModel>
    {
        private readonly EmployeeDbcontext employeeDbcontext;
        public UpdateEmployeeHandler(EmployeeDbcontext context)
        {
            employeeDbcontext = context;
        }
        public async Task<EntityModel> Handle(UpdateEmployee updateemp, CancellationToken cancellationToken)
        {
            var EmployeeDetails = await employeeDbcontext.Employeetable.Where(a => a.Id == updateemp.Id).FirstOrDefaultAsync();
            EntityModel responseModel = new EntityModel();
            //updates the value if id is exist
            if (EmployeeDetails != null)
            {
                EmployeeDetails.Name = updateemp.Name;
                EmployeeDetails.Phonenumber = updateemp.Phonenumber;
                EmployeeDetails.Email = updateemp.Email;
                EmployeeDetails.City = updateemp.City;
                EmployeeDetails.Pincode = updateemp.Pincode;
                EmployeeDetails.Salary = updateemp.Salary;
                employeeDbcontext.Employeetable.Update(EmployeeDetails);
                responseModel.ResponseId = await employeeDbcontext.SaveChangesAsync();
                responseModel.Additionalinfo = "Employee details updated Successfully";
            }
            //Throws Exception if id is not found
            else
            {
                throw new RecordsNotFoundException();
            }

            return responseModel;

        }
    }

}



