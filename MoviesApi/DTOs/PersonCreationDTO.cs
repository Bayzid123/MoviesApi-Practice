using Microsoft.AspNetCore.Http;
using MoviesApi.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.DTOs
{
    public class PersonCreationDTO: PersonPatchDTO
    {
        [FileSizeValidator(MaxFileSizeInMbs: 4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile Picture { get; set; }
    }
}
