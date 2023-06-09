﻿using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace EmployeeMangement.Validators
{
    public class PhonenumberValidation : PropertyValidator
    {
        public PhonenumberValidation() : base("Invalid PhoneNumber")
        {

        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            Regex regex = new Regex("[0-9]{10}");
            Match match = regex.Match(context.PropertyValue.ToString());
            if (match.Success)
                return true;
            else
                return false;
        }
    }    
}
