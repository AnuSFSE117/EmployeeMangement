using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EmployeeMangement.Validators
{
    public class Namevalidator: PropertyValidator
    {
        public Namevalidator() : base("Invalid City")
        {

        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            Regex regex = new Regex(@"^[a-z]+$", RegexOptions.IgnoreCase);
            Match match = regex.Match(context.PropertyValue.ToString());
            if (match.Success)
                return true;
            else
                return false;
        }

    }


}

