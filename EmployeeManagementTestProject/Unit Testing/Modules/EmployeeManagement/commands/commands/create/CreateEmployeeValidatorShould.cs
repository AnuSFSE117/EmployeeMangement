using EmployeeMangement.Modules.EmployeeManagement.command.create;
using EmployeeMangement.Modules.EmployeeManagement.command.Update;
using FluentValidation.TestHelper;

namespace EmployeeMangement.Unit_Testing.Modules.EmployeeManagement.create
{
    public class CreateEmployeeValidatorShould
    {
        CreateEmployeevalidator validator;
        public CreateEmployeeValidatorShould()
        {
            validator = new CreateEmployeevalidator();        
        }
        [Fact]
        public void NameEmpty()
        {
            var request = new CreateEmployee() { Name="",Phonenumber=9791211302,Email="anu26@gmaail.com",City="Chennai",Pincode=629179,Salary=10000};
           // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Name, request);
            
        }
        [Fact]
        public void NameMinimumCharacters()
        {
            var request = new CreateEmployee() { Name="An", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Name, request);

        }
        [Fact]
        public void InvalidName()
        {
            var request = new CreateEmployee() { Name = "Anu123", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Name, request);

        }
        [Fact]
        public void PhoneNumberEmpty()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 0, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Phonenumber, request);

        }
        [Fact]
        public void InvalidPhoneNumber()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 979121130, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Phonenumber, request);

        }
        [Fact]
        public void EmailEmpty()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = " ", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Email, request);

        }
        [Fact]
        public void InvalidEmailId()
        {
            var request = new CreateEmployee() {Name = "Anu", Phonenumber = 9791211302, Email = "anu26gmail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Email, request);

        }
        [Fact]
        public void CityEmpty()
        {
            var request = new CreateEmployee() {Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = " ", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.City, request);

        }
        [Fact]
        public void InvalidCityName()
        {
            var request = new CreateEmployee() {Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai12", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.City, request);

        }
        [Fact]
        public void PincodeEmpty()
        {
            var request = new CreateEmployee() {Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 0, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Pincode, request);

        }
        [Fact]
        public void InvalidPincode()
        {
            var request = new CreateEmployee() {Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 62917, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Pincode, request);

        }
        [Fact]
        public void SalaryNull()
        {
            var request = new CreateEmployee() {Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179};
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Salary, request);

        }
        [Fact]
        public void NameNotEmpty()
        {
            var request = new CreateEmployee() { Name = "A1", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Name, request);

        }
        [Fact]
        public void HaveMinimumCharacters()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Name, request);

        }
        [Fact]
        public void ValidName()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Name, request);

        }
        [Fact]
        public void PhoneNumbeNotEmpty()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 784, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Phonenumber, request);

        }
        [Fact]
        public void validPhoneNumber()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Phonenumber, request);

        }
        [Fact]
        public void EmailNotEmpty()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = " anu", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Email, request);

        }
        [Fact]
        public void validEmailId()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Email, request);

        }
        public void CityNotEmpty()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = " A123", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.City, request);

        }
        [Fact]
        public void validCityName()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.City, request);

        }
        [Fact]
        public void PincodenotEmpty()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 87, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Pincode, request);

        }
        [Fact]
        public void validPincode()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Pincode, request);

        }
        [Fact]
        public void SalaryNotNull()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179,Salary=10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Salary, request);

        }



    }
}
