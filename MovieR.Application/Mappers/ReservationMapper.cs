using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Reservation;
using MovieR.Application.Dtos.Seat;
using MovieR.Domain.Entities;

namespace MovieR.Application.Mappers
{
    public static class ReservationMapper
    {
        public static ReservationDto MapToDto(Reservation reservation)
        {
            return new ReservationDto
            {
                Id = reservation.Id,
                ReservationDate = reservation.ReservationDate,
                Status = reservation.Status.ToString(),
                ScreeningId = reservation.ScreeningId,
                ScreeningName = reservation.Screening.Movie.Title,
                UserId = reservation.UserId,
                UserName = reservation.User.UserName,
                ReservedSeats = reservation.ReservedSeats.Select(seat => new ReservedSeatDto
                {
                    SeatId = seat.SeatId,
                    SeatNumber = (seat.Seat.Row + seat.Seat.Column).ToString(),
                    Row = (seat.Seat.Row).ToString()
                }).ToList()
            };
        }
        
    }
}