namespace ToDo_List.Models;
class TaskSummary{
    public int Id { get; set; }
    public required string TaskName { get; set; }
    public required string Description { get; set; }
    public int ImportantLevel { get; set; }
    public TimeOnly TimeRequired { get; set; }

}