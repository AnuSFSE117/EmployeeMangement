using EmployeeMangement.Exception_Handling;
using EmployeeMangement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangement.Modules.EmployeeManagement.command.Update

{
    public class updateEmployee : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Phonenumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public int Salary { get; set; }

    }
    public class UpdateEmployeeHandler : IRequestHandler<updateEmployee, ResponseModel>
    {
        private readonly EmployeeDbcontext _db;
        public UpdateEmployeeHandler(EmployeeDbcontext obj)
        {
            _db = obj;
        }
        public async Task<ResponseModel> Handle(updateEmployee obj1, CancellationToken cancellationToken)
        {
            var EmployeeDetails = await _db.Employeetable.Where(a => a.Id == obj1.Id).FirstOrDefaultAsync();
            ResponseModel responseModel = new ResponseModel();
            try
            {
                var IsMailExists = _db.Employeetable.Where(em => em.Email == obj1.Email).ToList();
                if (IsMailExists.Count > 0)
                {
                    throw new Exception();
                }
                if (EmployeeDetails != null)
                {
                    EmployeeDetails.Name = obj1.Name;
                    EmployeeDetails.Phonenumber = obj1.Phonenumber;
                    EmployeeDetails.Email = obj1.Email;
                    EmployeeDetails.City = obj1.City;
                    EmployeeDetails.Pincode = obj1.Pincode;
                    EmployeeDetails.Salary = obj1.Salary;
                    _db.Employeetable.Update(EmployeeDetails);
                    await _db.SaveChangesAsync();
                    int result = responseModel.Id = EmployeeDetails.Id;
                    responseModel.Additionalinfo = "Employee details updated Successfully";
                    

                }
                
                
            }

           
            catch (Exception e)
            {
                throw new EmailAlreadyExistsException();
            }
            
            return responseModel;
            
        }
    }

}



