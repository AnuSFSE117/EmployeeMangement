using EmployeeMangement.Controllers;
using EmployeeMangement.Models;
using EmployeeMangement.Modules.EmployeeManagement.command.create;
using MediatR;
using Moq;

namespace EmployeeManagementTestProject.Unit_Testing.ControllerUnittesting
{
    public class CreateControllerUnitTesting
    {

        Mock<IMediator> _mediatorMock;
        EmployeeController _employeeController;
        public CreateControllerUnitTesting()
        {
            _mediatorMock = new Mock<IMediator>();
            _employeeController = new EmployeeController(_mediatorMock.Object);
        }

        [Theory]
        [MemberData(nameof(TestdataProvider.CreateObject), MemberType=typeof(TestdataProvider))]
        public async Task CreateEmployee_ReturnsCorrectResponse(CreateEmployee data)
        {
            #region"Assign"
            var entity = new EntityModel() { ResponseId = 1, Additionalinfo = "Employee Details Created" };
            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateEmployee>(), default)).ReturnsAsync(entity);
            #endregion

            #region"Act"
            var response = await _employeeController.Create(data);
            #endregion

            #region"Assert"
            Assert.IsAssignableFrom<EntityModel>(response);
            #endregion
        }

        [Fact]

        public async Task CreateEmployee_ReturnsFailResponse()
        {
            var data = new CreateEmployee { };

            var entity = new EntityModel() { ResponseId = 0, Additionalinfo = "Employee Details Not Created" };

            #region"Assign"


            _mediatorMock.Setup(x => x.Send(It.IsAny<CreateEmployee>(), default)).ReturnsAsync(entity);


            #endregion

            #region"Act"
            var response = await _employeeController.Create(data);
            #endregion

            #region"Assert"

            Assert.NotEqual(1, response.ResponseId);
            #endregion
        }
        public class TestdataProvider
        {
            public static IEnumerable<object[]> CreateObject()
            {
                yield return new object[] {
                    new CreateEmployee()
                    {
                        Name="Joice",
                        Phonenumber=9791211302,
                        Email="Joice@gmail.com",
                        City="salem",
                        Pincode=678345,
                        Salary=10000

                    }
                };
            }
        }
    }
}
