using ToDo_List.Models;

namespace ToDo_List.Clients;

public class TaskClient{
    private List<TaskSummary> tasks = [
        new() {
            Id = 1,
            TaskName = "Poucz sie",
            Description = "Informatyka",
            ImportantLevel = 6,
            TimeRequired = new TimeOnly(2,30)
        },
        new() {
            Id = 2,
            TaskName = "Wysypiaj sie",
            Description = "Najlepiej 8h",
            ImportantLevel = 10,
            TimeRequired = new TimeOnly(8,0)
        },
        new() {
            Id = 3,
            TaskName = "Zjedz Sniadanie",
            Description = "Platki na mleku",
            ImportantLevel = 3,
            TimeRequired = new TimeOnly(1,30)
        }
    ];

    public TaskSummary[] GetTaskSummaries() => tasks.ToArray();
}

