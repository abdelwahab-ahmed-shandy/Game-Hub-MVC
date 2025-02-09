namespace GameZone.Attributes
{
    public class FileMaxSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;

        public FileMaxSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file is not null)
            {
                var extension = Path.GetExtension(file.FileName);

                if (file.Length > _maxSize)
                {
                    return new ValidationResult(errorMessage: $"Max allwed size is {_maxSize} bytes !?");
                }
            }

            return ValidationResult.Success;
        }
    }

}
