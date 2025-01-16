using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieR.Application.Dtos.Review
{
    public class UpdateReviewDto
    {
        public string Content { get; set; } = string.Empty;
        public int Rating { get; set; }
   
    }
}