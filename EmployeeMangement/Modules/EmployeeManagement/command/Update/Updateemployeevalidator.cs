using EmployeeMangement.Validators;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EmployeeMangement.Modules.EmployeeManagement.command.Update
{
    public class Updateemployeevalidator : AbstractValidator<updateEmployee>
    {
        public Updateemployeevalidator()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
                .WithMessage("{PropertyName} should not be empty")
                 .Length(3, 25).WithMessage("{PropertyName} should  between 3 and 25 characters")
                 .Must(IsValidName).WithMessage("Invalid{PropertyName}");

            RuleFor(x => x.Phonenumber).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
                .WithMessage("{PropertyName} should not be empty")
                .SetValidator(new PhonenumberValidation()).WithMessage("Invalid PhoneNumber");


            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("{PropertyName} should not be empty")
                .EmailAddress().WithMessage("Invalid Mailid")
                .SetValidator(new Validators.EmailValidator());

            RuleFor(x => x.City).NotEmpty().WithMessage("{PropertyName} should not be empty")
                .SetValidator(new Cityvalidation());

            RuleFor(x => x.Pincode).NotEmpty().WithMessage("{PropertyName} should not be empty")
                .SetValidator(new PincodeValidation());

            RuleFor(x => x.Salary).NotNull().WithMessage("{PropertyName} should not be Null");

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


