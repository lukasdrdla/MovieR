using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieR.Application.Dtos.ScreeningRoom
{
    public class UpdateScreeningRoomDto
    {
        public string Name { get; set; } = string.Empty;
        public int TotalColumns { get; set; }
        public int TotalRows { get; set; }
        
    }
}