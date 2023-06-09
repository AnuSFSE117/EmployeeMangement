﻿using EmployeeMangement.Models;
using EmployeeMangement.Validators;
using FluentValidation;

namespace EmployeeMangement.Modules.EmployeeManagement.command.create
{
    public class CreateEmployeeValidator : AbstractValidator<CreateEmployee>
    {
        
        public CreateEmployeeValidator()
        {

            RuleFor(x => x.Name).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
                .WithMessage("{PropertyName} should not be empty")
                 .Length(3, 25).WithMessage("{PropertyName} should  between 3 and 25 characters")
                 .SetValidator(new Stringvalidation()).WithMessage("Invalid Name");

            RuleFor(x => x.Phonenumber).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty()
                .WithMessage("{PropertyName} should not be empty")
                .SetValidator(new PhonenumberValidation()).WithMessage("Invalid PhoneNumber");


            RuleFor(x => x.Email).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("{PropertyName} should not be empty")
                .NotNull().WithMessage("{PropertyName}should not be Null")
                .SetValidator(new EmailValidation());

            RuleFor(x => x.City).NotEmpty().WithMessage("{PropertyName} should not be empty").SetValidator(new Stringvalidation());
               
               

            RuleFor(x => x.Pincode).Cascade(CascadeMode.StopOnFirstFailure).NotEmpty().WithMessage("{PropertyName} should not be empty")
                .SetValidator(new PincodeValidation());

            RuleFor(x => x.Salary).NotEmpty().WithMessage("{PropertyName} should not be Null");

        }
        


        
        





    }


}
