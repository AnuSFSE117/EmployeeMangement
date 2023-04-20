using EmployeeMangement.Validators;
using FluentValidation;

namespace EmployeeMangement.Modules.EmployeeManagement.command.Update
{
    public class Updateemployeevalidator : AbstractValidator<updateEmployee>
    {
        public Updateemployeevalidator()
        {
            RuleFor(x => x.Id).Cascade(CascadeMode.StopOnFirstFailure).InclusiveBetween(1, 100).WithMessage("Invalid id");

            RuleFor(x => x.Name).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
                .WithMessage("{PropertyName} should not be empty")
               .Length(3, 25).WithMessage("{PropertyName} should  between 3 and 25 characters")
                 .SetValidator(new Namevalidator()).WithMessage("Invalid{PropertyName}");

            RuleFor(x => x.Phonenumber).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
                .WithMessage("{PropertyName} should not be empty")
                .SetValidator(new PhonenumberValidation()).WithMessage("Invalid PhoneNumber");


            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} should not be empty")
                .NotNull().WithMessage("{PropertyName}should not be Null")
                .SetValidator(new Validators.EmailValidation());



            RuleFor(x => x.City).NotEmpty().WithMessage("{PropertyName} should not be empty").SetValidator(new Cityvalidation());
                
            RuleFor(x => x.Pincode).NotEmpty().WithMessage("{PropertyName} should not be empty")
                .SetValidator(new PincodeValidation());

            RuleFor(x => x.Salary).NotEmpty().WithMessage("{PropertyName} should not be Null");

        }
        
    }


}


