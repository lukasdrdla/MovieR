using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieR.Application.Dtos;
using MovieR.Application.Dtos.ScreeningRoom;
using MovieR.Application.Interfaces;
using MovieR.Application.Mappers;
using MovieR.Domain.Entities;
using MovieR.Infrastructure.Data;

namespace MovieR.Infrastructure.Implementations
{
    public class ScreeningRoomService : IScreeningRoomService
    {
        private readonly ApplicationDbContext _context;

        public ScreeningRoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ScreeningRoomDto> CreateScreeningRoom(CreateScreeningRoomDto screeningRoomDto)
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
            return ScreeningRoomMapper.MapToDto(screeningRoom ?? new ScreeningRoom());
        }

        public async Task<IEnumerable<ScreeningRoomDto>> GetScreeningRoomsByCapacityAsync(int minCapacity, int maxCapacity)
        {
            var screeningRooms = await _context.ScreeningRooms
                .Where(room => room.MaxCapacity >= minCapacity && room.MaxCapacity <= maxCapacity)
                .ToListAsync();
            
            var screeningRoomDtos = screeningRooms.Select(room => ScreeningRoomMapper.MapToDto(room)).ToList();

            return screeningRoomDtos;
        }

        public async Task<IEnumerable<ScreeningRoomDto>> SearchScreeningRooms(string search)
        {
            var screeningRooms = await _context.ScreeningRooms
                .Where(room => room.Name.Contains(search))
                .ToListAsync();

            var screeningRoomDtos = screeningRooms.Select(room => ScreeningRoomMapper.MapToDto(room)).ToList();

            return screeningRoomDtos;
        }

        public async Task<ScreeningRoomDto> UpdateScreeningRoom(Guid id, UpdateScreeningRoomDto updateScreeningRoomDto)
        {
            var existingScreeningRoom = await _context.ScreeningRooms.FirstOrDefaultAsync(room => room.Id == id);
            if (existingScreeningRoom == null)
            {
                return null;
            }

            existingScreeningRoom.Name = updateScreeningRoomDto.Name;
            existingScreeningRoom.TotalColumns = updateScreeningRoomDto.TotalColumns;
            existingScreeningRoom.TotalRows = updateScreeningRoomDto.TotalRows;

            await _context.SaveChangesAsync(CancellationToken.None);
            return ScreeningRoomMapper.MapToDto(existingScreeningRoom);
        }
    }
}