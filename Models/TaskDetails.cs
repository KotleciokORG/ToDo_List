namespace ToDo_List.Models;
public class TaskDetails{
    public int Id { get; set; }
    public required string TaskName { get; set; }
    public string? Description { get; set; }
    public string? TaskGenreId { get; set; }
    public int Importance { get; set; }
    public TimeOnly StartTime { get; set; }

}