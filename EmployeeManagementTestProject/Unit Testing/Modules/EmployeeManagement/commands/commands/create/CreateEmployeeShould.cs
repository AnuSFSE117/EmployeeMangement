using EmployeeMangement.Exception_Handling;
using EmployeeMangement.Models;
using EmployeeMangement.Modules.EmployeeManagement.command.create;
using EntityFrameworkCoreMock;using Microsoft.EntityFrameworkCore;using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementXunitTest.Unit_Test.Modules.EmployeeManagement.Command.Create{    public class CreateEmployeeShould    {        DbContextMock<EmployeeDbcontext> dbContextMock;        CreateEmployeeHandler handler;        List<EmployeeModel> employees = new List<EmployeeModel>();        DbContextOptions<EmployeeDbcontext> dbContextOptions { get; } = new DbContextOptionsBuilder<EmployeeDbcontext>().Options;
        public CreateEmployeeShould()        {            dbContextMock = new DbContextMock<EmployeeDbcontext>(dbContextOptions);            handler = new CreateEmployeeHandler(this.dbContextMock.Object);            dbContextMock.CreateDbSetMock(x => x.Employeetable, employees);        }        [Fact]        public void passvalidation()        {            var request = new CreateEmployee() {Name="Anu", Phonenumber = 9791211302, Email = "anu26@gmail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 1; })).Verifiable();            var response = handler.Handle(request, CancellationToken.None);            Assert.True(response.Result.Id ==1);                             }        [Fact]        public void Exceptionvalidation()        {
            var request = new CreateEmployee() { Name = "vishnu", Phonenumber = 7591211302, Email = "anu2611@gmail.com", City = "porur", Pincode = 600040, Salary = 15000 };
            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 0; })).Verifiable();
            var response=Record.ExceptionAsync(async()=>await handler.Handle(request, CancellationToken.None));
            Assert.IsType<EmailAlreadyExistsException>(response.Result);
        }           }}