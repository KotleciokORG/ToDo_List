namespace ToDo_List.Models;
public class QuestDetails{
    public int Id { get; set; }
    public required string QuestName { get; set; }
    public string? Description { get; set; }
    public string? QuestGenreId { get; set; }
    public int Importance { get; set; }
    public TimeOnly StartTime { get; set; }

}