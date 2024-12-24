using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieR.Application.Context;
using MovieR.Application.Dtos.Screening;
using MovieR.Application.Interfaces;

namespace MovieR.Application.Implementations
{
    public class ScreeningService : IScreeningService
    {
        private readonly IApplicationDbContext _context;

        public ScreeningService(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<ScreeningDto> CreateScreening(CreateScreeningDto screeningDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteScreening(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ScreeningDto>> GetAllScreenings()
        {
            var screenings = await _context.Screenings.ToListAsync();
            var screeningsDtos = screenings.Select(Mappers.ScreeningMapper.MapToDto).ToList();
            return screeningsDtos;
            
        }

        public async Task<IEnumerable<ScreeningDto>> GetAvailableScreenings(Guid movieId, DateTime date)
        {
            var screenings = await _context.Screenings
                .Where(s => s.MovieId == movieId && s.StartDate.Date == date.Date)
                .ToListAsync();
            var screeningsDtos = screenings.Select(Mappers.ScreeningMapper.MapToDto).ToList();

            return screeningsDtos;
        }

        public Task<ScreeningDto> GetScreeningById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ScreeningDto>> GetScreeningsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ScreeningDto>> GetScreeningsByMovieId(Guid movieId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ScreeningDto>> GetTodayScreenings()
        {
            var todayScreenings = await _context.Screenings
                .Where(s => s.StartDate.Date == DateTime.Now.Date)
                .ToListAsync();
            var screeningsDtos = todayScreenings.Select(Mappers.ScreeningMapper.MapToDto).ToList();

            return screeningsDtos;
        }

        public async Task<IEnumerable<ScreeningDto>> GetUpcomingScreenings(int? daysAhead = null, DateTime? fromDay = null, DateTime? toDay = null)
        {
            var screenings = await _context.Screenings.ToListAsync();

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

        public Task<IEnumerable<ScreeningDto>> SearchScreenings(string search)
        {
            throw new NotImplementedException();
        }

        public Task<ScreeningDto> UpdateScreening(Guid id, UpdateScreeningDto screeningDto)
        {
            throw new NotImplementedException();
        }
    }
}