using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos;
using MovieR.Domain.Entities;

namespace MovieR.Application.Interfaces
{
    public interface IScreeningRoomService
    {
        Task<IEnumerable<ScreeningRoomDto>> GetAllScreeningRooms();
        Task<ScreeningRoomDto> GetScreeningRoomById(Guid id);
        Task<ScreeningRoomDto> CreateScreeningRoom(ScreeningRoomDto screeningRoomDto);
        Task<ScreeningRoomDto> UpdateScreeningRoom(Guid id, ScreeningRoomDto screeningRoomDto);
        Task<bool> DeleteScreeningRoom(Guid id);

    }
}