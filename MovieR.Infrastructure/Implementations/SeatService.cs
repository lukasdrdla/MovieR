using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieR.Application.Dtos.Seat;
using MovieR.Application.Interfaces;
using MovieR.Application.Mappers;
using MovieR.Domain.Entities;
using MovieR.Infrastructure.Data;

namespace MovieR.Infrastructure.Implementations
{
    public class SeatService : ISeatService
    {
        private readonly ApplicationDbContext _context;

        public SeatService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SeatDto> CreateSeat(CreateSeatDto createSeatDto)
        {
            var newSeat = new Seat
            {
                Row = createSeatDto.Row,
                Column = createSeatDto.Number,
                IsAvailable = createSeatDto.IsAvailable,
                ScreeningId = createSeatDto.ScreeningId
            };

            await _context.Seats.AddAsync(newSeat);
            await _context.SaveChangesAsync(CancellationToken.None);

            return SeatMapper.MapToDto(newSeat);
        }

        public async Task<bool> DeleteSeat(Guid id)
        {
            var existingSeat = await _context.Seats
            .Include(s => s.Screening)
            .ThenInclude(s => s.Movie)
            .FirstOrDefaultAsync(s => s.Id == id);
            if (existingSeat == null)
            {
                return false;
            }

            _context.Seats.Remove(existingSeat);
            await _context.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public async Task<IEnumerable<SeatDto>> GetAllSeats()
        {
            var seats = await _context.Seats
            .Include(s => s.Screening)
            .ThenInclude(s => s.Movie)
            .ToListAsync();
            var seatDto = seats.Select(SeatMapper.MapToDto).ToList();
            return seatDto;
        }

        public async Task<IEnumerable<SeatDto>> GetAvailableSeats(Guid screeningId)
        {
            var seats = await _context.Seats.Where(s => s.ScreeningId == screeningId && s.IsAvailable)
            .Include(s => s.Screening)
            .ThenInclude(s => s.Movie)
            .ToListAsync();
            var seatDtos = seats.Select(SeatMapper.MapToDto).ToList();
            return seatDtos;
        }

        public async Task<SeatDto> GetSeatById(Guid id)
        {
            var seat = await _context.Seats
            .Include(s => s.Screening)
            .ThenInclude(s => s.Movie)
            .FirstOrDefaultAsync(s => s.Id == id);
            return SeatMapper.MapToDto(seat ?? throw new Exception("Seat not found"));
        }

        public async Task SetSeatAvailability(Guid id, bool isAvailable)
        {
            var seat = await _context.Seats
            .Include(s => s.Screening)
            .ThenInclude(s => s.Movie)
            .FirstOrDefaultAsync(s => s.Id == id);

            if (seat == null)
            {
                throw new Exception("Seat not found");
            }

            seat.IsAvailable = isAvailable;
            await _context.SaveChangesAsync(CancellationToken.None);
        }

        public async Task<SeatDto> UpdateSeat(Guid id, UpdateSeatDto updateSeatDto)
        {
            var existingSeat = await _context.Seats.FirstOrDefaultAsync(s => s.Id == id);
            if (existingSeat == null)
            {
                throw new Exception("Seat not found");
            }

            existingSeat.Row = updateSeatDto.Row;
            existingSeat.Column = updateSeatDto.Number;
            existingSeat.IsAvailable = updateSeatDto.IsAvailable;
            existingSeat.ScreeningId = updateSeatDto.ScreeningId;

            await _context.SaveChangesAsync(CancellationToken.None);

            return SeatMapper.MapToDto(existingSeat);
        }
    }
}