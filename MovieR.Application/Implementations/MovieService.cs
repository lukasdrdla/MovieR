using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieR.Application.Context;
using MovieR.Application.Dtos.Movie;
using MovieR.Application.Dtos.Screening;
using MovieR.Application.Interfaces;
using MovieR.Application.Mappers;
using MovieR.Domain.Entities;

namespace MovieR.Application.Implementations
{
    public class MovieService : IMovieService
    {

        private readonly IApplicationDbContext _context;

        public MovieService(IApplicationDbContext context)
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

            return MovieMapper.MapToDto(movie);

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
            var movieDtos = movies.Select(movie => MovieMapper.MapToDto(movie)).ToList();

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
            if (reviews.Count == 0)
            {
                return 0;
            }

            var averageRating = reviews.Average(review => review.Rating);

            return averageRating;
        }

        public async Task<MovieDto> GetMovieByIdAsync(Guid id)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == id);
            return MovieMapper.MapToDto(movie);
        }

        public async Task<IEnumerable<ScreeningDto>> GetMovieScreeningsAsync(Guid movieId)
        {
            var screenings = await _context.Screenings.Where(screening => screening.MovieId == movieId).ToListAsync();
            var screeningDtos = screenings.Select(screening => ScreeningMapper.MapToDto(screening)).ToList();

            return screeningDtos;

        }

        public async Task<IEnumerable<MovieDto>> GetNowShowingMoviesAsync()
        {
            var nowShowingMovies = await _context.Movies
                    .Where(movie => movie.Screenings
                        .Any(screening => screening.StartDate < DateTime.UtcNow && 
                                        screening.StartDate.AddMinutes(movie.DurationMinutes) > DateTime.UtcNow))
                    .ToListAsync();
        var movieDtos = nowShowingMovies.Select(movie => MovieMapper.MapToDto(movie)).ToList();
            return movieDtos;
        }

        public async Task<IEnumerable<MovieDto>> GetPopularMoviesAsync(int count)
        {
            var popularMovies = await _context.Movies.OrderByDescending(movie => movie.Reviews).Take(count).ToListAsync();
            var movieDtos = popularMovies.Select(movie => MovieMapper.MapToDto(movie)).ToList();

            return movieDtos;
        }

        public async Task<IEnumerable<MovieDto>> GetRecommendedMoviesAsync(string genre)
        {
            var recommendedMovies = await _context.Movies.Where(movie => movie.Genre == genre).ToListAsync();
            var movieDtos = recommendedMovies.Select(movie => MovieMapper.MapToDto(movie)).ToList();

            return movieDtos;
        }

        public async Task<IEnumerable<MovieDto>> GetUpcomingMoviesAsync()
        {
            var upcomingMovies = await _context.Movies.Where(movie => movie.ReleaseDate > DateTime.UtcNow).ToListAsync();
            var movieDtos = upcomingMovies.Select(movie => MovieMapper.MapToDto(movie)).ToList();

            return movieDtos;
        }

        public async Task<IEnumerable<ScreeningDto>> GetUpcomingScreeningsAsync(Guid movieId)
        {
            var upcomingScreenings = await _context.Screenings.Where(screening => screening.MovieId == movieId && screening.StartDate > DateTime.Now).ToListAsync();
            var screeningDtos = upcomingScreenings.Select(screening => ScreeningMapper.MapToDto(screening)).ToList();

            return screeningDtos;
        }

        public async Task<IEnumerable<MovieDto>> SearchMoviesAsync(string title)
        {
            var movies = await _context.Movies.Where(movie => movie.Title.Contains(title)).ToListAsync();
            var movieDtos = movies.Select(movie => MovieMapper.MapToDto(movie)).ToList();

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

            return MovieMapper.MapToDto(existingMovie);
        }
    }
}