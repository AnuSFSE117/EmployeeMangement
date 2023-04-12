using FluentValidation;

namespace EmployeeMangement.Modules.EmployeeManagement.Query.Get
{
    public class getEmployeeByIdValidator : AbstractValidator<GetEmployeebyId>
    {
        public getEmployeeByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();

        }


    }


}
