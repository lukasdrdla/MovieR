using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieR.Application.Dtos.Movie;
using MovieR.Application.Interfaces;

namespace MovieR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movie
        [HttpGet]
        public async Task<IActionResult> GetMovies()
        {
            try {
                var movies = await _movieService.GetAllMoviesAsync();
                return Ok(movies);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }

        }

        // GET: api/Movie/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie([FromRoute] Guid id)
        {
            try {
                var movie = await _movieService.GetMovieByIdAsync(id);
                if (movie == null)
                {
                    return NotFound();
                }
                return Ok(movie);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // POST: api/Movie 
        [HttpPost]
        public async Task<IActionResult> CreateMovie([FromBody] CreateMovieDto movieDto)
        {
            try {
                var movie = await _movieService.CreateMovieAsync(movieDto);
                return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // PUT: api/Movie/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie([FromRoute] Guid id, [FromBody] UpdateMovieDto movieDto)
        {
            try {
                var movie = await _movieService.UpdateMovieAsync(id, movieDto);
                if (movie == null)
                {
                    return NotFound();
                }
                return Ok(movie);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // DELETE: api/Movie/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] Guid id)
        {
            try {
                var result = await _movieService.DeleteMovieAsync(id);
                if (!result)
                {
                    return NotFound();
                }
                return NoContent();
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // GET: api/Movie/Search/{title}
        [HttpGet("Search/{title}")]
        public async Task<IActionResult> SearchMovies([FromRoute] string title)
        {
            try {
                var movies = await _movieService.SearchMoviesAsync(title);
                return Ok(movies);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // GET: api/Movie/Filter?genre={genre}&releaseDateFrom={releaseDateFrom}&releaseDateTo={releaseDateTo}
        [HttpGet("Filter")]
        public async Task<IActionResult> FilterMovies([FromQuery] string genre, [FromQuery] DateTime? releaseDateFrom, [FromQuery] DateTime? releaseDateTo)
        {
            try {
                var movies = await _movieService.FilterMoviesAsync(genre, releaseDateFrom, releaseDateTo);
                return Ok(movies);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // GET: api/Movie/Upcoming
        [HttpGet("Upcoming")]
        public async Task<IActionResult> GetUpcomingMovies()
        {
            try {
                var movies = await _movieService.GetUpcomingMoviesAsync();
                return Ok(movies);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // GET: api/Movie/NowShowing
        [HttpGet("NowShowing")]
        public async Task<IActionResult> GetNowShowingMovies()
        {
            try {
                var movies = await _movieService.GetNowShowingMoviesAsync();
                return Ok(movies);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // GET: api/Movie/{id}/Screenings

        [HttpGet("{id}/Screenings")]
        public async Task<IActionResult> GetMovieScreenings([FromRoute] Guid id)
        {
            try {
                var screenings = await _movieService.GetMovieScreeningsAsync(id);
                return Ok(screenings);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }
        
    }
}