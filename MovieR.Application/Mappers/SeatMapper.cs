using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Seat;
using MovieR.Domain.Entities;

namespace MovieR.Application.Mappers
{
    public static class SeatMapper
    {
        public static SeatDto MapToDto(Seat seat)
        {
            return new SeatDto
            {
                Id = seat.Id,
                Row = seat.Row,
                Number = seat.Column,
                IsAvailable = seat.IsAvailable,
                ScreenName = seat.Screening.Movie.Title
                
            };
        }
        
    }
}