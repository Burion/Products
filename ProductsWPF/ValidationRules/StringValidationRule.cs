using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace ProductsWPF.ValidationRules
{
    public class StringValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string strValue = Convert.ToString(value);

            if (string.IsNullOrEmpty(strValue))
                return new ValidationResult(false, $"Value cannot be empty");
            return new ValidationResult(true, null);
        }
    }
}