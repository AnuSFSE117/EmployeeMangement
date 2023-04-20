using EmployeeMangement.Exceptions;
using EmployeeMangement.Models;
using EmployeeMangement.Modules.EmployeeManagement.Query.Get;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using static EmployeeMangement.Modules.EmployeeManagement.Query.Get.GetEmployee;

namespace EmployeeManagementTestProject.Unit_Testing.Modules.EmployeeManagement.commands.Query.Get
{
    public class GetEmployeeShould
    {
        //creating a virtual database
        DbContextMock<EmployeeDbcontext> dbContextMock;
        GetEmployeeHandler handler;
        List<EmployeeModel> employees = new List<EmployeeModel>(); //{ new EmployeeModel { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu2611@gmail.com", City = "Chennai", Pincode = 629179, Salary = 10000 } };
        DbContextOptions<EmployeeDbcontext> dbContextOptions { get; } = new DbContextOptionsBuilder<EmployeeDbcontext>().Options;
        public GetEmployeeShould()
        {
            dbContextMock = new DbContextMock<EmployeeDbcontext>(dbContextOptions);
            handler = new GetEmployeeHandler(this.dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.Employeetable, employees);

        }
        [Fact]
        public void passvalidation()
        {
            var request = new GetEmployee() ;
            var response = handler.Handle(request, CancellationToken.None);
            Assert.True(response.Result.Count>0);


        }
        [Fact]
        public void Exceptionvalidation()
        {
            var request = new GetEmployee() ;
            var response = Record.ExceptionAsync(async () => await handler.Handle(request, CancellationToken.None));
            Assert.IsType<RecordsNotFoundException>(response.Result);
        }

    }
}
