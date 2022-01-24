using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Helpers;
using MoviesApi.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.DTOs
{
    public class MovieCreationDTO: MoviePatchDTO
    {
        [FileSizeValidator(MaxFileSizeInMbs: 4)]
        [ContentTypeValidator(ContentTypeGroup.Image)]
        public IFormFile Poster { get; set; }

        [ModelBinder(BinderType=typeof(TypeBinder<List<int>>))]
        public List<int> GenresIds { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<ActorCreationDTO>>))]
        public List<ActorCreationDTO>Actors { get; set; }
    }
}
