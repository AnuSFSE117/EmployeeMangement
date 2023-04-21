using EmployeeMangement.Controllers;
using EmployeeMangement.Models;
using EmployeeMangement.Modules.EmployeeManagement.command.Delete;
using EmployeeMangement.Modules.EmployeeManagement.command.Update;
using EmployeeMangement.Modules.EmployeeManagement.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeManagementTestProject.Unit_Testing.ControllerUnittesting
{
    public class GetByIdControllerUnitTesting
    {

        private Mock<IMediator> _mediatorMock;
        private EmployeeController _employeeController;
        public GetByIdControllerUnitTesting()
        {
            _mediatorMock = new Mock<IMediator>();
            _employeeController = new EmployeeController(_mediatorMock.Object);
        }

        [Theory]
        [InlineData(1)]

        public async Task GetByIdEmployee_ReturnsCorrectResponse(int id)
        {
            var data = new GetEmployeebyId (){ Id = 1 };
            

            #region"Assign"
            var entity = new EntityModel() { ResponseId = 1, Additionalinfo = "Employee detail is effected" };
            _mediatorMock.Setup(x => x.Send(It.IsAny<EmployeeModel>, default)).ReturnsAsync(entity);
            #endregion

            #region"Act"
            var response = await _employeeController.GetById(data.Id);
            #endregion

            #region"Assert"
            Assert.IsAssignableFrom<OkObjectResult>(response);
            #endregion
        }
        [Fact]

        public async Task GetByIdEmployee_ReturnsFailResponse()
        {
            var data = new GetEmployeebyId { Id = 2 };

            var entity = new List<EmployeeModel>();

            #region"Assign"
            _mediatorMock.Setup(x => x.Send(It.IsAny<EmployeeModel>(), default)).ReturnsAsync(entity);
            #endregion

            #region"Act"
            var response = await _employeeController.GetById(data.Id);
            #endregion

            #region"Assert"

            Assert.IsAssignableFrom<OkObjectResult>(response);
            #endregion
        }
        public class TestdataProvider
        {
            public static IEnumerable<object[]> CreateObject()
            {
                yield return new object[] {
                    new DeleteEmployee()
                    {
                        Id = 1,

                    }
                };
            }
        }
    }
}










