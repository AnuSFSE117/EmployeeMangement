using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EmployeeMangement.Validators
{
    public class Cityvalidation : PropertyValidator
    {
        public Cityvalidation() : base("Invalid City")
        {

        }


        protected override bool IsValid(PropertyValidatorContext context)
        {
            Regex regex = new Regex(@"^[a-z\s]+$",RegexOptions.IgnoreCase);
            Match match = regex.Match(context.PropertyValue.ToString());
            if (match.Success)
                return true;
            else
                return false;
        }

    }

}

