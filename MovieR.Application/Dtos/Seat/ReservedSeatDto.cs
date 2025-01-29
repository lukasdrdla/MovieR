using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieR.Application.Dtos.Seat
{
    public class ReservedSeatDto
    {
        public Guid SeatId { get; set; }
        public string SeatNumber { get; set; } = string.Empty; // Přidáno pro zobrazení čísla sedadla
        public string Row { get; set; } = string.Empty; // Přidáno pro zobrazení řady
    }
}