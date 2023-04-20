using EmployeeMangement.Exception_Handling;
using EmployeeMangement.Models;
using MediatR;

namespace EmployeeMangement.Modules.EmployeeManagement.command.create
{
    // requests for CreateEmployee
    public class CreateEmployee : IRequest<ResponseModel>
    {
        public string Name { get; set; }
        public long Phonenumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public int Salary { get; set; }
    }
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployee, ResponseModel>
    {
        private readonly EmployeeDbcontext employeeDbcontext;
        public CreateEmployeeHandler(EmployeeDbcontext context)
        {
            employeeDbcontext = context;
        }

        public async Task<ResponseModel> Handle(CreateEmployee createemp, CancellationToken cancellationToken)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                
                var IsMailExists = employeeDbcontext.Employeetable.Where(em => em.Email == createemp.Email).ToList();
                //checks whether the EmailId is already Exist
                if (IsMailExists.Count > 0)  
                {
                    throw new Exception();
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
                    responseModel.Id = await employeeDbcontext.SaveChangesAsync();
                    responseModel.Additionalinfo = "Employee details added Successfully";
                   
                }
            }
            catch (Exception e)
            {
                //throws Exception If the given EmailId is already Exist
                throw new EmailAlreadyExistsException();
            }
         return responseModel;


        }
    }
}

