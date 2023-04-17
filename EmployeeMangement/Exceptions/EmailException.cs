namespace EmployeeMangement.Exception_Handling
{
    public class EmailException: Exception
    {
        public EmailException() : base(message: "Employee is already Exist") { }

    }
}
