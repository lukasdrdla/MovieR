using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Screening;
using MovieR.Domain.Entities;

namespace MovieR.Application.Mappers
{
    public static class ScreeningMapper
    {
        public static ScreeningDto MapToDto(Screening screening)
        {
            return new ScreeningDto
            {
                Id = screening.Id,
                StartTime = screening.StartDate,
                MovieId = screening.MovieId,
                ScreeningRoomId = screening.ScreeningRoomId
            };
        }
        
    }
}