namespace MovieR.Domain.Entities;

public class Movie
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; } = string.Empty;
    public int DurationMinutes { get; set; }
    public string PosterUrl { get; set; } = string.Empty;
    
    // Navigation properties
    public List<Review> Reviews { get; set; } = new List<Review>();
    public List<Screening> Screenings { get; set; } = new List<Screening>();
    
}