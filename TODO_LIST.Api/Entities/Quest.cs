namespace TODO_LIST.Api.Entities;

public class Quest{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; } = string.Empty;
    public int GenreId { get; set; }
    public Genre? Genre { get; set; }
    public int Importance { get; set; }
    public TimeOnly StartTime { get; set; }
}