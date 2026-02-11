using System.ComponentModel.DataAnnotations;

namespace ASP.NET_Core_Katmanli_Mimari_Projesi.Infrastructure.Validation
{
    public class EmailDomainAttribute : ValidationAttribute
    {
        private readonly string[] _allowedDomains;

        public EmailDomainAttribute(params string[] allowedDomains)
        {
            _allowedDomains = allowedDomains;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string email && !string.IsNullOrEmpty(email))
            {
                var domain = email.Split('@').LastOrDefault();
                if (domain != null && _allowedDomains.Contains(domain.ToLower()))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult($"Email domain must be one of: {string.Join(", ", _allowedDomains)}");
            }
            return ValidationResult.Success;
        }
    }
}

