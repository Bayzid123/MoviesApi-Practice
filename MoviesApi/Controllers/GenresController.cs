using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MoviesApi.DTOs;
using MoviesApi.Entities;
using MoviesApi.Filters;
using MoviesApi.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace MoviesApi.Controllers
{
    [Route("api/genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> logger;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public GenresController(ILogger<GenresController> logger, ApplicationDbContext context, IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        //public GenresController(InMemoryRepository inMemoryRepository)
        //{
        //    this.inMemoryRepository = inMemoryRepository;
        //}

        [HttpGet] //api/genres  
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            var genres = await context.Genres.AsNoTracking().ToListAsync();
            var genresDTOs = mapper.Map<List<GenreDTO>>(genres);
            return genresDTOs;
        }

        [HttpGet("{Id:int}", Name="getGenre")] // api/genres/example
        public async Task<ActionResult<GenreDTO>> Get(int Id)
        {

            var genre = await context.Genres.FirstOrDefaultAsync(X => X.Id == Id);
            if (genre == null)
            {
                return NotFound();
            }

            var genreDTO = mapper.Map<GenreDTO>(genre);
            return genreDTO;
        }

        [HttpPost]
        public async Task<ActionResult> post([FromBody] GenreCreationDTO genreCreation)
        {
            var genre = mapper.Map<Genre>(genreCreation);
            context.Add(genre);
            await context.SaveChangesAsync();
            var genreDTO = mapper.Map<GenreDTO>(genre);
            return new CreatedAtRouteResult("getGenre", new { genreDTO.Id }, genreDTO);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult> put(int id, [FromBody] GenreCreationDTO genreCreation)
        {
            var genre = mapper.Map<Genre>(genreCreation);
            genre.Id= id;
            context.Entry(genre).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exist = await context.Genres.AnyAsync(X=> X.Id==id);
            if (!exist)
            {
                return NotFound();
            }
            context.Remove(new Genre() { Id=id});
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
