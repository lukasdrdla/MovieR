using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Reservation;

namespace MovieR.Application.Interfaces
{
    public interface IReservationService
    {
        Task<IEnumerable<ReservationDto>> GetAllReservations();
        Task<ReservationDto> GetReservationById(Guid id);
        Task<ReservationDto> CreateReservation(CreateReservationDto reservationDto);
        Task<ReservationDto> UpdateReservation(Guid id, UpdateReservationDto reservationDto);
        Task<bool> DeleteReservation(Guid id);

        Task<IEnumerable<ReservationDto>> SearchReservations(string search);
        Task<IEnumerable<ReservationDto>> GetReservationsByScreeningRoomId(Guid screeningRoomId);
        Task<bool> IsReservationDateValid(Guid screeningRoomId, DateTime reservationDate);
        Task<IEnumerable<ReservationDto>> GetReservationsByDateRange(DateTime startDate, DateTime endDate);




        
    }
}