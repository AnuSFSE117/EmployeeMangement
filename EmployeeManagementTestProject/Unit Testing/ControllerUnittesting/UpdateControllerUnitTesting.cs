using EmployeeMangement.Controllers;
using EmployeeMangement.Models;
using EmployeeMangement.Modules.EmployeeManagement.command.create;
using EmployeeMangement.Modules.EmployeeManagement.command.Update;
using MediatR;
using Moq;
using static EmployeeManagementTestProject.Unit_Testing.ControllerUnittesting.CreateControllerUnitTesting;

namespace EmployeeManagementTestProject.Unit_Testing.ControllerUnittesting
{
    public class UpdateControllerUnitTesting
    {

        Mock<IMediator> _mediatorMock;
        EmployeeController _employeeController;
        public UpdateControllerUnitTesting()
        {
            _mediatorMock = new Mock<IMediator>();
            _employeeController = new EmployeeController(_mediatorMock.Object);
        }

        [Theory]
        [MemberData(nameof(TestdataProvider.CreateObject), MemberType = typeof(TestdataProvider))]
        public async Task UpdateEmployee_ReturnsCorrectResponse(UpdateEmployee data)
        {



            #region"Assign"
            var entity = new EntityModel() { ResponseId = 1, Additionalinfo = "Employee Details updated" };
            _mediatorMock.Setup(x => x.Send(It.IsAny<UpdateEmployee>(), default)).ReturnsAsync(entity);
            #endregion

            #region"Act"
            var response = await _employeeController.Update(data);
            #endregion

            #region"Assert"
            Assert.IsAssignableFrom<EntityModel>(response);
            #endregion
        }
   
        public class TestdataProvider
        {
            public static IEnumerable<object[]> CreateObject()
            {
                yield return new object[] {
                    new UpdateEmployee()
                    {
                        Id = 1,
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









