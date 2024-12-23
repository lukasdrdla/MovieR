using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieR.Domain.Entities;

namespace MovieR.Application.Context
{
    public interface IApplicationDbContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<ReservedSeat> ReservedSeats { get; set; }
        DbSet<Review> Reviews { get; set; }
        DbSet<Screening> Screenings { get; set; }
        DbSet<ScreeningRoom> ScreeningRooms { get; set; }
        DbSet<Seat> Seats { get; set; }
        DbSet<TicketPrice> TicketPrices { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}