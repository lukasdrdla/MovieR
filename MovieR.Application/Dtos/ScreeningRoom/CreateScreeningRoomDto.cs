using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieR.Application.Dtos.ScreeningRoom
{
    public class CreateScreeningRoomDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name can't be longer than 50 characters")]
        public string Name { get; set; } = string.Empty;
        [Range(1, 100, ErrorMessage = "Total columns must be between 1 and 100")]
        public int TotalColumns { get; set; }
        [Range(1, 100, ErrorMessage = "Total rows must be between 1 and 100")]
        public int TotalRows { get; set; }
    }
}