using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieR.Application.Dtos.Review;
using MovieR.Application.Interfaces;

namespace MovieR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // GET: api/Review
        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            try {
                var reviews = await _reviewService.GetAllReviews();
                return Ok(reviews);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }

        }

        // GET: api/Review/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReview([FromRoute] Guid id)
        {
            try {
                var review = await _reviewService.GetReviewById(id);
                if (review == null)
                {
                    return NotFound();
                }
                return Ok(review);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }
        
        // GET: api/Review/Movie/{movieId}
        [HttpGet("Movie/{movieId}")]
        public async Task<IActionResult> GetReviewsByMovieId([FromRoute] Guid movieId)
        {
            try {
                var reviews = await _reviewService.GetReviewsByMovieId(movieId);
                return Ok(reviews);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // GET: api/Review/Rating/{rating}
        [HttpGet("Rating/{rating}")]
        public async Task<IActionResult> GetReviewsByRating([FromRoute] int rating)
        {
            try {
                var reviews = await _reviewService.GetReviewsByRating(rating);
                return Ok(reviews);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // GET: api/Review/User/{userId}
        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetReviewsByUserId([FromRoute] Guid userId)
        {
            try {
                var reviews = await _reviewService.GetReviewsByUserId(userId);
                return Ok(reviews);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // POST: api/Review
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDto reviewDto)
        {
            try {
                var review = await _reviewService.CreateReview(reviewDto);
                return CreatedAtAction(nameof(GetReview), new { id = review.Id }, review);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // PUT: api/Review/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview([FromRoute] Guid id, [FromBody] UpdateReviewDto reviewDto)
        {
            try {
                var review = await _reviewService.UpdateReview(id, reviewDto);
                return Ok(review);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }
        
    }
}