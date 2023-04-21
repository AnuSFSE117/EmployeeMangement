using EmployeeMangement.Exception_Handling;
using EmployeeMangement.Models;
using MediatR;

namespace EmployeeMangement.Modules.EmployeeManagement.command.create
{
    
    public class CreateEmployee : IRequest<EntityModel>
    {
        public string Name { get; set; }
        public long Phonenumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public int Salary { get; set; }
    }
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, EntityModel>
    {
        private readonly EmployeeDbcontext employeeDbcontext;
        public CreateEmployeeHandler(EmployeeDbcontext context)
        {
            employeeDbcontext = context;
        }

        public async Task<EntityModel> Handle(CreateEmployee createemp, CancellationToken cancellationToken)
        {
            EntityModel responseModel = new EntityModel();
             
                var IsMailExists = employeeDbcontext.Employeetable.Where(em => em.Email == createemp.Email).ToList();
            //checks whether the EmailId is already Exist
            if (IsMailExists.Count ==1)
            {
                throw new EmailAlreadyExistsException();
            }
            else
            {

                var EmployeeDetails = new EmployeeModel();
                EmployeeDetails.Name = createemp.Name;
                EmployeeDetails.Phonenumber = createemp.Phonenumber;
                EmployeeDetails.Email = createemp.Email;
                EmployeeDetails.City = createemp.City;
                EmployeeDetails.Pincode = createemp.Pincode;
                EmployeeDetails.Salary = createemp.Salary;
                employeeDbcontext.Employeetable.Add(EmployeeDetails);
                await employeeDbcontext.SaveChangesAsync();
                responseModel.ResponseId = employeeDbcontext.Employeetable.Count();
                if (responseModel.ResponseId > 0)
                {
                    responseModel.Additionalinfo = "Employee Details added successfully";
                }
                else
                {
                    responseModel.Additionalinfo = "Employee Details Not added successfully";
                }
                return responseModel;

            }
            
           
         

        }
    }
}

