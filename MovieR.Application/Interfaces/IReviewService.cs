using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Review;

namespace MovieR.Application.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetAllReviews();
        Task<ReviewDto> GetReviewById(Guid id);
        Task<ReviewDto> CreateReview(CreateReviewDto reviewDto);
        Task<ReviewDto> UpdateReview(Guid id, UpdateReviewDto reviewDto);
        Task<bool> DeleteReview(Guid id);

        Task<IEnumerable<ReviewDto>> GetReviewsByMovieId(Guid movieId);
        Task<IEnumerable<ReviewDto>> GetReviewsByUserId(Guid userId);
        Task<IEnumerable<ReviewDto>> GetReviewsByRating(int rating);
        
        
    }
}