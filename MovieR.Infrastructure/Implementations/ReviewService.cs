using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieR.Application.Dtos.Review;
using MovieR.Application.Interfaces;
using MovieR.Application.Mappers;
using MovieR.Domain.Entities;
using MovieR.Infrastructure.Data;

namespace MovieR.Infrastructure.Implementations
{
    public class ReviewService : IReviewService
    {

        private readonly ApplicationDbContext _context;

        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReviewDto> CreateReview(CreateReviewDto reviewDto)
        {
            var review = new Review
            {
                ReviewDate = reviewDto.ReviewDate,
                Content = reviewDto.Content,
                Rating = reviewDto.Rating,
                MovieId = reviewDto.MovieId,
                UserId = reviewDto.UserId
            };

            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync(CancellationToken.None);

            return ReviewMapper.MapToDto(review);
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
            return ReviewMapper.MapToDto(review?? new Review());
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