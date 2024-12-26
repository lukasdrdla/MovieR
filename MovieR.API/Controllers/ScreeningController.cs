using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieR.Application.Dtos.Screening;
using MovieR.Application.Interfaces;

namespace MovieR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreeningController : ControllerBase
    {
        private readonly IScreeningService _screeningService;

        public ScreeningController(IScreeningService screeningService)
        {
            _screeningService = screeningService;
        }
        
        // GET: api/Screenings
        [HttpGet]
        public async Task<IActionResult> GetAllScreenings()
        {
            try {
                var screenings = await _screeningService.GetAllScreenings();
                return Ok(screenings);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        //GET: api/Screenings/Available
        [HttpGet("Available")]
        public async Task<IActionResult> GetAvailableScreenings([FromQuery] Guid movieId, [FromQuery] DateTime date)
        {
            try {
                var screenings = await _screeningService.GetAvailableScreenings(movieId, date);
                return Ok(screenings);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        //GET: api/Screenings/Upcoming
        [HttpGet("Upcoming")]
        public async Task<IActionResult> GetUpcomingScreenings([FromQuery] int? daysAhead, [FromQuery] DateTime? fromDay, [FromQuery] DateTime? toDay)
        {
            try {
                var screenings = await _screeningService.GetUpcomingScreenings(daysAhead, fromDay, toDay);
                return Ok(screenings);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        //GET: api/Screenings/Today
        [HttpGet("Today")]
        public async Task<IActionResult> GetTodayScreenings()
        {
            try {
                var screenings = await _screeningService.GetTodayScreenings();
                return Ok(screenings);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        //GET: api/Screenings/Movie/{movieId}
        [HttpGet("Movie/{movieId}")]
        public async Task<IActionResult> GetScreeningsByMovieId([FromRoute] Guid movieId)
        {
            try {
                var screenings = await _screeningService.GetScreeningsByMovieId(movieId);
                return Ok(screenings);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        //GET: api/Screenings/{id}/Seats
        [HttpGet("{id}/Seats")]
        public async Task<IActionResult> GetScreeningSeats([FromRoute] Guid id)
        {
            try {
                var seats = await _screeningService.GetScreeningSeats(id);
                return Ok(seats);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        //GET: api/Screenings/{id}/Reservations
        [HttpGet("{id}/Reservations")]
        public async Task<IActionResult> GetScreeningReservations([FromRoute] Guid id)
        {
            try {
                var reservations = await _screeningService.GetScreeningReservations(id);
                return Ok(reservations);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        //GET: api/Screenings/search?search={search}
        [HttpGet("search")]
        public async Task<IActionResult> SearchScreenings([FromQuery] string search)
        {
            try {
                var screenings = await _screeningService.SearchScreenings(search);
                return Ok(screenings);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        //GET: api/Screenings/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetScreeningById([FromRoute] Guid id)
        {
            try {
                var screening = await _screeningService.GetScreeningById(id);
                if (screening == null)
                {
                    return NotFound();
                }
                return Ok(screening);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        //PUT: api/Screenings/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateScreening([FromRoute] Guid id, [FromBody] UpdateScreeningDto screeningDto)
        {
            try {
                var updatedScreening = await _screeningService.UpdateScreening(id, screeningDto);
                if (updatedScreening == null)
                {
                    return NotFound();
                }
                return Ok(updatedScreening);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        //POST: api/Screenings
        [HttpPost]
        public async Task<IActionResult> CreateScreening([FromBody] CreateScreeningDto screeningDto)
        {
            try {
                var createdScreening = await _screeningService.CreateScreening(screeningDto);
                return CreatedAtAction(nameof(GetScreeningById), new { id = createdScreening.Id }, createdScreening);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        //DELETE: api/Screenings/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScreening([FromRoute] Guid id)
        {
            try {
                var result = await _screeningService.DeleteScreening(id);
                if (result)
                {
                    return Ok(new { Message = "Screening was successfully deleted." });
                }
                return NotFound();
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "An unexpected error occurred.", Error = e.Message });
            }
        }



        
    }
}