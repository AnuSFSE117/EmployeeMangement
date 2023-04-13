using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EmployeeMangement.Validators
{
    public class PincodeValidation : PropertyValidator
    {
        public PincodeValidation() : base("Invalid Pincode")
        {

        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            Regex regex = new Regex("^[5-6]{1}[0-9]{2}\\s{0,1}[0-9]{3}$");
            Match match = regex.Match(context.PropertyValue.ToString());
            if (match.Success)
                return true;
            else
                return false;
        }
    }
}
