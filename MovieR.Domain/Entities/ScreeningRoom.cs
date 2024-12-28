namespace MovieR.Domain.Entities;

public class ScreeningRoom
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public int TotalRows { get; set; }
    public int TotalColumns { get; set; }
    public int MaxCapacity { get; set; }

    // Navigation properties
    public List<Screening> Screenings { get; set; } = new List<Screening>();
}