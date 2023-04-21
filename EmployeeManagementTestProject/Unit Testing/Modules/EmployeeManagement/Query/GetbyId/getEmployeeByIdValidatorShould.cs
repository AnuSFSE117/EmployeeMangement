using EmployeeMangement.Modules.EmployeeManagement.command.Delete;
using EmployeeMangement.Modules.EmployeeManagement.Query.GetById;
using FluentValidation.TestHelper;

namespace EmployeeManagementTestProject.Unit_Testing.Modules.EmployeeManagement.create.Query
{
    public class getEmployeeByIdValidatorShould
    {
        GetEmployeeByIdValidator validator;
        public getEmployeeByIdValidatorShould()
        {
            validator = new GetEmployeeByIdValidator();


        }
        [Fact]
        public void FailsifNoMinimumId()
        {
            var request = new GetEmployeebyId() { Id = 0 };
            validator.ShouldHaveValidationErrorFor(x => x.Id, request);
        }
        [Fact]
        public void PassIfValidId()
        {
            var request = new GetEmployeebyId() { Id = 1 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Id, request);
        }
    }
}
