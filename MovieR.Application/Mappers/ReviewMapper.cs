using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Review;
using MovieR.Domain.Entities;

namespace MovieR.Application.Mappers
{
    public static class ReviewMapper
    {
        public static ReviewDto MapToDto(Review review)
        {
            return new ReviewDto
            {
                Id = review.Id,
                ReviewDate = review.ReviewDate,
                Content = review.Content??string.Empty,
                Rating = review.Rating,
                MovieId = review.MovieId,
                UserId = review.UserId
            };
        }
    

        
    }
}