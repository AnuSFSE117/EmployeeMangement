namespace EmployeeMangement.Exceptions
{
    public class IdNotFoundException:Exception
    {
        //gives the msg if the id is not found
        public IdNotFoundException() :base(message:"Id not found")
        {

        }
    }
}
