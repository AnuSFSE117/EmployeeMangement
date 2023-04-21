using EmployeeMangement.Modules.EmployeeManagement.command.create;
using EmployeeMangement.Modules.EmployeeManagement.command.Update;
using FluentValidation;
using FluentValidation.TestHelper;

namespace EmployeeMangement.Unit_Testing.Modules.EmployeeManagement.create
{
    public class CreateEmployeeValidatorShould
    {
        CreateEmployeeValidator validator;
        public CreateEmployeeValidatorShould()
        {
            validator = new CreateEmployeeValidator();        
        }
        [Fact]
        public void FailsIfNameEmpty()
        {
            var request = new CreateEmployee() { Name="",Phonenumber=9791211302,Email="anu26@gmaail.com",City="Chennai",Pincode=629179,Salary=10000};
           // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Name, request);
            
        }
        [Fact]
        public void FailsIfNameNull()
        {
            var request = new CreateEmployee() { Phonenumber = 9791211302, Email = "anu26@gmaail.com ", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Email, request);

        }
        [Fact]
        public void FailsIfNameHasNoMinimumCharacters()
        {
            var request = new CreateEmployee() { Name="An", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Name, request);

        }
        [Fact]
        public void FailsIfInvalidName()
        {
            var request = new CreateEmployee() { Name = "Anu123", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Name, request);

        }
        [Fact]
        public void FailsIfPhoneNumberEmpty()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 0, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Phonenumber, request);

        }
        [Fact]
        public void FailsifInvalidPhoneNumber()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 979121130, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Phonenumber, request);

        }
        [Fact]
        public void FailsIfEmailEmpty()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = " ", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Email, request);

        }
        [Fact]
        public void FailsIfEmailNull()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Email, request);

        }
        [Fact]
        public void FailsIfInvalidEmailId()
        {
            var request = new CreateEmployee() {Name = "Anu", Phonenumber = 9791211302, Email = "anu26gmail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Email, request);

        }
        [Fact]
        public void FailsIfCityEmpty()
        {
            var request = new CreateEmployee() {Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.City, request);

        }
       
        [Fact]
        public void FailsIfInvalidCityName()
        {
            var request = new CreateEmployee() {Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai12", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.City, request);

        }
        [Fact]
        public void FailsifPincodeEmpty()
        {
            var request = new CreateEmployee() {Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 0, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Pincode, request);

        }
        [Fact]
        public void failsIfInvalidPincode()
        {
            var request = new CreateEmployee() {Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 62917, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Pincode, request);

        }
        [Fact]
        public void failsifSalaryEmpty()
        {
            var request = new CreateEmployee() {Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179,Salary=0};
            // validator.Validate(request);
            validator.ShouldHaveValidationErrorFor(x => x.Salary, request);

        }
        
        [Fact]
        public void PassIfValidName()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Name, request);

        }
       
        [Fact]
        public void passIfvalidPhoneNumber()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Phonenumber, request);

        }
       
        [Fact]
        public void PassIfvalidEmailId()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Email, request);

        }
       
        [Fact]
        public void PassIfvalidCityName()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.City, request);

        }
       
        [Fact]
        public void PassIfvalidPincode()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Pincode, request);

        }
        [Fact]
        public void PassIfSalaryNotEmpty()
        {
            var request = new CreateEmployee() { Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179,Salary=10000 };
            // validator.Validate(request);
            validator.ShouldNotHaveValidationErrorFor(x => x.Salary, request);

        }
        [Fact]
        public void Passverification()
        {
            var request = new CreateEmployee() {Name = "Vishnu", Phonenumber = 9791211302, Email = "anu2611200@gmail.com", City = "Chennai", Pincode = 600040, Salary = 10000 };
            validator.Validate(request);
        }



    }
}
