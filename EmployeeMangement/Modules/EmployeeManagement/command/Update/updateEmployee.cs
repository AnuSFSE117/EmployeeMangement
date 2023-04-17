using EmployeeMangement.Exception_Handling;
using EmployeeMangement.Exceptions;
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
            var Emp = await _db.Employeetable.Where(a => a.Id == obj1.Id).FirstOrDefaultAsync();
            ResponseModel responseModel = new ResponseModel();
            try
            {
                var ismailexists = _db.Employeetable.Where(em => em.Email == obj1.Email).ToList();
                if (ismailexists.Count > 0)
                {
                    throw new Exception();
                }
                if (Emp != null)
                {
                    Emp.Name = obj1.Name;
                    Emp.Phonenumber = obj1.Phonenumber;
                    Emp.Email = obj1.Email;
                    Emp.City = obj1.City;
                    Emp.Pincode = obj1.Pincode;
                    Emp.Salary = obj1.Salary;
                    _db.Employeetable.Update(Emp);
                    await _db.SaveChangesAsync();
                    int result = responseModel.Id = Emp.Id;
                    responseModel.Additionalinfo = "Employee details updated Successfully";
                    return responseModel;

                }
            }


            catch (Exception e)
            {
                responseModel.Additionalinfo = "invalid data";
               
            }
             throw new EmailException();

        }
    }

}



