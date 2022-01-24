using System.Collections.Generic;

namespace MoviesApi.DTOs
{
    public class IndexMoviePageDTO
    {
        public List<MovieDTO> UpcomingReleases { get; set; }
        public List<MovieDTO> InTheaters { get; set; }
    }
}
