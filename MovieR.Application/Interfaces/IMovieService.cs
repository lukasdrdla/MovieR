using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Movie;
using MovieR.Application.Dtos.Screening;

namespace MovieR.Application.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<MovieDto> GetMovieByIdAsync(Guid id);
        Task<MovieDto> CreateMovieAsync(CreateMovieDto movieDto);
        Task<MovieDto> UpdateMovieAsync(Guid id, UpdateMovieDto movieDto);
        Task<bool> DeleteMovieAsync(Guid id);

        // Search and Filter Operations
        Task<IEnumerable<MovieDto>> SearchMoviesAsync(string title);
        Task<IEnumerable<MovieDto>> FilterMoviesAsync(string genre, DateTime? releaseDateFrom, DateTime? releaseDateTo);
        Task<IEnumerable<MovieDto>> GetUpcomingMoviesAsync();
        Task<IEnumerable<MovieDto>> GetNowShowingMoviesAsync();
        
    }
}