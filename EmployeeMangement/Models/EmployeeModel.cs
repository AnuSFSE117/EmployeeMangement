using FluentValidation;
using FluentValidation.Validators;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMangement.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public long Phonenumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public int Pincode { get; set; }
        public int Salary { get; set; }

    }
    public class EmployeeValidator : AbstractValidator<EmployeeModel>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Phonenumber).NotNull().WithMessage("provide valid phonenumber");
            RuleFor(x => x.Email).NotNull();
            RuleFor(x => x.City).NotEmpty().Length(1, 12);
            RuleFor(x => x.Pincode).NotEmpty().WithMessage("provide valid pincode");
            RuleFor(x => x.Salary).NotEmpty();

            
        }
    }
}
