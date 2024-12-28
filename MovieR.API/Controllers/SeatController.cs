using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieR.Application.Dtos.Seat;
using MovieR.Application.Interfaces;

namespace MovieR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeatController : ControllerBase
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }

        // GET: api/Seats
        [HttpGet]
        public async Task<IActionResult> GetAllSeats()
        {
            try {
                var seats = await _seatService.GetAllSeats();
                return Ok(seats);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // GET: api/Seat/5
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSeatById([FromRoute] Guid id)
        {
            try {
                var seat = await _seatService.GetSeatById(id);
                return Ok(seat);
            
            } catch (Exception e) {
                return NotFound(new { Message = e.Message });
            }
        }


        // GET: api/Seat/available/5
        [HttpGet("available/{screeningId:guid}")]
        public async Task<IActionResult> GetAvailableSeats([FromRoute] Guid screeningId)
        {
            try {
                var seats = await _seatService.GetAvailableSeats(screeningId);
                return Ok(seats);
            
            } catch (Exception e) {
                return NotFound(new { Message = e.Message });
            }
        }

        // POST: api/Seat
        [HttpPost]
        public async Task<IActionResult> CreateSeat([FromBody] CreateSeatDto createSeatDto)
        {
            try {
                var seat = await _seatService.CreateSeat(createSeatDto);
                return Ok(seat);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // PUT: api/Seat/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateSeat([FromRoute] Guid id, [FromBody] UpdateSeatDto updateSeatDto)
        {
            try {
                var seat = await _seatService.UpdateSeat(id, updateSeatDto);
                return Ok(seat);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // DELETE: api/Seat/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteSeat([FromRoute] Guid id)
        {
            try {
                var result = await _seatService.DeleteSeat(id);
                if (result)
                {
                    return Ok(new { Message = "Sedadlo bylo úspěšně smazáno." });
                }
                return NotFound(new { Message = "Sedadlo nebylo nalezeno." });
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // PUT: api/Seat/availability/5
        [HttpPut("availability/{id:guid}")]
        public async Task<IActionResult> SetSeatAvailability([FromRoute] Guid id, [FromBody] bool isAvailable)
        {
            try {
                await _seatService.SetSeatAvailability(id, isAvailable);
                return Ok(new { Message = "Stav sedadla byl úspěšně změněn." });
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }
        
        
    }
}