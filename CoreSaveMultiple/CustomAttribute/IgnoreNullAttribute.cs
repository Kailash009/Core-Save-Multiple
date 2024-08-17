using System.ComponentModel.DataAnnotations;

namespace CoreSaveMultiple.CustomAttribute
{
    public class IgnoreNullAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            return ValidationResult.Success;
        }
    }
}
