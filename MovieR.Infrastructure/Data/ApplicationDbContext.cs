using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieR.Domain.Entities;

namespace MovieR.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<ReservedSeat> ReservedSeats { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Screening> Screenings { get; set; } = null!;
        public DbSet<ScreeningRoom> ScreeningRooms { get; set; } = null!;
        public DbSet<Seat> Seats { get; set; } = null!;
        public DbSet<TicketPrice> TicketPrices { get; set; } = null!;
    

        
    }
}