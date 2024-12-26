using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Reservation;
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
                Status = reservation.Status,
                ScreeningRoomName = reservation.Screening.ScreeningRoom.Name,
                MovieName = reservation.Screening.Movie.Title,
                ScreeningId = reservation.ScreeningId,
                UserName = reservation.User.UserName??string.Empty
            };
        }
        
    }
}