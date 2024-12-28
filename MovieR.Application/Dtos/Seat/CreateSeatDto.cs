using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieR.Application.Dtos.Seat
{
    public class CreateSeatDto
    {
        public int Row { get; set; }
        public int Number { get; set; }
        public bool IsAvailable { get; set; }
        public Guid ScreeningId { get; set; }
        
    }
}