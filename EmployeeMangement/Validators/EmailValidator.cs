using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EmployeeMangement.Validators
{
    public class EmailValidator : PropertyValidator
    {

        public EmailValidator() : base("Invalid MailId")
        {

        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", RegexOptions.IgnoreCase);
            if (context.PropertyValue != null)
            {
                return regex.IsMatch((string)context.PropertyValue);
            }
            else
            {
                return false;
            }


        }
    }

}

