using System;
using System.Globalization;
using System.Windows.Controls;

namespace TILab1WPF.Validation
{
    public class RequiredValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string res = Convert.ToString(value);
            if (string.IsNullOrWhiteSpace(res))
            {
                return new ValidationResult(false, "Value cannot be empty");
            }

            return new ValidationResult(true, null);
        }
    }
}
