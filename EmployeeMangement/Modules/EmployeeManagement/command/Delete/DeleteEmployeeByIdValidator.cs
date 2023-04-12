
using FluentValidation;

namespace EmployeeMangement.Modules.EmployeeManagement.command.Delete
{
    public class DeleteEmployeeByIdValidator : AbstractValidator<DeleteEmployee>
    {
        public DeleteEmployeeByIdValidator()
        {

            RuleFor(x => x.Id).NotEmpty().NotNull();

        }
    }
}
