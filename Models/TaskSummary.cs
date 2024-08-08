namespace ToDo_List.Models;
public class TaskSummary{
    public int Id { get; set; }
    public required string TaskName { get; set; }
    public string Description { get; set; } = string.Empty;
    public required string TaskGenre { get; set; }
    public int Importance { get; set; }
    public TimeOnly StartTime { get; set; }

}