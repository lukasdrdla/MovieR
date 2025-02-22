using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieR.Application.Dtos.Seat
{
    public class SeatDto
    {
        public Guid Id { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        public bool IsAvailable { get; set; }
        public string ScreenName { get; set; } = string.Empty;
        
    }
}