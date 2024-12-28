using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MovieR.Application.Dtos.User;
using MovieR.Application.Interfaces;
using MovieR.Domain.Entities;

namespace MovieR.Application.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

    
        public UserService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public Task<AuthResponseDto> LoginAsync(LoginUserDto loginDto)
        {
            var user = _userManager.FindByEmailAsync(loginDto.Email).Result;
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var passwordValid = _userManager.CheckPasswordAsync(user, loginDto.Password).Result;

            if (!passwordValid)
            {
                throw new Exception("Invalid password");
            }

            var token = GenerateJwtToken(user).Result;

            return Task.FromResult(new AuthResponseDto
            {
                Token = token,
                Expires = DateTime.UtcNow.AddHours(1)
            });
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterUserDto registerDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists");
            }

            var newUser = new ApplicationUser
            {
                Email = registerDto.Email,
                UserName = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };

            var result = await _userManager.CreateAsync(newUser, registerDto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Failed to create user");
            }

            var token = await GenerateJwtToken(newUser);

            return new AuthResponseDto
            {
                Token = token,
                Expires = DateTime.UtcNow.AddHours(1)
            };

        }

        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            // Create claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Aud, _configuration["Jwt:Audience"] ?? ""),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration["Jwt:Issuer"] ?? ""),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString())
            };

            // Add user roles to claims
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            // SymmetricSecurityKey to sign the token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        

        
    }
}