namespace MovieR.Domain.Entities;

public class ReservedSeat
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SeatId { get; set; }
    public Guid ReservationId { get; set; }

    // Navigation properties
    public Seat Seat { get; set; } = null!;
    public Reservation Reservation { get; set; } = null!;
    
}