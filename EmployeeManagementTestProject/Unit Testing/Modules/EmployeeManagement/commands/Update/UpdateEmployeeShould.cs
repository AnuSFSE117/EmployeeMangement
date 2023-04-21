using EmployeeMangement.Exceptions;
using EmployeeMangement.Models;
using EmployeeMangement.Modules.EmployeeManagement.command.Update;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementTestProject.Unit_Testing.Modules.EmployeeManagement.commands.commands.Update
{
    public class UpdateEmployeeShould
    {
        DbContextMock<EmployeeDbcontext> dbContextMock;
        UpdateEmployeeHandler handler;
        List<EmployeeModel> employees = new List<EmployeeModel>() { new EmployeeModel {Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu2611@gmail.com", City = "Chennai", Pincode = 629179, Salary = 10000 } };
        DbContextOptions<EmployeeDbcontext> dbContextOptions { get; } = new DbContextOptionsBuilder<EmployeeDbcontext>().Options;
        public UpdateEmployeeShould()
        {
            dbContextMock = new DbContextMock<EmployeeDbcontext>(dbContextOptions);
            handler = new UpdateEmployeeHandler(this.dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.Employeetable, employees);

        }
        [Fact]
        public void passvalidation()
        {
            var request = new UpdateEmployee() {Id=1, Name = "shalini", Phonenumber = 7598275737, Email = "anu2611@gmail.com", City = "Chennai", Pincode = 600040, Salary = 15000 };
            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 1; })).Verifiable();
            var response = handler.Handle(request, CancellationToken.None);
            Assert.True(response.Result.ResponseId == 1);


        }
        [Fact]
        public void ThrowsRecordsNotFoundException()
        {
            var request = new UpdateEmployee() { Id=2,Name = "vishnu", Phonenumber = 7591211302, Email = "anu2611@gmail.com", City = "porur", Pincode = 600040, Salary = 15000 };
            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 0; })).Verifiable();
            var response = Record.ExceptionAsync(async () => await handler.Handle(request, CancellationToken.None));
            Assert.IsType<RecordsNotFoundException>(response.Result);
        }


    }
}
