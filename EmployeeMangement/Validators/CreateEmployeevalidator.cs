using EmployeeMangement.command;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeMangement.Validators
{
    public class CreateEmployeevalidator : AbstractValidator<CreateEmployee>
    {
        public CreateEmployeevalidator()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
                .WithMessage("{PropertyName} should be not empty. NEVER!")
                 .Length(3, 25).WithMessage("{PropertyName} should  be 3 and 25 characters")
                 .Must(IsValidName).WithMessage("{PropertyName} should all be Letters");
            

            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email address is required")
                .EmailAddress().WithMessage("Your email address is not valid")
                .Must(IsValidEmail);

            
        }


        private bool IsValidName(string name)
        {
            return name.All(char.IsLetter);
        }

        private  bool IsValidEmail(string mail)
        {
            
            var regex=new Regex(@"([a-z0-9!#$%&'*/+=?_{|}~](<*>\");
            return regex.IsMatch(mail);  
        }






    }


}
