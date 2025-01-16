using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieR.Application.Context;
using MovieR.Application.Dtos.Review;
using MovieR.Application.Interfaces;
using MovieR.Application.Mappers;

namespace MovieR.Application.Implementations
{
    public class ReviewService : IReviewService
    {

        private readonly IApplicationDbContext _context;

        public ReviewService(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ReviewDto> CreateReview(CreateReviewDto reviewDto)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteReview(Guid id)
        {
            var existingReview = await _context.Reviews.Where(review => review.Id == id).FirstOrDefaultAsync();
            if (existingReview == null)
            {
                return false;
            }

            _context.Reviews.Remove(existingReview);
            await _context.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public async Task<IEnumerable<ReviewDto>> GetAllReviews()
        {
            var reviews = await _context.Reviews.ToListAsync();
            var reviewDtos = reviews.Select(review => ReviewMapper.MapToDto(review));
            return reviewDtos;
        }

        public async Task<ReviewDto> GetReviewById(Guid id)
        {
            var review = await _context.Reviews.FirstOrDefaultAsync(review => review.Id == id);
            return ReviewMapper.MapToDto(review?? new Domain.Entities.Review());
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByMovieId(Guid movieId)
        {
            var reviews = await _context.Reviews.Where(review => review.MovieId == movieId).ToListAsync();
            var reviewDtos = reviews.Select(review => ReviewMapper.MapToDto(review));
            return reviewDtos;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByRating(int rating)
        {
            var reviews = await _context.Reviews.Where(review => review.Rating == rating).ToListAsync();
            var reviewDtos = reviews.Select(review => ReviewMapper.MapToDto(review));
            return reviewDtos;
        }

        public async Task<IEnumerable<ReviewDto>> GetReviewsByUserId(Guid userId)
        {
            var reviews = await _context.Reviews.Where(review => review.UserId == userId).ToListAsync();
            var reviewDtos = reviews.Select(review => ReviewMapper.MapToDto(review));
            return reviewDtos;
        }

        public async Task<ReviewDto> UpdateReview(Guid id, UpdateReviewDto reviewDto)
        {

            var existingReview = await _context.Reviews.Where(review => review.Id == id).FirstOrDefaultAsync();
            if (existingReview == null)
            {
                throw new KeyNotFoundException("Review not found");
            }

            existingReview.Content = reviewDto.Content;
            existingReview.Rating = reviewDto.Rating;

            await _context.SaveChangesAsync(CancellationToken.None);

            return ReviewMapper.MapToDto(existingReview);

        
    
            
        }
    }
}