namespace GameZone.Attributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string _allowedExtensions;

        public AllowedExtensionsAttribute(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file is not null)
            {
                var extension = Path.GetExtension(file.FileName);
                
                if (!_allowedExtensions.Split(separator: ',').Contains(extension, StringComparer.OrdinalIgnoreCase))
                {
                    return new ValidationResult(errorMessage: $"Only {_allowedExtensions} Are Allowed !?");
                }
            }

            return ValidationResult.Success;
        }
    }
}
