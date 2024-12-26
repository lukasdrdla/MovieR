using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Seat;

namespace MovieR.Application.Mappers
{
    public static class SeatMapper
    {
        public static SeatDto MapToDto(Domain.Entities.Seat seat)
        {
            return new SeatDto
            {
                Id = seat.Id,
                Row = seat.Row,
                Number = seat.Column,
                IsAvailable = seat.IsAvailable,
                ScreeningId = seat.ScreeningId
            };
        }
        
    }
}