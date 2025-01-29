using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieR.Application.Dtos.Reservation;
using MovieR.Application.Interfaces;

namespace MovieR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/Reservation
        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            try {
                var reservations = await _reservationService.GetAllReservations();
                return Ok(reservations);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }

        }

        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation([FromRoute] Guid id)
        {
            try {
                var reservation = await _reservationService.GetReservationById(id);
                if (reservation == null)
                {
                    return NotFound();
                }
                return Ok(reservation);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // POST: api/Reservation
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationDto reservationDto)
        {
            try
            {
                var reservation = await _reservationService.CreateReservation(reservationDto);
                return CreatedAtAction(nameof(GetReservation), new { id = reservation.Id }, reservation);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // DELETE: api/Reservation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] Guid id)
        {
            try
            {
                var success = await _reservationService.DeleteReservation(id);
                if (!success)
                {
                    return NotFound();
                }
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // PUT: api/Reservation/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReservation([FromRoute] Guid id, [FromBody] UpdateReservationDto reservationDto)
        {
            try
            {
                var reservation = await _reservationService.UpdateReservation(id, reservationDto);
                return Ok(reservation);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // GET: api/Reservation/Search/{search}
        [HttpGet("Search/{search}")]
        public async Task<IActionResult> SearchReservations([FromRoute] string search)
        {
            try
            {
                var reservations = await _reservationService.SearchReservations(search);
                return Ok(reservations);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // GET: api/Reservation/ScreeningRoom/{screeningRoomId}
        [HttpGet("ScreeningRoom/{screeningRoomId}")]
        public async Task<IActionResult> GetReservationsByScreeningRoomId([FromRoute] Guid screeningRoomId)
        {
            try
            {
                var reservations = await _reservationService.GetReservationsByScreeningRoomId(screeningRoomId);
                return Ok(reservations);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }



        


        
    }
}