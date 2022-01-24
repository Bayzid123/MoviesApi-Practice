using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MoviesApi.Validations
{
    public class ContentTypeValidator: ValidationAttribute
    {
        private readonly string[] validContentTypes;
        public readonly string[] imageContentTypes = new string[] { "image/jpeg", "image/png", "image/gif" };

        public ContentTypeValidator(string[] ValidContentTypes)
        {
            validContentTypes = ValidContentTypes;
        }

        public ContentTypeValidator(ContentTypeGroup contentTypeGroup)
        {
            switch (contentTypeGroup)
            {
                case ContentTypeGroup.Image:
                    validContentTypes = imageContentTypes;
                    break;
            }
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
            if (!validContentTypes.Contains(formfile.ContentType))
            {
                return new ValidationResult($"Content-Type should be one of the following:{string.Join(",", validContentTypes)}");
            }
            return ValidationResult.Success;
        }
    }

    public enum ContentTypeGroup
    {
        Image,
    }
}
