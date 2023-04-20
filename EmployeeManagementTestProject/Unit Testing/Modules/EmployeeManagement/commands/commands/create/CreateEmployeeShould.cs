﻿using EmployeeMangement.Exception_Handling;
using EmployeeMangement.Models;
using EmployeeMangement.Modules.EmployeeManagement.command.create;
using EntityFrameworkCoreMock;

namespace EmployeeManagementXunitTest.Unit_Test.Modules.EmployeeManagement.Command.Create
        public CreateEmployeeShould()
            var request = new CreateEmployee() { Name = "vishnu", Phonenumber = 7591211302, Email = "anu2611@gmail.com", City = "porur", Pincode = 600040, Salary = 15000 };
            dbContextMock.Setup(x => x.SaveChangesAsync(CancellationToken.None)).Returns(() => Task.Run(() => { return 0; })).Verifiable();
            var response=Record.ExceptionAsync(async()=>await handler.Handle(request, CancellationToken.None));
            Assert.IsType<EmailAlreadyExistsException>(response.Result);
        }