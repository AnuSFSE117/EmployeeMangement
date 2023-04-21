using EmployeeMangement.Controllers;
using EmployeeMangement.Models;
using EmployeeMangement.Modules.EmployeeManagement.Query.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EmployeeManagementTestProject.Unit_Testing.ControllerUnittesting
{
    public class GetAllEmployeeUnitTesting
    {
         Mock<IMediator> _mediatorMock;
         EmployeeController _employeeController;
        public List<EmployeeModel> Employee = new List<EmployeeModel>
        {
            new EmployeeModel{Id=1,Name="Shan",Phonenumber=9787654321,Email="Shan@gmail.com",City="Salem",Pincode=678876,Salary=15000}
        };
        public GetAllEmployeeUnitTesting()
        {
            _mediatorMock = new Mock<IMediator>();
            _employeeController = new EmployeeController(_mediatorMock.Object);
        }

        [Fact]

        public async Task GetAllEmployee_ReturnsCorrectResponse()
        {
            var data = new GetEmployee();
            #region"Assign"
            _mediatorMock.Setup(x => x.Send(data, default)).ReturnsAsync(Employee);
            #endregion
            #region"Act"
            var response = await _employeeController.Getall();
            #endregion
            #region"Assert"
            Assert.IsAssignableFrom<OkObjectResult>(response);
            #endregion
        }


    }
}
