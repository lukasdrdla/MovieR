namespace MovieR.Domain.Entities;

public class Seat
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int Row { get; set; }
    public int Column { get; set; }
    public bool IsAvailable { get; set; } = true;
    public Guid ScreeningId { get; set; }

    // Navigation properties
    public Screening Screening { get; set; } = null!;
}