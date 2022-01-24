using MoviesApi.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.DTOs
{
    public class GenreCreationDTO
    {
        [Required]
        [StringLength(40)]
        [FirstLetterUppercase]
        public string Name { get; set; }
    }
}
