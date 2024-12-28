using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Seat;

namespace MovieR.Application.Interfaces
{
    public interface ISeatService
    {
        Task<IEnumerable<SeatDto>> GetAllSeats();
        Task<SeatDto> GetSeatById(Guid id);
        Task<SeatDto> CreateSeat(CreateSeatDto createSeatDto);
        Task<SeatDto> UpdateSeat(Guid id, UpdateSeatDto updateSeatDto);
        Task<bool> DeleteSeat(Guid id);

        Task<IEnumerable<SeatDto>> GetAvailableSeats(Guid screeningId);
        Task SetSeatAvailability(Guid id, bool isAvailable);

    }
}