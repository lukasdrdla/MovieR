using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieR.Application.Context;
using MovieR.Domain.Entities;

namespace MovieR.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>, IApplicationDbContext
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
    

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var movie1Id = Guid.NewGuid();
            var movie2Id = Guid.NewGuid();
            var movie3Id = Guid.NewGuid();
            var movie4Id = Guid.NewGuid();
            var movie5Id = Guid.NewGuid();
            var movie6Id = Guid.NewGuid();

            builder.Entity<Movie>().HasData(
                new Movie { Id = movie1Id, Title = "The Shawshank Redemption", Description = "Two imprisoned" },
                new Movie { Id = movie2Id, Title = "The Godfather", Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." },
                new Movie { Id = movie3Id, Title = "The Dark Knight", Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice." },
                new Movie { Id = movie4Id, Title = "Batman", Description = "The Dark Knight of Gotham City begins his war on crime with his first major enemy being Jack Napier, a criminal who becomes the clownishly homicidal Joker." },
                new Movie { Id = movie5Id, Title = "The Lord of the Rings: The Return of the King", Description = "Gandalf and Aragorn lead the World" },
                new Movie { Id = movie6Id, Title = "Pulp Fiction", Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption." });


            var screeningRoom1Id = Guid.NewGuid();
            var screeningRoom2Id = Guid.NewGuid();
            var screeningRoom3Id = Guid.NewGuid();
            var screeningRoom4Id = Guid.NewGuid();
            var screeningRoom5Id = Guid.NewGuid();


            builder.Entity<ScreeningRoom>().HasData(
                new ScreeningRoom { Id = screeningRoom1Id, Name = "Sál 1", TotalColumns = 10, TotalRows = 10 },
                new ScreeningRoom { Id = screeningRoom2Id, Name = "Sál 2", TotalColumns = 8, TotalRows = 20 },
                new ScreeningRoom { Id = screeningRoom3Id, Name = "Sál 3", TotalColumns = 12, TotalRows = 15 },
                new ScreeningRoom { Id = screeningRoom4Id, Name = "Sál 4", TotalColumns = 15, TotalRows = 15 },
                new ScreeningRoom { Id = screeningRoom5Id, Name = "Sál 5", TotalColumns = 10, TotalRows = 10 });
            
            builder.Entity<Screening>().HasData(
                new Screening { Id = Guid.NewGuid(), StartDate = DateTime.Now.AddDays(1), MovieId = movie1Id, ScreeningRoomId = screeningRoom1Id },
                new Screening { Id = Guid.NewGuid(), StartDate = DateTime.Now.AddDays(2), MovieId = movie2Id, ScreeningRoomId = screeningRoom2Id },
                new Screening { Id = Guid.NewGuid(), StartDate = DateTime.Now.AddDays(3), MovieId = movie3Id, ScreeningRoomId = screeningRoom3Id },
                new Screening { Id = Guid.NewGuid(), StartDate = DateTime.Now.AddDays(4), MovieId = movie4Id, ScreeningRoomId = screeningRoom4Id },
                new Screening { Id = Guid.NewGuid(), StartDate = DateTime.Now.AddDays(5), MovieId = movie5Id, ScreeningRoomId = screeningRoom5Id },
                new Screening { Id = Guid.NewGuid(), StartDate = DateTime.Now.AddDays(6), MovieId = movie6Id, ScreeningRoomId = screeningRoom1Id });

        }




    }
}