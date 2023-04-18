namespace EmployeeMangement.Exception_Handling
{
    public class EmailAlreadyExistsException: Exception
    {
        public EmailAlreadyExistsException() : base(message: "Mail Id is already Exist") { }

    }
   

}
