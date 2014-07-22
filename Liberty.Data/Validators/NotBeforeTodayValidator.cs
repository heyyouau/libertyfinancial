using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liberty.Data.Validators
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple=false)]
    public sealed class NotBeforeTodayValidator : ValidationAttribute
    {
        public NotBeforeTodayValidator(string validationMessage):base()
        {
            ErrorMessage = validationMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var x = value;
            return base.IsValid(value, validationContext);
        }
        public override bool IsValid(object value)
        {
            return (DateTime)value < DateTime.Today;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }

    }
}
