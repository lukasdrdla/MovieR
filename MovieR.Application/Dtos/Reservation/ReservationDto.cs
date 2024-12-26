using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieR.Application.Dtos.Reservation
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "Pending";
        public string ScreeningRoomName { get; set; } = string.Empty;
        public string MovieName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public Guid ScreeningId { get; set; }

        
    }
}