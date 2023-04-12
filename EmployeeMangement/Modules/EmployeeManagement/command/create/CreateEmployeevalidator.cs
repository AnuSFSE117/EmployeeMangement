using EmployeeMangement.Validators;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EmployeeMangement.Modules.EmployeeManagement.command.create
{
    public class CreateEmployeevalidator : AbstractValidator<CreateEmployee>
    {

        public CreateEmployeevalidator()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
                .WithMessage("{PropertyName} should be not empty")
                 .Length(3, 25).WithMessage("{PropertyName} should  be 3 and 25 characters")
                 .Must(IsValidName).WithMessage("{PropertyName} should all be Letters");

            RuleFor(x => x.Phonenumber).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
                .WithMessage("{PropertyName} should be not empty")
                .SetValidator(new PhonenumberValidation()).WithMessage("Invalid PhoneNumber");


            RuleFor(x => x.Email).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().NotNull().WithMessage("Email address is required")
                .EmailAddress().WithMessage("Your email address is not valid")
                .SetValidator(new EmailValidator());

            RuleFor(x => x.City).NotEmpty().WithMessage("City is required")
                .Must(IsValidName);

            RuleFor(x => x.Pincode).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("Pincode is required")
                .GreaterThanOrEqualTo(500000);

            RuleFor(x => x.Salary).NotNull().WithMessage("Salary cannot be Null");

        }


        private bool IsValidName(string name)
        {
            return name.All(char.IsLetter);
        }

        private bool IsValidEmail(string mail)
        {

            var regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            return regex.IsMatch(mail);
        }






    }


}
