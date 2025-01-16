using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieR.Application.Dtos.Review
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public DateTime ReviewDate { get; set; }
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; }
        public Guid MovieId { get; set; }
        public Guid UserId { get; set; }
    }
}