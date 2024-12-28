using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieR.Application.Dtos.User
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expires { get; set; }
        
    }
}