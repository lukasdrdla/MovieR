using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieR.Application.Dtos.User;
using MovieR.Application.Interfaces;

namespace MovieR.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/User/register

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerDto)
        {
            try {
                var authResponse = await _userService.RegisterAsync(registerDto);
                return Ok(authResponse);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }

        // POST: api/User/login

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginDto)
        {
            try {
                var authResponse = await _userService.LoginAsync(loginDto);
                return Ok(authResponse);
            
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Nastala neočekávaná chyba.", Error = e.Message });
            }
        }
        
    }
}