using EmployeeMangement.Controllers;
using EmployeeMangement.Models;
using EmployeeMangement.Modules.EmployeeManagement.command.create;
using EmployeeMangement.Modules.EmployeeManagement.command.Delete;
using EmployeeMangement.Modules.EmployeeManagement.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementTestProject.Unit_Testing.ControllerUnittesting
{
    public class DeleteByIdControllerUnitTesting
    {

        private Mock<IMediator> _mediatorMock;
        private EmployeeController _employeeController;
        public DeleteByIdControllerUnitTesting()
        {
            _mediatorMock = new Mock<IMediator>();
            _employeeController = new EmployeeController(_mediatorMock.Object);
        }

        [Theory]
        [InlineData(1)]

        public async Task DeleteByIdEmployee_ReturnsCorrectResponse(int id)
        {
            var data = new DeleteEmployee { Id = 1 };

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

        public async Task DeleteByIdEmployee_ReturnsFailResponse()
        {
            var data = new DeleteEmployee { Id = 2 };

           

            #region"Assign"
            var entity = new EntityModel() { ResponseId = 0, Additionalinfo = "Employee detail is effected" };
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









