using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.Seat;

namespace MovieR.Application.Dtos.Reservation
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; } = string.Empty;
        public Guid ScreeningId { get; set; }
        public string ScreeningName { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public List<ReservedSeatDto> ReservedSeats { get; set; } = new();
        
    }
}