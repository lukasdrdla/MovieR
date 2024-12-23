namespace MovieR.Domain.Entities;

public class Reservation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; } = "Pending";
    public Guid ScreeningId { get; set; }
    public Guid UserId { get; set; }
    
    // Navigation properties
    public Screening Screening { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;
    public List<ReservedSeat> ReservedSeats { get; set; } = new();
}