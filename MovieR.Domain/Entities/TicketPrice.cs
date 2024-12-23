namespace MovieR.Domain.Entities;

public class TicketPrice
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public decimal Price { get; set; }
    public string Type { get; set; } = string.Empty;
    public Guid ScreeningId { get; set; }

    // Navigation properties
    public Screening Screening { get; set; } = null!;
}