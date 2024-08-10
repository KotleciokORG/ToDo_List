namespace ToDo_List.Models;
public class QuestSummary{
    public int Id { get; set; }
    public required string QuestName { get; set; }
    public string? Description { get; set; } = string.Empty;
    public required string QuestGenre { get; set; }
    public int Importance { get; set; }
    public TimeOnly StartTime { get; set; }
}