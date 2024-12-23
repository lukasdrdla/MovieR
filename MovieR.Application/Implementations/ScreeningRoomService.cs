using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieR.Application.Context;
using MovieR.Application.Dtos;
using MovieR.Application.Interfaces;
using MovieR.Application.Mappers;
using MovieR.Domain.Entities;

namespace MovieR.Application.Implementations
{
    public class ScreeningRoomService : IScreeningRoomService
    {
        private readonly IApplicationDbContext _context;

        public ScreeningRoomService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ScreeningRoomDto> CreateScreeningRoom(ScreeningRoomDto screeningRoomDto)
        {
            var screeningRoom = new ScreeningRoom
            {
                Id = Guid.NewGuid(),
                Name = screeningRoomDto.Name,
                TotalColumns = screeningRoomDto.TotalColumns,
                TotalRows = screeningRoomDto.TotalRows
            };

            await _context.ScreeningRooms.AddAsync(screeningRoom);
            await _context.SaveChangesAsync(CancellationToken.None);

            return ScreeningRoomMapper.MapToDto(screeningRoom);
            
        }

        public async Task<bool> DeleteScreeningRoom(Guid id)
        {
            var screeningRoom = await _context.ScreeningRooms.FirstOrDefaultAsync(room => room.Id == id);
            if (screeningRoom == null)
            {
                return false;
            }

            _context.ScreeningRooms.Remove(screeningRoom);
            await _context.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public async Task<IEnumerable<ScreeningRoomDto>> GetAllScreeningRooms()
        {
            var screeningRooms = await _context.ScreeningRooms.ToListAsync();
            
            var screeningRoomDtos = screeningRooms.Select(room => ScreeningRoomMapper.MapToDto(room)).ToList();

            return screeningRoomDtos;

        }

        public async Task<ScreeningRoomDto> GetScreeningRoomById(Guid id)
        {
            var screeningRoom = await _context.ScreeningRooms.FirstOrDefaultAsync(room => room.Id == id);
            return ScreeningRoomMapper.MapToDto(screeningRoom);
        }

        public async Task<ScreeningRoomDto> UpdateScreeningRoom(Guid id, ScreeningRoomDto screeningRoomDto)
        {
            var existingScreeningRoom = await _context.ScreeningRooms.FirstOrDefaultAsync(room => room.Id == id);
            if (existingScreeningRoom == null)
            {
                return null;
            }

            existingScreeningRoom.Name = screeningRoomDto.Name;
            existingScreeningRoom.TotalColumns = screeningRoomDto.TotalColumns;
            existingScreeningRoom.TotalRows = screeningRoomDto.TotalRows;

            await _context.SaveChangesAsync(CancellationToken.None);
            return ScreeningRoomMapper.MapToDto(existingScreeningRoom);
        }
    }
}