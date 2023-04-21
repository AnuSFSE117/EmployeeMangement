using FluentValidation;

namespace EmployeeMangement.Modules.EmployeeManagement.Query.GetById
{
    public class GetEmployeeByIdValidator : AbstractValidator<GetEmployeebyId>
    {
        public GetEmployeeByIdValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().InclusiveBetween(1, 100);

        }


    }


}
