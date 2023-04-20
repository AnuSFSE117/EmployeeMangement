﻿using EmployeeMangement.Exceptions;
using EmployeeMangement.Models;
using EmployeeMangement.Modules.EmployeeManagement.command.Delete;
using EmployeeMangement.Modules.EmployeeManagement.command.Update;
using EntityFrameworkCoreMock;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementTestProject.Unit_Testing.Modules.EmployeeManagement.commands.commands.delete
{
    public class DeleteEmployeeShould
    {
        DbContextMock<EmployeeDbcontext> dbContextMock;
        DeleteEmployeeHandler handler;
        List<EmployeeModel> employees = new List<EmployeeModel>() { new EmployeeModel { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu2611@gmail.com", City = "Chennai", Pincode = 629179, Salary = 10000 } };
        DbContextOptions<EmployeeDbcontext> dbContextOptions { get; } = new DbContextOptionsBuilder<EmployeeDbcontext>().Options;
        public DeleteEmployeeShould()
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
            Assert.True(response.Result.Id == 1);


        }
        [Fact]
        public void Exceptionvalidation()
        {
            var request = new DeleteEmployee() { Id = 6};
            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 0; })).Verifiable();
            var response = Record.ExceptionAsync(async () => await handler.Handle(request, CancellationToken.None));
            Assert.IsType<IdNotFoundException>(response.Result);
        }

    }
}