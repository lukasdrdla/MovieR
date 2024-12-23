using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos;
using MovieR.Domain.Entities;

namespace MovieR.Application.Mappers
{
    public static class ScreeningRoomMapper
    {
        public static ScreeningRoomDto MapToDto(ScreeningRoom screeningRoom)
        {
            return new ScreeningRoomDto
            {
                Id = screeningRoom.Id,
                Name = screeningRoom.Name,
                TotalRows = screeningRoom.TotalRows,
                TotalColumns = screeningRoom.TotalColumns
            };
        }
        
    }
}