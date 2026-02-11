using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Katmanli_Mimari_Projesi.Infrastructure.Validation
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime birthDate)
            {
                var age = DateTime.Today.Year - birthDate.Year;
                if (birthDate.Date > DateTime.Today.AddYears(-age)) age--;

                if (age >= _minimumAge)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult($"Minimum age must be {_minimumAge}");
            }
            return ValidationResult.Success;
        }
    }
}

