using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieR.Application.Dtos.Movie;
using MovieR.Application.Dtos.Screening;
using MovieR.Application.Interfaces;
using MovieR.Application.Mappers;
using MovieR.Domain.Entities;
using MovieR.Infrastructure.Data;

namespace MovieR.Infrastructure.Implementations
{
    public class MovieService : IMovieService
    {

        private readonly ApplicationDbContext _context;

        public MovieService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MovieDto> CreateMovieAsync(CreateMovieDto movieDto)
        {
            var movie = new Movie
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                ReleaseDate = movieDto.ReleaseDate,
                Genre = movieDto.Genre,
                DurationMinutes = movieDto.DurationMinutes,
                PosterUrl = movieDto.PosterUrl
            };

            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync(CancellationToken.None);

            return movie.MapToDto();

        }

        public async Task<bool> DeleteMovieAsync(Guid id)
        {
            var existingMovie = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
            if (existingMovie == null)
            {
                return false;
            }

            _context.Movies.Remove(existingMovie);
            await _context.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public Task<IEnumerable<MovieDto>> FilterMoviesAsync(string genre, DateTime? releaseDateFrom, DateTime? releaseDateTo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await _context.Movies.ToListAsync();
            var movieDtos = movies.Select(movie => movie.MapToDto()).ToList();

            return movieDtos;
        }

        public async Task<double> GetAverageRatingAsync(Guid movieId)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == movieId);
            if (movie == null)
            {
                return 0;
            }

            var reviews = await _context.Reviews.Where(review => review.MovieId == movieId).ToListAsync();

            var averageRating = reviews.Average(review => review.Rating);

            return averageRating;
        }

        public async Task<MovieDto> GetMovieByIdAsync(Guid id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
            return movie.MapToDto();
        }

        public async Task<IEnumerable<ScreeningDto>> GetMovieScreeningsAsync(Guid movieId)
        {
            var screenings = await _context.Screenings.Where(screening => screening.MovieId == movieId).ToListAsync();
            var screeningDtos = screenings.Select(screening => ScreeningMapper.MapToDto(screening)).ToList();

            return screeningDtos;

        }

        public async Task<IEnumerable<MovieDto>> GetNowShowingMoviesAsync()
        {
            var now = DateTime.UtcNow;
            var nowShowingMovies = await _context.Movies
            .Include(movie => movie.Screenings)
            .Where( movie => movie.Screenings.Any(screening => screening.StartDate <= now && screening.StartDate.AddMinutes(movie.DurationMinutes) >= now)).ToListAsync();
            var movieDtos = nowShowingMovies.Select(movie => movie.MapToDto()).ToList();
            return movieDtos;
        }

        public async Task<IEnumerable<MovieDto>> GetPopularMoviesAsync(int count)
        {
            var popularMovies = await _context.Movies.OrderByDescending(movie => movie.Reviews).Take(count).ToListAsync();
            var movieDtos = popularMovies.Select(movie => movie.MapToDto()).ToList();

            return movieDtos;
        }

        public async Task<IEnumerable<MovieDto>> GetRecommendedMoviesAsync(string genre)
        {
            var recommendedMovies = await _context.Movies.Where(movie => movie.Genre == genre).ToListAsync();
            var movieDtos = recommendedMovies.Select(movie => movie.MapToDto()).ToList();

            return movieDtos;
        }

        public async Task<IEnumerable<MovieDto>> GetUpcomingMoviesAsync()
        {
            var upcomingMovies = await _context.Movies.Where(movie => movie.ReleaseDate > DateTime.UtcNow).ToListAsync();
            var movieDtos = upcomingMovies.Select(movie => movie.MapToDto()).ToList();

            return movieDtos;
        }

        public async Task<IEnumerable<MovieDto>> SearchMoviesAsync(string title)
        {
            var movies = await _context.Movies.Where(movie => movie.Title.Contains(title)).ToListAsync();
            var movieDtos = movies.Select(movie => movie.MapToDto()).ToList();

            return movieDtos;
        }

        public async Task<MovieDto> UpdateMovieAsync(Guid id, UpdateMovieDto movieDto)
        {
            var existingMovie = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
            if (existingMovie == null)
            {
                return null;
            }

            existingMovie.Title = movieDto.Title;
            existingMovie.Description = movieDto.Description;
            existingMovie.ReleaseDate = movieDto.ReleaseDate;
            existingMovie.Genre = movieDto.Genre;
            existingMovie.DurationMinutes = movieDto.DurationMinutes;
            existingMovie.PosterUrl = movieDto.PosterUrl;

            await _context.SaveChangesAsync(CancellationToken.None);

            return existingMovie.MapToDto();
        }
    }
}