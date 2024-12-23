namespace MovieR.Domain.Entities;

public class Screening
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime StartDate { get; set; }
    public Guid MovieId { get; set; }
    public Guid ScreeningRoomId { get; set; }

    // Navigation properties
    public Movie Movie { get; set; } = null!;
    public ScreeningRoom ScreeningRoom { get; set; } = null!;
    public ICollection<Seat> Seats { get; set; } = new List<Seat>();
    public ICollection<TicketPrice> TicketPrices { get; set; } = new List<TicketPrice>();
    public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

}