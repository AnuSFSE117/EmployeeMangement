using EmployeeMangement.Exception_Handling;
using EmployeeMangement.Models;
using MediatR;

namespace EmployeeMangement.Modules.EmployeeManagement.command.create
{
    //mediatr requests for CreateEmployee
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

        public async Task<ResponseModel> Handle(CreateEmployee obj1, CancellationToken cancellationToken)
        {
            ResponseModel responseModel = new ResponseModel();
            

            try
            {
                
                var IsMailExists = employeeDbcontext.Employeetable.Where(em => em.Email == obj1.Email).ToList();
                if (IsMailExists.Count > 0)  //checks whether the EmailId Repeats
                {
                    throw new Exception();
                }
                else
                {

                    var EmployeeDetails = new EmployeeModel();
                    EmployeeDetails.Name = obj1.Name;
                    EmployeeDetails.Phonenumber = obj1.Phonenumber;
                    EmployeeDetails.Email = obj1.Email;
                    EmployeeDetails.City = obj1.City;
                    EmployeeDetails.Pincode = obj1.Pincode;
                    EmployeeDetails.Salary = obj1.Salary;
                    employeeDbcontext.Employeetable.Add(EmployeeDetails);
                    await employeeDbcontext.SaveChangesAsync();
                    int result = responseModel.Id = EmployeeDetails.Id;
                    responseModel.Additionalinfo = "Employee details added Successfully";
                   
                }
            }
            catch (Exception e)
            {
                //throws Exception If the given EmailId is already Present
                //throw new EmailAlreadyExistsException();
            }
         return responseModel;


        }
    }
}

