namespace MovieR.Domain.Entities;

public class Review
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
    public string Content { get; set; } = string.Empty;
    public int Rating { get; set; }
    public Guid MovieId { get; set; }
    public Guid UserId { get; set; }

    // Navigation properties
    public Movie Movie { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;
}