namespace EmployeeMangement.Exceptions
{
    public class RecordsNotFoundException : Exception
    {
        public RecordsNotFoundException() : base(message: "Records are not found") { }

    }
}
