using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieR.Application.Dtos.Movie
{
    public class CreateMovieDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
        public string Title { get; set; } = string.Empty;
        [StringLength(500, ErrorMessage = "Description can't be longer than 500 characters")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Release date is required")]
        public DateTime ReleaseDate { get; set; }
        [Required(ErrorMessage = "Genre is required")]
        [StringLength(50, ErrorMessage = "Genre can't be longer than 50 characters")]
        public string Genre { get; set; } = string.Empty;
        [Range(1, 500, ErrorMessage = "Duration must be between 1 and 500 minutes")]
        public int DurationMinutes { get; set; }
        [Url(ErrorMessage = "Poster URL must be a valid URL")]
        public string PosterUrl { get; set; } = string.Empty;
        
    }
}