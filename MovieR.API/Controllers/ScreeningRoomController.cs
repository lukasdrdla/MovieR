using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieR.Application.Dtos;
using MovieR.Application.Dtos.ScreeningRoom;
using MovieR.Application.Interfaces;
using MovieR.Domain.Entities;

namespace MovieR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScreeningRoomController : ControllerBase
    {

        private readonly IScreeningRoomService _screeningRoomService;

        public ScreeningRoomController(IScreeningRoomService screeningRoomService)
        {
            _screeningRoomService = screeningRoomService;
        }

        // GET: api/ScreeningRooms
        [HttpGet]
        public async Task<IActionResult> GetAllScreeningRooms()
        {
            try {
                var screeningRooms = await _screeningRoomService.GetAllScreeningRooms();
                return Ok(screeningRooms);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // GET: api/ScreeningRoom/5
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetScreeningRoomById(Guid id)
        {
            try {
                var screeningRoom = await _screeningRoomService.GetScreeningRoomById(id);
                return Ok(screeningRoom);
            
            } catch (Exception e) {
                return NotFound(new { Message = e.Message });
            }
        }

        // DELETE: api/ScreeningRoom/5
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteScreeningRoom(Guid id)
        {
            try {
                var result = await _screeningRoomService.DeleteScreeningRoom(id);
                if (result)
                {
                    return Ok(new { Message = "Místnost byla úspěšně smazána." });
                }
                return NotFound(new { Message = "Místnost nebyla nalezena." });
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // POST: api/ScreeningRoom

        [HttpPost]
        public async Task<IActionResult> CreateScreeningRoom([FromBody] CreateScreeningRoomDto screeningRoomDto)
        {
            try {
                var screeningRoom = await _screeningRoomService.CreateScreeningRoom(screeningRoomDto);
                return CreatedAtAction(nameof(GetScreeningRoomById), new { id = screeningRoom.Id }, screeningRoom);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        //PUT: api/ScreeningRoom/5
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateScreeningRoom(Guid id, [FromBody] UpdateScreeningRoomDto updateScreeningRoomDto)
        {
            try {
                var screeningRoom = await _screeningRoomService.UpdateScreeningRoom(id, updateScreeningRoomDto);
                if (screeningRoom == null)
                {
                    return NotFound(new { Message = "Místnost nebyla nalezena." });
                }
                return Ok(screeningRoom);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // GET: api/ScreeningRoom/GetScreeningRoomsByCapacity?minCapacity=10&maxCapacity=20
        [HttpGet("GetScreeningRoomsByCapacity")]
        public async Task<IActionResult> GetScreeningRoomsByCapacity(int minCapacity, int maxCapacity)
        {
            try {
                var screeningRooms = await _screeningRoomService.GetScreeningRoomsByCapacityAsync(minCapacity, maxCapacity);
                return Ok(screeningRooms);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        
    }
}