using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieR.Application.Dtos.Screening
{
    public class CreateScreeningDto
    {
        [Required(ErrorMessage = "Start time is required")]
        [DataType(DataType.DateTime, ErrorMessage = "Start time must be a valid date and time")]
        public DateTime StartTime { get; set; }
        [Required(ErrorMessage = "Movie ID is required")]
        public Guid MovieId { get; set; }
        [Required(ErrorMessage = "Screening Room ID is required")]
        public Guid ScreeningRoomId { get; set; }
    }
}