using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieR.Application.Dtos.Screening
{
    public class ScreeningDto
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }

        public string MovieTitle { get; set; } = string.Empty;
        public string ScreeningRoomName { get; set; } = string.Empty;
        
    }
}