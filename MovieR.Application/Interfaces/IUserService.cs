using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieR.Application.Dtos.User;

namespace MovieR.Application.Interfaces
{
    public interface IUserService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterUserDto registerDto);
        Task<AuthResponseDto> LoginAsync(LoginUserDto loginDto);
        
    }
}