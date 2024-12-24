using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetAvailableScreenings(Guid movieId, DateTime date)
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

        
    }
}