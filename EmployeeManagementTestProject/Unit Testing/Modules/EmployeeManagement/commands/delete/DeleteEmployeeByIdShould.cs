using EmployeeMangement.Exceptions;
using EmployeeMangement.Models;
using EmployeeMangement.Modules.EmployeeManagement.command.Delete;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementTestProject.Unit_Testing.Modules.EmployeeManagement.commands.commands.delete
{
    public class DeleteEmployeeByIdShould
    {
        DbContextMock<EmployeeDbcontext> dbContextMock;
        DeleteEmployeeHandler handler;
        List<EmployeeModel> employees = new List<EmployeeModel>() { new EmployeeModel { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu2611@gmail.com", City = "Chennai", Pincode = 629179, Salary = 10000 } };
        DbContextOptions<EmployeeDbcontext> dbContextOptions { get; } = new DbContextOptionsBuilder<EmployeeDbcontext>().Options;
        public DeleteEmployeeByIdShould()
        {
            dbContextMock = new DbContextMock<EmployeeDbcontext>(dbContextOptions);
            handler = new DeleteEmployeeHandler(this.dbContextMock.Object);
            dbContextMock.CreateDbSetMock(x => x.Employeetable, employees);

        }
        [Fact]
        public void passvalidation()
        {
            var request = new DeleteEmployee() { Id = 1 };
            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 1; })).Verifiable();
            var response = handler.Handle(request, CancellationToken.None);
            Assert.True(response.Result.ResponseId == 1);


        }
        [Fact]
        public void ThrowsIdNotFoundException()
        {
            var request = new DeleteEmployee() { Id = 6};
            var response = Record.ExceptionAsync(async () => await handler.Handle(request, CancellationToken.None));
            Assert.IsType<IdNotFoundException>(response.Result);

        }

    }
}
