using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Validations
{
    public class FileSizeValidator: ValidationAttribute
    {
        private readonly int maxFileSizeInMbs;

        public FileSizeValidator(int MaxFileSizeInMbs)
        {
            this.maxFileSizeInMbs = MaxFileSizeInMbs;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            IFormFile formfile = value as IFormFile;
            if (formfile == null)
            {
                return ValidationResult.Success;
            }
            if (formfile.Length > maxFileSizeInMbs * 1024 * 1024)
            {
                return new ValidationResult($"File size cannot be bigger than {maxFileSizeInMbs}megabytes");
            }
            return ValidationResult.Success;
        }
    }
}
