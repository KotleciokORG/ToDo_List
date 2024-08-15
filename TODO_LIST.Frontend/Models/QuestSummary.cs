namespace TODO_LIST.Frontend.Models;
public class QuestSummary{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; } = string.Empty;
    public required string Genre { get; set; }
    public int Importance { get; set; }
    public TimeOnly StartTime { get; set; }
}