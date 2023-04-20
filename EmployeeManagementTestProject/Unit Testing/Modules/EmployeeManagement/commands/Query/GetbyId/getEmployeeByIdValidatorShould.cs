using EmployeeMangement.Modules.EmployeeManagement.command.Delete;
using EmployeeMangement.Modules.EmployeeManagement.Query.GetById;
using FluentValidation.TestHelper;

namespace EmployeeManagementTestProject.Unit_Testing.Modules.EmployeeManagement.create.Query
{
    public class getEmployeeByIdValidatorShould
    {
        getEmployeeByIdValidator validator;
        public getEmployeeByIdValidatorShould()
        {
            validator = new getEmployeeByIdValidator();


        }
        [Fact]
        public void NotMinimumId()
        {
            var request = new GetEmployeebyId() { Id = 0 };
            validator.ShouldHaveValidationErrorFor(x => x.Id, request);
        }
        public void MinimumId()
        {
            var request = new GetEmployeebyId() { Id = 1 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Id, request);
        }
    }
}
