using EmployeeMangement.Models;
using FluentValidation;

namespace EmployeeMangement.Validators
{
    public class ModelValidator
    {
        public class EmployeeValidator : AbstractValidator<EmployeeModel>
        {
            public EmployeeValidator()
            {
                RuleFor(x => x.Name).NotNull();
                RuleFor(x => x.Phonenumber).NotNull().WithMessage("provide valid phonenumber");
                RuleFor(x => x.Email).EmailAddress().NotNull();
                RuleFor(x => x.City).NotEmpty().MaximumLength(10);
                RuleFor(x => x.Pincode).NotEmpty().WithMessage("provide valid pincode");
                RuleFor(x => x.Salary).NotEmpty();


            }
        }
    }
}
