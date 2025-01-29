using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Seat;

namespace MovieR.Application.Dtos.Reservation
{
    public class UpdateReservationDto
    {
        public DateTime? ReservationDate { get; set; }
        public string? Status { get; set; }
        public List<ReservedSeatDto>? ReservedSeats { get; set; }
    }
}