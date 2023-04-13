using EmployeeMangement.Models;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeMangement.Modules.EmployeeManagement.command.create
{
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
        private readonly EmployeeDbcontext EmployeeDbcontextobj;
        public CreateEmployeeHandler(EmployeeDbcontext obj)
        {
            EmployeeDbcontextobj = obj;
        }

        public async Task<ResponseModel> Handle(CreateEmployee obj1, CancellationToken cancellationToken)
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                var Emp = new EmployeeModel();
                Emp.Name = obj1.Name;
                Emp.Phonenumber = obj1.Phonenumber;
                Emp.Email = obj1.Email;
                Emp.City = obj1.City;
                Emp.Pincode = obj1.Pincode;
                Emp.Salary = obj1.Salary;
                EmployeeDbcontextobj.Employeetable.Add(Emp);
                await EmployeeDbcontextobj.SaveChangesAsync();
                int result = responseModel.Id = Emp.Id;
                responseModel.info = "Employee details added Successfully";
                return responseModel ;
            }
            catch (Exception e){
                responseModel.info = "invalid data";
            }
            return responseModel ;
        }
    }
}

