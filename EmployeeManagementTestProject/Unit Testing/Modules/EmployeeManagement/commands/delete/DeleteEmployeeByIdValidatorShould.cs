using EmployeeMangement.Modules.EmployeeManagement.command.Delete;
using FluentValidation.TestHelper;

namespace EmployeeManagementTestProject.Unit_Testing.Modules.EmployeeManagement.create.commands
{
    public class DeleteEmployeeByIdValidatorShould
    {
        DeleteEmployeeByIdValidator validator;
        public DeleteEmployeeByIdValidatorShould()
        {
            validator= new DeleteEmployeeByIdValidator();
        }
        [Fact]
        public void failsIfNoMinimumId()
        {
            var request = new DeleteEmployee() { Id = 0 };
            validator.ShouldHaveValidationErrorFor(x => x.Id, request);
        }
        [Fact]
        public void PassIfValidId()
        {
            var request = new DeleteEmployee() { Id = 1 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Id, request);
        }
    }
}

