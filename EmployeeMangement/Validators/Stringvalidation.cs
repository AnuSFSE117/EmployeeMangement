using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EmployeeMangement.Validators
{
    public class Stringvalidation: PropertyValidator
    {
        public Stringvalidation() : base("Invalid {PropertyName}")
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

