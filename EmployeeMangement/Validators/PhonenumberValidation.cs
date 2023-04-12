using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EmployeeMangement.Validators
{
    public class PhonenumberValidation : PropertyValidator
    {
        public PhonenumberValidation() : base("Please enter Correct PhoneNumber")
        {

        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            Regex regex = new Regex("[0-9]");
            if (context.PropertyValue != null)
            {
                return regex.Equals(context.PropertyValue);
            }
            else
            {
                return false;
            }
        }
    }
}
