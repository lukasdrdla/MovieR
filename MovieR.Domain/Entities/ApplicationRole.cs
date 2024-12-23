using Microsoft.AspNetCore.Identity;

namespace MovieR.Domain.Entities;

public class ApplicationRole : IdentityRole
{
    public string Description { get; set; } = string.Empty;
    
}