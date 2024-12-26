using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieR.Application.Context;
using MovieR.Application.Dtos.Reservation;
using MovieR.Application.Dtos.Screening;
using MovieR.Application.Dtos.Seat;
using MovieR.Application.Interfaces;
using MovieR.Domain.Entities;

namespace MovieR.Application.Implementations
{
    public class ScreeningService : IScreeningService
    {
        private readonly IApplicationDbContext _context;

        public ScreeningService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ScreeningDto> CreateScreening(CreateScreeningDto screeningDto)
        {
            var newScreening = new Screening
            {
                Id = Guid.NewGuid(),
                StartDate = screeningDto.StartTime,
                MovieId = screeningDto.MovieId,
                ScreeningRoomId = screeningDto.ScreeningRoomId
            };

            await _context.Screenings.AddAsync(newScreening);
            await _context.SaveChangesAsync(CancellationToken.None);

            return Mappers.ScreeningMapper.MapToDto(newScreening);

        }

        public async Task<bool> DeleteScreening(Guid id)
        {
            var existingScreening = await _context.Screenings.FirstOrDefaultAsync(s => s.Id == id);
            if (existingScreening == null)
            {
                return false;
            }

            _context.Screenings.Remove(existingScreening);
            await _context.SaveChangesAsync(CancellationToken.None);
            return true;
        }

        public async Task<IEnumerable<ScreeningDto>> GetAllScreenings()
        {
            var screenings = await _context.Screenings
            .Include(s => s.Movie)
            .Include(s => s.ScreeningRoom)
            .ToListAsync();
            var screeningsDtos = screenings.Select(Mappers.ScreeningMapper.MapToDto).ToList();
            return screeningsDtos;
            
        }

        public async Task<IEnumerable<ScreeningDto>> GetAvailableScreenings(Guid movieId, DateTime date)
        {
            var screenings = await _context.Screenings
                .Where(s => s.MovieId == movieId && s.StartDate.Date == date.Date)
                .Include(s => s.Movie)
                .Include(s => s.ScreeningRoom)
                .ToListAsync();
            var screeningsDtos = screenings.Select(Mappers.ScreeningMapper.MapToDto).ToList();

            return screeningsDtos;
        }

        public async Task<ScreeningDto> GetScreeningById(Guid id)
        {
            var screening = await _context.Screenings
                .Include(s => s.Movie)
                .Include(s => s.ScreeningRoom)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (screening == null)
            {
                return null;
            }

            var screeningDto = Mappers.ScreeningMapper.MapToDto(screening);
            return screeningDto;
        }

        public async Task<IEnumerable<ReservationDto>> GetScreeningReservations(Guid screeningId)
        {
            var reservations = await _context.Reservations
                .Where(r => r.ScreeningId == screeningId)
                .Include(r => r.Screening)
                .Include(r => r.User)
                .ToListAsync();

            var reservationsDtos = reservations.Select(Mappers.ReservationMapper.MapToDto).ToList();

            return reservationsDtos;
        }

        public async Task<IEnumerable<ScreeningDto>> GetScreeningsByMovieId(Guid movieId)
        {
            var screening = await _context.Screenings
                .Where(s => s.MovieId == movieId)
                .Include(s => s.Movie)
                .Include(s => s.ScreeningRoom)
                .ToListAsync();
            var screeningsDtos = screening.Select(Mappers.ScreeningMapper.MapToDto).ToList();

            return screeningsDtos;
        }

        public async Task<IEnumerable<SeatDto>> GetScreeningSeats(Guid screeningId)
        {
            var seats = await _context.Seats
                .Where(s => s.ScreeningId == screeningId)
                .ToListAsync();
            var seatsDtos = seats.Select(Mappers.SeatMapper.MapToDto).ToList();

            return seatsDtos;
            
        }

        public async Task<IEnumerable<ScreeningDto>> GetTodayScreenings()
        {
            var todayScreenings = await _context.Screenings
                .Where(s => s.StartDate.Date == DateTime.Now.Date)
                .Include(s => s.Movie)
                .Include(s => s.ScreeningRoom)
                .ToListAsync();
            var screeningsDtos = todayScreenings.Select(Mappers.ScreeningMapper.MapToDto).ToList();

            return screeningsDtos;
        }

        public async Task<IEnumerable<ScreeningDto>> GetUpcomingScreenings(int? daysAhead = null, DateTime? fromDay = null, DateTime? toDay = null)
        {
            var screenings = await _context.Screenings
            .Include(s => s.Movie)
            .Include(s => s.ScreeningRoom)
            .ToListAsync();

            if (daysAhead.HasValue)
            {
                var upcomingScreenings = screenings
                    .Where(s => s.StartDate.Date >= DateTime.Now.Date && s.StartDate.Date <= DateTime.Now.AddDays(daysAhead.Value).Date)
                    .ToList();
                var screeningsDtos = upcomingScreenings.Select(Mappers.ScreeningMapper.MapToDto).ToList();

                return screeningsDtos;
            }
            else if (fromDay.HasValue && toDay.HasValue)
            {
                var upcomingScreenings = screenings
                    .Where(s => s.StartDate.Date >= fromDay.Value.Date && s.StartDate.Date <= toDay.Value.Date)
                    .ToList();
                var screeningsDtos = upcomingScreenings.Select(Mappers.ScreeningMapper.MapToDto).ToList();

                return screeningsDtos;
            }
            else
            {
                var upcomingScreenings = screenings
                    .Where(s => s.StartDate.Date >= DateTime.Now.Date)
                    .ToList();
                var screeningsDtos = upcomingScreenings.Select(Mappers.ScreeningMapper.MapToDto).ToList();

                return screeningsDtos;

            }
        }

        public async Task<IEnumerable<ScreeningDto>> SearchScreenings(string search)
        {
            var screenings = await _context.Screenings
                .Where(s => s.Movie.Title.Contains(search) ||
                s.ScreeningRoom.Name.Contains(search) ||
                s.StartDate.ToString().Contains(search) ||
                s.MovieId.ToString().Contains(search) ||
                s.ScreeningRoomId.ToString().Contains(search))
                .Include(s => s.Movie)
                .Include(s => s.ScreeningRoom)
                .ToListAsync();
            var screeningsDtos = screenings.Select(Mappers.ScreeningMapper.MapToDto).ToList();

            return screeningsDtos;
        }

        public async Task<ScreeningDto> UpdateScreening(Guid id, UpdateScreeningDto screeningDto)
        {
            var existingScreening = await _context.Screenings.FirstOrDefaultAsync(s => s.Id == id);
            if (existingScreening == null)
            {
                return null;
            }

            existingScreening.StartDate = screeningDto.StartTime;
            existingScreening.MovieId = screeningDto.MovieId;
            existingScreening.ScreeningRoomId = screeningDto.ScreeningRoomId;

            await _context.SaveChangesAsync(CancellationToken.None);
            return Mappers.ScreeningMapper.MapToDto(existingScreening);
        }
    }
}