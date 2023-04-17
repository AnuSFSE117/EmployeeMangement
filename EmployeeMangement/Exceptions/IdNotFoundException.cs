namespace EmployeeMangement.Exceptions
{
    public class IdNotFoundException:Exception
    {
        public IdNotFoundException() :base(message:"Id not found")
        {

        }
    }
}
