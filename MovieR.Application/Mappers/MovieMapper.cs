using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Movie;
using MovieR.Domain.Entities;

namespace MovieR.Application.Mappers
{
    public static class MovieMapper
    {
        public static MovieDto MapToDto(this Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ReleaseDate = movie.ReleaseDate,
                Genre = movie.Genre,
                DurationMinutes = movie.DurationMinutes,
                PosterUrl = movie.PosterUrl
            };
        }
        
    }
}