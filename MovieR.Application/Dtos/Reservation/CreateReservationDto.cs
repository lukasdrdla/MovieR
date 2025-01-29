using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Seat;

namespace MovieR.Application.Dtos.Reservation
{
    public class CreateReservationDto
    {
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
        public Guid ScreeningId { get; set; }
        public Guid UserId { get; set; }
        public List<ReservedSeatDto> ReservedSeats { get; set; } = new();
    }
}