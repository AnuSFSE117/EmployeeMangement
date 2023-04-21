using EmployeeMangement.Exception_Handling;
using EmployeeMangement.Models;
using EmployeeMangement.Modules.EmployeeManagement.command.create;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementXunitTest.Unit_Test.Modules.EmployeeManagement.Command.Create
{
    public class CreateEmployeeShould
    {
        DbContextMock<EmployeeDbcontext> dbContextMock;
        CreateEmployeeHandler handler;
        List<EmployeeModel> employees = new List<EmployeeModel>() { new EmployeeModel {  Name= "Anu", Phonenumber = 9791211302, Email = "anu26@Yahoo.com", City = "Chennai", Pincode = 629179, Salary = 10000  } };
        DbContextOptions<EmployeeDbcontext> dbContextOptions { get; } = new DbContextOptionsBuilder<EmployeeDbcontext>().Options;
        public CreateEmployeeShould()
        {
            dbContextMock = new DbContextMock<EmployeeDbcontext>(dbContextOptions);
            handler = new CreateEmployeeHandler(this.dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.Employeetable, employees);

        }
        [Fact]
        public void ThrowsEmailExistsException()
        {
            var request = new CreateEmployee() { Name = "vishnu", Phonenumber = 7591211302, Email = "anu26@Yahoo.com", City = "porur", Pincode = 600040, Salary = 15000 };
            var response = Record.ExceptionAsync(async () => await handler.Handle(request, CancellationToken.None));
            Assert.IsType<EmailAlreadyExistsException>(response.Result);
        }
        [Fact]
        public void passvalidation()
        {
            var request = new CreateEmployee() {Name="Anu", Phonenumber = 9791211302, Email = "anu26@gmail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 1; })).Verifiable();
            var response = handler.Handle(request, CancellationToken.None);
            Assert.True(response.Result.ResponseId ==1);
        }
        

       


    }
}

