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

        // Reviews
        //Task<IEnumerable<ReviewDto>> GetMovieReviewsAsync(Guid movieId);
        //Task<ReviewDto> AddReviewAsync(Guid movieId, CreateReviewDto reviewDto);
        //Task<ReviewDto> UpdateReviewAsync(Guid movieId, Guid reviewId, UpdateReviewDto reviewDto);
        //Task<bool> DeleteReviewAsync(Guid movieId, Guid reviewId);

        // Screenings
        Task<IEnumerable<ScreeningDto>> GetMovieScreeningsAsync(Guid movieId);
        Task<IEnumerable<ScreeningDto>> GetUpcomingScreeningsAsync(Guid movieId);

        // Additional Operations
        Task<double> GetAverageRatingAsync(Guid movieId);
        Task<IEnumerable<MovieDto>> GetPopularMoviesAsync(int count);
        Task<IEnumerable<MovieDto>> GetRecommendedMoviesAsync(string genre);
        
    }
}