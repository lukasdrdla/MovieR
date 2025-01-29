using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieR.Application.Dtos.Reservation;
using MovieR.Application.Interfaces;
using MovieR.Application.Mappers;
using MovieR.Domain.Entities;
using MovieR.Infrastructure.Data;

namespace MovieR.Infrastructure.Implementations
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _context;

        public ReservationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReservationDto> CreateReservation(CreateReservationDto reservationDto)
        {
            if (!await IsReservationDateValid(reservationDto.ScreeningId, reservationDto.ReservationDate))
            {
                throw new InvalidOperationException("The reservation date is invalid or already booked.");
            }

            return null;
            
        }

        public Task<bool> DeleteReservation(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReservationDto>> GetAllReservations()
        {
            var reservations = await _context.Reservations
            .Include(reservation => reservation.ReservedSeats)
            .Include(reservation => reservation.Screening)
            .ToListAsync();
            var reservationsDto = reservations.Select(reservation => ReservationMapper.MapToDto(reservation));
            return reservationsDto;
        }

        public Task<ReservationDto> GetReservationById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReservationDto>> GetReservationsByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReservationDto>> GetReservationsByScreeningRoomId(Guid screeningRoomId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsReservationDateValid(Guid screeningRoomId, DateTime reservationDate)
        {
            var conflictingScreenings = await _context.Screenings
            .Include(screening => screening.Movie)
            .Where(screening => screening.ScreeningRoomId == screeningRoomId
            && screening.StartDate <= reservationDate
            && screening.EndDate >= reservationDate)
            .ToListAsync();

            return !conflictingScreenings.Any();
        }

        public Task<IEnumerable<ReservationDto>> SearchReservations(string search)
        {
            throw new NotImplementedException();
        }

        public Task<ReservationDto> UpdateReservation(Guid id, UpdateReservationDto reservationDto)
        {
            throw new NotImplementedException();
        }
    }
}