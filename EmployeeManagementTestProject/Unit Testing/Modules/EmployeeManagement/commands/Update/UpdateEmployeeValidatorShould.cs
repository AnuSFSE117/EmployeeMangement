using EmployeeMangement.Modules.EmployeeManagement.command.create;
using EmployeeMangement.Modules.EmployeeManagement.command.Update;
using FluentValidation.TestHelper;

namespace EmployeeManagementTestProject.Unit_Testing.Modules.EmployeeManagement.create
{
    public class UpdateEmployeeValidatorShould
    {
        UpdateEmployeeValidator validator;
        public UpdateEmployeeValidatorShould() {

            validator = new UpdateEmployeeValidator();
        }
        [Fact]
        public void FailsifNoMinimumId() 
        {
            var request=new UpdateEmployee() {Id = 0, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldHaveValidationErrorFor(x => x.Id, request);
        }
        [Fact]
        public void FailsifNameEmpty()
        {
            var request = new UpdateEmployee() {Id=1, Name = "", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldHaveValidationErrorFor(x => x.Name, request);


        }
        [Fact]
        public void FailsifNameNull()
        {
            var request = new UpdateEmployee() { Id = 1, Phonenumber = 9791211302, Email = "anu26@gmaail.com ", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldHaveValidationErrorFor(x => x.Email, request);


        }
        [Fact]
        public void FailsifNoMinimumCharacters()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "An", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldHaveValidationErrorFor(x => x.Name, request);


        }
        [Fact]
        public void FailsifInvalidName()
        {
            var request = new UpdateEmployee() { Name = "Anu123", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldHaveValidationErrorFor(x => x.Name, request);


        }
        [Fact]
        public void FailsifPhoneNumberEmpty()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 0, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldHaveValidationErrorFor(x => x.Phonenumber, request);


        }
        [Fact]
        public void FailsifInvalidPhoneNumber()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 979121130, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldHaveValidationErrorFor(x => x.Phonenumber, request);


        }
        [Fact]
        public void FailsifEmailEmpty()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = " ", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldHaveValidationErrorFor(x => x.Email, request);


        }
        [Fact]
        public void FailsifEmailNull()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldHaveValidationErrorFor(x => x.Email, request);


        }
        [Fact]
        public void FailsifInvalidEmailId()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26gmail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldHaveValidationErrorFor(x => x.Email, request);

        }
        [Fact]
        public void FailsifCityEmpty()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = " ", Pincode = 629179, Salary = 10000 };
            validator.ShouldHaveValidationErrorFor(x => x.City, request);

        }
        
        [Fact]
        public void FailsifInvalidCityName()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai12", Pincode = 629179, Salary = 10000 };
            validator.ShouldHaveValidationErrorFor(x => x.City, request);

        }
        [Fact]
        public void FailsifPincodeEmpty()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 0, Salary = 10000 };
           validator.ShouldHaveValidationErrorFor(x => x.Pincode, request);

        }
        [Fact]
        public void FailsifInvalidPincode()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 62917, Salary = 10000 };
            validator.ShouldHaveValidationErrorFor(x => x.Pincode, request);

        }
        [Fact]
        public void FailsifSalaryEmpty()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179 ,Salary=0};
            validator.ShouldHaveValidationErrorFor(x => x.Salary, request);

        }
        [Fact]
        public void PassifValidId()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Id, request);

        }


        [Fact]
        public void PassifValidName()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Name, request);

        }
       
        [Fact]
        public void PassifvalidPhoneNumber()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Phonenumber, request);

        }
       
        [Fact]
        public void PassifvalidEmailId()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Email, request);

        }
        
       
        [Fact]
        public void PassifvalidCityName()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldNotHaveValidationErrorFor(x => x.City, request);

        }
       
        [Fact]
        public void PassifvalidPincode()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Pincode, request);

        }
        [Fact]
        public void PassifSalaryNotEmpty()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmaail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.ShouldNotHaveValidationErrorFor(x => x.Salary, request);

        }
        [Fact]
        public void Passverification()
        {
            var request = new UpdateEmployee() { Id = 1, Name = "Anu", Phonenumber = 9791211302, Email = "anu26@gmail.com", City = "Chennai", Pincode = 629179, Salary = 10000 };
            validator.Validate(request);
        }



    }
}


    

