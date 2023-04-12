using EmployeeMangement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeMangement.Modules.EmployeeManagement.command.Update

{
    public class updateEmployee : IRequest<string>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Phonenumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public int Salary { get; set; }

    }
    public class UpdateEmployeeHandler : IRequestHandler<updateEmployee, string>
    {
        private readonly EmployeeDbcontext _db;
        public UpdateEmployeeHandler(EmployeeDbcontext obj)
        {
            _db = obj;
        }
        public async Task<string> Handle(updateEmployee obj1, CancellationToken cancellationToken)
        {
            var Emp = await _db.Employeetable.Where(a => a.Id == obj1.Id).FirstOrDefaultAsync();
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
                return "Success";
            }
            else
            {
                throw new Exception("Invalid id");
            }
        }

    }

}

